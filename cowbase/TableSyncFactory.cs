using System;
using System.Collections;

namespace cowbase
{
	
	public class TableSyncFactory : TableFactory
	{
		
		public TableSyncFactory(SyncState callingState) : base(callingState)
		{
				
			
		}
		public override int OnCommand(string strCommand,string cmdParams)
		{
			if(strCommand == "FLUSH")
			{
				if(SQLDB.FlushTables())
				{
					m_nextState = new TableInsertFactory(this);
					return (int)StateReturnCodes.State_ChangeState;
				}
				else
					return (int)StateReturnCodes.State_SendErrorResponse;
			}
				
			return base.OnCommand(strCommand,cmdParams);
		}

		protected override SyncState CreateINDOCSTableState(string stateParam)
		{
			return new INDOCSSyncState(stateParam,this);
		}


		protected override SyncState CreateOUTDOCSTableState(string stateParam)
		{
			return new OUTDOCSSyncState(stateParam,this);
		}

		protected override SyncState CreateCATTLETableState(string stateParam)
		{
			return new CATTLEGetSyncState(stateParam,this);
		}


		
	}
}
