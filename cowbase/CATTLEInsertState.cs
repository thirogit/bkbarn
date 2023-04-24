using System;
using System.IO;

namespace cowbase
{
	public class CATTLEInsertState : TableInsertState
	{
		public CATTLEInsertState(string stateParam,SyncState callingState) : base(stateParam,callingState)
		{

		}

		protected override void InsertRecord(string[] insParams)
		{

			string cowInsert = 
			"INSERT INTO CATTLE(ean,birthdate,sex,stock,weight,passno," + 
			"fstownralias,docin,docout,buyprice,myprice,buystock,buyweight," +
            "termbuystock,termbuyweight,termbuyprice," +
            "termsellstock,termsellweight,termsellprice," +
            "hasbuyinv,ingrp,action)" +
			"VALUES(%0q,%1e,%2,%3,%4n,%5e,%6e,%7,%8n,%9n,%10n,%11n,%12n," +
            "%13n,%14n,%15n,%16n,%17n,%18n,%19,%20,'-');";
			
			string sqlStmt = SQLBuilder.SQLSprintf(cowInsert,insParams);
            SQLDB.ExecuteNonQuery(sqlStmt);
            LOG.DoLog("CATTLEInsertState.InsertRecord():" + sqlStmt);
		}
	}
}
