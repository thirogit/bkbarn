using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.Common;

namespace cowbase
{
	public class EditOutDoc : NewOutDoc
	{
		private List<Cow> m_delCows;
		private List<Cow> m_newCows;

		private Doc m_editedDoc;
		

		public EditOutDoc(Doc doc)
		{
			m_delCows = new List<Cow>();
			m_newCows = new List<Cow>();
            m_editedDoc = doc;


            m_CurHent = m_editedDoc.hentid;
            m_hentBox.Text = m_editedDoc.hentalias;
            m_CurReason = m_editedDoc.reasonid;
            m_reasonLbl.Text = m_editedDoc.reasoncode;
            m_plateNoBox.Text = m_editedDoc.plateno;

            ICollection<Cow> cows = SQLDB.LoadCows(new cowbase.wheres.OutDocNoWhere(m_editedDoc.docno));

            foreach (Cow cow in cows)
            {
                AddToList(cow);
            }
           
			
			

		}
		protected override string GetCaption()
		{
			return "Edycja dokumentu WZ";
		}
		protected override bool DeleteCow(Cow cowd)
		{
            if (cowListBox.GetItemCount() > 0)
			{
                if (cowListBox.GetItemCount() > 1)
				{
					for(int i = 0;i < m_chngdCows.Count;i++)
						if(((Cow)m_chngdCows[i]).EAN.CompareTo(cowd.EAN) == 0)
						{
							m_chngdCows.RemoveAt(i);
							i--;
							break;
						}

					for(int i = 0;i < m_newCows.Count;i++)
						if(((Cow)m_newCows[i]).EAN.CompareTo(cowd.EAN) == 0)
						{
							m_newCows.RemoveAt(i);
							i--;
							return true; 
						}
					m_delCows.Add(cowd);				
				
					return true;
				}
				else
					BigOKMessageBox.ShowMessage("Usuwanie","Dokument musi zawierac co najmniej jedna pozycje");
			}
			return false;
		}
		protected override bool EditCow(Cow cowd)
		{
            LOG.DoLog("EditOutDoc.EditCow: BEFORE " + cowd.ToString());	
			EditCow editCow = new EditCow(cowd);
			
			if(editCow.ShowDialog() == DialogResult.OK)
			{
				if(cowd.action != Action.FRESH)
				{
					if(IsInChanged(cowd))	
                        return true;
					m_chngdCows.Add(cowd);
				}
                LOG.DoLog("EditOutDoc.EditCow: AFTER " + cowd.ToString());
				return true;
			}			
			return false;
			
		}

        protected override void Init()
        {
            this.Text = GetCaption();
            this.Closed += new EventHandler(OnClosedNewDocDlg);
            UpdateCowCount();
            cowListBox.SetFormatter(new OutDocCowItemStringFormatter());
        }

		

		protected override bool  CommitDoc()
		{
			bool bRet = true;
			string updateDocStmtFmt = "UPDATE outdocs SET hent = %0,plateno = '%1',reason = %2,action = '%3' WHERE docno = %4";

            try
            {
                if (!m_editedDoc.action.Equals(Action.NEW))
                    m_editedDoc.action = Action.UPDATE;

                m_editedDoc.hentalias = m_hentBox.Text;
                m_editedDoc.hentid = m_CurHent;
                m_editedDoc.plateno = m_plateNoBox.Text;
                m_editedDoc.reasonid = m_CurReason;
                m_editedDoc.reasoncode = m_reasonLbl.Text;
                m_editedDoc.cowcount = cowListBox.GetItemCount();
                
                string updateDocStmt = SQLBuilder.SQLSprintf(updateDocStmtFmt, m_CurHent, m_plateNoBox.Text,
                    m_CurReason, Utils.FormatActionSQL(m_editedDoc.action), m_editedDoc.docno);

                SQLDB.ExecuteNonQuery(updateDocStmt);

                string cowUpdateDocStmtFmt = "UPDATE cattle SET docout=%0,action = '%1',outgrp = %2 WHERE ean = '%3'";
                Cow cowd = null;
                int i;

                for (i = 0; i < m_newCows.Count; i++)
                {
                    cowd = (Cow)m_newCows[i];
                    if (cowd.action != Action.NEW) 
                        cowd.action = Action.UPDATE;

                    string cowUpdateDocStmt = SQLBuilder.SQLSprintf(cowUpdateDocStmtFmt, m_editedDoc.docno, Utils.FormatActionSQL(cowd.action), cowd.outgrp, cowd.EAN);
                    SQLDB.ExecuteNonQuery(cowUpdateDocStmt);
                }

                string cowUpdateStmtFmt = "UPDATE cattle SET stock = %0,sex = %1,weight = %2,action = '%3',myprice = %4, outgrp = %5," +
                    "termbuystock = %6, termbuyweight = %7, termbuyprice = %8, termsellstock = %9, termsellweight = %10, " +
                    "termsellprice = %11  WHERE ean = '%12'";


                for (i = 0; i < m_chngdCows.Count; i++)
                {
                    cowd = (Cow)m_chngdCows[i];
                    if (cowd.action != Action.NEW) 
                        cowd.action = Action.UPDATE;

                    string cowUpdateStmt = SQLBuilder.SQLSprintf(
                        cowUpdateStmtFmt,
                        cowd.stock.stockId,
                        cowd.sex.ToInt(),
                        cowd.weight, 
                        Utils.FormatActionSQL(cowd.action),
                        Utils.FormatMoneySQL(cowd.myprice),
                        cowd.outgrp,
                        Utils.FormatIntegerSQL(cowd.termbuystock),
                        Utils.FormatWeightSQL(cowd.termbuyweight),
                        Utils.FormatMoneySQL(cowd.termbuyprice),
                        Utils.FormatIntegerSQL(cowd.termsellstock),
                        Utils.FormatWeightSQL(cowd.termsellweight),
                        Utils.FormatMoneySQL(cowd.termsellprice),
                        cowd.EAN);

                    SQLDB.ExecuteNonQuery(cowUpdateStmt);

                }

                string cowDeleteFromDocStmtFmt = "UPDATE cattle SET docout=NULL,action = '%0',outgrp = NULL WHERE ean = '%1'";
                for (i = 0; i < m_delCows.Count; i++)
                {
                    cowd = (Cow)m_delCows[i];
                    if (cowd.action != Action.NEW) 
                        cowd.action = Action.UPDATE;
                    
                    string cowDeleteFromDocStmt = SQLBuilder.SQLSprintf(cowDeleteFromDocStmtFmt,
                        Utils.FormatActionSQL(cowd.action),
                        cowd.EAN);
                    SQLDB.ExecuteNonQuery(cowDeleteFromDocStmt);
                }
            }
            catch (SystemException sqlEx)
            {
                bRet = false;
                LOG.DoLog("EditOutDoc.CommitDoc(): " + sqlEx.Message + "STACK: " + sqlEx.StackTrace);
                BigOKMessageBox.ShowMessage("BLAD", sqlEx.Message);
            }

			return bRet;
		}
		protected override bool ContinueWithEAN(string EANStr)
		{
		
			if(base.ContinueWithEAN(EANStr))
			{
                m_newCows.Add((Cow)cowListBox.GetItem(cowListBox.GetItemCount() - 1));
				return true;
			}
			return false;		
		}
	}
}
