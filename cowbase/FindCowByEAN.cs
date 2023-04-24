using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.Common;

namespace cowbase
{
	public class FindCowByEAN : CenterForm
	{
		private System.Windows.Forms.Button m_delLastNum;
		private System.Windows.Forms.Button m_backBtn;
		protected System.Windows.Forms.Button m_OKbtn;
		private System.Windows.Forms.Button num9;
		private System.Windows.Forms.Button m_num8;
		private System.Windows.Forms.Button m_num7;
		private System.Windows.Forms.Button m_num6;
		private System.Windows.Forms.Button m_num5;
		private System.Windows.Forms.Button m_num4;
		private System.Windows.Forms.Button m_num3;
		private System.Windows.Forms.Button m_num2;
		protected System.Windows.Forms.TextBox eanBox;
		private System.Windows.Forms.Label m_foundCount;
		private System.Windows.Forms.Button m_num1;
		private System.Windows.Forms.Button m_num0;
		protected string m_gotchaEAN;
		protected bool m_onlyAvailable;
		
	
		public FindCowByEAN(bool onlyAvailable)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			this.KeyPress += new KeyPressEventHandler(FindCowByEAN_KeyPress);
			eanBox.KeyPress += new KeyPressEventHandler(FindCowByEAN_KeyPress);
			m_onlyAvailable = onlyAvailable;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			base.Dispose( disposing );
		}

		protected virtual void InsertDigit(int digit)
		{
			if(eanBox.TextLength < 12)
				eanBox.Text += digit.ToString();
			AskDB();
			this.Focus();// return focus to main form so it can receive keypress event
			
		}

		public string EANFound
		{
			get 
			{
				return m_gotchaEAN;
			}
			
		}


