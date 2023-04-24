using System;

namespace cowbase
{
	public class INDOCSInsertState : TableInsertState
	{
		public INDOCSInsertState(string stateParam,SyncState callingState) : base(stateParam,callingState)
		{
			
		}

		protected override void InsertRecord(string[] insParams)
		{
			string docInsert = "INSERT INTO INDOCS(docno,hent,reason,docdate,loaddate,plateno,action,hasmorecows)" +
				"VALUES(%0,%1,%2,%3q,%4q,%5q,'-',%6)";
            string sqlStmt = SQLBuilder.SQLSprintf(docInsert, insParams);
            SQLDB.ExecuteNonQuery(sqlStmt);
            LOG.DoLog("INDOCSInsertState.InsertRecord(): " + sqlStmt);
		}
	
		
	}
}
