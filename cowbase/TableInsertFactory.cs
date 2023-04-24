using System;


namespace cowbase
{
	
	public class TableInsertFactory : TableFactory
	{
		private TableState STOCKS = null;
		private TableState HENTS = null;

		public TableInsertFactory(SyncState callingState) : base(callingState)
		{
			STOCKS += new TableState(CreateSTOCKSTableState);
			HENTS += new TableState(CreateHENTSTableState);
			table2state.Add("STOCKS",STOCKS);
			table2state.Add("HENTS",HENTS);
		}
		
		protected override SyncState CreateINDOCSTableState(string stateParam)
		{
			return new INDOCSInsertState(stateParam,this);
		}


		protected override SyncState CreateOUTDOCSTableState(string stateParam)
		{
			return this;
		}

		protected override SyncState CreateCATTLETableState(string stateParam)
		{
			return new CATTLEInsertState(stateParam,this);
		}

		protected virtual SyncState CreateSTOCKSTableState(string stateParam)
		{
			return new STOCKSInsertState(stateParam,this);
		}

		protected virtual SyncState CreateHENTSTableState(string stateParam)
		{
			return new HENTSInsertState(stateParam,this);
		}




	}
}