        private void AskDB()
        {

            if (eanBox.TextLength > 0)
            {
                string cowCountQ = "SELECT count(*) FROM cattle WHERE ean LIKE '%" + eanBox.Text + "%'";
                
                if (m_onlyAvailable) cowCountQ += " AND docout IS NULL";
               
                
                try
                {
                    long cowCount = SQLDB.ExecuteCount(cowCountQ);
                    if (cowCount != 1)
                    {
                        m_OKbtn.Enabled = false;
                        m_foundCount.Text = "Znaleziono: " + cowCount.ToString();
                    }
                    else
                    {
                        string cowQ = "SELECT ean FROM cattle WHERE ean LIKE '%" + eanBox.Text + "%'";
                        DbDataReader reader = SQLDB.ExecuteQuery(cowQ);

                        reader.Read();
                        m_gotchaEAN = reader.GetString(reader.GetOrdinal("ean"));
                        m_foundCount.Text = m_gotchaEAN;
                        m_OKbtn.Enabled = true;
                        reader.Close();
                    }
                    
                }
                catch (SystemException e)
                {
                    throw new SystemException("EANPART = " + eanBox.Text, e);
                }               

            }
            else
            {
                m_OKbtn.Enabled = false;
                m_foundCount.Text = String.Empty;
            }



        }
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.m_delLastNum = new System.Windows.Forms.Button();
			this.m_backBtn = new System.Windows.Forms.Button();
			this.m_OKbtn = new System.Windows.Forms.Button();
			this.m_foundCount = new System.Windows.Forms.Label();
			this.num9 = new System.Windows.Forms.Button();
			this.m_num8 = new System.Windows.Forms.Button();
			this.m_num7 = new System.Windows.Forms.Button();
			this.m_num6 = new System.Windows.Forms.Button();
			this.m_num5 = new System.Windows.Forms.Button();
			this.m_num4 = new System.Windows.Forms.Button();
			this.m_num3 = new System.Windows.Forms.Button();
			this.m_num2 = new System.Windows.Forms.Button();
			this.m_num1 = new System.Windows.Forms.Button();
			this.eanBox = new System.Windows.Forms.TextBox();
			this.m_num0 = new System.Windows.Forms.Button();
			// 
			// m_delLastNum
			// 
			this.m_delLastNum.Location = new System.Drawing.Point(144, 24);
			this.m_delLastNum.Size = new System.Drawing.Size(40, 96);
			this.m_delLastNum.Text = "<<";
			this.m_delLastNum.Click += new System.EventHandler(this.m_delLastNum_Click);
			// 
			// m_backBtn
			// 
			this.m_backBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
			this.m_backBtn.Location = new System.Drawing.Point(88, 192);
			this.m_backBtn.Size = new System.Drawing.Size(96, 40);
			this.m_backBtn.Text = "Wstecz";
			this.m_backBtn.Click += new System.EventHandler(this.m_backBtn_Click);
			// 
			// m_OKbtn
			// 
			this.m_OKbtn.Enabled = false;
			this.m_OKbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
			this.m_OKbtn.Location = new System.Drawing.Point(0, 192);
			this.m_OKbtn.Size = new System.Drawing.Size(88, 40);
			this.m_OKbtn.Text = "OK";
			this.m_OKbtn.Click += new System.EventHandler(this.m_OKbtn_Click);
			// 
			// m_foundCount
			// 
			this.m_foundCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
			this.m_foundCount.Location = new System.Drawing.Point(0, 168);
			this.m_foundCount.Size = new System.Drawing.Size(184, 20);
			this.m_foundCount.Text = "__FOUND__";
			this.m_foundCount.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// num9
			// 
			this.num9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
			this.num9.Location = new System.Drawing.Point(96, 120);
			this.num9.Size = new System.Drawing.Size(48, 48);
			this.num9.Text = "9";
			this.num9.Click += new System.EventHandler(this.num9_Click);
			// 
			// m_num8
			// 
			this.m_num8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
			this.m_num8.Location = new System.Drawing.Point(48, 120);
			this.m_num8.Size = new System.Drawing.Size(48, 48);
			this.m_num8.Text = "8";
			this.m_num8.Click += new System.EventHandler(this.m_num8_Click);
			// 
			// m_num7
			// 
			this.m_num7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
			this.m_num7.Location = new System.Drawing.Point(0, 120);
			this.m_num7.Size = new System.Drawing.Size(48, 48);
			this.m_num7.Text = "7";
			this.m_num7.Click += new System.EventHandler(this.m_num7_Click);
			// 
			// m_num6
			// 
			this.m_num6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
			this.m_num6.Location = new System.Drawing.Point(96, 72);
			this.m_num6.Size = new System.Drawing.Size(48, 48);
			this.m_num6.Text = "6";
			this.m_num6.Click += new System.EventHandler(this.m_num6_Click);
			// 
			// m_num5
			// 
			this.m_num5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
			this.m_num5.Location = new System.Drawing.Point(48, 72);
			this.m_num5.Size = new System.Drawing.Size(48, 48);
			this.m_num5.Text = "5";
			this.m_num5.Click += new System.EventHandler(this.m_num5_Click);
			// 
			// m_num4
			// 
			this.m_num4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
			this.m_num4.Location = new System.Drawing.Point(0, 72);
			this.m_num4.Size = new System.Drawing.Size(48, 48);
			this.m_num4.Text = "4";
			this.m_num4.Click += new System.EventHandler(this.m_num4_Click);
			// 
			// m_num3
			// 
			this.m_num3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
			this.m_num3.Location = new System.Drawing.Point(96, 24);
			this.m_num3.Size = new System.Drawing.Size(48, 48);
			this.m_num3.Text = "3";
			this.m_num3.Click += new System.EventHandler(this.m_num3_Click);
			// 
			// m_num2
			// 
			this.m_num2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
			this.m_num2.Location = new System.Drawing.Point(48, 24);
			this.m_num2.Size = new System.Drawing.Size(48, 48);
			this.m_num2.Text = "2";
			this.m_num2.Click += new System.EventHandler(this.m_num2_Click);
			// 
			// m_num1
			// 
			this.m_num1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
			this.m_num1.Location = new System.Drawing.Point(0, 24);
			this.m_num1.Size = new System.Drawing.Size(48, 48);
			this.m_num1.Text = "1";
			this.m_num1.Click += new System.EventHandler(this.m_num1_Click);
			// 
			// eanBox
			// 
			this.eanBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
			this.eanBox.MaxLength = 10;
			this.eanBox.ReadOnly = true;
			this.eanBox.Size = new System.Drawing.Size(184, 26);
			this.eanBox.Text = "__EAN__";
			// 
			// m_num0
			// 
			this.m_num0.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
			this.m_num0.Location = new System.Drawing.Point(144, 120);
			this.m_num0.Size = new System.Drawing.Size(40, 48);
			this.m_num0.Text = "0";
			this.m_num0.Click += new System.EventHandler(this.m_num0_Click);
			// 
			// FindCowByEAN
			// 
			this.ClientSize = new System.Drawing.Size(186, 231);
			this.Controls.Add(this.m_num0);
			this.Controls.Add(this.eanBox);
			this.Controls.Add(this.m_delLastNum);
			this.Controls.Add(this.m_backBtn);
			this.Controls.Add(this.m_OKbtn);
			this.Controls.Add(this.m_foundCount);
			this.Controls.Add(this.num9);
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
			this.Text = "Szukaj numeru";
			this.Load += new System.EventHandler(this.FindCowByEAN_Load);

		}
		#endregion

		private void m_num1_Click(object sender, System.EventArgs e)
		{
			InsertDigit(1);
		}

		private void m_num2_Click(object sender, System.EventArgs e)
		{
			InsertDigit(2);
		}

		private void m_num3_Click(object sender, System.EventArgs e)
		{
			InsertDigit(3);
		}

		private void m_num4_Click(object sender, System.EventArgs e)
		{
			InsertDigit(4);
		}

		private void m_num5_Click(object sender, System.EventArgs e)
		{
			InsertDigit(5);
		}

		private void m_num6_Click(object sender, System.EventArgs e)
		{
			InsertDigit(6);
		}

		private void m_num7_Click(object sender, System.EventArgs e)
		{
			InsertDigit(7);
		}

		private void m_num8_Click(object sender, System.EventArgs e)
		{
			InsertDigit(8);
		}

		private void num9_Click(object sender, System.EventArgs e)
		{
			InsertDigit(9);
		}

		protected virtual void m_delLastNum_Click(object sender, System.EventArgs e)
		{
			if(eanBox.TextLength > 0)
			{
				eanBox.Text = eanBox.Text.Remove(eanBox.TextLength-1,1);
				AskDB();
			}
			this.Focus();
			
			
		}

		protected virtual void FindCowByEAN_Load(object sender, System.EventArgs e)
		{
			eanBox.Text = String.Empty;
			m_foundCount.Text = String.Empty;
			
		}

		private void m_OKbtn_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

		private void m_backBtn_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void m_num0_Click(object sender, System.EventArgs e)
		{
			InsertDigit(0);
		}

		private void FindCowByEAN_KeyPress(object sender, KeyPressEventArgs e)
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
						m_delLastNum_Click(null,null);
						e.Handled = true;
						break;
					case (char)0x0D:
						if(m_OKbtn.Enabled)
						{
							m_OKbtn_Click(null,null);
							e.Handled = true;
						}
						break;
					case (char)0x1B: //escape
						m_backBtn_Click(null,null);
						e.Handled = true;
						break;
				}

			}
			

		}

		
	}
}
