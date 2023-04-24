using System;

namespace cowbase
{
	public class STOCKSInsertState : TableInsertState
	{

		public STOCKSInsertState(string stateParam,SyncState callingState) : base(stateParam,callingState)
		{
			
		}
		
		protected override void InsertRecord(string[] insParams)
		{
			string stockInsert = "INSERT INTO STOCKS(stockid,stockcode,predefsex) VALUES(%0,%1q,%2);";
			
			string sqlStmt = SQLBuilder.SQLSprintf(stockInsert,insParams);
			LOG.DoLog("STOCKSInsertState.InsertRecord(): " + sqlStmt);
			SQLDB.ExecuteNonQuery(sqlStmt);		
		}


	}
}
