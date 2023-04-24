using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace cowbase
{
    public partial class NewChunk : CenterForm
    {

        public interface DistributeStrategy
        {
            void Distribute(ICollection<Cow> cows, Nullable<double> totalweight, Nullable<double> totalprice, Stock stock4all);
        };



        public class CowValidateResult
        {
            private bool m_bResult;
            private string m_sValidationError;
            private Cow m_validatedCow;

           

            public CowValidateResult(bool bResult, string sVaidationMessage, Cow cow)
            {
                m_bResult = bResult;
                m_sValidationError = sVaidationMessage;
                m_validatedCow = cow;
            }


            public bool Result
            {
                get { return m_bResult; }
                set { m_bResult = value; }
            }

            public string ValidationError
            {
                get { return m_sValidationError; }
                set { m_sValidationError = value; }
            }

            public Cow ValidatedCow
            {
                get { return m_validatedCow; }
                set { m_validatedCow = value; }
            }

        };


        public interface CowValidator
        {
            CowValidateResult Validate(string sEAN);            
        };


        private class NewChunkCowItemStringFormetter : CowItemStringFormatter
        {
            public override string GetCowItemString(Cow cow)
            {
                return cow.EAN + "    " + cow.sex.ToString() +
                    "    " + cow.stock.stockCode + "\n" + cow.weight.ToString() + "kg";
            }
        }

        private DistributeStrategy m_distributeStrategy;
        private CowValidator m_CowValidator;
        private ICollection<Cow> m_chunk;  
        protected EaringBCReader m_bcReader = EaringBCReader.GetInstance();
        private bool m_lockBCReader = false;


        public NewChunk(CowValidator CowValidator,DistributeStrategy distributeStrategy)
        {
            InitializeComponent();
            m_CowValidator = CowValidator;
            m_distributeStrategy = distributeStrategy;     
            

            chunkCowList.SetFormatter(new NewChunkCowItemStringFormetter());
            errorMsgLbl.Text = "Oczekiwanie";
            this.Closed += new EventHandler(OnClosed);
            this.Load += new EventHandler(OnLoad);
        }

        private void OnLoad(object sender, EventArgs e)
        {
            m_bcReader.OnRead += new EventHandler(OnEaringRead);
        }

        private void OnClosed(object sender, EventArgs e)
        {
            m_bcReader.OnRead -= OnEaringRead;
        }

        private void OnEaringRead(object sender, System.EventArgs e)
        {
            string sEAN = (string)sender;
            if (!m_lockBCReader)
            {
                if (IsInChunk(sEAN))
                {
                    ShowError("Juz obecny w transzy");
                }
                else
                {                   
                    CowValidateResult result = m_CowValidator.Validate(sEAN);
                    if (!result.Result)
                    {
                        ShowError(result.ValidationError);
                    }
                    else
                    {
                        chunkCowList.AddItem(result.ValidatedCow);
                        ShowGood();
                    }
                   
                }

            }
        }
          

        private void ShowError(string sError)
        {
            SetErrorLabel(sError, Color.Red);
        }

        private void ShowGood()
        {
            SetErrorLabel("Dobry", Color.Green);
        }

        private void SetErrorLabel(string sText,Color backColor)
        {
            errorMsgLbl.BackColor = backColor;
            errorMsgLbl.Text = sText;
        }

        private void closeChunkBtn_Click(object sender, EventArgs e)
        {
            m_lockBCReader = true;
            ICollection<Cow> chunkCows = new LinkedList<Cow>();
            for (int i = 0; i < chunkCowList.GetItemCount(); i++)
            {
                chunkCows.Add((Cow)chunkCowList.GetItem(i));
            }

            CloseChunk closeChunkDlg = new CloseChunk(chunkCows, m_distributeStrategy);
            if (closeChunkDlg.ShowDialog() == DialogResult.OK)
            {
                m_chunk = chunkCows;
                this.DialogResult = DialogResult.OK;
                Close();
            }
            m_lockBCReader = false;
        }

        public ICollection<Cow> GetChunk()
        {
            return m_chunk;
        }

        private bool IsInChunk(string sEAN)
        {
            for (int i = 0; i < chunkCowList.GetItemCount(); i++)
            {
                Cow cow = (Cow)chunkCowList.GetItem(i);
                if (sEAN.CompareTo(cow.EAN) == 0)
                    return true;
            }
            return false;            
        }

        private void cancelChunkBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}