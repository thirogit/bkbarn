using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using System.Net;
using System.Net.Sockets;
using JouniHeikniemi.Tools.Text;
using System.IO;
using System.Text;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Xml;


namespace cowbase
{
	public class MainForm : CenterForm 
	{
		private System.Windows.Forms.Button UpdateBtn;
		private System.Windows.Forms.Button OutdocsBtn;
		private System.Windows.Forms.Button IndocsBtn;
		private System.Windows.Forms.Button m_exitBtn;

		ClientSocket m_syncClient = new ClientSocket();		
		private SyncState m_syncState = null;
			
		// handle updates from socket
		EventHandler m_processCommand;
		// hold socket notification arguments
		NotifyCommand m_notifyCommand;
		private System.Windows.Forms.Button SyncBtn;
		object m_notifyData;
		private System.Windows.Forms.Label m_syncStatusLabel;
		private System.Windows.Forms.Label m_statusLabel;
        private Button OptBtn;

		Timer m_readyTimer = new Timer();
        //Timer m_trySendCrashReportsTimer = new Timer();

		public MainForm()
		{
		
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			this.Closing += new CancelEventHandler(OnCloseMainForm);
			m_syncClient.Notify += new ClientSocket.NotifyEventHandler(NotifyCallback);
			m_processCommand = new EventHandler(ProcessNotifyCommand);
			m_readyTimer.Tick +=new EventHandler(ReadyTimerTick);
			m_readyTimer.Interval = 1000*60;
			m_readyTimer.Enabled = false;

            //m_trySendCrashReportsTimer.Tick += new EventHandler(TrySendCrashReportsTimerTick);
            //m_trySendCrashReportsTimer.Interval = 1000 * 5; //5 sec
            //m_trySendCrashReportsTimer.Enabled = false;


          
			
		}
		protected override void Dispose( bool disposing )
		{
			
			base.Dispose( disposing );
		}
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.UpdateBtn = new System.Windows.Forms.Button();
            this.OutdocsBtn = new System.Windows.Forms.Button();
            this.IndocsBtn = new System.Windows.Forms.Button();
            this.SyncBtn = new System.Windows.Forms.Button();
            this.m_exitBtn = new System.Windows.Forms.Button();
            this.m_syncStatusLabel = new System.Windows.Forms.Label();
            this.m_statusLabel = new System.Windows.Forms.Label();
            this.OptBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UpdateBtn
            // 
            this.UpdateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.UpdateBtn.Location = new System.Drawing.Point(0, 0);
            this.UpdateBtn.Name = "UpdateBtn";
            this.UpdateBtn.Size = new System.Drawing.Size(240, 48);
            this.UpdateBtn.TabIndex = 6;
            this.UpdateBtn.Text = "Aktualizacja";
            this.UpdateBtn.Click += new System.EventHandler(this.UpdateBtn_Click);
            // 
            // OutdocsBtn
            // 
            this.OutdocsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.OutdocsBtn.Location = new System.Drawing.Point(120, 48);
            this.OutdocsBtn.Name = "OutdocsBtn";
            this.OutdocsBtn.Size = new System.Drawing.Size(120, 48);
            this.OutdocsBtn.TabIndex = 5;
            this.OutdocsBtn.Text = "WZ";
            this.OutdocsBtn.Click += new System.EventHandler(this.OutdocsBtn_Click);
            // 
            // IndocsBtn
            // 
            this.IndocsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.IndocsBtn.Location = new System.Drawing.Point(0, 48);
            this.IndocsBtn.Name = "IndocsBtn";
            this.IndocsBtn.Size = new System.Drawing.Size(120, 48);
            this.IndocsBtn.TabIndex = 4;
            this.IndocsBtn.Text = "PZ";
            this.IndocsBtn.Click += new System.EventHandler(this.IndocsBtn_Click);
            // 
            // SyncBtn
            // 
            this.SyncBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.SyncBtn.Location = new System.Drawing.Point(0, 144);
            this.SyncBtn.Name = "SyncBtn";
            this.SyncBtn.Size = new System.Drawing.Size(240, 48);
            this.SyncBtn.TabIndex = 3;
            this.SyncBtn.Text = "Synchronizacja";
            this.SyncBtn.Click += new System.EventHandler(this.syncBtn_Click);
            // 
            // m_exitBtn
            // 
            this.m_exitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_exitBtn.Location = new System.Drawing.Point(0, 224);
            this.m_exitBtn.Name = "m_exitBtn";
            this.m_exitBtn.Size = new System.Drawing.Size(190, 48);
            this.m_exitBtn.TabIndex = 2;
            this.m_exitBtn.Text = "Koniec";
            this.m_exitBtn.Click += new System.EventHandler(this.m_exitBtn_Click);
            // 
            // m_syncStatusLabel
            // 
            this.m_syncStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_syncStatusLabel.Location = new System.Drawing.Point(0, 195);
            this.m_syncStatusLabel.Name = "m_syncStatusLabel";
            this.m_syncStatusLabel.Size = new System.Drawing.Size(240, 24);
            this.m_syncStatusLabel.Text = "__SYNC_STATUS__";
            this.m_syncStatusLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // m_statusLabel
            // 
            this.m_statusLabel.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.m_statusLabel.Location = new System.Drawing.Point(0, 96);
            this.m_statusLabel.Name = "m_statusLabel";
            this.m_statusLabel.Size = new System.Drawing.Size(240, 48);
            this.m_statusLabel.Text = "_STATUS_";
            this.m_statusLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // OptBtn
            // 
            this.OptBtn.Location = new System.Drawing.Point(190, 224);
            this.OptBtn.Name = "OptBtn";
            this.OptBtn.Size = new System.Drawing.Size(50, 47);
            this.OptBtn.TabIndex = 7;
            this.OptBtn.Text = "Opcje";
            this.OptBtn.Click += new System.EventHandler(this.OptBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(238, 271);
            this.Controls.Add(this.OptBtn);
            this.Controls.Add(this.m_statusLabel);
            this.Controls.Add(this.m_syncStatusLabel);
            this.Controls.Add(this.m_exitBtn);
            this.Controls.Add(this.SyncBtn);
            this.Controls.Add(this.IndocsBtn);
            this.Controls.Add(this.OutdocsBtn);
            this.Controls.Add(this.UpdateBtn);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Baza Krówek 2011";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

		}
		#endregion

