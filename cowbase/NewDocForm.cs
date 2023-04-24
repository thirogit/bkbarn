using System;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.Common;

namespace cowbase
{
    public abstract class NewDocForm : CenterForm
    {

		protected int m_CurReason;
        protected int m_CurHent;
		protected EaringBCReader m_bcReader = EaringBCReader.GetInstance();
        private EventHandler EaringReadHandler;        
        protected bool m_lockBCReader;
        protected int m_curActiveGrp;
        protected Button m_SetGrpBtn;
        private Button m_CancelBtn;
        private Button m_AddBtn;
        protected CowListBox cowListBox;
        protected Button m_setGrpCheckBox;
        protected Button m_activeGrp;
        private Button m_DelBtn;
        private Button m_EditBtn;
        private Button m_AddCowBtn;
        private TabControl tabControl1;
        private TabPage docTabPage;
        private Label m_cowCountLabel;
        private Label label1;
        protected Label m_reasonLbl;
        private Button m_reasonBtn;
        private Button m_plateNoBtn;
        protected TextBox m_plateNoBox;
        private Button m_hentBtn;
        protected TextBox m_hentBox;
        private TabPage cowsTabPage;
        protected bool m_activeGrpSettingEnabled = false;

		public NewDocForm()
		{
			InitializeComponent();
			
			m_CurReason = GetDefaultReasonId();
			m_CurHent = 0;
			
			m_lockBCReader = false;
			m_curActiveGrp = 0;
            m_SetGrpBtn.Text = m_curActiveGrp.ToString();
		}

		protected int GetDefaultReasonId()
		{
            string reasonQ = "SELECT reasonid FROM inoutreasons WHERE reasoncode = '" + GetDefaultReasonCode() + '\'';
            try
            {
                return (int)SQLDB.ExecuteScalar(reasonQ);
            }
            catch (SystemException sqlEx)
            {
                LOG.DoLog("GetDefaultReasonId(): QUERY = " + reasonQ + " MSG = " + sqlEx.Message);
            }
            return 0;
		}

		protected abstract string GetCaption();
		

		protected abstract string GetDefaultReasonCode();
		
		protected abstract int GetInOut();

		protected abstract bool DeleteCow(Cow cowd);

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
            this.m_SetGrpBtn = new System.Windows.Forms.Button();
            this.m_CancelBtn = new System.Windows.Forms.Button();
            this.m_AddBtn = new System.Windows.Forms.Button();
            this.cowListBox = new cowbase.CowListBox();
            this.m_setGrpCheckBox = new System.Windows.Forms.Button();
            this.m_activeGrp = new System.Windows.Forms.Button();
            this.m_DelBtn = new System.Windows.Forms.Button();
            this.m_EditBtn = new System.Windows.Forms.Button();
            this.m_AddCowBtn = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.docTabPage = new System.Windows.Forms.TabPage();
            this.m_cowCountLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_reasonLbl = new System.Windows.Forms.Label();
            this.m_reasonBtn = new System.Windows.Forms.Button();
            this.m_plateNoBtn = new System.Windows.Forms.Button();
            this.m_plateNoBox = new System.Windows.Forms.TextBox();
            this.m_hentBtn = new System.Windows.Forms.Button();
            this.m_hentBox = new System.Windows.Forms.TextBox();
            this.cowsTabPage = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.docTabPage.SuspendLayout();
            this.cowsTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_SetGrpBtn
            // 
            this.m_SetGrpBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_SetGrpBtn.Location = new System.Drawing.Point(77, 0);
            this.m_SetGrpBtn.Name = "m_SetGrpBtn";
            this.m_SetGrpBtn.Size = new System.Drawing.Size(77, 26);
            this.m_SetGrpBtn.TabIndex = 23;
            this.m_SetGrpBtn.Text = "_GRP_";
            this.m_SetGrpBtn.Click += new System.EventHandler(this.m_SetGrpBtn_Click);
            // 
            // m_CancelBtn
            // 
            this.m_CancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_CancelBtn.Location = new System.Drawing.Point(119, 248);
            this.m_CancelBtn.Name = "m_CancelBtn";
            this.m_CancelBtn.Size = new System.Drawing.Size(116, 27);
            this.m_CancelBtn.TabIndex = 33;
            this.m_CancelBtn.Text = "Anuluj";
            this.m_CancelBtn.Click += new System.EventHandler(this.m_CancelBtn_Click);
            // 
            // m_AddBtn
            // 
            this.m_AddBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_AddBtn.Location = new System.Drawing.Point(3, 250);
            this.m_AddBtn.Name = "m_AddBtn";
            this.m_AddBtn.Size = new System.Drawing.Size(110, 25);
            this.m_AddBtn.TabIndex = 34;
            this.m_AddBtn.Text = "WprowadŸ";
            this.m_AddBtn.Click += new System.EventHandler(this.AddBtnClick);
            // 
            // cowListBox
            // 
            this.cowListBox.BackColor = System.Drawing.SystemColors.Window;
            
            
            this.cowListBox.ForeColor = System.Drawing.SystemColors.ControlText;
            
