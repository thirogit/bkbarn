using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data ;
using System.Data.Common;

namespace cowbase
{
	public class UpdateCattle : CenterForm //System.Windows.Forms.Form 
	{
        private System.Windows.Forms.Label birthDateLbl;
		private System.Windows.Forms.TextBox eanTextBox;
		private System.Windows.Forms.Label sexLbl;
		private System.Windows.Forms.Label stockLbl;
        private System.Windows.Forms.Label weightLbl;
        private System.Windows.Forms.Label myPriceLbl;
        private System.Windows.Forms.Label birthDateVal;
		private System.Windows.Forms.Label weightVal;
		private System.Windows.Forms.Label sexVal;
        private System.Windows.Forms.Label mypriceVal;
		private System.Windows.Forms.Button m_changeWeightBtn;
		private System.Windows.Forms.Label stockVal;
		private System.Windows.Forms.Button m_OKbtn;
		private EaringBCReader m_bcReader;
		private System.Windows.Forms.Label delivDateLbl;
		private System.Windows.Forms.Label delivDateVal;
		private string NULLValue = "BRAK";
		private double m_curCowWeight;
		private int m_curCowStock;
		private CowSex m_curCowSex;
		private System.Windows.Forms.Button m_chngMyPriceBtn;
		private System.Windows.Forms.Button m_chngStock;
		private System.Windows.Forms.Button m_chngSex;
		private System.Windows.Forms.Button m_KeyinEanBtn;
		private Nullable<double> m_curMyPrice;
        private EventHandler MyReadEventHandler;
        private System.Windows.Forms.Label deliverVal;
		private System.Windows.Forms.Label deliverLbl;
		private char m_curCowAction;
		private System.Windows.Forms.Button m_CalculateMyPrice;
		private Color m_OrginalBackColor;
        private Button DetailsBtn;
        private Label termbuyheader;
        private Label termbuypriceVal;
        private Label termbuystockVal;
        private Label termbuyweightVal;
        private Label termpricerow;
        private Label termstockrow;
        private Label termweightrow;
        private Label termsellpriceVal;
        private Label termsellstockVal;
        private Label termsellweightVal;
        private Label termvaluesheader;
        private Label termsellheader;
		private bool m_lockBCReader;
        private bool m_hasBuyInv;
        private DateTime m_birthdate;
        private Nullable<double> m_curTermBuyPrice;
        private Nullable<double> m_curTermSellPrice;
        private Nullable<double> m_curTermBuyWeight;
        private Nullable<double> m_curTermSellWeight;
        private string cowUpdateStmtFmt = "UPDATE cattle SET %3 = %0, action = %1q WHERE ean = %2q";
        private int m_curTermBuyStockId;
        private int m_curTermSellStockId;