		static void Main() 
		{
            


#if !COWBASEMOCK
            OpenNETCF.Threading.NamedMutex singleInstanceMutex = new OpenNETCF.Threading.NamedMutex(false, "COWBASE");
            if (!singleInstanceMutex.WaitOne(5, false))
            {
                BigOKMessageBox.ShowMessage("Jednoczesnie moze dzialac tylko jedna aplikacja");
                Application.Exit();
                return;
            }

            UpdateVersionFile();
#endif
                        
            LOG.DoLog("Start.");
            try
            {
                Application.Run(new MainForm());
                LOG.DoLog("Clean exit.");
            }
            catch (Exception ex)
            {
                
                //BigOKMessageBox.ShowMessage("Blad krytyczny",
                //    "Wystapil krytyczny blad,\naplikacja zostanie zamknieta,\nuruchom program ponownie\n i podlacz terminal do internetu\naby wyslac raport o bledzie.");
                LOG.DoLogCritical(ex.Message + " STACKTRACE = " + ex.StackTrace);
                Application.Exit();
            }
            finally
            {

                LOG.End();
#if !COWBASEMOCK
                singleInstanceMutex.ReleaseMutex();
#endif
            }

		}

       

        private static void UpdateVersionFile()
        {
            string cfgFilePathAndName = Utils.GetApplicationDirectory() + "\\cowbase_version.xml";
            XmlTextWriter writer = new XmlTextWriter(cfgFilePathAndName, null);
            //Write the root element
            writer.WriteStartElement("cowbaseUpdate");
            //Write sub-elements
            writer.WriteElementString("version", Utils.GetAssemblyBuildNo().ToString());
           
            // end the root element
            writer.WriteEndElement();
            //Write the XML to file and close the writer
            writer.Close();
        }

		
		private void MainForm_Load(object sender, System.EventArgs e)
		{
            Settings.Instance.Log();

            //m_trySendCrashReportsTimer.Enabled = true;
			SetReadyStatus();	
			
            if(!SQLDB.ConnectToDB())
			{
				MessageBox.Show(SQLDB.GetLastError());
                LOG.DoLog("MainForm_Load(): Failed to connect to DB: " + SQLDB.GetLastError());
				this.Close();
			}
			else
			{
				RefreshStatus();
			}

            this.Text = "BK2011 - Build " + Utils.GetAssemblyBuildNo().ToString();
		
		}       

		private void UpdateBtn_Click(object sender, System.EventArgs e)
		{
            LOG.DoLog("UpdateBtn_Click()");
			UpdateCattle cowUpdate = new UpdateCattle();
			cowUpdate.ShowDialog();	
			cowUpdate = null;            
		}
		