            this.cowListBox.Location = new System.Drawing.Point(0, 32);
            this.cowListBox.Name = "cowListBox";
            this.cowListBox.SelectedIndex = -1;
            
            this.cowListBox.Size = new System.Drawing.Size(229, 150);
            this.cowListBox.TabIndex = 50;
            
            // 
            // m_setGrpCheckBox
            // 
            this.m_setGrpCheckBox.BackColor = System.Drawing.Color.White;
            this.m_setGrpCheckBox.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.m_setGrpCheckBox.ForeColor = System.Drawing.Color.Black;
            this.m_setGrpCheckBox.Location = new System.Drawing.Point(154, 0);
            this.m_setGrpCheckBox.Name = "m_setGrpCheckBox";
            this.m_setGrpCheckBox.Size = new System.Drawing.Size(77, 26);
            this.m_setGrpCheckBox.TabIndex = 45;
            this.m_setGrpCheckBox.Text = "Ustawiaj";
            this.m_setGrpCheckBox.Click += new System.EventHandler(this.m_setGrpCheckBox_Click);
            // 
            // m_activeGrp
            // 
            this.m_activeGrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.m_activeGrp.Location = new System.Drawing.Point(0, 0);
            this.m_activeGrp.Name = "m_activeGrp";
            this.m_activeGrp.Size = new System.Drawing.Size(77, 26);
            this.m_activeGrp.TabIndex = 46;
            this.m_activeGrp.Text = "Akt. grupa";
            this.m_activeGrp.Click += new System.EventHandler(this.m_activeGrp_Click);
            // 
            // m_DelBtn
            // 
            this.m_DelBtn.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.m_DelBtn.Location = new System.Drawing.Point(154, 188);
            this.m_DelBtn.Name = "m_DelBtn";
            this.m_DelBtn.Size = new System.Drawing.Size(74, 26);
            this.m_DelBtn.TabIndex = 47;
            this.m_DelBtn.Text = "Usun";
            this.m_DelBtn.Click += new System.EventHandler(this.m_DelBtn_Click);
            // 
            // m_EditBtn
            // 
            this.m_EditBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.m_EditBtn.Location = new System.Drawing.Point(77, 188);
            this.m_EditBtn.Name = "m_EditBtn";
            this.m_EditBtn.Size = new System.Drawing.Size(77, 26);
            this.m_EditBtn.TabIndex = 48;
            this.m_EditBtn.Text = "Edytuj";
            this.m_EditBtn.Click += new System.EventHandler(this.m_EditBtn_Click);
            // 
            // m_AddCowBtn
            // 
            this.m_AddCowBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.m_AddCowBtn.Location = new System.Drawing.Point(0, 188);
            this.m_AddCowBtn.Name = "m_AddCowBtn";
            this.m_AddCowBtn.Size = new System.Drawing.Size(77, 26);
            this.m_AddCowBtn.TabIndex = 49;
            this.m_AddCowBtn.Text = "Dodaj";
            this.m_AddCowBtn.Click += new System.EventHandler(this.AddCowBtnClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.docTabPage);
            this.tabControl1.Controls.Add(this.cowsTabPage);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(240, 245);
            this.tabControl1.TabIndex = 57;
            // 
            // docTabPage
            // 
            this.docTabPage.Controls.Add(this.m_cowCountLabel);
            this.docTabPage.Controls.Add(this.label1);
            this.docTabPage.Controls.Add(this.m_reasonLbl);
            this.docTabPage.Controls.Add(this.m_reasonBtn);
            this.docTabPage.Controls.Add(this.m_plateNoBtn);
            this.docTabPage.Controls.Add(this.m_plateNoBox);
            this.docTabPage.Controls.Add(this.m_hentBtn);
            this.docTabPage.Controls.Add(this.m_hentBox);
            this.docTabPage.Location = new System.Drawing.Point(4, 25);
            this.docTabPage.Name = "docTabPage";
            this.docTabPage.Size = new System.Drawing.Size(232, 216);
            this.docTabPage.Text = "Dokument";
            // 
            // m_cowCountLabel
            // 
            this.m_cowCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_cowCountLabel.Location = new System.Drawing.Point(78, 110);
            this.m_cowCountLabel.Name = "m_cowCountLabel";
            this.m_cowCountLabel.Size = new System.Drawing.Size(100, 24);
            this.m_cowCountLabel.Text = "COUNT";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(0, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 24);
            this.label1.Text = "Iloœæ: ";
            // 
            // m_reasonLbl
            // 
            this.m_reasonLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_reasonLbl.Location = new System.Drawing.Point(78, 76);
            this.m_reasonLbl.Name = "m_reasonLbl";
            this.m_reasonLbl.Size = new System.Drawing.Size(60, 26);
            // 
            // m_reasonBtn
            // 
            this.m_reasonBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.m_reasonBtn.Location = new System.Drawing.Point(0, 76);
            this.m_reasonBtn.Name = "m_reasonBtn";
            this.m_reasonBtn.Size = new System.Drawing.Size(72, 26);
            this.m_reasonBtn.TabIndex = 40;
            this.m_reasonBtn.Text = "Powód";
            this.m_reasonBtn.Click += new System.EventHandler(this.m_reasonBtn_Click);
            // 
            // m_plateNoBtn
            // 
            this.m_plateNoBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.m_plateNoBtn.Location = new System.Drawing.Point(0, 42);
            this.m_plateNoBtn.Name = "m_plateNoBtn";
            this.m_plateNoBtn.Size = new System.Drawing.Size(72, 26);
            this.m_plateNoBtn.TabIndex = 41;
            this.m_plateNoBtn.Text = "Rejestracja";
            this.m_plateNoBtn.Click += new System.EventHandler(this.m_plateNoBtn_Click);
            // 
            // m_plateNoBox
            // 
            this.m_plateNoBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_plateNoBox.Location = new System.Drawing.Point(78, 43);
            this.m_plateNoBox.Name = "m_plateNoBox";
            this.m_plateNoBox.ReadOnly = true;
            this.m_plateNoBox.Size = new System.Drawing.Size(150, 25);
            this.m_plateNoBox.TabIndex = 42;
            this.m_plateNoBox.Text = "__PLATE__";
            // 
            // m_hentBtn
            // 
            this.m_hentBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.m_hentBtn.Location = new System.Drawing.Point(0, 8);
            this.m_hentBtn.Name = "m_hentBtn";
            this.m_hentBtn.Size = new System.Drawing.Size(72, 26);
            this.m_hentBtn.TabIndex = 43;
            this.m_hentBtn.Text = "Kontrahent";
            this.m_hentBtn.Click += new System.EventHandler(this.m_hentBtn_Click);
            // 
            // m_hentBox
            // 
            this.m_hentBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_hentBox.Location = new System.Drawing.Point(78, 9);
            this.m_hentBox.Name = "m_hentBox";
            this.m_hentBox.ReadOnly = true;
            this.m_hentBox.Size = new System.Drawing.Size(150, 25);
            this.m_hentBox.TabIndex = 44;
            this.m_hentBox.Text = "__HENT_ALIAS___";
            // 
            // cowsTabPage
            // 
            this.cowsTabPage.Controls.Add(this.m_activeGrp);
            this.cowsTabPage.Controls.Add(this.m_DelBtn);
            this.cowsTabPage.Controls.Add(this.cowListBox);
            this.cowsTabPage.Controls.Add(this.m_EditBtn);
            this.cowsTabPage.Controls.Add(this.m_setGrpCheckBox);
            this.cowsTabPage.Controls.Add(this.m_AddCowBtn);
            this.cowsTabPage.Controls.Add(this.m_SetGrpBtn);
            this.cowsTabPage.Location = new System.Drawing.Point(4, 25);
            this.cowsTabPage.Name = "cowsTabPage";
            this.cowsTabPage.Size = new System.Drawing.Size(232, 216);
            this.cowsTabPage.Text = "Zwierzeta";
            // 
            // NewDocForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(238, 275);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.m_AddBtn);
            this.Controls.Add(this.m_CancelBtn);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewDocForm";
            this.Text = "__NEWDOC_CAPTION__";
            this.Load += new System.EventHandler(this.NewDocForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.docTabPage.ResumeLayout(false);
            this.cowsTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void m_reasonBtn_Click(object sender, System.EventArgs e)
		{
			m_lockBCReader = true;
			if(!SyncLockMessage.CheckSyncLock())
			{
				m_lockBCReader = false;
				return;
			}
            DbDataReader reader = null;
            System.Collections.ArrayList a = new System.Collections.ArrayList();
            string docReasonsQ = "SELECT reasoncode,reasonid FROM inoutreasons WHERE inoutreason = 0 OR " +
                                   "inoutreason = " + GetInOut().ToString();
            try
            {
                reader = SQLDB.ExecuteQuery(docReasonsQ);               
                int reasoncodeOrd = reader.GetOrdinal("reasoncode");
                int reasonidOrd = reader.GetOrdinal("reasonid");
                while (reader.Read())
                {
                    a.Add(new System.Collections.DictionaryEntry(reader.GetInt32(reasonidOrd), reader.GetString(reasoncodeOrd)));
                }
            }
            catch(Exception ex)
            {
                BigOKMessageBox.ShowMessage("BLAD", "Blad wyswietlania listy powodow: " + ex.Message);
                LOG.DoLog("m_reasonBtn_Click(): QUERY = " + docReasonsQ + " MSG = " + ex.Message);
                a = null;
                return;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                reader = null;
            }

			ButtonList btnList = new ButtonList(a,m_CurReason,"Wybierz powód");
			if(btnList.ShowDialog() == DialogResult.OK)
			{
				m_CurReason = (int)btnList.GetSelected();
				for(int i = 0;i < a.Count;i++)
				{
                    if (((System.Collections.DictionaryEntry)a[i]).Key.Equals(m_CurReason))
					{
                        m_reasonLbl.Text = ((System.Collections.DictionaryEntry)a[i]).Value.ToString();
						break;
					}
				}								
			}
			m_lockBCReader = false;
		}

		private void m_plateNoBtn_Click(object sender, System.EventArgs e)
		{
			m_lockBCReader = true;
			if(!SyncLockMessage.CheckSyncLock())
			{
				m_lockBCReader = false;
				return;
			}
			Keypad keypad = new Keypad(16,"Wprowadz numer rejestracyjny");
			if(keypad.ShowDialog() == DialogResult.OK)
			{
				m_plateNoBox.Text = keypad.TextTyped;
			}
			m_lockBCReader = false;
		}

		private void m_hentBtn_Click(object sender, System.EventArgs e)
		{
			m_lockBCReader = true;
			if(!SyncLockMessage.CheckSyncLock())
			{
				m_lockBCReader = false;
				return;
			}


            ThreeBtnsOpt whichHents = new ThreeBtnsOpt
                ("Firmy", true, "Indywidualni", true, "Wszyscy", true);

            int htype = -1;

            if (whichHents.ShowDialog() == DialogResult.OK)
            {
                switch (whichHents.GetSelectedOpt())
                 {
                     case 1: //firmy
                         htype = 1;
                         break;
                     case 2: //indiwidualni
                         htype = 2;
                         break;
                     case 3: //wszyscy
                         htype = -1;
                         break;
                 }
            }
            else
            {
                whichHents = null;
                return;
            }
            whichHents = null;
			
			string hentQ = "SELECT * FROM hents";
            if(htype != -1)
                hentQ += " WHERE henttype = " + htype.ToString();

            DbDataReader reader = null;
            string hentOpt;
            System.Collections.ArrayList a = new System.Collections.ArrayList();


            try
            {
                reader = SQLDB.ExecuteQuery(hentQ);
                int hentidOrd = reader.GetOrdinal("hentid");
                int aliasOrd = reader.GetOrdinal("alias");
                int nameOrd = reader.GetOrdinal("name");
                int zipOrd = reader.GetOrdinal("zip");
                int cityOrd = reader.GetOrdinal("city");
                int streetOrd = reader.GetOrdinal("street");
                int poboxOrd = reader.GetOrdinal("pobox");

                while (reader.Read())
                {
                    hentOpt = reader.GetString(nameOrd) + "(" + reader.GetString(aliasOrd) + ")\r\n" +
                              reader.GetString(streetOrd) + ' ' + reader.GetString(poboxOrd) + "\r\n" +
                              reader.GetString(zipOrd) + ' ' + reader.GetString(cityOrd);

                    a.Add(new System.Collections.DictionaryEntry(reader.GetInt32(hentidOrd), hentOpt));
                }
            }
            catch (Exception ex)
            {
                LOG.DoLog("m_hentBtn_Click(): QUERY1 = " + hentQ + " MSG = " + ex.Message);
                BigOKMessageBox.ShowMessage("BLAD", "Blad podczas wyswietlania listy kontrahentow");
                a = null;
                m_lockBCReader = false;
                return;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }

			ButtonList btnList = new ButtonList(a,m_CurHent,"Wybierz kontrahenta");
			if(btnList.ShowDialog() == DialogResult.OK)
			{
				m_CurHent = (int)btnList.GetSelected();
                string hentAliasQ = "SELECT alias,plate FROM hents WHERE hentid = " + m_CurHent.ToString();
                try
                {
                    reader = SQLDB.ExecuteQuery(hentAliasQ);
                    reader.Read();
                    m_hentBox.Text = reader.GetString(reader.GetOrdinal("alias"));
                    if (m_plateNoBox.TextLength == 0)
                        m_plateNoBox.Text = reader.GetString(reader.GetOrdinal("plate"));
                }
                catch (Exception ex)
                {
                    LOG.DoLog("m_hentBtn_Click(): QUERY2 = " + hentAliasQ + " MSG = " + ex.Message);
                    BigOKMessageBox.ShowMessage("BLAD", "Blad podczas ustawiania danych kontrahenta.");
                    a = null;
                    m_lockBCReader = false;
                    return;
                }
                finally
                {
                    if (reader != null)
                        reader.Close();
                    reader = null;
                }
						
			}
            reader = null;
			m_lockBCReader = false;
		
		}

		private void m_CancelBtn_Click(object sender, System.EventArgs e)
		{			
			DialogResult = DialogResult.Cancel;
			Close();		
		}

		private void AddBtnClick(object sender, System.EventArgs e)
		{			
			string OKCaption = "Blad";
			m_lockBCReader = false;
			if(!SyncLockMessage.CheckSyncLock())
			{
				m_lockBCReader = false;
				return;
			}
			try
			{

				if(m_CurReason == 0)
				{
					BigOKMessageBox.ShowMessage(OKCaption,"Wybierz powod.");
					return;
				}

				if(m_CurHent == 0)
				{
					BigOKMessageBox.ShowMessage(OKCaption,"Wybierz kontrahenta.");
					return;
				}

				if(m_plateNoBox.TextLength == 0)
				{
					BigOKMessageBox.ShowMessage(OKCaption,"Brak numeru rejestracyjnego.");
				}

                if (cowListBox.GetItemCount() == 0)
				{
					BigOKMessageBox.ShowMessage(OKCaption,"Brak pozycji na liscie zwierzat.");
					return;
				}


				if(CommitDoc()) 
				{
					DialogResult = DialogResult.OK;
					Close();
				}
			}
			catch(Exception ex)
			{
                throw ex;
			}
			finally
			{
				m_lockBCReader = false;
			}
			
		}


		protected abstract bool ContinueWithEAN(string EANStr);
		protected abstract bool  CommitDoc();

		protected virtual void AddCowBtnClick(object sender, System.EventArgs e)
		{
			m_lockBCReader = true;
			if(!SyncLockMessage.CheckSyncLock())
			{
				m_lockBCReader = false;
				return;
			}
			EnterEANForm enterEAN = new EnterEANForm();
			
			if(enterEAN.ShowDialog() == DialogResult.OK)
			{
			
				ContinueWithEAN(enterEAN.EANFound);			
			}
			UpdateCowCount();
			m_lockBCReader = false;
		}


        protected virtual void Init()
        {
            m_reasonLbl.Text = GetDefaultReasonCode();
            m_plateNoBox.Text = String.Empty;
            m_hentBox.Text = String.Empty;
            this.Text = GetCaption();            
            UpdateCowCount();
            m_activeGrpSettingEnabled = true;
            m_setGrpCheckBox_Click(null, null);
        }

		

		protected virtual void NewDocForm_Load(object sender, System.EventArgs e)
		{
            this.Closed += new EventHandler(OnClosedNewDocDlg);
            m_bcReader.Init();
            EaringReadHandler = new EventHandler(OnEaringRead);
            m_bcReader.OnRead += EaringReadHandler;

            Init();			
		}
		protected void OnClosedNewDocDlg(object sender, EventArgs e)
		{
            m_bcReader.OnRead -= EaringReadHandler;
			m_bcReader.Finish();
		}

		private void OnEaringRead(object sender, System.EventArgs e)
		{
            if (!m_lockBCReader)
            {
                ContinueWithEAN((string)sender);
                UpdateCowCount();
            }
		}

		protected int IsOnList(string EAN,bool bSelect)
		{
            for (int i = 0; i < cowListBox.GetItemCount(); i++)
                if (EAN.Equals(((Cow)cowListBox.GetItem(i)).EAN))
                {
                    if (bSelect)
                    {
                        cowListBox.SelectItem(i);
                    }
                    return i;
                }
			return -1;
		}

		protected bool IsInDB(string EAN)
		{
            string eanCowCountQ = "SELECT COUNT(*) FROM cattle WHERE ean = '" + EAN + '\'';
            try
            {
                return SQLDB.ExecuteCount(eanCowCountQ) > 0;
            }
            catch (SystemException sqlEx)
            {
                LOG.DoLog("IsInDB(): EAN = " + EAN + " MSG = " + sqlEx.Message);
            }
            return false;			
		}

        protected void AddToList(Cow cow)
        {
            cowListBox.AddItem(cow);
            cowListBox.SelectItem(cowListBox.GetItemCount() - 1);

        }
		
		protected Cow ReadCowFromDB(string sEAN,bool bOnlyAvailable)
		{
            ICollection<Cow> singleCow  = SQLDB.LoadCows(new cowbase.wheres.AndWhere(new cowbase.wheres.EanWhere(sEAN), new cowbase.wheres.CowInStockWhere()));
          
            if (singleCow.Count != 1)
                return null;

            IEnumerator<Cow> cowEnumerator = singleCow.GetEnumerator();
            cowEnumerator.MoveNext();

            return cowEnumerator.Current;

		}

		private void m_DelBtn_Click(object sender, System.EventArgs e)
		{
            m_lockBCReader = true;
            if (!SyncLockMessage.CheckSyncLock())
            {
                m_lockBCReader = false;
                return;
            }
            if (cowListBox.SelectedIndex >= 0)
            {
                if (DeleteCow((Cow)cowListBox.GetItem(cowListBox.SelectedIndex)))
                {
                    cowListBox.RemoveItemAt(cowListBox.SelectedIndex);
                }
            }

            UpdateCowCount();
            m_lockBCReader = false;
			
		}

		protected abstract bool EditCow(Cow cowd);

		private void m_EditBtn_Click(object sender, System.EventArgs e)
		{
            m_lockBCReader = true;
            if (!SyncLockMessage.CheckSyncLock())
            {
                m_lockBCReader = false;
                return;
            }
            if (cowListBox.SelectedIndex >= 0)
            {
                if (EditCow((Cow)cowListBox.GetItem(cowListBox.SelectedIndex)))
                {
                    cowListBox.Invalidate();
                }
            }
            m_lockBCReader = false;
		}

		private void m_activeGrp_Click(object sender, System.EventArgs e)
		{
			ChooseGroup chooseGrp = new ChooseGroup(m_curActiveGrp,"Wybierz grupê");
			if(chooseGrp.ShowDialog() == DialogResult.OK)
			{
				m_curActiveGrp = (int)chooseGrp.GetSelected();
                m_SetGrpBtn.Text = m_curActiveGrp.ToString();
			}
		}

		private void m_SetGrpBtn_Click(object sender, System.EventArgs e)
		{
            if (cowListBox.SelectedIndex >= 0)
            {
                SetGroup((Cow)cowListBox.GetItem(cowListBox.SelectedIndex), m_curActiveGrp);
                cowListBox.Invalidate();
            }
		}	

		protected void UpdateCowCount()
		{
            m_cowCountLabel.Text = cowListBox.GetItemCount().ToString();
            cowsTabPage.Text = "Zwierzeta (" + m_cowCountLabel.Text + ")";

		}

        protected abstract void SetGroup(Cow cowd,int group);

        private void m_setGrpCheckBox_Click(object sender, EventArgs e)
        {
            m_activeGrpSettingEnabled = !m_activeGrpSettingEnabled;

            if (m_activeGrpSettingEnabled)
            {
                m_setGrpCheckBox.ForeColor = System.Drawing.Color.White;
                m_setGrpCheckBox.BackColor = System.Drawing.Color.Black;
            }
            else
            {
                m_setGrpCheckBox.ForeColor = System.Drawing.Color.Black;
                m_setGrpCheckBox.BackColor = System.Drawing.Color.White;
            }
        }		
	}
}
