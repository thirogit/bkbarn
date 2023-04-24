using System;
using System.Data.Common;

namespace cowbase
{
	public class DOCSyncState : SyncState
	{
		private DbDataReader m_doc_reader;																																									
		private int m_hentOrd;
		private int m_docdateOrd;
		private int m_platenoOrd;
		private int m_loaddateOrd;
		private int m_docnoOrd;
		private int m_reasonOrd;
		private int m_actionOrd;

		public DOCSyncState(string tableName,string stateParam,SyncState callingState) : base(callingState)
		{
            string docSelQ = "SELECT * FROM %0 WHERE action = 'U' OR action = 'N'";
            string docCountQ = "SELECT COUNT(*) FROM %0 WHERE action = 'U' OR action = 'N'";

            m_doc_reader = null;
            string sqlStmt = SQLBuilder.SQLSprintf(docCountQ, tableName);

            try
            {
                m_response = SQLDB.ExecuteCount(sqlStmt).ToString();
                m_doc_reader = SQLDB.ExecuteQuery(SQLBuilder.SQLSprintf(docSelQ, tableName));
                m_hentOrd = m_doc_reader.GetOrdinal("hent");
                m_docdateOrd = m_doc_reader.GetOrdinal("docdate");
                m_platenoOrd = m_doc_reader.GetOrdinal("plateno");
                m_loaddateOrd = m_doc_reader.GetOrdinal("loaddate");
                m_docnoOrd = m_doc_reader.GetOrdinal("docno");
                m_reasonOrd = m_doc_reader.GetOrdinal("reason");
                m_actionOrd = m_doc_reader.GetOrdinal("action");
            }
            catch (SystemException sqlEx)
            {
                throw sqlEx;
            }
		}
        private void finalizeReader()
        {
            if (m_doc_reader != null)
                m_doc_reader.Close();
            m_doc_reader = null;
        }

		public override int OnCommand(string strCommand,string cmdParams)
		{
			
			switch(strCommand)
			{
				case "NEXT":
                    if (m_doc_reader != null &&  m_doc_reader.Read())
					{
						m_response = SQLBuilder.SQLSprintf("DOC,%0,%1,%2,%3,'%4',%5,%6",
							m_doc_reader.GetInt32(m_docnoOrd),
							SQLBuilder.GetSQLFlatDateStr(m_doc_reader.GetDateTime(m_docdateOrd)),
							SQLBuilder.GetSQLFlatDateStr(m_doc_reader.GetDateTime(m_loaddateOrd)),
							m_doc_reader.GetInt32(m_hentOrd),
							EncodeSyncString(m_doc_reader.GetString(m_platenoOrd)),
							m_doc_reader.GetInt32(m_reasonOrd),
							m_doc_reader.GetString(m_actionOrd));							
					}
					else
					{
						m_response = "DOC,END";
                        finalizeReader();
					}
					return (int)StateReturnCodes.State_SendResponse;
				case "EXIT":
					m_nextState = m_callingState;
                    finalizeReader();
					return (int)StateReturnCodes.State_ChangeState;


			}
			
			return (int)StateReturnCodes.State_BadCommand;		
		}
	}
}