		private void OutdocsBtn_Click(object sender, System.EventArgs e)
		{
			NewOrEdit newOrEditOutDoc = new NewOrEdit("WZ");
			switch(newOrEditOutDoc.ShowDialog())
			{
				case DialogResult.Yes:
					if(!SyncLockMessage.CheckSyncLock()) break;
                    LOG.DoLog("New OutDoc."); 
					NewOutDoc newOut = new NewOutDoc();
					newOut.ShowDialog();
					newOut = null;
					break;
				case DialogResult.No:
                    LOG.DoLog("Edit OutDoc.");
					OutDocListView dlv = new OutDocListView();
					dlv.ShowDialog();
					dlv = null;
					break;
				
				case DialogResult.OK:
                    LOG.DoLog("Search passport OutDoc.");
					SearchPassInOutDocs passSearch = new SearchPassInOutDocs();
					passSearch.ShowDialog();
					passSearch = null;
					break;
			}
			newOrEditOutDoc = null;
			RefreshStatus();			
		}

		private void SetSyncStatusLabel(string statusStr)
		{
			m_syncStatusLabel.Text = statusStr;
		}

		private void OnCloseMainForm(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(m_syncClient.Connected)
				m_syncClient.Disconnect();
			m_readyTimer.Enabled = false;
		}

		private void EnableBtns(bool bEnable)
		{
			UpdateBtn.Enabled = bEnable;
			OutdocsBtn.Enabled = bEnable;
			IndocsBtn.Enabled = bEnable;
		}

		private void syncBtn_Click(object sender, System.EventArgs e)
		{
			if(!m_syncClient.Connected)
			{
                LOG.DoLog("Sync CONNECT.");
				m_readyTimer.Enabled = false;
				SetSyncStatusLabel("£¹czenie...");

                TryToSendCrashReports();

				if(!m_syncClient.Connect(Settings.Instance.host, 998))
				{
                    LOG.DoLog("Sync FAILD TO CONNECT.");
					BigOKMessageBox.ShowMessage("Po³¹czenie","B³¹d podczas po³aczenia z PC");
					SetSyncStatusLabel("B³ad po³aczenia.");
					m_readyTimer.Enabled = true;
					return; 				
				}						
				
				m_syncState = new DispatchState();			
				m_syncClient.Receive();	
				EnableBtns(false);	
				SyncBtn.Text = "Przerwij";
			}
			else
			{
                LOG.DoLog("Sync DISCONNECT.");
				m_syncClient.Disconnect();                
			}
		}

		private void m_exitBtn_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		private void IndocsBtn_Click(object sender, System.EventArgs e)
		{           
            NewOrEdit newOrEditOutDoc = new NewOrEdit("PZ");
			switch(newOrEditOutDoc.ShowDialog())
			{
				case DialogResult.Yes:
					if(!SyncLockMessage.CheckSyncLock()) break;
                    LOG.DoLog("New InDoc.");
					NewDocForm newDoc = new NewInDoc();
					newDoc.ShowDialog();
					newDoc = null;
					break;
				case DialogResult.No:
                    LOG.DoLog("Edit InDoc.");
					InDocListView dlv = new InDocListView();
					dlv.ShowDialog();
					dlv = null;
					break;
				case DialogResult.OK:
                    LOG.DoLog("Search passport InDoc.");
					SearchPassInInDocs passSearch = new SearchPassInInDocs();
					passSearch.ShowDialog();
					passSearch = null;
					break;
			}
			newOrEditOutDoc = null;
			RefreshStatus();			
		}
		// notification from socket
		private void NotifyCallback(NotifyCommand command, object data)
		{
			try
			{
				// The .Net Compact Framework does not support Control.Invoke
				// that allows you to pass arguments to the delegate. So save
				// arguments to class fields and then invoke the delegate.
				lock(this)
				{
					// save arguments to class fields				
					m_notifyCommand = command;
					m_notifyData = data;
					
					// execute the method on the GUI's thread, this method
					// uses the _notifyCommand and _notifyData fields
					Invoke(m_processCommand);
				}
			}
			catch
			{
			}
		}

		private void ProcessNotifyCommand(object sender, System.EventArgs e)
		{
			switch (m_notifyCommand)
			{
				case NotifyCommand.Connected:
                    LOG.DoLog("Sync CONNECTED.");
					SetSyncStatusLabel("Po³¹czono.");					
					break;					
				case NotifyCommand.Disconnect:
                    LOG.DoLog("Sync DISCONNECT.");
                    EnableBtns(true);
                    SyncBtn.Text = "Synchronizacja";
                    RefreshStatus();
					SetSyncStatusLabel("Roz³¹czono.");
					m_readyTimer.Enabled = true;					
					break;
				case NotifyCommand.ReceivedData:					
					ParseMessage((string)m_notifyData);								
					break;			
			}		
		}

