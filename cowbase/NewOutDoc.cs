using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace cowbase
{
	public class NewOutDoc : NewDocForm
	{
		protected List<Cow> m_chngdCows;
		
		
        public NewOutDoc()
		{
			m_chngdCows  = new List<Cow>();				
		}
		
		protected override string GetDefaultReasonCode()
		{
			return "S";
		}
		
		protected override int GetInOut()
		{
			return -1;	
		}

		protected override string GetCaption()
		{
			return "Nowy dokument WZ";
		}

        protected override void Init()
        {
            base.Init();
            cowListBox.SetFormatter(new OutDocCowItemStringFormatter());
        }

		protected override bool ContinueWithEAN(string EANStr)
		{
            Cow cowd;
            int pos = IsOnList(EANStr, true);
            if (pos >= 0)
            {
                if (m_activeGrpSettingEnabled)
                {
                    cowd = (Cow)cowListBox.GetItem(pos);
                    cowd.outgrp = m_curActiveGrp;

                    cowListBox.SelectItem(pos);

                    if (!IsInChanged(cowd))
                        m_chngdCows.Add(cowd);
                }
                return false;
            }

            if (!IsInDB(EANStr))
            {
                BigOKMessageBox.ShowMessage("Brak kolczyka", "Wprowadzony numer nie istnieje w bazie danych");
                return false;
            }

            cowd = ReadCowFromDB(EANStr, true);
            if (cowd == null)
            {
                BigOKMessageBox.ShowMessage("Zwierze niedostepne", "Wprowadzony numer zwierzecia jest juz przypisany do innej WZ-tki");
                return false;
            }
            cowd.outgrp = m_curActiveGrp;
            AddToList(cowd);

            LOG.DoLog("NewOutDoc.ContinueWithEAN(): " + cowd.ToString());
			
			return true;		
		}

		protected override void AddCowBtnClick(object sender, System.EventArgs e)
		{
            m_lockBCReader = true;

            ThreeBtnsOpt chooseWhatToAdd = new ThreeBtnsOpt("Transza", true,
                                                            "Jedno zwierze", true,
                                                            "", false);

            if (chooseWhatToAdd.ShowDialog() == DialogResult.OK)
            {
               
                switch (chooseWhatToAdd.GetSelectedOpt())
                {
                    case 1: //chunk

                        List<Cow> outDocCows = new List<Cow>();

                        for (int i = 0; i < cowListBox.GetItemCount(); i++)
                            outDocCows.Add((Cow)cowListBox.GetItem(i));

                        NewChunk newOutDocChunkDlg = new NewChunk(new NewOutDocChunkCowValidator(outDocCows),new TermSellValuesDistributeStrategy());
                        if (newOutDocChunkDlg.ShowDialog() == DialogResult.OK)
                        {
                            ICollection<Cow> newChunk = newOutDocChunkDlg.GetChunk();
                            IEnumerator<Cow> chunkEnumerator = newChunk.GetEnumerator();
                            while (chunkEnumerator.MoveNext())
                            {
                                Cow cow = chunkEnumerator.Current;
                                cow.outgrp = m_curActiveGrp;

                                if (!IsInChanged(cow))
                                    m_chngdCows.Add(cow);

                                AddToList(cow);
                            }
                        }                       


                        break;
                    case 2: //one cow
                        FindCowByEAN findEAN = new FindCowByEAN(true);

                        if (findEAN.ShowDialog() == DialogResult.OK)
                        {
                            ContinueWithEAN(findEAN.EANFound);
                        }
                        break;
                    case 3: //                        
                        break;
                }               
            }			
			UpdateCowCount();
            m_lockBCReader = false;
		}

		protected override bool  CommitDoc()
		{
			string docInsQuery = "INSERT INTO outdocs(docno,hent,docdate,plateno,loaddate,reason,action) VALUES(%0,%1,GETDATE(),%2q,GETDATE(),%3,'N')";
            string minDocQ = "SELECT MIN(docno) FROM outdocs";
            bool bRet = true;
			try
			{				
				Int64 mindocno = 0;
                object minNoScalar = SQLDB.ExecuteScalar(minDocQ);
				if(minNoScalar is System.DBNull)
					mindocno = -1;
				else
				{
                    int iMinDocNoScalar = (int)minNoScalar;
                    if (iMinDocNoScalar > 0) 
						mindocno = -1;
					else
						mindocno = iMinDocNoScalar - 1;
				}				
				
				string docSqlStmt = SQLBuilder.SQLSprintf(docInsQuery,mindocno,
					m_CurHent,
					m_plateNoBox.Text,
					m_CurReason);

                SQLDB.ExecuteNonQuery(docSqlStmt);

				string cowUpdate1 = "UPDATE cattle SET action = '%0',docout = %1,outgrp = %2 WHERE ean = '%3'";
				string cowUpdate2 = "UPDATE cattle SET weight = %0,sex = %1,stock = %2,action = '%3',docout = %4," +
                                    "myprice = %5,outgrp = %6, termbuystock = %7, termbuyweight = %8, termbuyprice = %9," +
                                    "termsellstock = %10, termsellweight = %11, termsellprice = %12 WHERE ean = '%13'";
				

				Cow cowd = null;
                for (int i = 0; i < cowListBox.GetItemCount(); i++)
				{
                    cowd = (Cow)cowListBox.GetItem(i);
                    if (cowd.action != Action.NEW)
                        cowd.action = Action.UPDATE;

                    string cowSqlStmt = String.Empty;

					if(IsInChanged(cowd))
                        cowSqlStmt = SQLBuilder.SQLSprintf(cowUpdate2, cowd.weight,
																			    cowd.sex.ToInt(),
																			    cowd.stock.stockId,
																			    Utils.FormatActionSQL(cowd.action),
																		        mindocno,
                                                                                Utils.FormatMoneySQL(cowd.myprice),
                                                                                cowd.outgrp,
                                                                                Utils.FormatIntegerSQL(cowd.termbuystock),
                                                                                Utils.FormatWeightSQL(cowd.termbuyweight),
                                                                                Utils.FormatMoneySQL(cowd.termbuyprice),
                                                                                Utils.FormatIntegerSQL(cowd.termsellstock),
                                                                                Utils.FormatWeightSQL(cowd.termsellweight),
                                                                                Utils.FormatMoneySQL(cowd.termsellprice),                                                                                
                                                                                cowd.EAN);
					else
                        cowSqlStmt = SQLBuilder.SQLSprintf(cowUpdate1, 
                            Utils.FormatActionSQL(cowd.action),
                            mindocno,
                            cowd.outgrp,
                            cowd.EAN);

                    SQLDB.ExecuteNonQuery(cowSqlStmt);
				}			

			}
			catch(SystemException sqlEx)
			{
				bRet = false;
				BigOKMessageBox.ShowMessage("BLAD",sqlEx.Message);
                LOG.DoLog("NewOutDoc.CommitDoc(): " + sqlEx.Message + " at " + sqlEx.StackTrace);
            }

			return bRet;
			
		}
		protected override bool DeleteCow(Cow cowd)
		{
			return true;
		}

		protected bool IsInChanged(Cow cowd)
		{
			for(int i = 0;i < m_chngdCows.Count;i ++)
			{
				if(cowd.EAN.CompareTo(((Cow)m_chngdCows[i]).EAN) == 0)
					return true;
			}
			return false;
		}
		protected override bool EditCow(Cow cowd)
		{
            LOG.DoLog("NewOutDoc() : Editing " + cowd.ToString());
			EditCow editCow = new EditCow(cowd);
			
			if(editCow.ShowDialog() == DialogResult.OK)
			{
                LOG.DoLog("NewOutDoc() : AfterEdit " + cowd.ToString());
				if(!IsInChanged(cowd))
					m_chngdCows.Add(cowd);

			
				return true;
			}
			
			return false;
		}

			

        protected override void SetGroup(Cow cowd, int group)
        {
            cowd.outgrp = group;
            if (!IsInChanged(cowd))
                m_chngdCows.Add(cowd);
        }		
	}
}
