using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Common;

namespace cowbase
{
    public partial class CowDetails : CenterForm
    {

        public CowDetails(String EAN)
        {
            InitializeComponent();
            AskDBForDetails(EAN);
        }
        private void AskDBForDetails(string aEAN)
        {
            
            string cowDetailsQ =  "SELECT passno,fstownralias," +
                                  "buyprice,buyweight,buystocks.stockcode AS buystockcode," +
                                  "indocs.docno AS indocno,outdocs.docno AS outdocno " +
                                  "FROM cattle " +
                                  "LEFT JOIN indocs ON (indocs.docno = cattle.docin) " +
                                  "LEFT JOIN hents inhents ON (indocs.hent = inhents.hentid) " +
                                  "LEFT JOIN stocks buystocks ON (cattle.buystock = buystocks.stockid) " +
                                  "LEFT JOIN outdocs ON cattle.docout = outdocs.docno " +
                                  "WHERE ean = '" + aEAN + "'";

            DbDataReader reader = null;

            try
            {
                reader = SQLDB.ExecuteQuery(cowDetailsQ);
                if (reader.Read())
                {
                    SetLabel(reader, "fstownralias", fstownerVal);
                    SetLabel(reader, "buyprice", buyPriceVal);
                    SetLabel(reader, "buyweight", buyWeightVal);
                    SetLabel(reader, "buystockcode", buyStockVal);
                    SetDocNoLabel(reader, "indocno", indocNoVal);
                    SetDocNoLabel(reader, "outdocno", outDocNoVal);
                    SetLabel(reader, "passno", passNoVal);
                }
            }
            catch (SystemException sqlEx)
            {
                LOG.DoLog("AskDBForDetails(): EAN = '" + aEAN + "' MSG = " + sqlEx.Message);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                reader = null;
            }

        }


        private void SetLabel(DbDataReader aReader, string colName, Label aLabel)
        {

            int ordinal = aReader.GetOrdinal(colName);
            if (aReader.IsDBNull(ordinal))
                aLabel.Text = "BRAK";
            else
                aLabel.Text = aReader.GetValue(ordinal).ToString();

        }
        private void SetDocNoLabel(DbDataReader aReader, string colName, Label aLabel)
        {

            int ordinal = aReader.GetOrdinal(colName);
            if (aReader.IsDBNull(ordinal))
                aLabel.Text = "BRAK";
            else
            {
                int docno = aReader.GetInt32(ordinal);
                if(docno <= 0)
                    aLabel.Text = "NOWY";
                else
                    aLabel.Text = docno.ToString();
            }
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}