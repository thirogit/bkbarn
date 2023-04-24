using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace cowbase
{
	/// <summary>
	/// Summary description for ButtonList.
	/// </summary>
	public class ButtonList : CenterForm //System.Windows.Forms.Form
	{
		protected ArrayList m_optArray;
		private object m_keySelected;
        private object m_keyPreSelected;

		private Button[] m_optBtns;
		private TextBox[] m_optBoxes;
		private int m_optOffset;
		private System.Windows.Forms.Button m_cancelBtn;
		private System.Windows.Forms.TextBox m_optBox4;
		private System.Windows.Forms.TextBox m_optBox3;
		private System.Windows.Forms.TextBox m_optBox2;
		private System.Windows.Forms.TextBox m_optBox1;
		private System.Windows.Forms.Button m_OKBtn;
		private System.Windows.Forms.Button m_DnBtn;
		private System.Windows.Forms.Button m_PgDnBtn;
		private System.Windows.Forms.Button m_PgUpBtn;
		private System.Windows.Forms.Button m_UpBtn;
		private System.Windows.Forms.Button m_opt4Btn;
		private System.Windows.Forms.Button m_opt3Btn;
		private System.Windows.Forms.Button m_opt2Btn;
		private System.Windows.Forms.Button m_opt1Btn;
		private Button m_btnSelected;	
		private string m_caption;

		private float m_fontSize = 0.0F;
		private bool m_bBold;

	
		public ButtonList(ArrayList optArray,object keyPreSelected,string caption)
		{
			m_optArray = optArray;

			m_optBtns = new Button[4];
			
			m_optBoxes = new TextBox[4];
            
            m_keyPreSelected = keyPreSelected;
			
			m_caption = (string)caption.Clone();
            			
			InitializeComponent();
			this.KeyUp +=new KeyEventHandler(ButtonList_KeyUp);

			m_UpBtn.Text = new String('\xD9',1);

			
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
            this.m_cancelBtn = new System.Windows.Forms.Button();
            this.m_optBox4 = new System.Windows.Forms.TextBox();
            this.m_optBox3 = new System.Windows.Forms.TextBox();
            this.m_optBox2 = new System.Windows.Forms.TextBox();
            this.m_optBox1 = new System.Windows.Forms.TextBox();
            this.m_OKBtn = new System.Windows.Forms.Button();
            this.m_DnBtn = new System.Windows.Forms.Button();
            this.m_PgDnBtn = new System.Windows.Forms.Button();
            this.m_PgUpBtn = new System.Windows.Forms.Button();
            this.m_UpBtn = new System.Windows.Forms.Button();
            this.m_opt4Btn = new System.Windows.Forms.Button();
            this.m_opt3Btn = new System.Windows.Forms.Button();
            this.m_opt2Btn = new System.Windows.Forms.Button();
            this.m_opt1Btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_cancelBtn
            // 
            this.m_cancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_cancelBtn.Location = new System.Drawing.Point(164, 194);
            this.m_cancelBtn.Name = "m_cancelBtn";
            this.m_cancelBtn.Size = new System.Drawing.Size(74, 40);
            this.m_cancelBtn.TabIndex = 0;
            this.m_cancelBtn.Text = "Anuluj";
            this.m_cancelBtn.Click += new System.EventHandler(this.m_cancelBtn_Click);
            // 
            // m_optBox4
            // 
            this.m_optBox4.Location = new System.Drawing.Point(28, 144);
            this.m_optBox4.Multiline = true;
            this.m_optBox4.Name = "m_optBox4";
            this.m_optBox4.ReadOnly = true;
            this.m_optBox4.Size = new System.Drawing.Size(182, 48);
            this.m_optBox4.TabIndex = 1;
            this.m_optBox4.Text = "__OPT4__";
            this.m_optBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // m_optBox3
            // 
            this.m_optBox3.Location = new System.Drawing.Point(28, 96);
            this.m_optBox3.Multiline = true;
            this.m_optBox3.Name = "m_optBox3";
            this.m_optBox3.ReadOnly = true;
            this.m_optBox3.Size = new System.Drawing.Size(182, 48);
            this.m_optBox3.TabIndex = 2;
            this.m_optBox3.Text = "__OPT3__";
            this.m_optBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // m_optBox2
            // 
            this.m_optBox2.Location = new System.Drawing.Point(28, 48);
            this.m_optBox2.Multiline = true;
            this.m_optBox2.Name = "m_optBox2";
            this.m_optBox2.ReadOnly = true;
            this.m_optBox2.Size = new System.Drawing.Size(182, 48);
            this.m_optBox2.TabIndex = 3;
            this.m_optBox2.Text = "__OPT2__";
            this.m_optBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // m_optBox1
            // 
            this.m_optBox1.Location = new System.Drawing.Point(28, 0);
            this.m_optBox1.Multiline = true;
            this.m_optBox1.Name = "m_optBox1";
            this.m_optBox1.ReadOnly = true;
            this.m_optBox1.Size = new System.Drawing.Size(182, 48);
            this.m_optBox1.TabIndex = 4;
            this.m_optBox1.Text = "__OPT1__";
            this.m_optBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // m_OKBtn
            // 
            this.m_OKBtn.Enabled = false;
            this.m_OKBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_OKBtn.Location = new System.Drawing.Point(0, 194);
            this.m_OKBtn.Name = "m_OKBtn";
            this.m_OKBtn.Size = new System.Drawing.Size(164, 40);
            this.m_OKBtn.TabIndex = 5;
            this.m_OKBtn.Text = "OK";
            this.m_OKBtn.Click += new System.EventHandler(this.m_OKBtn_Click);
            // 
            // m_DnBtn
            // 
            this.m_DnBtn.Font = new System.Drawing.Font("Symbol", 15.75F, System.Drawing.FontStyle.Bold);
            this.m_DnBtn.Location = new System.Drawing.Point(210, 144);
            this.m_DnBtn.Name = "m_DnBtn";
            this.m_DnBtn.Size = new System.Drawing.Size(28, 48);
            this.m_DnBtn.TabIndex = 6;
            this.m_DnBtn.Text = "Ú";
            this.m_DnBtn.Click += new System.EventHandler(this.m_DnBtn_Click);
            // 
            // m_PgDnBtn
            // 
            this.m_PgDnBtn.Font = new System.Drawing.Font("Symbol", 15.75F, System.Drawing.FontStyle.Bold);
            this.m_PgDnBtn.Location = new System.Drawing.Point(210, 96);
            this.m_PgDnBtn.Name = "m_PgDnBtn";
            this.m_PgDnBtn.Size = new System.Drawing.Size(28, 48);
            this.m_PgDnBtn.TabIndex = 7;
            this.m_PgDnBtn.Text = "ß";
            this.m_PgDnBtn.Click += new System.EventHandler(this.m_PgDnBtn_Click);
            // 
            // m_PgUpBtn
            // 
            this.m_PgUpBtn.Font = new System.Drawing.Font("Symbol", 15.75F, System.Drawing.FontStyle.Bold);
            this.m_PgUpBtn.Location = new System.Drawing.Point(210, 48);
            this.m_PgUpBtn.Name = "m_PgUpBtn";
            this.m_PgUpBtn.Size = new System.Drawing.Size(28, 48);
            this.m_PgUpBtn.TabIndex = 8;
            this.m_PgUpBtn.Text = "Ý";
            this.m_PgUpBtn.Click += new System.EventHandler(this.m_PgUpBtn_Click);
            // 
            // m_UpBtn
            // 
            this.m_UpBtn.Font = new System.Drawing.Font("Symbol", 15.75F, System.Drawing.FontStyle.Bold);
            this.m_UpBtn.Location = new System.Drawing.Point(210, 0);
            this.m_UpBtn.Name = "m_UpBtn";
            this.m_UpBtn.Size = new System.Drawing.Size(28, 48);
            this.m_UpBtn.TabIndex = 9;
            this.m_UpBtn.Text = "U";
            this.m_UpBtn.Click += new System.EventHandler(this.m_UpBtn_Click);
            // 
            // m_opt4Btn
            // 
            this.m_opt4Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_opt4Btn.Location = new System.Drawing.Point(0, 144);
            this.m_opt4Btn.Name = "m_opt4Btn";
            this.m_opt4Btn.Size = new System.Drawing.Size(28, 48);
            this.m_opt4Btn.TabIndex = 10;
            this.m_opt4Btn.Text = "X";
            this.m_opt4Btn.Click += new System.EventHandler(this.m_opt4Btn_Click);
            // 
            // m_opt3Btn
            // 
            this.m_opt3Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_opt3Btn.Location = new System.Drawing.Point(0, 96);
            this.m_opt3Btn.Name = "m_opt3Btn";
            this.m_opt3Btn.Size = new System.Drawing.Size(28, 48);
            this.m_opt3Btn.TabIndex = 11;
            this.m_opt3Btn.Text = "X";
            this.m_opt3Btn.Click += new System.EventHandler(this.m_opt3Btn_Click);
            // 
            // m_opt2Btn
            // 
            this.m_opt2Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_opt2Btn.Location = new System.Drawing.Point(0, 48);
            this.m_opt2Btn.Name = "m_opt2Btn";
            this.m_opt2Btn.Size = new System.Drawing.Size(28, 48);
            this.m_opt2Btn.TabIndex = 12;
            this.m_opt2Btn.Text = "X";
            this.m_opt2Btn.Click += new System.EventHandler(this.m_opt2Btn_Click);
            // 
            // m_opt1Btn
            // 
            this.m_opt1Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_opt1Btn.Location = new System.Drawing.Point(0, 0);
            this.m_opt1Btn.Name = "m_opt1Btn";
            this.m_opt1Btn.Size = new System.Drawing.Size(28, 48);
            this.m_opt1Btn.TabIndex = 13;
            this.m_opt1Btn.Text = "X";
            this.m_opt1Btn.Click += new System.EventHandler(this.m_opt1Btn_Click);
            // 
            // ButtonList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(238, 237);
            this.Controls.Add(this.m_cancelBtn);
            this.Controls.Add(this.m_optBox4);
            this.Controls.Add(this.m_optBox3);
            this.Controls.Add(this.m_optBox2);
            this.Controls.Add(this.m_optBox1);
            this.Controls.Add(this.m_OKBtn);
            this.Controls.Add(this.m_DnBtn);
            this.Controls.Add(this.m_PgDnBtn);
            this.Controls.Add(this.m_PgUpBtn);
            this.Controls.Add(this.m_UpBtn);
            this.Controls.Add(this.m_opt4Btn);
            this.Controls.Add(this.m_opt3Btn);
            this.Controls.Add(this.m_opt2Btn);
            this.Controls.Add(this.m_opt1Btn);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ButtonList";
            this.Text = "ButtonList";
            this.Load += new System.EventHandler(this.ButtonList_Load);
            this.ResumeLayout(false);

		}
		#endregion

		protected void SetFont(float size,bool bBold)
		{
			if(size < 10.0F) m_fontSize = 10.0F;
				else	m_fontSize = size;

            m_bBold = bBold;
			
		}


		private void ButtonList_Load(object sender, System.EventArgs e)
		{
			if(m_fontSize > 0.0)
			{	
				Font font = new Font(m_optBox1.Font.Name,m_fontSize, m_bBold ? FontStyle.Bold : FontStyle.Regular);
				m_optBox1.Font = font;
				m_optBox2.Font = font;
				m_optBox3.Font = font;
				m_optBox4.Font = font;
			}	
		
			
			m_optBtns[0] = m_opt1Btn;
			m_optBtns[1] = 	m_opt2Btn;
			m_optBtns[2] = m_opt3Btn;
			m_optBtns[3] = m_opt4Btn;

			m_optBoxes[0] = m_optBox1;
			m_optBoxes[1] = m_optBox2;
			m_optBoxes[2] = m_optBox3;
			m_optBoxes[3] = m_optBox4;
			m_btnSelected = null;

			m_optOffset = 0;

			this.Text = m_caption;

	
			DictionaryEntry entry;
			int i;
			for( i = 0; i < m_optArray.Count; i ++)
			{
				entry = (DictionaryEntry)m_optArray[i];
                if (KeyEquals(entry.Key,m_keyPreSelected))
				{
					if(	m_optArray.Count >= 4)
					{
						if(i > (m_optArray.Count-4))
							m_optOffset = m_optArray.Count-4;
						else
							m_optOffset = i;
					}
					else
						m_optOffset = 0;                    
				}
				

			}
			

			if(m_optArray.Count <= 4)
			{	
				for(i = 0;i < m_optBoxes.Length;i++)
					((TextBox)m_optBoxes[i]).Enabled  = false;
			}

			KeyEventHandler keyDownHandler = new KeyEventHandler(ButtonList_KeyUp);; 
			for(i = 0;i < m_optBoxes.Length;i++)
				((TextBox)m_optBoxes[i]).KeyDown += keyDownHandler;
			
			SetOptCtrls();
			
		
		}

        protected virtual bool KeyEquals(object key, object keySelect)
        {
            return key.Equals(keySelect);
        }

		private void m_opt1Btn_Click(object sender, System.EventArgs e)
		{
			if(m_btnSelected != null)
				m_btnSelected.Text = String.Empty;
			m_btnSelected = m_optBtns[0];
			m_optBtns[0].Text = "X";
			m_keySelected = ((DictionaryEntry)m_optArray[0+m_optOffset]).Key;
			m_OKBtn.Enabled = true;
			this.Focus();
			
		}

		private void m_opt2Btn_Click(object sender, System.EventArgs e)
		{
		
			if(m_btnSelected != null)
				m_btnSelected.Text = String.Empty;
			m_btnSelected = m_optBtns[1];
			m_optBtns[1].Text = "X";
			m_keySelected = ((DictionaryEntry)m_optArray[1+m_optOffset]).Key;	
			m_OKBtn.Enabled = true;
			this.Focus();
		
		}

		private void m_opt3Btn_Click(object sender, System.EventArgs e)
		{
			if(m_btnSelected != null)
				m_btnSelected.Text = String.Empty;
			m_btnSelected = m_optBtns[2];
			m_optBtns[2].Text = "X";
			m_keySelected = ((DictionaryEntry)m_optArray[2+m_optOffset]).Key;
			m_OKBtn.Enabled = true;
			this.Focus();
		
		}

		private void m_opt4Btn_Click(object sender, System.EventArgs e)
		{
			if(m_btnSelected != null)
				m_btnSelected.Text = String.Empty;
			m_btnSelected = m_optBtns[3];
			m_optBtns[3].Text = "X";
			m_keySelected = ((DictionaryEntry)m_optArray[3+m_optOffset]).Key;
			m_OKBtn.Enabled = true;
			this.Focus();
		
		}

		private void SetOptCtrls()
		{

			DictionaryEntry entry;
			for(int i = 0; i < 4; i ++)
			{
				if(i+m_optOffset >= m_optArray.Count)
				{
					m_optBtns[i].Text = String.Empty;
					m_optBtns[i].Enabled = false;
					m_optBtns[i].Visible = false;
					m_optBoxes[i].Text = String.Empty;
					m_optBoxes[i].Enabled = false;
					m_optBoxes[i].Visible = false;
				}
				else
				{
					entry = (DictionaryEntry)m_optArray[i+m_optOffset];
					
					m_optBtns[i].Enabled = true;
                    if (KeyEquals(entry.Key, m_keyPreSelected))
					{
						m_optBtns[i].Text = "X";
						m_btnSelected = m_optBtns[i];
						m_OKBtn.Enabled = true;
                        m_keySelected = entry.Key;
					}
					else 
						m_optBtns[i].Text = String.Empty;

					m_optBoxes[i].Text = entry.Value.ToString();
					m_optBoxes[i].Enabled = true;
					

				}
			}

			//m_progressLbl.Text =  ((m_optOffset*100)/(m_optArray.Count-4)).ToString() + "%";
			


		}

		

		protected void Scroll(int nDelta)
		{
			if(m_optOffset+nDelta < 0)
				m_optOffset = 0;
			else
				if(m_optOffset+nDelta+4 >= m_optArray.Count)
				{
					if(m_optArray.Count > 4)	
						m_optOffset = m_optArray.Count-4;
					else 
						m_optOffset = 0;
				}
			else
				m_optOffset += nDelta;


			SetOptCtrls();
			this.Focus();


		}

		private void m_UpBtn_Click(object sender, System.EventArgs e)
		{
			Scroll(-1);
		}

		private void m_PgUpBtn_Click(object sender, System.EventArgs e)
		{
			Scroll(-3);
		}

		private void m_PgDnBtn_Click(object sender, System.EventArgs e)
		{
			Scroll(3);
		}

		private void m_DnBtn_Click(object sender, System.EventArgs e)
		{
			Scroll(1);
		}

		private void m_OKBtn_Click(object sender, System.EventArgs e)
		{
		
			DialogResult = DialogResult.OK;
			Close();
		}

		public object GetSelected()
		{
			return m_keySelected;
		}

		private void m_cancelBtn_Click(object sender, System.EventArgs e)
		{
			
			DialogResult = DialogResult.Cancel;
			Close();
		
		}

		
		private void ButtonList_KeyUp(object sender, KeyEventArgs e)
		{
			
			switch(e.KeyCode)
			{		
				case Keys.Left:
					m_PgUpBtn_Click(null,null);
				break;
				case Keys.Right:
					m_PgDnBtn_Click(null,null);
				break;
				case Keys.Up:
					m_UpBtn_Click(null,null);
				break;
				case Keys.Down:
					m_DnBtn_Click(null,null);
				break;
				case Keys.Escape:
					m_cancelBtn_Click(null,null);
				break;
				case Keys.Enter:
					m_OKBtn_Click(null,null);
				break;

			}
		}
	}
}
