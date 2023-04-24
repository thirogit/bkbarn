using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.Common;

namespace cowbase
{
	public class EditInDoc : NewInDoc
	{
		private List<Cow> m_delCows;
		private List<Cow> m_editCows;
        private Doc m_editedDoc;

		public EditInDoc(Doc doc)
		{
            m_delCows = new List<Cow>();
            m_editCows = new List<Cow>();

            m_editedDoc = doc;
            
            m_CurHent = m_editedDoc.hentid;
            m_hentBox.Text = m_editedDoc.hentalias;
            m_CurReason = m_editedDoc.reasonid;
            m_reasonLbl.Text = m_editedDoc.reasoncode;
            m_plateNoBox.Text = m_editedDoc.plateno;
            ICollection<Cow> cows = SQLDB.LoadCows(new cowbase.wheres.InDocNoWhere(m_editedDoc.docno));

            foreach (Cow cow in cows)
            {
                AddToList(cow);
            }       
            
			
				
		}

		protected override string GetCaption()
		{
			return "Edycja dokumentu PZ";
		}

		protected override bool DeleteCow(Cow cowd)
		{

            if (cowListBox.GetItemCount() > 0)
			{
                if (cowListBox.GetItemCount() > 1)
				{
                    if (cowd.action == Action.NEW)
                    {
                        string cowOutDocQ = "SELECT docout FROM cattle WHERE ean = '" + cowd.EAN + "'";
						DbDataReader reader = null;
						try
						{

                            reader = SQLDB.ExecuteQuery(cowOutDocQ);
                            reader.Read();
							if(!reader.IsDBNull(reader.GetOrdinal("docout")))
							{
								BigOKMessageBox.ShowMessage("Wystawiona WZ-tka",
									"Nie mozna usunac tego zwierzacia poniewaz przypisane jest juz do WZtki");
								return false;
							}
						}
						catch(Exception ex)
						{
							LOG.DoLog("EditInDoc.DeleteCow() exception: " + ex.Message);
							BigOKMessageBox.ShowMessage("Blad usuwania",ex.Message);
							return false;
						}
						finally
						{
                            if (reader != null)
                                reader.Close();
							reader = null;
						}

                        for (int i = 0; i < m_editCows.Count; i++)
                        {
                            if (((Cow)m_editCows[i]).EAN.CompareTo(cowd.EAN) == 0)
                            {
                                m_editCows.RemoveAt(i);
                                i--;
                                break;
                            }
                        }

                        m_delCows.Add(cowd);
                    }
                    else
                    {
                        BigOKMessageBox.ShowMessage("Usuwanie", "Nie mo¿na usuwaæ zwierz¹t nie wprowadzonych przez kolektor");
                        return false;
                    }

					return true;
				}
				else
					BigOKMessageBox.ShowMessage("Usuwanie","Dokument musi zawierac conajmniej jedna pozycje");
			}
			return false;
		}
		protected override bool EditCow(Cow cowd)
		{
			EditCow editCow = new EditCow(cowd);

			if(editCow.ShowDialog() == DialogResult.OK)
			{
				if(cowd.action != Action.FRESH)
				{
					if(!IsInEdited(cowd))
					    m_editCows.Add(cowd);					
				}
				return true;
			}
			return false;
		}

        protected bool IsInEdited(Cow cow)
        {
            for (int i = 0; i < m_editCows.Count; i++)
                if (((Cow)m_editCows[i]).EAN.CompareTo(cow.EAN) == 0)
                    return true;
            return false;			
        }

