using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Data.Common;
#if COWBASEMOCK
using System.Data.Odbc;
#else
using System.Data.SqlServerCe;
#endif



namespace cowbase
{
	public class SQLDB
	{
		private static SQLDB m_DB;
		public static readonly int MAX_OUT_GRP = 9;
		public static readonly int NULL_OUT_GRP = -1;
        public static readonly int PRICE_PRECISION = 5;
        public static readonly int WEIGHT_PRECISION = 5;
		
		private DbConnection m_cConn = null;		
		private string m_sError = null;


#if !COWBASEMOCK
        private SqlCeEngine m_ceEngine = null;
        private static readonly string m_DataSource = "\\cattlebase.sdf";
        private static string m_DataSourceStr = "Data Source = " + m_DataSource + "; Locale Identifier=1031";
		   
#endif

//        Jak okreœliæ lokalizacjê tymczasowej bazy danych za pomoc¹ obiektów danych ActiveX dla systemu Microsoft Windows CE (ADOCE)
//Operacje ADOCE (ActiveX Data Objects for Microsoft Windows CE) s¹ kontrolowane przez ci¹gi po³¹czeñ, które zawieraj¹ listê wartoœci w³aœciwoœci oddzielonych œrednikami. Lokalizacjê tymczasowej bazy danych mo¿na okreœliæ, dodaj¹c na koñcu ci¹gu po³¹czenia nastêpuj¹cy podci¹g:

//";SSCE:Temp File Directory = katalog_tymczasowej_bazy_danych"  

//Jeœli poszczególne wartoœci w³aœciwoœci s¹ poprawnie oddzielone œrednikami, umiejscowienie œcie¿ki do tymczasowej bazy danych wewn¹trz ci¹gu po³¹czenia nie jest wa¿ne.

//W przypadku operacji ADOCE metoda Connection.Open wymaga okreœlenia lokalizacji tymczasowej bazy danych.

//Lokalizacjê tymczasowej bazy danych mo¿na okreœliæ równie¿ w Ÿród³owym ci¹gu po³¹czenia dla metody Engine.CompactDatabase. 

		private SQLDB()
		{		
		}
#if COWBASEMOCK
        protected static bool MockConnectToDB()
        {
            OdbcConnection odbcConnection =
                new OdbcConnection("Driver={PostgreSQL ODBC Driver(ANSI)};Server=localhost;Port=5432;Database=cattlebase;Uid=postgres;Pwd=potomak7");
            try
            {
                odbcConnection.Open();

                if (odbcConnection.State == System.Data.ConnectionState.Open)
                {
                    GetDB().m_cConn = odbcConnection;
                    return true;
                }
            }
            catch (System.Exception e)
            {
                GetDB().m_sError = e.Message;
            }
            return false;
        }
#else
        protected static bool CeConnectToDB()
        {
            if(GetDB().m_ceEngine == null)
                GetDB().m_ceEngine = new SqlCeEngine(m_DataSourceStr);
        
		    try
			{
                bool bDoCreate = false;
                if (!File.Exists(m_DataSource))
                {
                    GetDB().m_ceEngine.CreateDatabase();
                    bDoCreate = true;
                }

                SqlCeConnection ceConnection = new SqlCeConnection(m_DataSourceStr);
                ceConnection.Open();

                if (ceConnection.State == System.Data.ConnectionState.Open)
                {
                    GetDB().m_cConn = ceConnection;
                    if (bDoCreate)
                        return CreateDatabase();	
                }     
			}
			catch(SqlCeException sqlEx)
			{
                GetDB().m_sError = sqlEx.Message;
                return false;
            }
            return true;
        }
#endif