		public UpdateCattle()
		{
			InitializeComponent();
			m_bcReader = EaringBCReader.GetInstance();
				
			m_lockBCReader = false;
		
		}
		protected override void Dispose( bool disposing )
		{
			m_bcReader.OnRead -= MyReadEventHandler;
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.eanTextBox = new System.Windows.Forms.TextBox();
            this.birthDateLbl = new System.Windows.Forms.Label();
            this.sexLbl = new System.Windows.Forms.Label();
            this.stockLbl = new System.Windows.Forms.Label();
            this.weightLbl = new System.Windows.Forms.Label();
            this.m_changeWeightBtn = new System.Windows.Forms.Button();
            this.m_chngStock = new System.Windows.Forms.Button();
            this.m_chngSex = new System.Windows.Forms.Button();
            this.myPriceLbl = new System.Windows.Forms.Label();
            this.m_KeyinEanBtn = new System.Windows.Forms.Button();
            this.birthDateVal = new System.Windows.Forms.Label();
            this.weightVal = new System.Windows.Forms.Label();
            this.stockVal = new System.Windows.Forms.Label();
            this.sexVal = new System.Windows.Forms.Label();
            this.mypriceVal = new System.Windows.Forms.Label();
            this.m_OKbtn = new System.Windows.Forms.Button();
            this.delivDateLbl = new System.Windows.Forms.Label();
            this.delivDateVal = new System.Windows.Forms.Label();
            this.m_chngMyPriceBtn = new System.Windows.Forms.Button();
            this.deliverVal = new System.Windows.Forms.Label();
            this.deliverLbl = new System.Windows.Forms.Label();
            this.m_CalculateMyPrice = new System.Windows.Forms.Button();
            this.DetailsBtn = new System.Windows.Forms.Button();
            this.termbuyheader = new System.Windows.Forms.Label();
            this.termbuypriceVal = new System.Windows.Forms.Label();
            this.termbuystockVal = new System.Windows.Forms.Label();
            this.termbuyweightVal = new System.Windows.Forms.Label();
            this.termpricerow = new System.Windows.Forms.Label();
            this.termstockrow = new System.Windows.Forms.Label();
            this.termweightrow = new System.Windows.Forms.Label();
            this.termsellpriceVal = new System.Windows.Forms.Label();
            this.termsellstockVal = new System.Windows.Forms.Label();
            this.termsellweightVal = new System.Windows.Forms.Label();
            this.termvaluesheader = new System.Windows.Forms.Label();
            this.termsellheader = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // eanTextBox
            // 
            this.eanTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.eanTextBox.Location = new System.Drawing.Point(0, 0);
            this.eanTextBox.Name = "eanTextBox";
            this.eanTextBox.ReadOnly = true;
            this.eanTextBox.Size = new System.Drawing.Size(176, 28);
            this.eanTextBox.TabIndex = 31;
            // 
            // birthDateLbl
            // 
            this.birthDateLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular);
            this.birthDateLbl.Location = new System.Drawing.Point(0, 48);
            this.birthDateLbl.Name = "birthDateLbl";
            this.birthDateLbl.Size = new System.Drawing.Size(88, 16);
            this.birthDateLbl.Text = "Data urodzenia:";
            // 
            // sexLbl
            // 
            this.sexLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.sexLbl.Location = new System.Drawing.Point(0, 112);
            this.sexLbl.Name = "sexLbl";
            this.sexLbl.Size = new System.Drawing.Size(40, 16);
            this.sexLbl.Text = "P³eæ:";
            // 
            // stockLbl
            // 
            this.stockLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.stockLbl.Location = new System.Drawing.Point(0, 96);
            this.stockLbl.Name = "stockLbl";
            this.stockLbl.Size = new System.Drawing.Size(48, 16);
            this.stockLbl.Text = "Rasa:";
            // 
            // weightLbl
            // 
            this.weightLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.weightLbl.Location = new System.Drawing.Point(0, 80);
            this.weightLbl.Name = "weightLbl";
            this.weightLbl.Size = new System.Drawing.Size(48, 16);
            this.weightLbl.Text = "Waga:";
            // 
            // m_changeWeightBtn
            // 
            this.m_changeWeightBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.m_changeWeightBtn.Location = new System.Drawing.Point(176, 111);
            this.m_changeWeightBtn.Name = "m_changeWeightBtn";
            this.m_changeWeightBtn.Size = new System.Drawing.Size(62, 32);
            this.m_changeWeightBtn.TabIndex = 25;
            this.m_changeWeightBtn.Text = "Waga";
            this.m_changeWeightBtn.Click += new System.EventHandler(this.ChangeWeightBtn_Click);
            // 
            // m_chngStock
            // 
            this.m_chngStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.m_chngStock.Location = new System.Drawing.Point(176, 175);
            this.m_chngStock.Name = "m_chngStock";
            this.m_chngStock.Size = new System.Drawing.Size(62, 32);
            this.m_chngStock.TabIndex = 24;
            this.m_chngStock.Text = "Rasa";
            this.m_chngStock.Click += new System.EventHandler(this.m_chngStock_Click);
            // 
            // m_chngSex
            // 
            this.m_chngSex.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.m_chngSex.Location = new System.Drawing.Point(176, 207);
            this.m_chngSex.Name = "m_chngSex";
            this.m_chngSex.Size = new System.Drawing.Size(62, 32);
            this.m_chngSex.TabIndex = 23;
            this.m_chngSex.Text = "P³eæ";
            this.m_chngSex.Click += new System.EventHandler(this.m_chngSex_Click);
            // 
            // myPriceLbl
            // 
            this.myPriceLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.myPriceLbl.Location = new System.Drawing.Point(0, 126);
            this.myPriceLbl.Name = "myPriceLbl";
            this.myPriceLbl.Size = new System.Drawing.Size(76, 16);
            this.myPriceLbl.Text = "Moja cena:";
            // 
            // m_KeyinEanBtn
            // 
            this.m_KeyinEanBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.m_KeyinEanBtn.Location = new System.Drawing.Point(176, 0);
            this.m_KeyinEanBtn.Name = "m_KeyinEanBtn";
            this.m_KeyinEanBtn.Size = new System.Drawing.Size(62, 28);
            this.m_KeyinEanBtn.TabIndex = 18;
            this.m_KeyinEanBtn.Text = "Wpisz";
            this.m_KeyinEanBtn.Click += new System.EventHandler(this.m_KeyinEanBtn_Click);
            // 
            // birthDateVal
            // 
            this.birthDateVal.BackColor = System.Drawing.Color.Red;
            this.birthDateVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular);
            this.birthDateVal.ForeColor = System.Drawing.SystemColors.Highlight;
            this.birthDateVal.Location = new System.Drawing.Point(80, 48);
            this.birthDateVal.Name = "birthDateVal";
            this.birthDateVal.Size = new System.Drawing.Size(96, 16);
            this.birthDateVal.Text = "__BIRTHDATE__";
            // 
            // weightVal
            // 
            this.weightVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.weightVal.ForeColor = System.Drawing.SystemColors.Highlight;
            this.weightVal.Location = new System.Drawing.Point(48, 80);
            this.weightVal.Name = "weightVal";
            this.weightVal.Size = new System.Drawing.Size(128, 16);
            this.weightVal.Text = "__WEIGHT__";
            // 
            // stockVal
            // 
            this.stockVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.stockVal.ForeColor = System.Drawing.SystemColors.Highlight;
            this.stockVal.Location = new System.Drawing.Point(40, 96);
            this.stockVal.Name = "stockVal";
            this.stockVal.Size = new System.Drawing.Size(136, 16);
            this.stockVal.Text = "__STOCK__";
            // 
            // sexVal
            // 
            this.sexVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.sexVal.ForeColor = System.Drawing.SystemColors.Highlight;
            this.sexVal.Location = new System.Drawing.Point(40, 112);
            this.sexVal.Name = "sexVal";
            this.sexVal.Size = new System.Drawing.Size(136, 16);
            this.sexVal.Text = "__SEX__";
            // 
            // mypriceVal
            // 
            this.mypriceVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.mypriceVal.ForeColor = System.Drawing.SystemColors.Highlight;
            this.mypriceVal.Location = new System.Drawing.Point(74, 126);
            this.mypriceVal.Name = "mypriceVal";
            this.mypriceVal.Size = new System.Drawing.Size(102, 16);
            this.mypriceVal.Text = "__MYPRICE__";
            // 
            // m_OKbtn
            // 
            this.m_OKbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_OKbtn.Location = new System.Drawing.Point(0, 240);
            this.m_OKbtn.Name = "m_OKbtn";
            this.m_OKbtn.Size = new System.Drawing.Size(238, 31);
            this.m_OKbtn.TabIndex = 8;
            this.m_OKbtn.Text = "OK";
            this.m_OKbtn.Click += new System.EventHandler(this.m_OKbtn_Click);
            // 
            // delivDateLbl
            // 
            this.delivDateLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular);
            this.delivDateLbl.Location = new System.Drawing.Point(0, 64);
            this.delivDateLbl.Name = "delivDateLbl";
            this.delivDateLbl.Size = new System.Drawing.Size(88, 16);
            this.delivDateLbl.Text = "Data przywozu:";
            // 
            // delivDateVal
            // 
            this.delivDateVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular);
            this.delivDateVal.ForeColor = System.Drawing.SystemColors.Highlight;
            this.delivDateVal.Location = new System.Drawing.Point(80, 64);
            this.delivDateVal.Name = "delivDateVal";
            this.delivDateVal.Size = new System.Drawing.Size(98, 16);
            this.delivDateVal.Text = "__DELIVDATE__";
            // 
            // m_chngMyPriceBtn
            // 
            this.m_chngMyPriceBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.m_chngMyPriceBtn.Location = new System.Drawing.Point(176, 143);
            this.m_chngMyPriceBtn.Name = "m_chngMyPriceBtn";
            this.m_chngMyPriceBtn.Size = new System.Drawing.Size(62, 32);
            this.m_chngMyPriceBtn.TabIndex = 5;
            this.m_chngMyPriceBtn.Text = "Cena";
            this.m_chngMyPriceBtn.Click += new System.EventHandler(this.m_chngMyPriceBtn_Click);
            // 
            // deliverVal
            // 
            this.deliverVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular);
            this.deliverVal.ForeColor = System.Drawing.SystemColors.Highlight;
            this.deliverVal.Location = new System.Drawing.Point(56, 30);
            this.deliverVal.Name = "deliverVal";
            this.deliverVal.Size = new System.Drawing.Size(182, 16);
            this.deliverVal.Text = "__DELIVER__";
            // 
            // deliverLbl
            // 
            this.deliverLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular);
            this.deliverLbl.Location = new System.Drawing.Point(0, 30);
            this.deliverLbl.Name = "deliverLbl";
            this.deliverLbl.Size = new System.Drawing.Size(56, 16);
            this.deliverLbl.Text = "Dostawca:";
            // 
            // m_CalculateMyPrice
            // 
            this.m_CalculateMyPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.m_CalculateMyPrice.Location = new System.Drawing.Point(176, 79);
            this.m_CalculateMyPrice.Name = "m_CalculateMyPrice";
            this.m_CalculateMyPrice.Size = new System.Drawing.Size(62, 32);
            this.m_CalculateMyPrice.TabIndex = 0;
            this.m_CalculateMyPrice.Text = "Przelicz";
            this.m_CalculateMyPrice.Click += new System.EventHandler(this.m_CalculateMyPrice_Click);
            // 
            // DetailsBtn
            // 
            this.DetailsBtn.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.DetailsBtn.Location = new System.Drawing.Point(176, 47);
            this.DetailsBtn.Name = "DetailsBtn";
            this.DetailsBtn.Size = new System.Drawing.Size(62, 32);
            this.DetailsBtn.TabIndex = 32;
            this.DetailsBtn.Text = "Szczegoly";
            this.DetailsBtn.Click += new System.EventHandler(this.DetailsBtn_Click);
            // 
            // termbuyheader
            // 
            this.termbuyheader.Font = new System.Drawing.Font("Tahoma", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.termbuyheader.Location = new System.Drawing.Point(40, 158);
            this.termbuyheader.Name = "termbuyheader";
            this.termbuyheader.Size = new System.Drawing.Size(48, 17);
            this.termbuyheader.Text = "KUPNA";
            // 
            // termbuypriceVal
            // 
            this.termbuypriceVal.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.termbuypriceVal.ForeColor = System.Drawing.SystemColors.Highlight;
            this.termbuypriceVal.Location = new System.Drawing.Point(40, 212);
            this.termbuypriceVal.Name = "termbuypriceVal";
            this.termbuypriceVal.Size = new System.Drawing.Size(68, 16);
            this.termbuypriceVal.Text = "PRICE";
            // 
            // termbuystockVal
            // 
            this.termbuystockVal.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.termbuystockVal.ForeColor = System.Drawing.SystemColors.Highlight;
            this.termbuystockVal.Location = new System.Drawing.Point(40, 195);
            this.termbuystockVal.Name = "termbuystockVal";
            this.termbuystockVal.Size = new System.Drawing.Size(68, 16);
            this.termbuystockVal.Text = "STOCK";
            // 
            // termbuyweightVal
            // 
            this.termbuyweightVal.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.termbuyweightVal.ForeColor = System.Drawing.SystemColors.Highlight;
            this.termbuyweightVal.Location = new System.Drawing.Point(40, 178);
            this.termbuyweightVal.Name = "termbuyweightVal";
            this.termbuyweightVal.Size = new System.Drawing.Size(68, 16);
            this.termbuyweightVal.Text = "WEIGHT";
            // 
            // termpricerow
            // 
            this.termpricerow.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.termpricerow.Location = new System.Drawing.Point(0, 212);
            this.termpricerow.Name = "termpricerow";
            this.termpricerow.Size = new System.Drawing.Size(40, 16);
            this.termpricerow.Text = "Cena:";
            // 
            // termstockrow
            // 
            this.termstockrow.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.termstockrow.Location = new System.Drawing.Point(0, 195);
            this.termstockrow.Name = "termstockrow";
            this.termstockrow.Size = new System.Drawing.Size(40, 16);
            this.termstockrow.Text = "Rasa:";
            // 
            // termweightrow
            // 
            this.termweightrow.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.termweightrow.Location = new System.Drawing.Point(0, 178);
            this.termweightrow.Name = "termweightrow";
            this.termweightrow.Size = new System.Drawing.Size(40, 16);
            this.termweightrow.Text = "Waga:";
            // 
            // termsellpriceVal
            // 
            this.termsellpriceVal.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.termsellpriceVal.ForeColor = System.Drawing.SystemColors.Highlight;
            this.termsellpriceVal.Location = new System.Drawing.Point(114, 212);
            this.termsellpriceVal.Name = "termsellpriceVal";
            this.termsellpriceVal.Size = new System.Drawing.Size(62, 16);
            this.termsellpriceVal.Text = "PRICE";
            // 
            // termsellstockVal
            // 
            this.termsellstockVal.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.termsellstockVal.ForeColor = System.Drawing.SystemColors.Highlight;
            this.termsellstockVal.Location = new System.Drawing.Point(114, 195);
            this.termsellstockVal.Name = "termsellstockVal";
            this.termsellstockVal.Size = new System.Drawing.Size(62, 16);
            this.termsellstockVal.Text = "STOCK";
            // 
            // termsellweightVal
            // 
            this.termsellweightVal.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.termsellweightVal.ForeColor = System.Drawing.SystemColors.Highlight;
            this.termsellweightVal.Location = new System.Drawing.Point(114, 178);
            this.termsellweightVal.Name = "termsellweightVal";
            this.termsellweightVal.Size = new System.Drawing.Size(62, 16);
            this.termsellweightVal.Text = "WEIGHT";
            // 
            // termvaluesheader
            // 
            this.termvaluesheader.Font = new System.Drawing.Font("Tahoma", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.termvaluesheader.Location = new System.Drawing.Point(0, 142);
            this.termvaluesheader.Name = "termvaluesheader";
            this.termvaluesheader.Size = new System.Drawing.Size(176, 16);
            this.termvaluesheader.Text = "Terminalowe wartosci";
            this.termvaluesheader.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // termsellheader
            // 
            this.termsellheader.Font = new System.Drawing.Font("Tahoma", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.termsellheader.Location = new System.Drawing.Point(114, 158);
            this.termsellheader.Name = "termsellheader";
            this.termsellheader.Size = new System.Drawing.Size(62, 16);
            this.termsellheader.Text = "SPRZED.";
            // 
            // UpdateCattle
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(238, 271);
            this.Controls.Add(this.termsellheader);
            this.Controls.Add(this.termvaluesheader);
            this.Controls.Add(this.termsellpriceVal);
            this.Controls.Add(this.termsellstockVal);
            this.Controls.Add(this.termsellweightVal);
            this.Controls.Add(this.termbuypriceVal);
            this.Controls.Add(this.termbuystockVal);
            this.Controls.Add(this.termbuyweightVal);
            this.Controls.Add(this.termpricerow);
            this.Controls.Add(this.termstockrow);
            this.Controls.Add(this.termweightrow);
            this.Controls.Add(this.termbuyheader);
            this.Controls.Add(this.DetailsBtn);
            this.Controls.Add(this.m_CalculateMyPrice);
            this.Controls.Add(this.deliverVal);
            this.Controls.Add(this.deliverLbl);
            this.Controls.Add(this.m_chngMyPriceBtn);
            this.Controls.Add(this.delivDateVal);
            this.Controls.Add(this.delivDateLbl);
            this.Controls.Add(this.m_OKbtn);
            this.Controls.Add(this.mypriceVal);
            this.Controls.Add(this.sexVal);
            this.Controls.Add(this.stockVal);
            this.Controls.Add(this.weightVal);
            this.Controls.Add(this.birthDateVal);
            this.Controls.Add(this.m_KeyinEanBtn);
            this.Controls.Add(this.myPriceLbl);
            this.Controls.Add(this.m_chngSex);
            this.Controls.Add(this.m_chngStock);
            this.Controls.Add(this.m_changeWeightBtn);
            this.Controls.Add(this.sexLbl);
            this.Controls.Add(this.stockLbl);
            this.Controls.Add(this.weightLbl);
            this.Controls.Add(this.birthDateLbl);
            this.Controls.Add(this.eanTextBox);
            this.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateCattle";
            this.Text = "Edycja krowy";
            this.Load += new System.EventHandler(this.UpdateCattle_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void UpdateCattle_Load(object sender, System.EventArgs e)
		{
			EnableBtns(false);
			SetNullLabels();
			m_bcReader.Init();
            MyReadEventHandler = new EventHandler(this.ReaderNotify);
            m_bcReader.OnRead += MyReadEventHandler;
			this.Closed += new EventHandler(OnClosedUpdateCattleDlg);
			m_OrginalBackColor = this.BackColor;
		}
		
		private void OnClosedUpdateCattleDlg(object sender, EventArgs e)
		{           
            m_bcReader.OnRead -= MyReadEventHandler;
			m_bcReader.Finish();
		}


		private void ReaderNotify(object sender, System.EventArgs e)
		{
			if(!m_lockBCReader)
			{
				eanTextBox.Text =  (string)sender;
				AskDB(eanTextBox.Text);				
			}
		}
		

		private void EnableBtns(bool bEnable)
		{
			m_changeWeightBtn.Enabled = bEnable;
			m_chngMyPriceBtn.Enabled = bEnable;
			m_chngStock.Enabled = bEnable;
			m_chngSex.Enabled = bEnable;
			m_CalculateMyPrice.Enabled = bEnable;
            DetailsBtn.Enabled = bEnable;
		}

		private void SetNullLabels()
		{
			birthDateVal.Text = NULLValue;
			deliverVal.Text = NULLValue;
			weightVal.Text = NULLValue;
			sexVal.Text = NULLValue;
			mypriceVal.Text = NULLValue;
			stockVal.Text = NULLValue;
			delivDateVal.Text = NULLValue;

            termbuypriceVal.Text = NULLValue;
            termbuystockVal.Text = NULLValue;
            termbuyweightVal.Text = NULLValue;
            termsellpriceVal.Text = NULLValue;
            termsellstockVal.Text = NULLValue;
            termsellweightVal.Text = NULLValue;
            
			
		}

		
		private void m_KeyinEanBtn_Click(object sender, System.EventArgs e)
		{
			m_lockBCReader = true;
			FindCowByEAN eankeypad = new FindCowByEAN(false);
			if(eankeypad.ShowDialog() == DialogResult.OK)
			{
				eanTextBox.Text = eankeypad.EANFound;
				AskDB(eanTextBox.Text);
			}
			m_lockBCReader = false;
		}


		private object SetLabel(DbDataReader aReader,string colName,Label aLabel)
		{
            object retObj = null;
			int ordinal = aReader.GetOrdinal(colName);
            if (aReader.IsDBNull(ordinal))
                aLabel.Text = NULLValue;
            else
            {
                retObj = aReader.GetValue(ordinal);
                aLabel.Text = retObj.ToString();
            }
            return retObj;

		}

        private object SetDateLabel(DbDataReader aReader, string colName, Label aLabel)
        {
            object retObj = null;
            int ordinal = aReader.GetOrdinal(colName);
            if (aReader.IsDBNull(ordinal))
                aLabel.Text = NULLValue;
            else
            {
                retObj = aReader.GetValue(ordinal);
                aLabel.Text = Utils.FormatDayDate((DateTime)retObj);
            }
            return retObj;

        }
           

	

        private void AskDB(string aEAN)
		{
			string eanCowQ = "SELECT cattle.action AS cowaction,stocks.stockcode as stockcode," +
				                 "inhents.alias AS deliveralias,birthdate,sex," +
                                 "buystocks.stockcode AS termbuystockcode,termbuyweight,termbuyprice,buystocks.stockid AS termbuystockid," +
                                 "sellstocks.stockcode AS termsellstockcode,termsellweight,termsellprice,sellstocks.stockid AS termsellstockid," +
                                 "weight,myprice,loaddate,stocks.stockid AS stockid,hasbuyinv " +
				                 "FROM cattle LEFT JOIN stocks ON (cattle.stock = stocks.stockid) " +
								 "LEFT JOIN indocs ON (indocs.docno = cattle.docin) " +
								 "LEFT JOIN hents inhents ON (indocs.hent = inhents.hentid) " +
                                 "LEFT JOIN stocks buystocks ON (buystocks.stockid = termbuystock) " +
                                 "LEFT JOIN stocks sellstocks ON (sellstocks.STOCKID = termsellstock) " +
								 "WHERE ean = '" + aEAN + "'";
          
            DbDataReader reader = null;
            try
            {
                reader = SQLDB.ExecuteQuery(eanCowQ);
                object objValue = null;
                int ord;
                if (reader.Read())
                {
                    BackColor = m_OrginalBackColor;
                    birthDateVal.BackColor = m_OrginalBackColor;
                    objValue = SetDateLabel(reader, "birthdate", birthDateVal);
                    if (objValue != null)
                    {
                        m_birthdate = (DateTime)objValue;
                        if (!(Settings.Instance.redBirthdateDays == 0 ||
                            DateTime.Now.CompareTo(m_birthdate.AddDays(Settings.Instance.redBirthdateDays)) < 0))
                        {
                            birthDateVal.BackColor = Color.Red;
                        }
                    }

                    SetLabel(reader, "deliveralias", deliverVal);
                    SetLabel(reader, "stockcode", stockVal);
                    SetDateLabel(reader, "loaddate", delivDateVal);


                    objValue = SetLabel(reader, "myprice", mypriceVal);
                    if (objValue != null)
                        m_curMyPrice = Decimal.ToDouble((decimal)objValue);
                    else
                        m_curMyPrice = null;

                    m_curCowSex = CowSex.FromInt(reader.GetInt32(reader.GetOrdinal("sex")));
                    sexVal.Text = m_curCowSex.ToString();

                    objValue = SetLabel(reader, "weight", weightVal);
                    if (objValue != null)
                        m_curCowWeight = Decimal.ToDouble((decimal)objValue);
                    else
                        m_curCowWeight = 0;

                    m_curCowStock = reader.GetInt32(reader.GetOrdinal("stockid"));

                    m_curCowAction = reader.GetString(reader.GetOrdinal("cowaction")).ToCharArray()[0];

                    if (m_curCowAction != 'N') m_curCowAction = 'U';


                    objValue = SetLabel(reader, "termbuyprice", termbuypriceVal);
                    if (objValue != null)
                        m_curTermBuyPrice = Decimal.ToDouble((decimal)objValue);
                    else
                        m_curTermBuyPrice = null;

                    objValue = SetLabel(reader, "termsellprice", termsellpriceVal);
                    if (objValue != null)
                        m_curTermSellPrice = Decimal.ToDouble((decimal)objValue);
                    else
                        m_curTermSellPrice = null;


                    objValue = SetLabel(reader, "termbuyweight", termbuyweightVal);
                    if (objValue != null)
                        m_curTermBuyWeight = Decimal.ToDouble((decimal)objValue);
                    else
                        m_curTermBuyWeight = null;

                    objValue = SetLabel(reader, "termsellweight", termsellweightVal);
                    if (objValue != null)
                        m_curTermSellWeight = Decimal.ToDouble((decimal)objValue);
                    else
                        m_curTermSellWeight = null;

                    SetLabel(reader, "termbuystockcode", termbuystockVal);
                    SetLabel(reader, "termsellstockcode", termsellstockVal);

                    ord = reader.GetOrdinal("hasbuyinv");
                    if (!reader.IsDBNull(ord))
                        m_hasBuyInv = reader.GetInt32(ord) != 0;
                    else m_hasBuyInv = false;

                    m_curTermBuyStockId = 0;
                    ord = reader.GetOrdinal("termbuystockid");
                    if (!reader.IsDBNull(ord))
                        m_curTermBuyStockId = reader.GetInt32(ord);

                    m_curTermSellStockId = 0;
                    ord = reader.GetOrdinal("termsellstockid");
                    if (!reader.IsDBNull(ord))
                        m_curTermSellStockId = reader.GetInt32(ord);

                    EnableBtns(true);

                }
                else
                {
                    EnableBtns(false);
                    BackColor = Color.Red;
                    birthDateVal.BackColor = Color.Red;
                    SetNullLabels();
                }
            }
            catch (SystemException sqlEx)
            {
                LOG.DoLog("AskDB(): QUERY = " + eanCowQ + ", MSG = " + sqlEx.Message + ", STACKTRACE = " + sqlEx.StackTrace.ToString());
                throw sqlEx;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                reader = null;
            }

		}

		private void m_OKbtn_Click(object sender, System.EventArgs e)
		{	
			Close();
		}

		private void m_chngMyPriceBtn_Click(object sender, System.EventArgs e)
		{
			m_lockBCReader = true;
			if(!SyncLockMessage.CheckSyncLock()) 
			{
				m_lockBCReader = false;
				return;			
			}

            ThreeBtnsOpt priceChngSel = 
                new ThreeBtnsOpt("Terminalowa cena kupna",true,
                                 "Terminalowa cena sprzeda¿y",true,
                                 "Moja cena",true);


            if (priceChngSel.ShowDialog() == DialogResult.OK)
            {
                
                string numkeypadCaption = String.Empty;
                Nullable<double> numkeypadValue = null;
                Label valueLabel = null;
                string sqlField = String.Empty;
                

                switch (priceChngSel.GetSelectedOpt())
                {
                    case 1:
                        numkeypadCaption = "Zmiana term. ceny kupna";
                        numkeypadValue = m_curTermBuyPrice;
                        valueLabel = termbuypriceVal;
                        sqlField = "termbuyprice";
                        break;

                    case 2:
                        numkeypadCaption = "Zmiana term. ceny sprzed.";
                        numkeypadValue = m_curTermSellPrice;
                        valueLabel = termsellpriceVal;
                        sqlField = "termsellprice";
                        break;
                    case 3:
                        numkeypadCaption = "Zmiana mojej ceny";
                        numkeypadValue = m_curMyPrice;
                        valueLabel = mypriceVal;
                        sqlField = "myprice";
                        break;
                }
                NumKeypad numkeypad = new NumKeypad(numkeypadCaption);
                numkeypad.ComaEnable = true;
                numkeypad.AllowNull = true;

                numkeypad.DoubleValue = numkeypadValue;
                
                if (numkeypad.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        
                        string cowUpdateStmt = SQLBuilder.SQLSprintf(   cowUpdateStmtFmt,
                                                                        Utils.FormatMoneySQL(numkeypad.DoubleValue),
                                                                        m_curCowAction,
                                                                        eanTextBox.Text,
                                                                        sqlField);
                        SQLDB.ExecuteNonQuery(cowUpdateStmt);

                    }
                    catch (Exception sqlEx)
                    {
                        BigOKMessageBox.ShowMessage("Blad", "Blad podczas aktualizacji ceny zwierzecia" +
                                                               " o numerze " + eanTextBox.Text + ": " +
                                                               sqlEx.Message);
                        LOG.DoLog("m_chngMyPriceBtn_Click(): " + sqlEx.Message);
                    }

                    numkeypadValue = numkeypad.DoubleValue;

                    switch (priceChngSel.GetSelectedOpt())
                    {
                        case 1:                           
                            m_curTermBuyPrice = numkeypadValue;                            
                            break;
                        case 2:
                            m_curTermSellPrice = numkeypadValue;
                            break;
                        case 3:
                            m_curMyPrice = numkeypadValue;
                            break;
                    }

                    if (numkeypadValue.HasValue)
                        valueLabel.Text = Utils.FormatMoney(numkeypadValue.Value);
                    else
                        valueLabel.Text = NULLValue;
                    
                }
            }



			m_lockBCReader = false;
		
		}

		private void m_chngSex_Click(object sender, System.EventArgs e)
		{
			m_lockBCReader = true;
			if(!SyncLockMessage.CheckSyncLock()) 
			{
				m_lockBCReader = false;
				return;
			}
            if (!m_hasBuyInv)
            {
                ChooseSex sexList = new ChooseSex(m_curCowSex, "Wybierz p³eæ");
                string sexUpdateStmtFmt = "UPDATE cattle SET sex = %0, action = %1q WHERE ean = %2q";
                if (sexList.ShowDialog() == DialogResult.OK)
                {
                    m_curCowSex = (CowSex)sexList.GetSelected();
                    try
                    {
                        string sexUpdateStmt = SQLBuilder.SQLSprintf(sexUpdateStmtFmt, m_curCowSex.ToInt(), m_curCowAction, eanTextBox.Text);
                        SQLDB.ExecuteNonQuery(sexUpdateStmt);
                    }
                    catch (Exception ex)
                    {
                        BigOKMessageBox.ShowMessage("Blad SQL", "Blad podczas aktualizacji plci zwierzecia" +
                                                               " o numerze " + eanTextBox.Text + ": " +
                                                               ex.Message);
                        LOG.DoLog("m_chngMyPriceBtn_Click(): " + ex.Message);    
                    }

                    sexVal.Text = m_curCowSex.ToString();
                }
            }
            else
                BigOKMessageBox.ShowMessage("Wystawiona faktura","Na to zwierze wystawiono juz fakture kupna\nzmiana plci jest niemozliwa.");
			m_lockBCReader = false;
		}

		
		private void m_CalculateMyPrice_Click(object sender, System.EventArgs e)
		{

			string calculateUpdateStmtFmt = "UPDATE cattle SET %4 = %0,%5 = %1, action = %2q WHERE ean = %3q";
			m_lockBCReader = true;			
			if(!SyncLockMessage.CheckSyncLock())
			{
				m_lockBCReader = false;
				return;
			}

            string caption = String.Empty;
            double weight = 0;
            double price = 0.0;

            ThreeBtnsOpt priceChngSel =
              new ThreeBtnsOpt("Kupno", true,
                               "Sprzeda¿", true,
                               "Moja", true);
            if (priceChngSel.ShowDialog() == DialogResult.OK)
            {

                price = 0.0;
                weight = 0.0;
                switch (priceChngSel.GetSelectedOpt())
                {
                    case 1:
                        caption = "Oblicz cene kupna";
                        if (m_curTermBuyWeight.HasValue)
                            weight = m_curTermBuyWeight.Value;
                        if(m_curTermBuyPrice.HasValue)
                            price = m_curTermBuyPrice.Value;
                        break;
                    case 2:
                        caption = "Oblicz cene sprzeda¿y";
                        if(m_curTermSellWeight.HasValue)
                            weight = m_curTermSellWeight.Value;
                        if (m_curTermSellPrice.HasValue) 
                            price = m_curTermSellPrice.Value;
                        break;
                    case 3:
                        caption = "Oblicz moja cene";
                        weight = m_curCowWeight;
                        if (m_curMyPrice.HasValue)
                            price = m_curMyPrice.Value;             
                        break;
                }

                MyPriceCalculator calculator = new MyPriceCalculator(caption);
                calculator.Price = price;
                calculator.Weight = weight;               
                if (calculator.ShowDialog() == DialogResult.OK)
                {
                    string priceSQLField = String.Empty;
                    string weightSQLField = String.Empty;
                    Label apriceLbl = null;
                    Label aweightLbl = null;


                    switch (priceChngSel.GetSelectedOpt())
                    {
                        case 1: //kupno

                            priceSQLField = "termbuyprice";
                            weightSQLField = "termbuyweight";
                            m_curTermBuyWeight = calculator.Weight;
                            m_curTermBuyPrice = calculator.Price;
                            apriceLbl = termbuypriceVal;
                            aweightLbl = termbuyweightVal;
                            
                            break;
                        case 2: //sprzedaz

                             priceSQLField = "termsellprice";
                             weightSQLField = "termsellweight";
                             m_curTermSellWeight = calculator.Weight;
                             m_curTermSellPrice= calculator.Price;
                             apriceLbl = termsellpriceVal;
                             aweightLbl = termsellweightVal;
                            
                            break;
                        case 3: //moja
                            
                            if(m_hasBuyInv && calculator.Weight != weight)
                            {
                                BigOKMessageBox.ShowMessage("Wystawiona faktura",
                                "Probujesz zmienic wage zwierzecia na ktore wystawiono fakture");
                                priceChngSel = null;
                                calculator = null;
                                m_lockBCReader = false;
                                return;
                            }

                            priceSQLField = "myprice";
                            weightSQLField = "weight";
                            m_curCowWeight = calculator.Weight;
                            m_curMyPrice = calculator.Price;
                            apriceLbl = mypriceVal;
                            aweightLbl = weightVal;
                            break;
                    }
                                       
                    try
                    {
                        string calculateUpdateStmt = SQLBuilder.SQLSprintf(calculateUpdateStmtFmt, 
                                    calculator.Weight, Utils.FormatMoneySQL(calculator.Price),
                                    m_curCowAction, eanTextBox.Text, weightSQLField,
                                    priceSQLField);

                        SQLDB.ExecuteNonQuery(calculateUpdateStmt);

                        apriceLbl.Text = Utils.FormatMoney(calculator.Price);
                        aweightLbl.Text = calculator.Weight.ToString();
                    }
                    catch (System.Exception ex)
                    {
                        BigOKMessageBox.ShowMessage("Blad SQL", "Aktualizacja rekordu zakonczyla sie niepowodzeniem");
                        LOG.DoLog("m_CalculateMyPrice_Click(): " + ex.Message);
                    }
                }
                calculator = null;
            }
            priceChngSel = null;
			m_lockBCReader = false;

		}

        private void DetailsBtn_Click(object sender, EventArgs e)
        {
            CowDetails cowDetails = new CowDetails(eanTextBox.Text);
            cowDetails.ShowDialog();
            cowDetails = null;
        }

        private void ChangeWeightBtn_Click(object sender, System.EventArgs e)
        {
            m_lockBCReader = true;
            if (!SyncLockMessage.CheckSyncLock())
            {
                m_lockBCReader = false;
                return;
            }

            ThreeBtnsOpt weightChngSel =
                new ThreeBtnsOpt("Terminalowa waga kupna", true,
                                 "Terminalowa waga sprzeda¿y", true,
                                 "Podst. waga", !m_hasBuyInv);



            if (weightChngSel.ShowDialog() == DialogResult.OK)
            {

                string numkeypadCaption = String.Empty;
                Nullable<double> weightValue = null;
                Label valueLabel = null;
                string sqlField = String.Empty;
                bool allowNull = false;

                switch (weightChngSel.GetSelectedOpt())
                {
                    case 1:
                        numkeypadCaption = "Zmiana term. wagi kupna";
                        weightValue = m_curTermBuyWeight;
                        valueLabel = termbuyweightVal;
                        sqlField = "termbuyweight";
                        allowNull = true;
                        break;

                    case 2:
                        numkeypadCaption = "Zmiana term. wagi sprzed.";
                        weightValue = m_curTermSellWeight;
                        valueLabel = termsellweightVal;
                        sqlField = "termsellweight";
                        allowNull = true;
                        break;
                    case 3:
                        numkeypadCaption = "Zmiana podst. wagi";
                        weightValue = m_curCowWeight;
                        valueLabel = weightVal;
                        sqlField = "weight";
                        allowNull = false;
                        break;
                }
                NumKeypad numkeypad = new NumKeypad(numkeypadCaption);
                numkeypad.ComaEnable = true;
                numkeypad.AllowNull = allowNull;
                numkeypad.FloatPrecision = 3;

                numkeypad.DoubleValue = weightValue;

                if (numkeypad.ShowDialog() == DialogResult.OK)
                {
                    string cowUpdateStmt = SQLBuilder.SQLSprintf(cowUpdateStmtFmt,
                                                                 Utils.FormatWeightSQL(numkeypad.DoubleValue),
                                                                 m_curCowAction,
                                                                 eanTextBox.Text,
                                                                 sqlField);
                    
                    try
                    {
                        SQLDB.ExecuteNonQuery(cowUpdateStmt);

                    }
                    catch (Exception sqlEx)
                    {
                        LOG.DoLog("ChangeWeightBtn_Click(): STMT = " + cowUpdateStmt + ", MESSAGE = " + sqlEx.Message + ", STACKTRACE = " + sqlEx.StackTrace.ToString());
                        throw sqlEx;
                    }

                    switch (weightChngSel.GetSelectedOpt())
                    {
                        case 1:
                            m_curTermBuyWeight = numkeypad.DoubleValue;
                            break;
                        case 2:
                            m_curTermSellWeight = numkeypad.DoubleValue;
                            break;
                        case 3:
                            m_curCowWeight = numkeypad.DoubleValue.Value;
                            break;
                    }
                    if (numkeypad.DoubleValue.HasValue)
                        valueLabel.Text = numkeypad.DoubleValue.ToString();
                    else
                        valueLabel.Text = NULLValue;

                }
            }
            m_lockBCReader = false;		
        }

        private void m_chngStock_Click(object sender, System.EventArgs e)
        {
            m_lockBCReader = true;
            if (!SyncLockMessage.CheckSyncLock())
            {
                m_lockBCReader = false;
                return;
            }

            ThreeBtnsOpt stockChngSel =
              new ThreeBtnsOpt("Terminalowa rasa kupna", true,
                               "Terminalowa rasa sprzeda¿y", true,
                               "Podst. rasa", !m_hasBuyInv);

            if (stockChngSel.ShowDialog() == DialogResult.OK)
            {

                string stockChngCaption = String.Empty;
                int stockInitValue = 0;
                Label valueLabel = null;
                string sqlField = String.Empty;
                bool bNoneStock = false;

                switch (stockChngSel.GetSelectedOpt())
                {
                    case 1:
                        stockChngCaption = "Zmiana term. rasy kupna";
                        stockInitValue = m_curTermBuyStockId;
                        valueLabel = termbuystockVal;
                        sqlField = "termbuystock";
                        bNoneStock = true;
                        break;

                    case 2:
                        stockChngCaption = "Zmiana term. rasy sprzed.";
                        stockInitValue = m_curTermSellStockId;
                        valueLabel = termsellstockVal;
                        sqlField = "termsellstock";
                        bNoneStock = true;
                        break;
                    case 3:
                        stockChngCaption = "Zmiana podst. rasy";
                        stockInitValue = m_curCowStock;
                        valueLabel = stockVal;
                        sqlField = "stock";
                        bNoneStock = false;
                        break;
                }

                ChooseStock stockList = new ChooseStock(stockInitValue, stockChngCaption, bNoneStock);
                
                if (stockList.ShowDialog() == DialogResult.OK)
                {
                    Stock selectedStock = ((Stock)stockList.GetSelected());
                    try
                    {
                        
                        string cowUpdateStmt = SQLBuilder.SQLSprintf(cowUpdateStmtFmt, selectedStock.stockId, m_curCowAction,
                                           eanTextBox.Text, sqlField);
                        SQLDB.ExecuteNonQuery(cowUpdateStmt);

                    }
                    catch (Exception sqlEx)
                    {
                        BigOKMessageBox.ShowMessage("Blad SQL", "Blad podczas aktualizacji rasy zwierzecia" +
                                                               " o numerze " + eanTextBox.Text + ": " +
                                                               sqlEx.Message);
                        LOG.DoLog("m_chngStock_Click(): " + sqlEx.Message);
                    }

                    switch (stockChngSel.GetSelectedOpt())
                    {
                        case 1:
                            m_curTermBuyStockId = selectedStock.stockId;
                            break;
                        case 2:
                            m_curTermSellStockId = selectedStock.stockId;
                            break;
                        case 3:
                           
                            m_curCowStock = selectedStock.stockId;
                           
                            break;
                    }

                    valueLabel.Text = ((Stock)stockList.GetSelected()).stockCode;

                }
            }
            m_lockBCReader = false;	
        }

		
	}
}
