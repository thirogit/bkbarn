using System;

namespace cowbase
{
	
	public class DispatchState : SyncState
	{
		public DispatchState() : base(null)
		{
			
		}
		public override int OnCommand(string strCommand,string cmdParams)
		{
			switch(strCommand)
			{
				case "GET":
					//m_nextState = new TableInsertFactory();
					m_nextState = new TableSyncFactory(this);
					return (int)StateReturnCodes.State_ChangeState;
				case "SET":
					m_nextState = new TableInsertFactory(this);
					return (int)StateReturnCodes.State_ChangeState;
				case "FLUSH":
					if(SQLDB.FlushTables() && SQLDB.UnlockSync())
						return (int)StateReturnCodes.State_SendOKResponse;
					else
					{
                        m_response = SQLDB.GetLastError();
						return (int)StateReturnCodes.State_SendErrorResponse;
					}
				case "LOCK":
					if(SQLDB.LockSync())
						return (int)StateReturnCodes.State_SendOKResponse;
					else
					{
                        m_response = SQLDB.GetLastError();
						return (int)StateReturnCodes.State_SendErrorResponse;
					}
				case "GOSYNC":
					if(SQLDB.IsSyncLocked())
						m_response = "1";
					else
						m_response = "0";

					return (int)StateReturnCodes.State_SendResponse;
	           }

			return (int)StateReturnCodes.State_BadCommand;		
		}


		
	}
}