		protected override bool  CommitDoc()
		{
			bool bRet = true;
			string updateDocStmtFmt = "UPDATE indocs SET hent = %0,plateno = '%1',reason = %2,action = '%3' WHERE docno = %4";

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

            try
            {
                SQLDB.ExecuteNonQuery(updateDocStmt);
            }
            catch(SystemException sqlEx)
            {
                LOG.DoLog("STMT = " + updateDocStmt + ", MSG = " + sqlEx.Message + ", STACKTRACE = " + sqlEx.StackTrace.ToString());
                throw sqlEx;
            }

				string cowInsStmtFmt = "INSERT INTO CATTLE(ean,sex,stock,weight,docin,myprice,action,ingrp) VALUES(%0q,%1,%2,%3,%4,%5,'N',%6)";
				Cow cowd = null;
				int i;
                for (i = 0; i < cowListBox.GetItemCount(); i++)
				{
                    cowd = (Cow)cowListBox.GetItem(i);
                    if (cowd.action == Action.FRESH)
					{
                        string cowInsStmt = SQLBuilder.SQLSprintf(cowInsStmtFmt, 
                                                                  cowd.EAN, 
                                                                  cowd.sex.ToInt(),
                                                                  cowd.stock.stockId, 
                                                                  Utils.FormatWeightSQL(cowd.weight), 
                                                                  m_editedDoc.docno, 
                                                                  Utils.FormatMoneySQL(cowd.myprice), 
                                                                  cowd.ingrp);
                     
                        try
                        {
                            SQLDB.ExecuteNonQuery(cowInsStmt);
                        }
                        catch (SystemException sqlEx)
                        {
                            LOG.DoLog("STMT = " + cowInsStmt + ", MSG = " + sqlEx.Message + ", STACKTRACE = " + sqlEx.StackTrace.ToString());
                            throw sqlEx;
                        }
					}
				}

				string cowUpdateStmtFmt = "UPDATE cattle SET stock = %0,sex = %1,weight = %2,action = '%3',myprice = %4," +
                    "termbuystock = %5, termbuyweight = %6, termbuyprice = %7, termsellstock = %8, termsellweight = %9, " +
                    "termsellprice = %10,ingrp = %12  WHERE ean = '%11'";
                for(i = 0;i < m_editCows.Count;i++)
				{
					cowd = (Cow)m_editCows[i];
                    if (cowd.action != Action.NEW)
                        cowd.action = Action.UPDATE;

                    string cowUpdateStmt = SQLBuilder.SQLSprintf(cowUpdateStmtFmt,
                         cowd.stock.stockId,
                         cowd.sex.ToInt(),
                         cowd.weight,
                         Utils.FormatActionSQL(cowd.action),
                         Utils.FormatMoneySQL(cowd.myprice),
                         Utils.FormatIntegerSQL(cowd.termbuystock),
                         Utils.FormatWeightSQL(cowd.termbuyweight),
                         Utils.FormatMoneySQL(cowd.termbuyprice),
                         Utils.FormatIntegerSQL(cowd.termsellstock),
                         Utils.FormatWeightSQL(cowd.termsellweight),
                         Utils.FormatMoneySQL(cowd.termsellprice),
                         cowd.EAN,
                         cowd.ingrp);

                    try
                    {                    
                        SQLDB.ExecuteNonQuery(cowUpdateStmt);
                    }
                    catch (SystemException sqlEx)
                    {
                        LOG.DoLog("STMT = " + cowUpdateStmt + ", MSG = " + sqlEx.Message + ", STACKTRACE = " + sqlEx.StackTrace.ToString());
                        throw sqlEx;
                    }

				}

            	string cowDeleteStmtFmt = "DELETE FROM cattle WHERE ean = '%0'";
				for(i = 0;i < m_delCows.Count;i++)
				{
					cowd = (Cow)m_delCows[i];
                    string cowDeleteStmt = SQLBuilder.SQLSprintf(cowDeleteStmtFmt, cowd.EAN);
                    try
                    {                     
                        SQLDB.ExecuteNonQuery(cowDeleteStmt);
                    }
                    catch (SystemException sqlEx)
                    {
                        LOG.DoLog("STMT = " + cowDeleteStmt + ", MSG = " + sqlEx.Message + ", STACKTRACE = " + sqlEx.StackTrace.ToString());
                        throw sqlEx;
                    }

				}
			
			return bRet;
		}
        protected override void Init()
        {
            this.Text = GetCaption();
            this.Closed += new EventHandler(OnClosedNewDocDlg);
            UpdateCowCount();
            cowListBox.SetFormatter(new InDocCowItemStringFormetter());
        }
		

        protected override void AlreadyOnList(int pos)
        {
            cowListBox.SelectItem(pos);
            Cow cow = (Cow)cowListBox.GetItem(pos);
            if (m_activeGrpSettingEnabled)
            {
                cow.ingrp = m_curActiveGrp;
                if (!IsInEdited(cow))
                    m_editCows.Add(cow);
            }
        }

        protected override void SetGroup(Cow cowd, int group)
        {
            cowd.ingrp = group;
            if (!IsInEdited(cowd))
                m_editCows.Add(cowd);
        }
		
	}
}
