using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace cowbase
{
	public class MyPriceCalculator : CenterForm  //System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button m_btn4;
		private System.Windows.Forms.Button m_btn5;
		private System.Windows.Forms.Button m_btn2;
		private System.Windows.Forms.Button m_btn1;
		private System.Windows.Forms.Button m_btn3;
		private System.Windows.Forms.Button m_btn6;
		private System.Windows.Forms.Button m_btn9;
		private System.Windows.Forms.Button m_btn8;
		private System.Windows.Forms.Button m_btn7;
		private System.Windows.Forms.Button m_btnDel;
		private System.Windows.Forms.Button m_btn0;
		private System.Windows.Forms.Button m_btnComa;
		private System.Windows.Forms.Button m_setMyPriceBtn;
		private System.Windows.Forms.Button m_cancelBtn;
		private System.Windows.Forms.Label m_weightValue;
		private bool m_priceHasComa;		
		private System.Windows.Forms.Button m_setWeightBtn;
		private System.Windows.Forms.Label MyPriceInfoLabel;
		private System.Windows.Forms.Label m_mypriceLabel;
		private System.Windows.Forms.Button m_setPricePerKgBtn;
		private System.Windows.Forms.Label m_mypricePerKg;
		private System.Windows.Forms.Label m_activeLabel;

        private double m_weight;
        private double m_price;
        private bool m_firstClear;
        


        public double Weight 
        {
            set 
            {
                if (value < 0) m_weight = 0;
                else
                    m_weight = value;
            }

            get
            {
                return m_weight;
            }
        }

        public double Price
        {
            set
            {
                if(value < 0.0) m_price = 0.0;
                else
                    m_price = value;
            }
            get 
            {
                return m_price;
            }
        }

	
		public MyPriceCalculator(string caption)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			this.KeyPress += new KeyPressEventHandler(MyPriceCalculator_KeyPress);
            this.Text = caption;
            m_price = 0.0;
            m_weight = 0;

			m_priceHasComa = false;

            m_firstClear = true;
			

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
            this.m_btn4 = new System.Windows.Forms.Button();
            this.m_btn5 = new System.Windows.Forms.Button();
            this.m_btn2 = new System.Windows.Forms.Button();
            this.m_btn1 = new System.Windows.Forms.Button();
            this.m_btn3 = new System.Windows.Forms.Button();
            this.m_btn6 = new System.Windows.Forms.Button();
            this.m_btn9 = new System.Windows.Forms.Button();
            this.m_btn8 = new System.Windows.Forms.Button();
            this.m_btn7 = new System.Windows.Forms.Button();
            this.m_btnDel = new System.Windows.Forms.Button();
            this.m_btn0 = new System.Windows.Forms.Button();
            this.m_btnComa = new System.Windows.Forms.Button();
            this.m_setWeightBtn = new System.Windows.Forms.Button();
            this.m_setMyPriceBtn = new System.Windows.Forms.Button();
            this.m_cancelBtn = new System.Windows.Forms.Button();
            this.m_weightValue = new System.Windows.Forms.Label();
            this.m_setPricePerKgBtn = new System.Windows.Forms.Button();
            this.m_mypricePerKg = new System.Windows.Forms.Label();
            this.MyPriceInfoLabel = new System.Windows.Forms.Label();
            this.m_mypriceLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // m_btn4
            // 
            this.m_btn4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.m_btn4.Location = new System.Drawing.Point(38, 127);
            this.m_btn4.Name = "m_btn4";
            this.m_btn4.Size = new System.Drawing.Size(48, 34);
            this.m_btn4.TabIndex = 19;
            this.m_btn4.Text = "4";
            this.m_btn4.Click += new System.EventHandler(this.m_btn4_Click);
            // 
            // m_btn5
            // 
            this.m_btn5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.m_btn5.Location = new System.Drawing.Point(86, 127);
            this.m_btn5.Name = "m_btn5";
            this.m_btn5.Size = new System.Drawing.Size(48, 34);
            this.m_btn5.TabIndex = 18;
            this.m_btn5.Text = "5";
            this.m_btn5.Click += new System.EventHandler(this.m_btn5_Click);
            // 
            // m_btn2
            // 
            this.m_btn2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.m_btn2.Location = new System.Drawing.Point(86, 161);
            this.m_btn2.Name = "m_btn2";
            this.m_btn2.Size = new System.Drawing.Size(48, 34);
            this.m_btn2.TabIndex = 16;
            this.m_btn2.Text = "2";
            this.m_btn2.Click += new System.EventHandler(this.m_btn2_Click);
            // 
            // m_btn1
            // 
            this.m_btn1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.m_btn1.Location = new System.Drawing.Point(38, 161);
            this.m_btn1.Name = "m_btn1";
            this.m_btn1.Size = new System.Drawing.Size(48, 34);
            this.m_btn1.TabIndex = 17;
            this.m_btn1.Text = "1";
            this.m_btn1.Click += new System.EventHandler(this.m_btn1_Click);
            // 
            // m_btn3
            // 
            this.m_btn3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.m_btn3.Location = new System.Drawing.Point(134, 161);
            this.m_btn3.Name = "m_btn3";
            this.m_btn3.Size = new System.Drawing.Size(48, 34);
            this.m_btn3.TabIndex = 14;
            this.m_btn3.Text = "3";
            this.m_btn3.Click += new System.EventHandler(this.m_btn3_Click);
            // 
            // m_btn6
            // 
            this.m_btn6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.m_btn6.Location = new System.Drawing.Point(134, 127);
            this.m_btn6.Name = "m_btn6";
            this.m_btn6.Size = new System.Drawing.Size(48, 34);
            this.m_btn6.TabIndex = 15;
            this.m_btn6.Text = "6";
            this.m_btn6.Click += new System.EventHandler(this.m_btn6_Click);
            // 
            // m_btn9
            // 
            this.m_btn9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.m_btn9.Location = new System.Drawing.Point(134, 93);
            this.m_btn9.Name = "m_btn9";
            this.m_btn9.Size = new System.Drawing.Size(48, 34);
            this.m_btn9.TabIndex = 11;
            this.m_btn9.Text = "9";
            this.m_btn9.Click += new System.EventHandler(this.m_btn9_Click);
            // 
            // m_btn8
            // 
            this.m_btn8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.m_btn8.Location = new System.Drawing.Point(86, 93);
            this.m_btn8.Name = "m_btn8";
            this.m_btn8.Size = new System.Drawing.Size(48, 34);
            this.m_btn8.TabIndex = 12;
            this.m_btn8.Text = "8";
            this.m_btn8.Click += new System.EventHandler(this.m_btn8_Click);
            // 
            // m_btn7
            // 
            this.m_btn7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.m_btn7.Location = new System.Drawing.Point(38, 93);
            this.m_btn7.Name = "m_btn7";
            this.m_btn7.Size = new System.Drawing.Size(48, 34);
            this.m_btn7.TabIndex = 13;
            this.m_btn7.Text = "7";
            this.m_btn7.Click += new System.EventHandler(this.m_btn7_Click);
            // 
            // m_btnDel
            // 
            this.m_btnDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.m_btnDel.Location = new System.Drawing.Point(134, 195);
            this.m_btnDel.Name = "m_btnDel";
            this.m_btnDel.Size = new System.Drawing.Size(48, 34);
            this.m_btnDel.TabIndex = 8;
            this.m_btnDel.Text = "<<";
            this.m_btnDel.Click += new System.EventHandler(this.m_btnDel_Click);
            // 
            // m_btn0
            // 
            this.m_btn0.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.m_btn0.Location = new System.Drawing.Point(86, 195);
            this.m_btn0.Name = "m_btn0";
            this.m_btn0.Size = new System.Drawing.Size(48, 34);
            this.m_btn0.TabIndex = 9;
            this.m_btn0.Text = "0";
            this.m_btn0.Click += new System.EventHandler(this.m_btn0_Click);
            // 
            // m_btnComa
            // 
            this.m_btnComa.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.m_btnComa.Location = new System.Drawing.Point(38, 195);
            this.m_btnComa.Name = "m_btnComa";
            this.m_btnComa.Size = new System.Drawing.Size(48, 34);
            this.m_btnComa.TabIndex = 10;
            this.m_btnComa.Text = ".";
            this.m_btnComa.Click += new System.EventHandler(this.m_btnComa_Click);
            // 
            // m_setWeightBtn
            // 
            this.m_setWeightBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_setWeightBtn.Location = new System.Drawing.Point(0, 0);
            this.m_setWeightBtn.Name = "m_setWeightBtn";
            this.m_setWeightBtn.Size = new System.Drawing.Size(80, 32);
            this.m_setWeightBtn.TabIndex = 7;
            this.m_setWeightBtn.Text = "Waga:";
            this.m_setWeightBtn.Click += new System.EventHandler(this.m_setWeightBtn_Click);
            // 
            // m_setMyPriceBtn
            // 
            this.m_setMyPriceBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.m_setMyPriceBtn.Location = new System.Drawing.Point(0, 235);
            this.m_setMyPriceBtn.Name = "m_setMyPriceBtn";
            this.m_setMyPriceBtn.Size = new System.Drawing.Size(110, 40);
            this.m_setMyPriceBtn.TabIndex = 6;
            this.m_setMyPriceBtn.Text = "Ustaw";
            this.m_setMyPriceBtn.Click += new System.EventHandler(this.m_setMyPriceBtn_Click);
            // 
            // m_cancelBtn
            // 
            this.m_cancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.m_cancelBtn.Location = new System.Drawing.Point(110, 235);
            this.m_cancelBtn.Name = "m_cancelBtn";
            this.m_cancelBtn.Size = new System.Drawing.Size(108, 40);
            this.m_cancelBtn.TabIndex = 5;
            this.m_cancelBtn.Text = "Anuluj";
            this.m_cancelBtn.Click += new System.EventHandler(this.m_cancelBtn_Click);
            // 
            // m_weightValue
            // 
            this.m_weightValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_weightValue.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.m_weightValue.Location = new System.Drawing.Point(80, 8);
            this.m_weightValue.Name = "m_weightValue";
            this.m_weightValue.Size = new System.Drawing.Size(72, 21);
            this.m_weightValue.Text = "000000";
            this.m_weightValue.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // m_setPricePerKgBtn
            // 
            this.m_setPricePerKgBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.m_setPricePerKgBtn.Location = new System.Drawing.Point(0, 32);
            this.m_setPricePerKgBtn.Name = "m_setPricePerKgBtn";
            this.m_setPricePerKgBtn.Size = new System.Drawing.Size(80, 32);
            this.m_setPricePerKgBtn.TabIndex = 3;
            this.m_setPricePerKgBtn.Text = "Cena za kg:";
            this.m_setPricePerKgBtn.Click += new System.EventHandler(this.m_setPricePerKgBtn_Click);
            // 
            // m_mypricePerKg
            // 
            this.m_mypricePerKg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_mypricePerKg.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.m_mypricePerKg.Location = new System.Drawing.Point(80, 40);
            this.m_mypricePerKg.Name = "m_mypricePerKg";
            this.m_mypricePerKg.Size = new System.Drawing.Size(72, 24);
            this.m_mypricePerKg.Text = "000000";
            this.m_mypricePerKg.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // MyPriceInfoLabel
            // 
            this.MyPriceInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.MyPriceInfoLabel.Location = new System.Drawing.Point(0, 67);
            this.MyPriceInfoLabel.Name = "MyPriceInfoLabel";
            this.MyPriceInfoLabel.Size = new System.Drawing.Size(48, 20);
            this.MyPriceInfoLabel.Text = "Cena:";
            // 
            // m_mypriceLabel
            // 
            this.m_mypriceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.m_mypriceLabel.Location = new System.Drawing.Point(54, 67);
            this.m_mypriceLabel.Name = "m_mypriceLabel";
            this.m_mypriceLabel.Size = new System.Drawing.Size(96, 20);
            this.m_mypriceLabel.Text = "9999999.99";
            // 
            // MyPriceCalculator
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(218, 275);
            this.Controls.Add(this.m_mypriceLabel);
            this.Controls.Add(this.MyPriceInfoLabel);
            this.Controls.Add(this.m_mypricePerKg);
            this.Controls.Add(this.m_setPricePerKgBtn);
            this.Controls.Add(this.m_weightValue);
            this.Controls.Add(this.m_cancelBtn);
            this.Controls.Add(this.m_setMyPriceBtn);
            this.Controls.Add(this.m_setWeightBtn);
            this.Controls.Add(this.m_btnDel);
            this.Controls.Add(this.m_btn0);
            this.Controls.Add(this.m_btnComa);
            this.Controls.Add(this.m_btn9);
            this.Controls.Add(this.m_btn8);
            this.Controls.Add(this.m_btn7);
            this.Controls.Add(this.m_btn3);
            this.Controls.Add(this.m_btn6);
            this.Controls.Add(this.m_btn2);
            this.Controls.Add(this.m_btn1);
            this.Controls.Add(this.m_btn5);
            this.Controls.Add(this.m_btn4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MyPriceCalculator";
            this.Text = "__CAPTION__";
            this.Load += new System.EventHandler(this.MyPriceCalculator_Load);
            this.ResumeLayout(false);

		}
		#endregion

		

		private void m_setMyPriceBtn_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.OK;
			m_weight = Utils.ParseInteger(m_weightValue.Text);
            if (m_weight <= 0.001)
			{
				BigOKMessageBox.ShowMessage("Nipoprawna waga","Waga musi byæ wieksza od 0.0009");
				this.Focus();
				return;
			}
			m_price = Utils.ParseFloat(m_mypriceLabel.Text);			
			Close();	
		}

		private void m_cancelBtn_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();	
		}

		private void m_btn1_Click(object sender, System.EventArgs e)
		{
			InsertDigit(1);
		}

		private void m_btn2_Click(object sender, System.EventArgs e)
		{
			InsertDigit(2);
		}

		private void m_btn3_Click(object sender, System.EventArgs e)
		{
			InsertDigit(3);
		}

		private void m_btn0_Click(object sender, System.EventArgs e)
		{
			InsertDigit(0);
		}

		private void m_btn6_Click(object sender, System.EventArgs e)
		{
			InsertDigit(6);
		}

		private void m_btn5_Click(object sender, System.EventArgs e)
		{
			InsertDigit(5);
		}

		private void m_btn4_Click(object sender, System.EventArgs e)
		{
			InsertDigit(4);
		}

		private void m_btn7_Click(object sender, System.EventArgs e)
		{
			InsertDigit(7);
		}

		private void m_btn8_Click(object sender, System.EventArgs e)
		{
			InsertDigit(8);
		}

		private void m_btn9_Click(object sender, System.EventArgs e)
		{
			InsertDigit(9);
		}

		private void InsertDigit(int digit)
		{
			if(m_activeLabel.Text.Length < 6)
			{
                if (m_firstClear)
                {
                    m_activeLabel.Text = String.Empty;
                    m_firstClear = false;
                    m_priceHasComa = false;
                }

				m_activeLabel.Text += digit.ToString();
				ComputePrice();				
			}
			this.Focus();
		}
		private void ComputePrice()
		{
			float mypriceperkg = 0.0F;

            
            if(m_mypricePerKg.Text.Length > 0)
                mypriceperkg = Utils.ParseFloat(m_mypricePerKg.Text);
			
			float weight = 0;
			
			if(m_weightValue.Text.Length > 0)
			{
                weight = Utils.ParseFloat(m_weightValue.Text);
                m_mypriceLabel.Text = Utils.FormatMoney(mypriceperkg * weight);
			}
			else
                m_mypriceLabel.Text = Utils.FormatMoney(0.0F);

		}

		private void m_setWeightBtn_Click(object sender, System.EventArgs e)
		{
			m_activeLabel = m_weightValue;
			m_weightValue.ForeColor = Color.DarkRed;
			m_mypricePerKg.ForeColor = Color.Black;
			m_btnComa.Enabled = true;
            m_firstClear = true;
			this.Focus();
		}

		private void m_btnComa_Click(object sender, System.EventArgs e)
		{
			if(!m_priceHasComa && m_activeLabel.Text.Length < 6)
			{
                m_activeLabel.Text += Utils.GetDecimalSeparator();
				m_priceHasComa = true;
			}
			this.Focus();
		}

		private void m_btnDel_Click(object sender, System.EventArgs e)
		{
			int len = m_activeLabel.Text.Length;
			if(len > 0)
			{
				len--;
				if(m_activeLabel.Text[len] == Utils.GetDecimalSeparator())
					m_priceHasComa = false;
				m_activeLabel.Text = m_activeLabel.Text.Remove(len,1);
				ComputePrice();
                m_firstClear = false;
			}
			this.Focus();
		}

		private void m_setPricePerKgBtn_Click(object sender, System.EventArgs e)
		{
			m_activeLabel = m_mypricePerKg;
			m_mypricePerKg.ForeColor = Color.DarkRed;
			m_weightValue.ForeColor = Color.Black;
			m_btnComa.Enabled = true;
            m_firstClear = true;
			this.Focus();
		}

		private void MyPriceCalculator_Load(object sender, System.EventArgs e)
		{
            double mypriceperkg = 0.0;
			m_weightValue.Text = m_weight.ToString();

            if (m_weight > 0)
            {
                mypriceperkg = (m_price / m_weight);
                m_mypricePerKg.Text = Utils.FormatMoney(mypriceperkg);
            }
            else
                m_mypricePerKg.Text = Utils.FormatMoney(0.0);
            m_mypriceLabel.Text = Utils.FormatMoney (mypriceperkg * m_weight);          

			m_setPricePerKgBtn_Click(null,null);
			
			
		}

		private void MyPriceCalculator_KeyPress(object sender, KeyPressEventArgs e)
		{
			char chr = e.KeyChar;
			if(chr >= '0' && chr <= '9')
			{
				InsertDigit(Utils.ParseInteger(chr.ToString()));
				e.Handled = true;
			}
			else
			{
				switch(chr)
				{
					case (char)0x08:
						m_btnDel_Click(null,null);
						e.Handled = true;
						break;
					case ',':
					case '.':
						m_btnComa_Click(null,null);
						e.Handled = true;
						break;
					case (char)0x1B:
						m_cancelBtn_Click(null,null);
						e.Handled = true;
						break;
					case (char)0x0D:
						m_setMyPriceBtn_Click(null,null);
						e.Handled = true;
						break;
				}
			}
		}
	}
}
