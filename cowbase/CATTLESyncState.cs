using System;
using System.Data.Common;

namespace cowbase
{
    public class CATTLEGetSyncState : SyncState
    {
        private DbDataReader m_cow_reader;

        private int m_eanOrd;
        private int m_sexOrd;
        private int m_stockOrd;
        private int m_weightOrd;
        private int m_docinOrd;
        private int m_docoutOrd;
        private int m_mypriceOrd;
        private int m_actionOrd;
        private int m_outgrpOrd;
        private int m_termbuypriceOrd;
        private int m_termbuyweightOrd;
        private int m_termbuystockOrd;
        private int m_termsellpriceOrd;
        private int m_termsellweightOrd;
        private int m_termsellstockOrd;
        private int m_ingrpOrd;

        public CATTLEGetSyncState(string stateParam, SyncState callingState)
            : base(callingState)
        {
            string cowQueryFmt = "SELECT ean,sex,stock,weight,docin,docout,myprice,action,outgrp," +
                                 "termbuyprice,termbuyweight,termbuystock," +
                                 "termsellprice,termsellweight,termsellstock,ingrp" +
                                 " FROM cattle WHERE action = 'N' OR action ='U'";

            string cowCountQ = "SELECT COUNT(*) FROM cattle WHERE  action = 'N' OR action ='U'";

            try
            {

                m_response = SQLDB.ExecuteCount(cowCountQ).ToString();
                m_cow_reader = SQLDB.ExecuteQuery(cowQueryFmt);

                m_eanOrd = m_cow_reader.GetOrdinal("ean");
                m_sexOrd = m_cow_reader.GetOrdinal("sex");
                m_stockOrd = m_cow_reader.GetOrdinal("stock");
                m_weightOrd = m_cow_reader.GetOrdinal("weight");
                m_docinOrd = m_cow_reader.GetOrdinal("docin");
                m_docoutOrd = m_cow_reader.GetOrdinal("docout");
                m_mypriceOrd = m_cow_reader.GetOrdinal("myprice");
                m_actionOrd = m_cow_reader.GetOrdinal("action");
                m_outgrpOrd = m_cow_reader.GetOrdinal("outgrp");
                m_termbuypriceOrd = m_cow_reader.GetOrdinal("termbuyprice");
                m_termbuyweightOrd = m_cow_reader.GetOrdinal("termbuyweight");
                m_termbuystockOrd = m_cow_reader.GetOrdinal("termbuystock");
                m_termsellpriceOrd = m_cow_reader.GetOrdinal("termsellprice");
                m_termsellweightOrd = m_cow_reader.GetOrdinal("termsellweight");
                m_termsellstockOrd = m_cow_reader.GetOrdinal("termsellstock");
                m_ingrpOrd = m_cow_reader.GetOrdinal("ingrp");
            }
            catch (SystemException sqlEx)
            {
                throw sqlEx;               
            }   

        }

        private string GetStringValue(int Ord)
        {
            string value = String.Empty;

            if (!m_cow_reader.IsDBNull(Ord))
                value = m_cow_reader.GetValue(Ord).ToString();
            return value;
        }

        private string GetFloatValue(int Ord,int prec)
        {
            string value = String.Empty;

            if (!m_cow_reader.IsDBNull(Ord))
                value = Utils.FormatFloat(Decimal.ToDouble(m_cow_reader.GetDecimal(Ord)), prec);
            return value;
        }

        private void finalizeReader()
        {
            if (m_cow_reader != null)
                m_cow_reader.Close();
            m_cow_reader = null;
        }

        public override int OnCommand(string strCommand, string cmdParams)
        {
            switch (strCommand)
            {
                case "EXIT":
                    m_nextState = m_callingState;
                    finalizeReader();
                    return (int)StateReturnCodes.State_ChangeState;

                case "NEXT":

                    if (m_cow_reader != null && m_cow_reader.Read())
                    {
                        string myprice, docout;
                        int outgrp;
                        string termbuyprice;
                        string termbuyweight;
                        string termbuystock;
                        string termsellprice;
                        string termsellweight;
                        string termsellstock;

                        myprice = GetFloatValue(m_mypriceOrd, SQLDB.PRICE_PRECISION);
                        docout = GetStringValue(m_docoutOrd);

                        if (m_cow_reader.IsDBNull(m_outgrpOrd))
                            outgrp = -1;
                        else
                            outgrp = m_cow_reader.GetInt32(m_outgrpOrd);


                        termbuyprice = GetFloatValue(m_termbuypriceOrd, SQLDB.PRICE_PRECISION);
                        termbuyweight = GetFloatValue(m_termbuyweightOrd, SQLDB.WEIGHT_PRECISION);
                        termbuystock = GetStringValue(m_termbuystockOrd);
                        termsellprice = GetFloatValue(m_termsellpriceOrd, SQLDB.PRICE_PRECISION);
                        termsellweight = GetFloatValue(m_termsellweightOrd, SQLDB.WEIGHT_PRECISION);
                        termsellstock = GetStringValue(m_termsellstockOrd);


                        m_response = SQLBuilder.SQLSprintf("COW,%0,%1,%2,%3,%4,%5,%6,%7,%8,%9,%10,%11,%12,%13,%14,%15",
                            m_cow_reader.GetString(m_eanOrd),
                            m_cow_reader.GetInt32(m_sexOrd),
                            m_cow_reader.GetInt32(m_stockOrd),
                            Utils.FormatWeightSQL(Decimal.ToDouble(m_cow_reader.GetDecimal(m_weightOrd))),
                            myprice,
                            m_cow_reader.GetInt32(m_docinOrd),
                            docout,
                            outgrp,
                            termbuyprice,
                            termbuyweight,
                            termbuystock,
                            termsellprice,
                            termsellweight,
                            termsellstock,
                            m_cow_reader.GetString(m_actionOrd),
                            m_cow_reader.GetInt32(m_ingrpOrd)
                            );

                        myprice = null;
                        docout = null;
                        termbuyprice = null;
                        termbuyweight = null;
                        termbuystock = null;
                        termsellprice = null;
                        termsellweight = null;
                        termsellstock = null;
                    }
                    else
                    {
                        m_response = "COW,END";
                        finalizeReader();            
                    }

                    break;
                default:
                    return (int)StateReturnCodes.State_BadCommand;

            }


            return (int)StateReturnCodes.State_SendResponse;
        }
    }



}
