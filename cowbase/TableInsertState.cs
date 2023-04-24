using System;
using JouniHeikniemi.Tools.Text;
using System.Text;
using System.IO;

namespace cowbase
{
	
	public abstract class TableInsertState : SyncState
	{
		public TableInsertState(string stateParam,SyncState callingState) : base(callingState)
		{
			
		}

		public override int OnCommand(string strCommand,string cmdParams)
		{
			switch(strCommand)
			{
				case "EOT":
					m_nextState = m_callingState;
					return (int)StateReturnCodes.State_ChangeState;				
				case "INSERT":
					CSVReader recordIns = new CSVReader(new MemoryStream(Encoding.ASCII.GetBytes(cmdParams)));
					string[] insParams = recordIns.GetCSVLine();
					try
					{					
						InsertRecord(insParams);
					}
					catch(SystemException sqlEx)
					{
						m_response = sqlEx.Message;
                        LOG.DoLog("OnCommand(INSERT): PARAMS = " + cmdParams + " MSG = " + sqlEx.Message); 
						m_nextState = m_callingState;
						return (int)StateReturnCodes.State_SendErrorResponse;
					}
					break;
				default:
					return (int)StateReturnCodes.State_BadCommand;

			}
						
			
			return (int)StateReturnCodes.State_SendOKResponse;		
		}


		protected abstract void InsertRecord(string[] insParams);

	}
}