		private void ParseMessage(string strCmd)
		{
			string syncCommand = null,syncCmdParams = null;
			int indexOfComa = strCmd.IndexOf(',',0);
			if(indexOfComa > 0)
			{				
				syncCommand = strCmd.Substring(0,indexOfComa);
				indexOfComa++;
				if(indexOfComa < strCmd.Length)
				{
					syncCmdParams = strCmd.Substring(indexOfComa,strCmd.Length-indexOfComa);
				}
			}
			else
				syncCommand = strCmd;

			switch(m_syncState.OnCommand(syncCommand,syncCmdParams))
			{
                case (int)StateReturnCodes.State_ChangeState:
				{
					SyncState nextState = m_syncState.GetNextState();
					m_syncState = null; //dispose current state
					m_syncState = nextState;
                    string stateResp = nextState.GetResponse();

                    if (stateResp != null && stateResp.Length > 0)
                        goto case (int)StateReturnCodes.State_SendResponse;

					goto case (int)StateReturnCodes.State_SendOKResponse;
				}
				case (int)StateReturnCodes.State_SendResponse:
				{
					m_syncClient.SendResponse(m_syncState.GetResponse());
					break;
				}
				case (int)StateReturnCodes.State_SendOKResponse:
				{
					m_syncClient.SendOKResponse();
					break;
				}
				case (int)StateReturnCodes.State_SendErrorResponse:
				{
					m_syncClient.SendErrResponse(m_syncState.GetResponse());
					SyncState nextState = m_syncState.GetNextState();
					m_syncState = null; //dispose current state
					m_syncState = nextState;
					break;
				}
				case (int)StateReturnCodes.State_BadCommand:
				{
					m_syncClient.SendBadResponse(syncCommand + '(' + syncCmdParams + ')');
					break;
				}				
				default:
				{
					throw new Exception("Unknown state return code");
				}
			}
		}

		void SetReadyStatus()
		{
			SetSyncStatusLabel("Gotowy");
		}

		private void ReadyTimerTick(object sender, EventArgs e)
		{
			SetReadyStatus();
			m_readyTimer.Enabled = false;
		}

      

		private void RefreshStatus()
		{
            MemoryUsage mu = new MemoryUsage();      

            double programUsePercent = mu.GetProgramMemoryUsage()*100;
            double storageUsePercent = mu.GetStorageMemoryUsage() * 100;

			m_statusLabel.Text = String.Format("Wszystkich: {0}, na stanie {1}\nPamiec: PROG {2}%. STOR {3}%",
                                SQLDB.GetCowCount(false), 
                                SQLDB.GetCowCount(true),
                                (int)programUsePercent, (int)storageUsePercent);                      
		}

        private void OptBtn_Click(object sender, EventArgs e)
        {
            LOG.DoLog("Options.");
            Options optDlg = new Options();
            if (optDlg.ShowDialog() == DialogResult.OK)
            {
                Settings.Instance.Log();
            }
        }

        private void TryToSendCrashReports()
        {            
            //m_trySendCrashReportsTimer.Enabled = false;


            try
            {
                string fromToEmailAddress = "bkcrashreport@poczta.onet.pl";
                OpenNETCF.Net.Mail.MailMessage message = new OpenNETCF.Net.Mail.MailMessage(fromToEmailAddress,fromToEmailAddress);
                message.Subject = "BK Crash Report Build " + Utils.GetAssemblyBuildNo().ToString();
                OpenNETCF.Net.Mail.SmtpClient smtpClient = new OpenNETCF.Net.Mail.SmtpClient("smtp.poczta.onet.pl",587);
                smtpClient.Credentials = new OpenNETCF.Net.Mail.SmtpCredential("bkcrashreport@poczta.onet.pl", "boskieWymion0", "poczta.onet.pl");
                    

                string outbox = LOG.GetOutboxDirectoryPath();
                string[] outboxFiles = Directory.GetFiles(outbox);

                if (outboxFiles.Length > 0)
                {
                    for (int i = 0; i < outboxFiles.Length; i++)
                    {
                        StreamReader reader = new StreamReader(outboxFiles[i]);
                        message.Body = reader.ReadToEnd();
                        reader.Close();
                        smtpClient.Send(message);
                        File.Delete(outboxFiles[i]);
                    }
                }
            }
            catch (Exception ex)
            {
                
            }

            //m_trySendCrashReportsTimer.Enabled = true;
        }


	}
}
