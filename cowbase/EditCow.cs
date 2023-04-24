using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace cowbase
{
	/// <summary>
	/// Summary description for EditCow.
	/// </summary>
	public class EditCow : CenterForm  //System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private Cow m_cow;
		
		private System.Windows.Forms.Button WeightBtn;
		private System.Windows.Forms.Label m_SexLabel;
		private System.Windows.Forms.Label m_WeightLabel;
		private System.Windows.Forms.Label m_StockLabel;
		private System.Windows.Forms.Button StockBtn;
		private System.Windows.Forms.Button SexBtn;
		private System.Windows.Forms.Button m_CalculateBtn;
        private Button PriceBtn;
        private Label m_PriceLabel;

		private CowSex m_cowSex;
        private Nullable<double> m_cowWeight;
        private Stock m_cowStock;
        private int m_editSel;
        private Nullable<double> m_cowPrice;
        private string NULLValue = "BRAK";
	
		public EditCow(Cow cowd)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			m_cow = cowd;
			
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.m_SexLabel = new System.Windows.Forms.Label();
            this.m_WeightLabel = new System.Windows.Forms.Label();
            this.m_StockLabel = new System.Windows.Forms.Label();
            this.WeightBtn = new System.Windows.Forms.Button();
            this.StockBtn = new System.Windows.Forms.Button();
            this.SexBtn = new System.Windows.Forms.Button();
            this.OKBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.m_CalculateBtn = new System.Windows.Forms.Button();
            this.PriceBtn = new System.Windows.Forms.Button();
            this.m_PriceLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // m_SexLabel
            // 
            this.m_SexLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.m_SexLabel.Location = new System.Drawing.Point(72, 80);
            this.m_SexLabel.Name = "m_SexLabel";
            this.m_SexLabel.Size = new System.Drawing.Size(96, 32);
            this.m_SexLabel.Text = "__SEX__";
            // 
            // m_WeightLabel
            // 
            this.m_WeightLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.m_WeightLabel.Location = new System.Drawing.Point(80, 0);
            this.m_WeightLabel.Name = "m_WeightLabel";
            this.m_WeightLabel.Size = new System.Drawing.Size(128, 32);
            this.m_WeightLabel.Text = "_KG_";
            // 
            // m_StockLabel
            // 
            this.m_StockLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.m_StockLabel.Location = new System.Drawing.Point(72, 40);
            this.m_StockLabel.Name = "m_StockLabel";
            this.m_StockLabel.Size = new System.Drawing.Size(136, 32);
            this.m_StockLabel.Text = "__STOCK__";
            // 
            // WeightBtn
            // 
            this.WeightBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.WeightBtn.Location = new System.Drawing.Point(0, 0);
            this.WeightBtn.Name = "WeightBtn";
            this.WeightBtn.Size = new System.Drawing.Size(72, 32);
            this.WeightBtn.TabIndex = 5;
            this.WeightBtn.Text = "Waga";
            this.WeightBtn.Click += new System.EventHandler(this.WeightBtn_Click);
            // 
            // StockBtn
            // 
            this.StockBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.StockBtn.Location = new System.Drawing.Point(0, 40);
            this.StockBtn.Name = "StockBtn";
            this.StockBtn.Size = new System.Drawing.Size(72, 32);
            this.StockBtn.TabIndex = 4;
            this.StockBtn.Text = "Rasa";
            this.StockBtn.Click += new System.EventHandler(this.StockBtn_Click);
            // 
            // SexBtn
            // 
            this.SexBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.SexBtn.Location = new System.Drawing.Point(0, 80);
            this.SexBtn.Name = "SexBtn";
            this.SexBtn.Size = new System.Drawing.Size(72, 32);
            this.SexBtn.TabIndex = 3;
            this.SexBtn.Text = "Plec";
            this.SexBtn.Click += new System.EventHandler(this.SexBtn_Click);
            // 
            // OKBtn
            // 
            this.OKBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.OKBtn.Location = new System.Drawing.Point(2, 195);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(136, 48);
            this.OKBtn.TabIndex = 2;
            this.OKBtn.Text = "OK";
            this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.CancelBtn.Location = new System.Drawing.Point(146, 195);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(80, 48);
            this.CancelBtn.TabIndex = 1;
            this.CancelBtn.Text = "Anuluj";
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // m_CalculateBtn
            // 
            this.m_CalculateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.m_CalculateBtn.Location = new System.Drawing.Point(0, 156);
            this.m_CalculateBtn.Name = "m_CalculateBtn";
            this.m_CalculateBtn.Size = new System.Drawing.Size(72, 32);
            this.m_CalculateBtn.TabIndex = 0;
            this.m_CalculateBtn.Text = "Przelicz";
            this.m_CalculateBtn.Click += new System.EventHandler(this.m_CalculateBtn_Click);
            // 
            // PriceBtn
            // 
            this.PriceBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.PriceBtn.Location = new System.Drawing.Point(0, 118);
            this.PriceBtn.Name = "PriceBtn";
            this.PriceBtn.Size = new System.Drawing.Size(72, 32);
            this.PriceBtn.TabIndex = 9;
            this.PriceBtn.Text = "Cena";
            this.PriceBtn.Click += new System.EventHandler(this.PriceBtn_Click);
            // 
            // m_PriceLabel
            // 
            this.m_PriceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.m_PriceLabel.Location = new System.Drawing.Point(78, 118);
            this.m_PriceLabel.Name = "m_PriceLabel";
            this.m_PriceLabel.Size = new System.Drawing.Size(130, 32);
            this.m_PriceLabel.Text = "__PRICE__";
            // 
            // EditCow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(226, 243);
            this.Controls.Add(this.m_PriceLabel);
            this.Controls.Add(this.PriceBtn);
            this.Controls.Add(this.m_CalculateBtn);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.OKBtn);
            this.Controls.Add(this.SexBtn);
            this.Controls.Add(this.StockBtn);
            this.Controls.Add(this.WeightBtn);
            this.Controls.Add(this.m_StockLabel);
            this.Controls.Add(this.m_WeightLabel);
            this.Controls.Add(this.m_SexLabel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditCow";
            this.Text = "Edycja krowy";
            this.Load += new System.EventHandler(this.EditCow_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void EditCow_Load(object sender, System.EventArgs e)
		{
              ThreeBtnsOpt editChngSel =
              new ThreeBtnsOpt("Kupno", true,
                               "Sprzeda¿", true,
                               "Moja", true);

           
            if (editChngSel.ShowDialog() == DialogResult.OK)
            {
                 m_editSel = editChngSel.GetSelectedOpt();
                 m_cowSex = m_cow.sex;
                 m_cowPrice = null;
                 switch (m_editSel)
                {
                    case 1: //buy
                         m_cowWeight = m_cow.termbuyweight;

                         if (m_cow.termbuystock.HasValue)
                             m_cowStock = SQLDB.GetStock(m_cow.termbuystock.Value);
                         
                         m_cowPrice = m_cow.termbuyprice;
                        break;
                    case 2: //sell
                        m_cowWeight = m_cow.termsellweight;
                         if(m_cow.termsellstock.HasValue)
                             m_cowStock = SQLDB.GetStock(m_cow.termsellstock.Value);
                        m_cowPrice = m_cow.termsellprice;
                        break;
                    case 3: //my
                        m_cowWeight = m_cow.weight;
                        m_cowStock = m_cow.stock;
                        m_cowPrice = m_cow.myprice;                       
                        break;
                }           

                m_WeightLabel.Text = FormatWeight(m_cowWeight);
                
                m_SexLabel.Text = m_cowSex.ToString();

                m_StockLabel.Text = FormatStock(m_cowStock);

                m_PriceLabel.Text = FormatPrice(m_cowPrice);              
            }
            else
            {
                Close();
                return;
            }
            
           
		}

        private string FormatStock(Stock stock)
        {
            if (stock != null)
                return stock.stockCode;

            return NULLValue;
        }

        private string FormatPrice(Nullable<double> dPrice)
        {
            if (dPrice.HasValue)
                return Utils.FormatMoney(dPrice.Value);

            return NULLValue;
        }

        private string FormatWeight(Nullable<double> dWeight)
        {
            if (dWeight.HasValue)
                return Utils.FormatFloat(dWeight.Value,3);

            return NULLValue;
        }



		private void WeightBtn_Click(object sender, System.EventArgs e)
		{
			NumKeypad numkeypad = new NumKeypad("Zmiana wagi");
			numkeypad.ComaEnable = true;
			numkeypad.DoubleValue = m_cowWeight;
            numkeypad.AllowNull = false;
            numkeypad.FloatPrecision = 3;

			if(numkeypad.ShowDialog() == DialogResult.OK)
			{
				m_cowWeight = numkeypad.IntValue;
				m_WeightLabel.Text = FormatWeight(m_cowWeight);
			}
		}

		private void StockBtn_Click(object sender, System.EventArgs e)
		{
            int stockId = 0;
            if (m_cowStock != null)
                stockId = m_cowStock.stockId;

            ChooseStock stockList = new ChooseStock(stockId, "Zmiana rasy",false);
			
			if(stockList.ShowDialog() == DialogResult.OK)
			{
				Stock stock = (Stock)stockList.GetSelected();
                if (stock.stockId == 0)
                    m_cowStock = null;
                else
                    m_cowStock = stock;

				m_StockLabel.Text = FormatStock(m_cowStock);						
			}
		}

		private void SexBtn_Click(object sender, System.EventArgs e)
		{
			ChooseSex sexList = new ChooseSex(m_cowSex,"Zmiana p³ci");
			if(sexList.ShowDialog() == DialogResult.OK)
			{
				m_cowSex = (CowSex)sexList.GetSelected();
                m_SexLabel.Text = m_cowSex.ToString();
			}
		}

		private void OKBtn_Click(object sender, System.EventArgs e)
		{
            switch (m_editSel)
            {
                case 1: //buy
                    m_cow.termbuyweight = m_cowWeight;
                    if (m_cowStock != null)
                    {
                        m_cow.termbuystock = m_cowStock.stockId;
                    }
                    else
                    {
                        m_cow.termbuystock = null;
                    }
                    m_cow.termbuyprice = m_cowPrice;
                    break;
                case 2: //sell
                    m_cow.termsellweight = m_cowWeight;
                    if (m_cowStock != null)
                    {
                        m_cow.termsellstock = m_cowStock.stockId;
                    }
                    else
                    {
                       m_cow.termsellstock = null;
                    }                    
                    m_cow.termsellprice = m_cowPrice;
                    break;
                case 3: //my
                    if((m_cow.weight != m_cowWeight || !m_cow.stock.Equals(m_cowStock)) && m_cow.hasBuyInv)
                    {
                        BigOKMessageBox.ShowMessage("Wystawiona faktura",
                            "Na to zwierze wystawiona jest juz faktura.\n" +
                            "Nie mozesz zmienic mojej rasy lub mojej wagi");
                    }
                    else
                    {
                        if (!m_cowWeight.HasValue)
                        {
                            BigOKMessageBox.ShowMessage("Brakuje wagi","Wartosc podstawowej wagi musi byc obecna.");
                            break;
                        }

                        if (m_cowStock == null)
                        {
                            BigOKMessageBox.ShowMessage("Brakuje rasy", "Wartosc podstawowej rasy musi byc obecna.");
                            break;
                        }
                        m_cow.weight = m_cowWeight.Value;
                        m_cow.stock = m_cowStock;
                    }                   

                    m_cow.myprice = m_cowPrice;
                    break;
            }
            if (!m_cow.sex.Equals(m_cowSex) && m_cow.hasBuyInv)
            {
                BigOKMessageBox.ShowMessage("Wystawiona faktura",
                           "Na to zwierze wystawiona jest juz faktura.\n" +
                           "Nie mozesz zmienic plci");
            }
            else
                m_cow.sex = m_cowSex;

			DialogResult = DialogResult.OK;
			Close();
		}

		private void CancelBtn_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void m_CalculateBtn_Click(object sender, System.EventArgs e)
		{
			MyPriceCalculator calculator = new MyPriceCalculator("Oblicz cene");

            if (m_cowPrice.HasValue)
                calculator.Price = m_cowPrice.Value;
            else 
                calculator.Price = 0;

            if (m_cowWeight.HasValue)
                calculator.Weight = m_cowWeight.Value;
            else
                calculator.Weight = 0;

			if(calculator.ShowDialog() == DialogResult.OK)
			{
                m_cowPrice = calculator.Price;
                m_cowWeight = calculator.Weight;
                m_WeightLabel.Text = FormatWeight(m_cowWeight);
                m_PriceLabel.Text = FormatPrice(m_cowPrice);
			}
			calculator = null;
		}

        private void PriceBtn_Click(object sender, EventArgs e)
        {

            NumKeypad numkeypad = new NumKeypad("Zmiana ceny");
            numkeypad.ComaEnable = true;
            numkeypad.DoubleValue = m_cowPrice;
            numkeypad.AllowNull = true;

            if (numkeypad.ShowDialog() == DialogResult.OK)
            {
                m_cowPrice = numkeypad.DoubleValue;
                m_PriceLabel.Text = FormatPrice(m_cowPrice);
            }
        }
	}
}
