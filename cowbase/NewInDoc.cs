using System;
using System.Windows.Forms;

namespace cowbase
{
	public class NewInDoc : NewDocForm
	{
		public NewInDoc()
		{
		}

		protected override string GetDefaultReasonCode()
		{
			return "K";
		}
		
		protected override int GetInOut()
		{
			return 1;	
		}

		protected override string GetCaption()
		{
			return "Nowy dokument PZ";
		}

        protected virtual void AlreadyOnList(int pos)
        {
            cowListBox.SelectItem(pos);
            if (m_activeGrpSettingEnabled)
            {
                ((Cow)cowListBox.GetItem(pos)).ingrp = m_curActiveGrp;
            }
        }

        protected override void Init()
        {
            base.Init();
            cowListBox.SetFormatter(new InDocCowItemStringFormetter());
        }
		
		protected override bool ContinueWithEAN(string EANStr)
		{
					
			if(!Utils.IsEANValid(EANStr))
				if(!AskYesNo.Ask("Bledny numer kolczyka.\n Kontynuowac?"))
					return false;
			
		    int pos = IsOnList(EANStr,true);
            if (pos >= 0)
            {
                AlreadyOnList(pos);
                return false;
            }
			
			if(IsInDB(EANStr))
			{
				BigOKMessageBox.ShowMessage("Duplikat","Wprowadzony numer juz\r\nistnieje w bazie danych");
				return false;
			}

			ChooseStock stockList = new ChooseStock(0,"Wybierz rase",false);
			if(stockList.ShowDialog() == DialogResult.OK)
			{
				NumKeypad weightPad = new NumKeypad("Podaj wage");
				weightPad.ComaEnable = true;
                weightPad.FloatPrecision = 3;
                weightPad.AllowNull = false;
				if(weightPad.ShowDialog() == DialogResult.OK)
				{
                    CowSex sex = CowSex.NONE;
                    if (Settings.Instance.usePredefSex)
                    {
                        sex = ((Stock)stockList.GetSelected()).predefSex;
                    }

                    do
                    {
                        if (sex.Equals(CowSex.NONE))
                        {
                            ChooseSex sexList = new ChooseSex(CowSex.NONE, "Wybierz plec");
                            if (sexList.ShowDialog() != DialogResult.OK)
                                break;
                            else
                                sex = (CowSex)sexList.GetSelected();
                        }


                        Cow cowd = new Cow();
                        cowd.EAN = (string)EANStr.Clone();
                        cowd.weight = weightPad.DoubleValue.Value;
                        cowd.sex = sex;
                        cowd.stock = (Stock)stockList.GetSelected();
                        cowd.action = Action.FRESH;
                        cowd.ingrp = m_curActiveGrp;

                        AddToList(cowd);
                        return true;

                    } while (false);
				}
			}
			return false;		
		}


		protected override bool  CommitDoc()
		{
			string docInsQuery = "INSERT INTO indocs(docno,hent,docdate,plateno,loaddate,reason,action,hasmorecows) VALUES(%0,%1,GETDATE(),%2q,GETDATE(),%3,'N',%4)";
            string minDocQ = "SELECT MIN(docno) FROM INDOCS";
            bool bRet = true;

            if (cowListBox.GetItemCount() == 0)
            {
                BigOKMessageBox.ShowMessage("Brak rekordow", "Pusta lista zwierzat.");
                return false;
            }

            try
            {
                int mindocno = 0;
                object minNoScalar = SQLDB.ExecuteScalar(minDocQ);
                if (minNoScalar is System.DBNull)
                    mindocno = -1;
                else
                {
                    if ((int)minNoScalar > 0)
                        mindocno = -1;
                    else
                        mindocno = ((int)minNoScalar) - 1;
                }

                string docInsertStmt = SQLBuilder.SQLSprintf(docInsQuery, mindocno,
                    m_CurHent,
                    m_plateNoBox.Text,
                    m_CurReason,
                    cowListBox.GetItemCount());

                SQLDB.ExecuteNonQuery(docInsertStmt);


                string cowInsQuery = "INSERT INTO CATTLE(ean,sex,stock,weight,docin,myprice,action," + 
                                     "termbuystock,termbuyweight,termbuyprice,ingrp,termsellstock,termsellweight,termsellprice)" +
                                     " VALUES(%0q,%1,%2,%3,%4,%5,'N',%6,%7,%8,%9,%10,%11,%12)";

                

                Cow cowd = null;
                for (int i = 0; i < cowListBox.GetItemCount(); i++)
                {
                    cowd = (Cow)cowListBox.GetItem(i);
                    string cowInsertStmt = SQLBuilder.SQLSprintf(cowInsQuery, 
                        cowd.EAN,
                        cowd.sex.ToInt(),
                        cowd.stock.stockId,
                        cowd.weight,
                        mindocno,
                        Utils.FormatMoneySQL(cowd.myprice),
                        Utils.FormatIntegerSQL(cowd.termbuystock),
                        Utils.FormatWeightSQL(cowd.termbuyweight),
                        Utils.FormatMoneySQL(cowd.termbuyprice),
                        cowd.ingrp,
                        Utils.FormatIntegerSQL(cowd.termsellstock),
                        Utils.FormatWeightSQL(cowd.termsellweight),
                        Utils.FormatMoneySQL(cowd.termsellprice)
                        );
                    SQLDB.ExecuteNonQuery(cowInsertStmt);
                }
            }
            catch (SystemException sqlEx)
            {
                bRet = false;
                BigOKMessageBox.ShowMessage("Blad", sqlEx.Message);
                LOG.DoLog("NewInDoc.CommitDoc(): " + sqlEx.Message);
            }

			return bRet;
		}

		protected override bool DeleteCow(Cow cowd)
		{
			return true;
		}
		protected override bool EditCow(Cow cowd)
		{
			EditCow editCow = new EditCow(cowd);
			return editCow.ShowDialog() == DialogResult.OK;			
		}	

		
        protected override void SetGroup(Cow cowd, int group)
        {
            cowd.ingrp = group;
        }
		
	}
}
