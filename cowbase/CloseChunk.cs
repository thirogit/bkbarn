using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace cowbase
{
    public partial class CloseChunk :  CenterForm
    {
        ICollection<Cow> m_chunkCows;
        NewChunk.DistributeStrategy m_distributeStrategy;
        Nullable<double> m_totalWeight;
        Nullable<double> m_totalPrice;
        Nullable<double> m_pricePerKg;
        Stock            m_stock4All;

        private static readonly string NULL_LABEL_TEXT = "BRAK";


        public CloseChunk(ICollection<Cow> chunkCows,NewChunk.DistributeStrategy distributeStrategy)
        {
            InitializeComponent();
            m_chunkCows = chunkCows;
            m_distributeStrategy = distributeStrategy;
        }

        private void SetGrayPricePerKgLabel(double pricePerKg)
        {
            SetLabelWithColor(perKgPriceLabel, Utils.FormatMoney(pricePerKg), Color.Gray);
        }
        private void SetGrayTotalPriceLabel(double totalPrice)
        {
            SetLabelWithColor(totalPriceLabel, Utils.FormatMoney(totalPrice), Color.Gray);
        }
        private void SetBlackPricePerKgLabel(double pricePerKg)
        {
            SetLabelWithColor(perKgPriceLabel, Utils.FormatMoney(pricePerKg), Color.Black);
        }
        private void SetBlackTotalPriceLabel(double totalPrice)
        {
            SetLabelWithColor(totalPriceLabel, Utils.FormatMoney(totalPrice), Color.Black);
        }

        private void SetLabelWithColor(Label label, String value, Color textColor)
        {
            label.Text = value;
            label.ForeColor = textColor;
        }

        private void SetValueLabels()
        {
            if (m_totalPrice.HasValue)
            {
                SetBlackTotalPriceLabel(m_totalPrice.Value);
                if (m_totalWeight.HasValue)
                {
                    SetGrayPricePerKgLabel(m_totalPrice.Value / m_totalWeight.Value);
                }
                else
                {
                    SetLabelWithColor(perKgPriceLabel, NULL_LABEL_TEXT, Color.Black);     
                }
            }
            else
            {
                if (m_pricePerKg.HasValue)
                {
                    SetBlackPricePerKgLabel(m_pricePerKg.Value);
                    if (m_totalWeight.HasValue)
                    {
                        SetGrayTotalPriceLabel(m_pricePerKg.Value * m_totalWeight.Value);
                    }
                    else
                    {
                        SetLabelWithColor(totalPriceLabel, NULL_LABEL_TEXT, Color.Black);    
                    }
                }
                else
                {
                    SetLabelWithColor(totalPriceLabel,NULL_LABEL_TEXT,Color.Black);
                    SetLabelWithColor(perKgPriceLabel, NULL_LABEL_TEXT, Color.Black);                   
                }
            }

            if (m_totalWeight.HasValue)
                totalWeightLabel.Text = Utils.FormatFloat(m_totalWeight.Value,3);
            else
                totalWeightLabel.Text = NULL_LABEL_TEXT;

            if (m_stock4All != null)
                stockForAllLabel.Text = m_stock4All.stockCode;
            else
                stockForAllLabel.Text = NULL_LABEL_TEXT;

        }
              

        private void setChunkTotalPriceBtn_Click(object sender, EventArgs e)
        {
            NumKeypad numkeypad = new NumKeypad("Podaj cene transzy");
            numkeypad.ComaEnable = true;
            numkeypad.AllowNull = true;
            numkeypad.DoubleValue = m_totalPrice;

            if (numkeypad.ShowDialog() == DialogResult.OK)
            {
                m_totalPrice = numkeypad.DoubleValue;
                m_pricePerKg = null;
                SetValueLabels();
            }

        }

        private void setChunkTotalStockBtn_Click(object sender, EventArgs e)
        {
            int selectedStockId = m_stock4All != null ? m_stock4All.stockId : 0;
            ChooseStock stockList = new ChooseStock(selectedStockId, "Podaj rase dla transzy", true);

            if (stockList.ShowDialog() == DialogResult.OK)
            {
              m_stock4All = ((Stock)stockList.GetSelected());
              SetValueLabels();
            }
           
        }

        private void setChunkTotalWeightBtn_Click(object sender, EventArgs e)
        {
            NumKeypad numkeypad = new NumKeypad("Podaj wage transzy");
            numkeypad.ComaEnable = true;
            numkeypad.AllowNull = true;
           

            if (numkeypad.ShowDialog() == DialogResult.OK)
            {
                m_totalWeight = numkeypad.DoubleValue;
                
                setChunkPricePerKgBtn.Enabled = m_totalWeight.HasValue;
               
                SetValueLabels();
              
            }
        }

       

        private void okBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Distribute();
                this.DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                BigOKMessageBox.ShowMessage(ex.Message);
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void CloseChunk_Load(object sender, EventArgs e)
        {
            SetValueLabels();
            setChunkPricePerKgBtn.Enabled = false;
        }

        private void Distribute()
        {
            m_distributeStrategy.Distribute(m_chunkCows, m_totalWeight, GetTotalPrice(), m_stock4All);
        }

        private Nullable<double> GetTotalPrice()
        {
            if (m_totalPrice.HasValue)
                return m_totalPrice;
            else if (m_pricePerKg.HasValue && m_totalWeight.HasValue)
                return m_pricePerKg.Value * m_totalWeight.Value;
            return null;
            
        }

       

        private void setChunkPricePerKgBtn_Click(object sender, EventArgs e)
        {
            NumKeypad numkeypad = new NumKeypad("Podaj cene za KG");
            numkeypad.ComaEnable = true;
            numkeypad.AllowNull = true;

            if (numkeypad.ShowDialog() == DialogResult.OK)
            {
                m_pricePerKg = numkeypad.DoubleValue;
                m_totalPrice = null;
                SetValueLabels();             
            }
        }
    }
}