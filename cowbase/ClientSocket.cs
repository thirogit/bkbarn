/*
	NotifyCommand enum
	--
	List of socket notification commands.
	
	
	ClientSocket class
	--
	Connects and sends data over TCP sockets. Uses async sockets so a delegate 
	method is called when the socket command completes. Raises an Notify event 
	when socket operations complete and passes any associated data with the event.
*/

using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Text;
using System.Configuration;
using System.Collections;
using System.Diagnostics;
//using Common;


namespace cowbase
{
	/// <summary>
	/// Socket notification commands.
	/// </summary>
	public enum NotifyCommand
	{
		Connected,
		ReceivedData,
		Disconnect
	}

	
	/// <summary>
	/// Use async sockets to connect, send and receive data over TCP sockets.
	/// </summary>
	public class ClientSocket
	{
		// notification event
		public delegate void NotifyEventHandler(NotifyCommand command, object data);
		public event NotifyEventHandler Notify;

		private TcpClient m_tcp_client;
		private NetworkStream m_sync_stream;
		private static string HELLO = "HELLO";
		public static int MAX_CMD_LEN = 256;
		private byte[] m_partialBuffer = new byte[MAX_CMD_LEN];

		// used to synchronize the shutdown process, terminate
		// any pending async calls before Disconnect returns
		ManualResetEvent _asyncEvent = new ManualResetEvent(true);
		
		bool _connected = false;

		public  string m_syncPrefix = "SYNC";
		private byte[] m_OKResponse = Encoding.ASCII.GetBytes("OK\n");
		public static string m_responsePrefix = "OK,";
		public static string m_errResponsePrefix = "ERR,";
		public static string m_badResponsePrefix = "BAD,";

		private byte[] m_recvBuffer = new byte[ClientSocket.MAX_CMD_LEN];
		private int m_recvBufferPos = 0;
		
			

		// async callbacks
		private AsyncCallback _receiveCallback;

		/// <summary>
		/// Returns true if the socket is connected to the server. The property 
		/// Socket.Connected does not always indicate if the socket is currently 
		/// connected, this polls the socket to determine the latest connection state.
		/// </summary>
		public bool Connected
		{
			get
			{
				return _connected;
			}
		}


		public ClientSocket()
		{
			// hookup async callbacks
			_receiveCallback = new AsyncCallback(ReceiveCallback);
		}
		
		/// <summary>
		/// Connect to the specified address and port number.
		/// </summary>
		public bool Connect(string address, int port)
		{
			if(_connected) return false;
			
			m_tcp_client = new TcpClient();
            string helloBackString = HELLO + '\n';
			Byte[] byteHelloBack = new Byte[helloBackString.Length];
			Byte[] byteHello = 	Encoding.ASCII.GetBytes(HELLO + ',' + Utils.GetAssemblyBuildNo() + '\n');
			m_recvBufferPos = 0;
			
            _asyncEvent.Reset();

			try 
			{
				m_tcp_client.Connect(address, port);
				m_sync_stream = m_tcp_client.GetStream();
				m_sync_stream.Write(byteHello, 0, byteHello.Length);
                if (m_sync_stream.Read(byteHelloBack, 0, helloBackString.Length) == helloBackString.Length)
				{
                    if (Encoding.ASCII.GetString(byteHelloBack, 0, helloBackString.Length) == helloBackString)
					{
						_connected = true;
						RaiseNotifyEvent(NotifyCommand.Connected,null);
						
					}
					else
					{
						Disconnect();
						return false;
					}
				}										
			} 
			catch(Exception ex)
			{
                LOG.DoLog("Cant connect to: " + address + " : " + ex.Message);
				Disconnect();
				return false;		
			}

			return true;
		
		}

		/// <summary>
		/// Disconnect from the server.
		/// </summary>
		public void Disconnect()
		{
			// return right away if have not created socket
			if (m_tcp_client == null)
			    return;		

						
				
			try
			{
                //m_tcp_client.Client.Shutdown(SocketShutdown.Both);

				if(m_sync_stream != null) m_sync_stream.Close();

                
				m_tcp_client.Close();
				
			}
			catch 
			{


			}            
			m_sync_stream = null;
			m_tcp_client = null;
			_connected = false;

            _asyncEvent.Reset();

			RaiseNotifyEvent(NotifyCommand.Disconnect,null);
			//LOG.DoLog("Disconnect(): waitone");
			// wait for any async operations to complete
			_asyncEvent.WaitOne();
			

			
			
			
			

		}

		/// <summary>
		/// Send data to the server.
		/// </summary>
		public void Send(byte[] data)
		{
			m_sync_stream.Write(data, 0, data.Length);
		}

