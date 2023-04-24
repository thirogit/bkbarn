using System;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace cowbase
{
	public abstract class PassSearchDlg : CenterForm
    {
		private System.Windows.Forms.Button m_OKBtn;
		private EaringBCReader m_bcReader;
		private EventHandler MyReadEventHandler;
        
		private System.Windows.Forms.Label m_cowsLeftLabel;
		private int m_cowsLeft;
		private System.Windows.Forms.Button m_activeBtn;
        private int m_curActiveGrp;
        private Buzzer m_buzzer;
        private Button activeGrpBtn;
       
        private CowListBox cowListBox;
        private bool m_searchByGroupEnabled = false;
        private CowGroupAccessor m_cowGroupAccessor;

        public PassSearchDlg(ICollection<Cow> cowArray, CowGroupAccessor cowGroupAccessor)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            m_cowGroupAccessor = cowGroupAccessor;
			m_bcReader = EaringBCReader.GetInstance();
			


            foreach (Cow cow in cowArray)
            {
                AddToList(cow);
            }

            m_cowsLeft = cowArray.Count;
			
            m_curActiveGrp = 0;
			m_activeBtn.Text = m_curActiveGrp.ToString();
            m_buzzer = new Buzzer();

            cowListBox.SetFormatter(new PassSearchCowItemStringFormetter(cowGroupAccessor));
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
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
            this.m_OKBtn = new System.Windows.Forms.Button();
            this.m_cowsLeftLabel = new System.Windows.Forms.Label();
            this.m_activeBtn = new System.Windows.Forms.Button();
            this.activeGrpBtn = new System.Windows.Forms.Button();
            this.cowListBox = new PassSearchCowListBox();
            this.SuspendLayout();
            // 
            // m_OKBtn
            // 
            this.m_OKBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.m_OKBtn.Location = new System.Drawing.Point(0, 232);
            this.m_OKBtn.Name = "m_OKBtn";
            this.m_OKBtn.Size = new System.Drawing.Size(237, 40);
            this.m_OKBtn.TabIndex = 3;
            this.m_OKBtn.Text = "OK";
            this.m_OKBtn.Click += new System.EventHandler(this.m_OKBtn_Click);
            // 
            // m_cowsLeftLabel
            // 
            this.m_cowsLeftLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.m_cowsLeftLabel.Location = new System.Drawing.Point(175, 2);
            this.m_cowsLeftLabel.Name = "m_cowsLeftLabel";
            this.m_cowsLeftLabel.Size = new System.Drawing.Size(48, 24);
            
            this.m_cowsLeftLabel.Text = "999";
            this.m_cowsLeftLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // m_activeBtn
            // 
            this.m_activeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_activeBtn.Location = new System.Drawing.Point(93, 0);
            this.m_activeBtn.Name = "m_activeBtn";
            this.m_activeBtn.Size = new System.Drawing.Size(56, 29);
            this.m_activeBtn.TabIndex = 1;
            this.m_activeBtn.Text = "GRP";
            this.m_activeBtn.Click += new System.EventHandler(this.m_activeBtn_Click);
            // 
            // activeGrpBtn
            // 
            this.activeGrpBtn.BackColor = System.Drawing.Color.White;
            this.activeGrpBtn.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.activeGrpBtn.ForeColor = System.Drawing.Color.Black;
            this.activeGrpBtn.Location = new System.Drawing.Point(0, 0);
            this.activeGrpBtn.Name = "activeGrpBtn";
            this.activeGrpBtn.Size = new System.Drawing.Size(87, 29);
            this.activeGrpBtn.TabIndex = 5;
            this.activeGrpBtn.Text = "Szukaj grupy";
            this.activeGrpBtn.Click += new System.EventHandler(this.activeGrpBtn_Click);
            // 
            // cowListBox
            // 
            this.cowListBox.BackColor = System.Drawing.SystemColors.Window;
            
            
            this.cowListBox.ForeColor = System.Drawing.SystemColors.ControlText;
            
            this.cowListBox.Location = new System.Drawing.Point(0, 35);
            this.cowListBox.Name = "cowListBox";
            this.cowListBox.SelectedIndex = -1;
            
            this.cowListBox.Size = new System.Drawing.Size(237, 180);
            this.cowListBox.TabIndex = 7;
            

          
            // 
            // PassSearchDlg
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(238, 271);
            this.Controls.Add(this.cowListBox);
            this.Controls.Add(this.activeGrpBtn);
            this.Controls.Add(this.m_activeBtn);
            this.Controls.Add(this.m_cowsLeftLabel);
            this.Controls.Add(this.m_OKBtn);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PassSearchDlg";
            this.Text = "Wyszukiwanie paszportów";
            this.Load += new System.EventHandler(this.PassSearchDlg_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void m_OKBtn_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}		
		
		private void OnClosedPassSearchDlg(object sender, EventArgs e)
		{
            m_bcReader.OnRead -= MyReadEventHandler;
			m_bcReader.Finish();
            m_buzzer.DisposeBuzzer();
		}

		private void PassSearchDlg_Load(object sender, System.EventArgs e)
		{
			m_bcReader.Init();
            MyReadEventHandler = new EventHandler(this.ReaderNotify);
            m_bcReader.OnRead += MyReadEventHandler;

			this.Closed += new EventHandler(OnClosedPassSearchDlg);
			

            m_activeBtn.Enabled = m_searchByGroupEnabled;
			m_cowsLeftLabel.Text = m_cowsLeft.ToString();
			
            if (!m_buzzer.InitBuzzer())
            {
                BigOKMessageBox.ShowMessage("AUDIO", "Nie udalo sie zainicjalizowac urzadzenia AUDIO.");
            }           
	
		}

        private void SetSearchResultColor(Color resultColor)
        {
            this.BackColor = resultColor;
            cowListBox.BackColor = resultColor;
		
        }

		private void ReaderNotify(object sender, System.EventArgs e)
		{
            PassSearchCowItem cowItem;	
			Cow cow;

            for (int i = 0; i < cowListBox.GetItemCount(); i++)
			{
                cowItem = (PassSearchCowItem)cowListBox.GetItem(i);
                cow = cowItem.cow;
                if (cow.EAN.Equals(sender))
				{
					
                    cowListBox.SelectItem(i);

                    if (m_searchByGroupEnabled && GetCowGroup(cow) != m_curActiveGrp)
					{
                        SetSearchResultColor(Color.Blue);                        
					}
					else
					{
                        if (!cowItem.passportFound)
						{
                            cowItem.passportFound = true;
                         
							m_cowsLeft--;
							m_cowsLeftLabel.Text = m_cowsLeft.ToString();
						}
                        SetSearchResultColor(Color.GreenYellow);
                        cowListBox.Invalidate();
					}
                    
					m_buzzer.Buzz(BuzzerDevice.BuzzerSignals.GOOD);
					return;
				}
			}
            SetSearchResultColor(Color.Red);
            m_buzzer.Buzz(BuzzerDevice.BuzzerSignals.BAD);
			
		}

		protected void AddToList(Cow cow)
		{
		      cowListBox.AddItem(new PassSearchCowItem(cow));
		}	

		private void m_activeBtn_Click(object sender, System.EventArgs e)
		{
			ChooseGroup chooseGrp = new ChooseGroup(m_curActiveGrp,"Wybierz grupê");
			if(chooseGrp.ShowDialog() == DialogResult.OK)
			{
				m_curActiveGrp = (int)chooseGrp.GetSelected();
				m_activeBtn.Text = m_curActiveGrp.ToString();
			}
		}

        protected int GetCowGroup(Cow cow)
        {
            return m_cowGroupAccessor.GetGroup(cow);
        }

        private void activeGrpBtn_Click(object sender, EventArgs e)
        {
            m_searchByGroupEnabled = !m_searchByGroupEnabled;
            m_activeBtn.Enabled = m_searchByGroupEnabled;

            if (m_searchByGroupEnabled)
            {
                activeGrpBtn.ForeColor = System.Drawing.Color.White;
                activeGrpBtn.BackColor = System.Drawing.Color.Black;
            }
            else
            {
                activeGrpBtn.ForeColor = System.Drawing.Color.Black;
                activeGrpBtn.BackColor = System.Drawing.Color.White;
            }
        }

	}
}
