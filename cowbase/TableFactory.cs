using System;
using System.Collections;

namespace cowbase
{

	public abstract class TableFactory : SyncState
	{

		protected Hashtable table2state = null;
		
		protected delegate SyncState TableState(string stateParam);
		private TableState INDOCS = null;
		private TableState OUTDOCS = null;
		private TableState CATTLE = null;



		public TableFactory(SyncState callingState) : base(callingState)
		{
			INDOCS += new TableState(CreateINDOCSTableState);
			OUTDOCS += new TableState(CreateOUTDOCSTableState);
			CATTLE += new TableState(CreateCATTLETableState);

			table2state = new Hashtable();
			table2state.Add("INDOCS",INDOCS);
			table2state.Add("OUTDOCS",OUTDOCS);
			table2state.Add("CATTLE",CATTLE);

			
			
		}
		public override int OnCommand(string strCommand,string cmdParams)
		{
			TableState stateDelegate = null;
			string tableName = null;
			

			if(strCommand == "EXIT")
			{
				m_nextState = m_callingState;
				return (int)StateReturnCodes.State_ChangeState;
			}
			else
			{
				IDictionaryEnumerator stateEnumerator = table2state.GetEnumerator();
				while ( stateEnumerator.MoveNext() )
				{

					tableName = (string)stateEnumerator.Key;
					stateDelegate = (TableState)stateEnumerator.Value;

					if(tableName.CompareTo(strCommand) == 0)
					{
						m_nextState = stateDelegate(cmdParams);
						return (int)StateReturnCodes.State_ChangeState;
					}
					
				}

			}			

			return (int)StateReturnCodes.State_BadCommand;		
		}

		protected abstract SyncState CreateINDOCSTableState(string stateParam);
		protected abstract SyncState CreateOUTDOCSTableState(string stateParam);
		protected abstract SyncState CreateCATTLETableState(string stateParam);
		
	
	}
}