		public void Send(string sendStr)
		{
			LOG.DoLog("ClientSocket.Send():" + sendStr);
			Send(Encoding.ASCII.GetBytes(sendStr));
		}

		public void SendOKResponse()
		{
			Send(m_OKResponse);
		}

		public void SendResponse(string strResponse)
		{
			Send(m_responsePrefix + strResponse + "\n");
		}

		public void SendErrResponse(string strErrResponse)
		{
			Send(m_errResponsePrefix + strErrResponse + "\n");
		}

		public void SendBadResponse(string strBadResponse)
		{
			Send(m_badResponsePrefix + strBadResponse + "\n");
		}

		/// <summary>
		/// Read data from server.
		/// </summary>
		public void Receive()
		{
			//LOG.DoLog("Receive(): reset");
			_asyncEvent.Reset();


			try
			{
				
				m_sync_stream.BeginRead(m_partialBuffer,0 ,MAX_CMD_LEN,_receiveCallback,null);						
				
			}
			catch
			{
				Disconnect();				
			}
			
		}

		/// <summary>
		/// Raise notification event.
		/// </summary>
		private void RaiseNotifyEvent(NotifyCommand command, object data)
		{
			//LOG.DoLog("RaiseNotifyEvent(): set");
			// the async operation has completed
			_asyncEvent.Set();

			// don't raise notification events when disconnecting
			if ((this.Notify != null))
				Notify(command, data);
		}


		//
		// async callbacks
		//	

		private void ReceiveCallback(IAsyncResult ar)
		{
			if(m_sync_stream == null || m_tcp_client == null) return;
			try
			{
				int byteRead = m_sync_stream.EndRead(ar);
                if (byteRead > 0)
                    OnDataReceived(m_partialBuffer, byteRead);
                else
                {
                    Disconnect();                    
                }

				
			}
			catch(Exception ex)
			{
                LOG.DoLog("ReceiveCallback(): " + ex.Message);
				Disconnect();
			}
		}

		private void OnDataReceived(byte[] partialBuffer,int byteRead)
		{	
			int partPos = 0,lastLF  = 0,i;
			bool bAdd = false;
			//LOG.DoLog("entering OnDataReceived()");

			//LOG.DoLog("OnDataReceived() partialBuffer: " + Encoding.ASCII.GetString(partialBuffer,0,byteRead));

			//Debug.Write("OnDataReceived() partialBuffer : byteRead = " + byteRead.ToString(),"1");
			//Debug.Write(partialBuffer,"1");
			//LOG.DoLog("OnDataReceived() m_recvBufferPos (while)= " + m_recvBufferPos.ToString());

			while(partPos < byteRead)
			{
				if(partialBuffer[partPos] != '\n') 
				{
					partPos++;
					continue;
				}
				bAdd = true;
				for(i = lastLF;i < partPos;i++)
				{
					m_recvBuffer[m_recvBufferPos] = partialBuffer[i];
					m_recvBufferPos++;
					if(m_recvBufferPos >= MAX_CMD_LEN)
					{
						m_recvBufferPos = 0;
						bAdd = false;
						break; //drop this command
					}
				}
				if(bAdd)
				{	
					//LOG.DoLog("OnDataReceived() m_recvBufferPos (add)= " + m_recvBufferPos.ToString());
					string strCmd = Encoding.ASCII.GetString(m_recvBuffer,0,m_recvBufferPos);
					//LOG.DoLog("OnDataReceived() bAdd: " + strCmd);
					int indexOfComa = strCmd.IndexOf(',',0);
					if(indexOfComa > 0)
					{
						if(strCmd.Substring(0,indexOfComa) == m_syncPrefix)
						{
							indexOfComa++;

							strCmd = strCmd.Substring(indexOfComa,strCmd.Length-indexOfComa);
							//LOG.DoLog("OnDataReceived() notify: " + strCmd);
							RaiseNotifyEvent(NotifyCommand.ReceivedData,strCmd);
						}	
						
					}

					
					//else DoLogMsg("Incorrect command : " + strCmd);				

					//DoLogMsg(strCmd);

					
					m_recvBufferPos = 0;
					//LOG.DoLog("OnDataReceived() m_recvBufferPos (end add)= " + m_recvBufferPos.ToString());
				}
				lastLF = partPos;
				break;
			}

			for(i = lastLF;i < partPos;i++)
			{
				m_recvBuffer[m_recvBufferPos++] = partialBuffer[i];					
			}
		
		//LOG.DoLog("entering OnDataReceived()");		
		Receive();		
		}

	}
}
	