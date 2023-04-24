using System;

namespace cowbase
{
	public class HENTSInsertState : TableInsertState
	{
		public HENTSInsertState(string stateParam,SyncState callingState) : base(stateParam,callingState)
		{
		}

		protected override void InsertRecord(string[] insParams)
		{
			string hentInsert = "INSERT INTO HENTS(hentid,alias,name,zip,city,street,pobox,arimrno,plate,henttype)" + 
				                  "VALUES(%0,%1q,%2q,%3q,%4q,%5q,%6q,%7e,%8q,%9);";
						
				
			string sqlStmt = SQLBuilder.SQLSprintf(hentInsert,insParams);
            SQLDB.ExecuteNonQuery(sqlStmt);
            LOG.DoLog("HENTSInsertState.InsertRecord():" + sqlStmt);
		}
	}
}