        public static bool ConnectToDB()
        {
#if COWBASEMOCK
                return MockConnectToDB();
#else
                return CeConnectToDB();
#endif
        }

#if !COWBASEMOCK
		protected static bool CreateDatabase()
		{
            string[] SQLFILES =
			{
					"HENTTYPESSQL",
					"HENTSSQL",
					"REASONSSQL",
					"STOCKSSQL",
					"INDOCSSQL",
					"OUTDOCSSQL",
					"CATTLESQL",
					"SYNCLOCKSQL"
			};
		
			string cmdText = String.Empty;
			foreach(string sqlfile in SQLFILES)
			{
                try
                {
                   cmdText = cowbase.Properties.Resources.ResourceManager.GetString(sqlfile,
                                    cowbase.Properties.Resources.Culture);

                    try
                    {
                        ExecuteNonQuery(cmdText);
                    }
                    catch (SystemException ex)
                    {
                        GetDB().m_sError = "Error in file " + sqlfile + "\n" + ex.Message;
                        LOG.DoLog("DoInitialDatabaseSetup(): " + GetDB().m_sError);
                        return false;
                    }
                    finally
                    {
                        cmdText = null;
                    }
                }
                catch (System.Exception e)
                {
                    GetDB().m_sError = "SQL delcaration file doesn't exist in resources: " + sqlfile;
                    LOG.DoLog("DoInitialDatabaseSetup(): " + GetDB().m_sError + " MSG = " + e.Message);
					return false;
                }
                finally
                {
                    cmdText = null;
                }                

                try
                {
                   cmdText = cowbase.Properties.Resources.ResourceManager.GetString(sqlfile+ "_DEF",
                    cowbase.Properties.Resources.Culture);

                   if (cmdText != null)
                   {
                       string sqlline;
                       StringReader sr = new StringReader(cmdText);
                       while ((sqlline = sr.ReadLine()) != null)
                       {
                           try
                           {
                               ExecuteNonQuery(sqlline);
                           }
                           catch (Exception ex)
                           {
                               GetDB().m_sError = "Error in sql definition resource file " + sqlfile + " at line:\n" +
                                   sqlline + "\n" + ex.Message;
                               LOG.DoLog(GetDB().m_sError);
                               sr.Close();
                               sr = null;
                               return false;
                           }
                       }
                       sr.Close();
                       sr = null;
                   }
                    
                }
                catch (System.Exception e)
                {
                    LOG.DoLog("Exception while processing DEF file: " + sqlfile + ": " + e.Message);
                }				
			}
            return true;
		}
#endif

		protected static DbConnection GetDBConnection()
		{
			return GetDB().m_cConn;
		}

		public static SQLDB GetDB()
		{
            if(m_DB == null)
                m_DB = new SQLDB();
            return m_DB;
		}

		public static string GetLastError()
		{
			return GetDB().m_sError;
		}

        public static long ExecuteCount(string countQ)
        {
            object scalarObj = ExecuteScalar(countQ);
#if COWBASEMOCK
            return (long)scalarObj;
#else
            return (int)scalarObj;
#endif
        }

        public static object ExecuteScalar(string sqlQuery)
        {
            DbCommand sqlQueryCmd = GetDBConnection().CreateCommand();
            try
            {
                sqlQueryCmd.CommandText = sqlQuery;
                return sqlQueryCmd.ExecuteScalar();
            }
            finally
            {
                sqlQueryCmd.Dispose();
                sqlQueryCmd = null;
            }
        }
        public static int ExecuteNonQuery(string sqlStmt)
        {
            DbCommand sqlStmtCmd = GetDBConnection().CreateCommand();
            try
            {
                sqlStmtCmd.CommandText = sqlStmt;
                return sqlStmtCmd.ExecuteNonQuery();
            }
            finally
            {
                sqlStmtCmd.Dispose();
                sqlStmtCmd = null;
            }
        }

        public static DbDataReader ExecuteQuery(string sqlQuery)
        {
            DbCommand sqlQueryCmd = GetDBConnection().CreateCommand();
            try
            {
                sqlQueryCmd.CommandText = sqlQuery;
                return sqlQueryCmd.ExecuteReader();
            }
            finally
            {
                sqlQueryCmd = null;
            }
        }

		public static bool IsSyncLocked()
		{
			string lockQ = "SELECT lock FROM synclock WHERE lockid = 1";
			object lockValue;
            try
            {            
                lockValue = ExecuteScalar(lockQ);
                if (lockValue == null)
                {                    
                    ExecuteNonQuery("INSERT INTO synclock(lockid,locktime,lock) VALUES(1,GETDATE(),0);");
                    return false;
                }
                else
                    return (int)lockValue != 0;
            }
            catch (SystemException ex)
            {
                GetDB().m_sError = ex.Message;
                LOG.DoLog("IsSyncLocked(): " + ex.Message);
                return false;
            }            
		}

