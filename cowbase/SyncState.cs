using System;

namespace cowbase
{
	
	enum StateReturnCodes : int
	{
		State_ChangeState = -1,
		State_BadCommand = 0,
		State_SendResponse = 1,
		State_SendOKResponse = 2,
		State_SendErrorResponse = 3
	};

	

	public class SyncState
	{
		public SyncState(SyncState callingState)
		{
			m_callingState = callingState;
		}

		public virtual int OnCommand(string strCommand,string cmdParams)
		{
			m_nextState = this;
			return (int)StateReturnCodes.State_BadCommand;		
		}
		protected SyncState m_callingState;
		protected SyncState m_nextState;
		protected string m_response = null;

		public SyncState GetNextState()
		{
			return m_nextState;

		}
		public string GetResponse()
		{
			return m_response;
		}

		public string EncodeSyncString(string input)
		{

			char[] escapeChars = {',','\'','\\'};
			string output = "";
			foreach(char c in input)
			{
				foreach(char cc in escapeChars)
				{
					if(c == cc)
					{
						output += '\\';
						break;
					}
				}
				output += c;
			}

			return output;
		}

	}
}
