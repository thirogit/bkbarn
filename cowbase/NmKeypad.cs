using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace cowbase
{
	/// <summary>
	/// Summary description for NmKeypad.
	/// </summary>
	public class NumKeypad : CenterForm //System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button m_num1;
		private System.Windows.Forms.Button m_num2;
		private System.Windows.Forms.Button m_num3;
		private System.Windows.Forms.Button m_num6;
		private System.Windows.Forms.Button m_num5;
		private System.Windows.Forms.Button m_num4;
		private System.Windows.Forms.Button m_num8;
		private System.Windows.Forms.Button m_num7;
		private System.Windows.Forms.Label m_numValue;
		private System.Windows.Forms.Button m_OKbtn;
		private System.Windows.Forms.Button m_delLastNum;
		private System.Windows.Forms.Button m_comaBtn;
		private System.Windows.Forms.Button m_num0;
		private System.Windows.Forms.Button m_num9;
		private System.Windows.Forms.Button m_backBtn;
        private bool m_hasComa;
        private bool m_firstClear;
        private bool m_allowNull;


        private int floatPrecision = 2;


        public int FloatPrecision
        {
            get
            {
                return floatPrecision;
            }
            set
            {
                floatPrecision = Math.Max(2, value);
            }
        }

		public bool ComaEnable
		{
			get 
			{
				return m_comaBtn.Enabled;
			}
			set
			{
				m_comaBtn.Enabled = value;
			}
		}

        public bool AllowNull
        {
            get
            {
                return m_allowNull;
            }
            set
            {
                m_allowNull = value;
            }
        }  
        

		public Nullable<int> IntValue
		{
			get 
			{
                if (m_numValue.Text.Length == 0)
                    return null;
                else
				    return Utils.ParseInteger(m_numValue.Text);
			}
			set
			{
                if (value.HasValue)
                {
                    m_numValue.Text = value.Value.ToString();
                    m_hasComa = false;
                }
                else
                {
                    m_numValue.Text = String.Empty;
                }
			}
		}
		public Nullable<double> DoubleValue
		{
			get 
			{
                if(m_numValue.Text.Length == 0)
                    return null;
                else
                    return Utils.ParseFloat(m_numValue.Text);
			}
			set
			{
                if (value.HasValue)
                {
                    m_numValue.Text = Utils.FormatFloat(value.Value, floatPrecision);
                    m_hasComa = m_numValue.Text.IndexOf(Utils.GetDecimalSeparator(), 0) >= 0;
                }
                else
                {
                    m_numValue.Text = string.Empty;
                }
			}
		}	
	
		public NumKeypad(string caption)
		{
			InitializeComponent();
			this.KeyPress += new KeyPressEventHandler(NumKeypad_KeyPress);
			this.Text = caption;
			m_hasComa = false;
            m_firstClear = true;
            m_allowNull = false;
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
            this.m_num1 = new System.Windows.Forms.Button();
            this.m_num2 = new System.Windows.Forms.Button();
            this.m_num3 = new System.Windows.Forms.Button();
            this.m_num6 = new System.Windows.Forms.Button();
            this.m_num5 = new System.Windows.Forms.Button();
            this.m_num4 = new System.Windows.Forms.Button();
            this.m_num9 = new System.Windows.Forms.Button();
            this.m_num8 = new System.Windows.Forms.Button();
            this.m_num7 = new System.Windows.Forms.Button();
            this.m_numValue = new System.Windows.Forms.Label();
            this.m_OKbtn = new System.Windows.Forms.Button();
            this.m_backBtn = new System.Windows.Forms.Button();
            this.m_delLastNum = new System.Windows.Forms.Button();
            this.m_comaBtn = new System.Windows.Forms.Button();
            this.m_num0 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_num1
            // 
            this.m_num1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_num1.Location = new System.Drawing.Point(0, 0);
            this.m_num1.Name = "m_num1";
            this.m_num1.Size = new System.Drawing.Size(78, 36);
            this.m_num1.TabIndex = 14;
            this.m_num1.Text = "1";
            this.m_num1.Click += new System.EventHandler(this.m_num1_Click);
            // 
            // m_num2
            // 
            this.m_num2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_num2.Location = new System.Drawing.Point(78, 0);
            this.m_num2.Name = "m_num2";
            this.m_num2.Size = new System.Drawing.Size(78, 36);
            this.m_num2.TabIndex = 13;
            this.m_num2.Text = "2";
            this.m_num2.Click += new System.EventHandler(this.m_num2_Click);
            // 
            // m_num3
            // 
            this.m_num3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_num3.Location = new System.Drawing.Point(156, 0);
            this.m_num3.Name = "m_num3";
            this.m_num3.Size = new System.Drawing.Size(78, 36);
            this.m_num3.TabIndex = 12;
            this.m_num3.Text = "3";
            this.m_num3.Click += new System.EventHandler(this.m_num3_Click);
            // 
            // m_num6
            // 
            this.m_num6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_num6.Location = new System.Drawing.Point(156, 36);
            this.m_num6.Name = "m_num6";
            this.m_num6.Size = new System.Drawing.Size(78, 36);
            this.m_num6.TabIndex = 9;
            this.m_num6.Text = "6";
            this.m_num6.Click += new System.EventHandler(this.m_num6_Click);
            // 
            // m_num5
            // 
            this.m_num5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_num5.Location = new System.Drawing.Point(78, 36);
            this.m_num5.Name = "m_num5";
            this.m_num5.Size = new System.Drawing.Size(78, 36);
            this.m_num5.TabIndex = 10;
            this.m_num5.Text = "5";
            this.m_num5.Click += new System.EventHandler(this.m_num5_Click);
            // 
            // m_num4
            // 
            this.m_num4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_num4.Location = new System.Drawing.Point(0, 36);
            this.m_num4.Name = "m_num4";
            this.m_num4.Size = new System.Drawing.Size(78, 36);
            this.m_num4.TabIndex = 11;
            this.m_num4.Text = "4";
            this.m_num4.Click += new System.EventHandler(this.m_num4_Click);
            // 
            // m_num9
            // 
            this.m_num9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_num9.Location = new System.Drawing.Point(156, 72);
            this.m_num9.Name = "m_num9";
            this.m_num9.Size = new System.Drawing.Size(78, 36);
            this.m_num9.TabIndex = 6;
            this.m_num9.Text = "9";
            this.m_num9.Click += new System.EventHandler(this.num9_Click);
            // 
            // m_num8
            // 
            this.m_num8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_num8.Location = new System.Drawing.Point(78, 72);
            this.m_num8.Name = "m_num8";
            this.m_num8.Size = new System.Drawing.Size(78, 36);
            this.m_num8.TabIndex = 7;
            this.m_num8.Text = "8";
            this.m_num8.Click += new System.EventHandler(this.m_num8_Click);
            // 
            // m_num7
            // 
            this.m_num7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_num7.Location = new System.Drawing.Point(0, 72);
            this.m_num7.Name = "m_num7";
            this.m_num7.Size = new System.Drawing.Size(78, 36);
            this.m_num7.TabIndex = 8;
            this.m_num7.Text = "7";
            this.m_num7.Click += new System.EventHandler(this.m_num7_Click);
            // 
            // m_numValue
            // 
            this.m_numValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_numValue.Location = new System.Drawing.Point(0, 144);
            this.m_numValue.Name = "m_numValue";
            this.m_numValue.Size = new System.Drawing.Size(235, 29);
            this.m_numValue.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // m_OKbtn
            // 
            this.m_OKbtn.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.m_OKbtn.Location = new System.Drawing.Point(0, 173);
            this.m_OKbtn.Name = "m_OKbtn";
            this.m_OKbtn.Size = new System.Drawing.Size(118, 40);
            this.m_OKbtn.TabIndex = 4;
            this.m_OKbtn.Text = "OK";
            this.m_OKbtn.Click += new System.EventHandler(this.m_OKbtn_Click);
            // 
            // m_backBtn
            // 
            this.m_backBtn.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.m_backBtn.Location = new System.Drawing.Point(118, 173);
            this.m_backBtn.Name = "m_backBtn";
            this.m_backBtn.Size = new System.Drawing.Size(117, 40);
            this.m_backBtn.TabIndex = 3;
            this.m_backBtn.Text = "Wstecz";
            this.m_backBtn.Click += new System.EventHandler(this.m_backBtn_Click);
            // 
            // m_delLastNum
            // 
            this.m_delLastNum.Location = new System.Drawing.Point(156, 108);
            this.m_delLastNum.Name = "m_delLastNum";
            this.m_delLastNum.Size = new System.Drawing.Size(78, 36);
            this.m_delLastNum.TabIndex = 2;
            this.m_delLastNum.Text = "<<";
            this.m_delLastNum.Click += new System.EventHandler(this.m_delLastNum_Click);
            // 
            // m_comaBtn
            // 
            this.m_comaBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_comaBtn.Location = new System.Drawing.Point(0, 108);
            this.m_comaBtn.Name = "m_comaBtn";
            this.m_comaBtn.Size = new System.Drawing.Size(78, 36);
            this.m_comaBtn.TabIndex = 1;
            this.m_comaBtn.Text = ".";
            this.m_comaBtn.Click += new System.EventHandler(this.m_comaBtn_Click);
            // 
            // m_num0
            // 
            this.m_num0.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_num0.Location = new System.Drawing.Point(78, 108);
            this.m_num0.Name = "m_num0";
            this.m_num0.Size = new System.Drawing.Size(78, 36);
            this.m_num0.TabIndex = 0;
            this.m_num0.Text = "0";
            this.m_num0.Click += new System.EventHandler(this.m_num0_Click);
            // 
            // NumKeypad
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(235, 214);
            this.Controls.Add(this.m_num0);
            this.Controls.Add(this.m_comaBtn);
            this.Controls.Add(this.m_delLastNum);
            this.Controls.Add(this.m_backBtn);
            this.Controls.Add(this.m_OKbtn);
            this.Controls.Add(this.m_numValue);
            this.Controls.Add(this.m_num9);
            this.Controls.Add(this.m_num8);
            this.Controls.Add(this.m_num7);
            this.Controls.Add(this.m_num6);
            this.Controls.Add(this.m_num5);
            this.Controls.Add(this.m_num4);
            this.Controls.Add(this.m_num3);
            this.Controls.Add(this.m_num2);
            this.Controls.Add(this.m_num1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NumKeypad";
            this.Text = "Klawiatura numeryczna";
            this.Load += new System.EventHandler(this.NumKeypad_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void m_OKbtn_Click(object sender, System.EventArgs e)
		{
            if (m_numValue.Text.Length > 0 || m_allowNull)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
                BigOKMessageBox.ShowMessage("Brak wartosci","Wprowadz wartosc");
		}
		
		private void NumKeypad_Load(object sender, System.EventArgs e)
		{
            
		}

		private void m_num1_Click(object sender, System.EventArgs e)
		{
			InsertDigit(1);
		}

		private void m_backBtn_Click(object sender, System.EventArgs e)
		{

			DialogResult = DialogResult.Cancel;
			Close();
		
		}

		private void m_num2_Click(object sender, System.EventArgs e)
		{
			InsertDigit(2);
		}

		private void m_num3_Click(object sender, System.EventArgs e)
		{
			InsertDigit(3);
		}

		private void m_num6_Click(object sender, System.EventArgs e)
		{
			InsertDigit(6);
		}

		private void num9_Click(object sender, System.EventArgs e)
		{
			InsertDigit(9);
		}

		

		private void m_num5_Click(object sender, System.EventArgs e)
		{
			InsertDigit(5);
		}

		private void m_num4_Click(object sender, System.EventArgs e)
		{
			InsertDigit(4);
		}

		private void m_num7_Click(object sender, System.EventArgs e)
		{
			InsertDigit(7);
		}

		private void m_num8_Click(object sender, System.EventArgs e)
		{
			InsertDigit(8);
		}

		private void m_num0_Click(object sender, System.EventArgs e)
		{
			InsertDigit(0);
		}

		private void m_comaBtn_Click(object sender, System.EventArgs e)
		{
			if(!m_hasComa && m_numValue.Text.Length < 10)
			{
				m_numValue.Text += '.';
				m_hasComa = true;
			}
			this.Focus();
		}

		private void InsertDigit(int digit)
		{
            if (m_numValue.Text.Length < 10)
            {
                
                if(m_firstClear)
                {
                    m_numValue.Text = String.Empty;
                    m_firstClear = false;
                    m_hasComa = false;
                }
				
                m_numValue.Text += digit.ToString();

            }
			this.Focus();			
		}

		private void m_delLastNum_Click(object sender, System.EventArgs e)
		{
			int len = m_numValue.Text.Length;
			if(len > 0)
			{
				len--;
				if(m_numValue.Text[len] == '.')
					m_hasComa = false;
				m_numValue.Text = m_numValue.Text.Remove(len,1);
                m_firstClear = false;
			}
			this.Focus();
		}

		private void NumKeypad_KeyPress(object sender, KeyPressEventArgs e)
		{
			
			char chr = e.KeyChar;
			if(chr >= '0' && chr <= '9')
				InsertDigit(Utils.ParseInteger(chr.ToString()));
			else
			{
				switch(chr)
				{
					case '.':
					case ',':
						if(m_comaBtn.Enabled)
							m_comaBtn_Click(null,null);
						break;
					case (char)0x08:
						m_delLastNum_Click(null,null);
						break;
					case (char)0x0D:
						m_OKbtn_Click(null,null);
						break;
					case (char)0x1B:
						m_backBtn_Click(null,null);
						break;


				}
			}
			//e.Handled = true;
		}

     
	}
}