		public static bool LockSync()
		{
			string lockU = "UPDATE synclock  SET lock = 1,locktime = GETDATE() WHERE lockid = 1";
			try
            {                
                return ExecuteNonQuery(lockU) == 1;
            }
            catch (SystemException ex)
            {
                GetDB().m_sError = ex.Message;
                LOG.DoLog("LockSync(): " + ex.Message);
                return false;
            }            
		}

		public static bool FlushTables()
		{
			string[] tables =
				{					
					"CATTLE",
					"STOCKS",
					"INDOCS",
					"OUTDOCS",
					"HENTS"
				};

			
			string delCommand = "DELETE FROM %0";
            string sqlStmt = String.Empty;

            try
            {
                for (int i = 0; i < tables.Length; i++)
                {
                    sqlStmt = SQLBuilder.SQLSprintf(delCommand, tables[i]);
                    ExecuteNonQuery(sqlStmt);
                }            
            }
            catch (SystemException sqlEx)
            {
                GetDB().m_sError = sqlEx.Message;
                LOG.DoLog("FlushTables(): STMT = " + sqlStmt + " MSG = " + GetDB().m_sError);
                return false;
            }   
			return true;
		}


        public static bool UnlockSync()
        {
            string unlockU = "UPDATE synclock  SET lock = 0,locktime = GETDATE() WHERE lockid = 1";
            try
            {
                return ExecuteNonQuery(unlockU) == 1;
            }
            catch (SystemException ex)
            {
                GetDB().m_sError = ex.Message;
                LOG.DoLog("UnlockSync(): " + ex.Message);
                return false;
            }
        }

		public static Stock GetStock(int stockid)
		{
            Stock stock = null;
            string stockQ = "SELECT stockid,stockcode,predefsex FROM stocks WHERE stockid = " + stockid.ToString();
		    DbDataReader reader = null;
	
            try
            {
                reader = ExecuteQuery(stockQ);

                int stockCodeOrd = reader.GetOrdinal("stockcode");
                int stockIdOrd = reader.GetOrdinal("stockid");
                int stockPreDefSex = reader.GetOrdinal("predefsex");
                if (reader.Read())
                {
                    stock = new Stock();

                    stock.stockCode = reader.GetString(stockCodeOrd);
                    stock.stockId = reader.GetInt32(stockIdOrd);
                    if (!reader.IsDBNull(stockPreDefSex))
                        stock.predefSex = CowSex.FromInt(reader.GetInt32(stockPreDefSex));

                }
            }
            catch (SystemException sqlEx)
            {
                LOG.DoLog("GetStockCodeStr(): QUERY = " + stockQ + " MSG = " + sqlEx.Message);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                reader = null;
            }            
            return stock;					
		}

		public static long GetCowCount(bool bInCows)
		{
            string countQ = "SELECT COUNT(*) FROM cattle";
            if (bInCows) countQ += " WHERE docout IS NULL";
            long cowcount = 0;

            try
            {
                cowcount = ExecuteCount(countQ);
            }
            catch (SystemException sqlEx)
            {
                LOG.DoLog("GetCowCount(): QUERY = " + countQ + " MSG = " + sqlEx.Message);


            }
            return cowcount;
		}


        public static Cow FindCow(string sEAN)
        {
            ICollection<Cow> singleCow = SQLDB.LoadCows(new cowbase.wheres.EanWhere(sEAN));

            if (singleCow.Count != 1)
                return null;

            IEnumerator<Cow> cowEnumerator = singleCow.GetEnumerator();
            cowEnumerator.MoveNext();

            return cowEnumerator.Current;

        }
              
        
        public static ICollection<Cow> LoadCows(cowbase.wheres.CowWhere where)
		{

            ICollection<Cow> cowResultList = new LinkedList<Cow>();
			string cowQ = "SELECT cattle.action AS action,sex,stock,weight,myprice,ean," +
                                 "outgrp,inhents.hentid AS hentid,inhents.alias AS hentalias," +
                                 "termbuyprice,termbuyweight,termbuystock," +
                                 "termsellprice,termsellweight,termsellstock," +
                                 "hasbuyinv,ingrp" +
								 " FROM cattle" +
								 " LEFT JOIN indocs ON (indocs.docno = cattle.docin)" +
								 " LEFT JOIN hents inhents ON (indocs.hent = inhents.hentid)";

            DbDataReader cow_reader = null;

            if (where != null)
            {
                cowQ += " WHERE ";
                cowQ += where.getWhere();
            }
                     

            try
            {

                cow_reader = ExecuteQuery(cowQ);

                int sexOrd = cow_reader.GetOrdinal("sex"),
                    stockOrd = cow_reader.GetOrdinal("stock"),
                    weightOrd = cow_reader.GetOrdinal("weight"),
                    mypriceOrd = cow_reader.GetOrdinal("myprice"),
                    eanOrd = cow_reader.GetOrdinal("ean"),
                    actionOrd = cow_reader.GetOrdinal("action"),
                    outgrpOrd = cow_reader.GetOrdinal("outgrp"),
                    hentidOrd = cow_reader.GetOrdinal("hentid"),
                    hentaliasOrd = cow_reader.GetOrdinal("hentalias"),
                    termbuypriceOrd = cow_reader.GetOrdinal("termbuyprice"),
                    termbuyweightOrd = cow_reader.GetOrdinal("termbuyweight"),
                    termbuystockOrd = cow_reader.GetOrdinal("termbuystock"),
                    termsellpriceOrd = cow_reader.GetOrdinal("termsellprice"),
                    termsellweightOrd = cow_reader.GetOrdinal("termsellweight"),
                    termsellstockOrd = cow_reader.GetOrdinal("termsellstock"),
                    hasbuyinvOrd = cow_reader.GetOrdinal("hasbuyinv"),
                    ingrpOrd = cow_reader.GetOrdinal("ingrp");

                while (cow_reader.Read())
                {
                    Cow cow = new Cow();
                    cow.EAN = cow_reader.GetString(eanOrd);
                    cow.sex = CowSex.FromInt(cow_reader.GetInt32(sexOrd));
                    cow.stock = SQLDB.GetStock(cow_reader.GetInt32(stockOrd));
                    cow.weight = Decimal.ToDouble(cow_reader.GetDecimal(weightOrd));
                   
                    cow.action = Action.FromCharacter(cow_reader.GetString(actionOrd).ToCharArray()[0]);

                    if (!cow_reader.IsDBNull(mypriceOrd))
                        cow.myprice = Decimal.ToDouble(cow_reader.GetDecimal(mypriceOrd));


                    if (cow_reader.IsDBNull(outgrpOrd))
                        cow.outgrp = NULL_OUT_GRP;
                    else
                        cow.outgrp = cow_reader.GetInt32(outgrpOrd);

                    cow.hentid = cow_reader.GetInt32(hentidOrd);
                    cow.hentalias = cow_reader.GetString(hentaliasOrd);

                    if (!cow_reader.IsDBNull(termbuypriceOrd))
                        cow.termbuyprice = Decimal.ToDouble(cow_reader.GetDecimal(termbuypriceOrd));

                    if (!cow_reader.IsDBNull(termbuyweightOrd))
                        cow.termbuyweight = Decimal.ToDouble(cow_reader.GetDecimal(termbuyweightOrd));

                    if (!cow_reader.IsDBNull(termbuystockOrd))
                        cow.termbuystock = cow_reader.GetInt32(termbuystockOrd);

                    if (!cow_reader.IsDBNull(termsellpriceOrd))
                        cow.termsellprice = Decimal.ToDouble(cow_reader.GetDecimal(termsellpriceOrd));

                    if (!cow_reader.IsDBNull(termsellweightOrd))
                        cow.termsellweight = Decimal.ToDouble(cow_reader.GetDecimal(termsellweightOrd));

                    if (!cow_reader.IsDBNull(termsellstockOrd))
                        cow.termsellstock = cow_reader.GetInt32(termsellstockOrd);

                    if (!cow_reader.IsDBNull(hasbuyinvOrd))
                        cow.hasBuyInv = cow_reader.GetInt32(hasbuyinvOrd) > 0;

                    if (!cow_reader.IsDBNull(ingrpOrd))
                        cow.ingrp = cow_reader.GetInt32(ingrpOrd);
                    else
                        cow.ingrp = SQLDB.NULL_OUT_GRP;

                    cowResultList.Add(cow);
                }
            }
            catch (Exception ex)
            {
                LOG.DoLog("LoadCows(): QUERY = " + cowQ + ", MSG = " + ex.Message + ", STACKTRACE = " + ex.StackTrace.ToString());
                throw ex;
            }
            finally
            {
                if (cow_reader != null)
                    cow_reader.Close();
                cow_reader = null;
            }
            return cowResultList;
		}

	
       


	}
}
