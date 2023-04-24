using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data ;
using System.Data.Common; 


namespace cowbase
{
	public abstract class DocListView :  CenterForm //System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button m_BackBtn;
		private System.Windows.Forms.Button m_UpBtn;
		private System.Windows.Forms.Button m_DnBtn;
		private System.Windows.Forms.ColumnHeader DocNoCol;
		private System.Windows.Forms.ColumnHeader HentCol;
		private System.Windows.Forms.ColumnHeader LoadDateCol;
		private System.Windows.Forms.ColumnHeader CountCol;
		private System.Windows.Forms.Button m_SelBtn;
		protected string m_tableName;
        private DocListBox docListBox;
		protected string m_cattleDocFieldName;
			
		public DocListView()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			m_tableName = String.Empty;
			m_cattleDocFieldName = String.Empty;
			

			m_DnBtn.Text = new String('\xDA',1); //down arrow
			m_SelBtn.Text = new String('\xE0',1); //action sign	
			m_UpBtn.Text = new String('\xD9',1);
            docListBox.SetFormatter(new DocItemStringFormatter());
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
            this.m_BackBtn = new System.Windows.Forms.Button();
            this.m_UpBtn = new System.Windows.Forms.Button();
            this.m_DnBtn = new System.Windows.Forms.Button();
            this.m_SelBtn = new System.Windows.Forms.Button();
            this.DocNoCol = new System.Windows.Forms.ColumnHeader();
            this.HentCol = new System.Windows.Forms.ColumnHeader();
            this.LoadDateCol = new System.Windows.Forms.ColumnHeader();
            this.CountCol = new System.Windows.Forms.ColumnHeader();
            this.docListBox = new cowbase.DocListBox();
            this.SuspendLayout();
            // 
            // m_BackBtn
            // 
            this.m_BackBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.m_BackBtn.Location = new System.Drawing.Point(2, 242);
            this.m_BackBtn.Name = "m_BackBtn";
            this.m_BackBtn.Size = new System.Drawing.Size(236, 32);
            this.m_BackBtn.TabIndex = 4;
            this.m_BackBtn.Text = "Wstecz";
            this.m_BackBtn.Click += new System.EventHandler(this.m_OKBtn_Click);
            // 
            // m_UpBtn
            // 
            this.m_UpBtn.Font = new System.Drawing.Font("Symbol", 15.75F, System.Drawing.FontStyle.Bold);
            this.m_UpBtn.Location = new System.Drawing.Point(203, 2);
            this.m_UpBtn.Name = "m_UpBtn";
            this.m_UpBtn.Size = new System.Drawing.Size(35, 80);
            this.m_UpBtn.TabIndex = 3;
            this.m_UpBtn.Text = "U";
            this.m_UpBtn.Click += new System.EventHandler(this.m_UpBtn_Click);
            // 
            // m_DnBtn
            // 
            this.m_DnBtn.Font = new System.Drawing.Font("Symbol", 15.75F, System.Drawing.FontStyle.Bold);
            this.m_DnBtn.Location = new System.Drawing.Point(203, 160);
            this.m_DnBtn.Name = "m_DnBtn";
            this.m_DnBtn.Size = new System.Drawing.Size(35, 80);
            this.m_DnBtn.TabIndex = 2;
            this.m_DnBtn.Text = "Ú";
            this.m_DnBtn.Click += new System.EventHandler(this.m_DnBtn_Click);
            // 
            // m_SelBtn
            // 
            this.m_SelBtn.Font = new System.Drawing.Font("Symbol", 15.75F, System.Drawing.FontStyle.Bold);
            this.m_SelBtn.Location = new System.Drawing.Point(203, 88);
            this.m_SelBtn.Name = "m_SelBtn";
            this.m_SelBtn.Size = new System.Drawing.Size(35, 66);
            this.m_SelBtn.TabIndex = 1;
            this.m_SelBtn.Text = "a";
            this.m_SelBtn.Click += new System.EventHandler(this.m_SelBtn_Click);
            // 
            // DocNoCol
            // 
            this.DocNoCol.Text = "Nr";
            this.DocNoCol.Width = 30;
            // 
            // HentCol
            // 
            this.HentCol.Text = "Kontrahent";
            this.HentCol.Width = 100;
            // 
            // LoadDateCol
            // 
            this.LoadDateCol.Text = "Data przywozu";
            this.LoadDateCol.Width = 80;
            // 
            // CountCol
            // 
            this.CountCol.Text = "Ilosc";
            this.CountCol.Width = 30;
            // 
            // docListBox
            //


            this.docListBox.BackColor = System.Drawing.SystemColors.Window;
            
            
            this.docListBox.ForeColor = System.Drawing.SystemColors.ControlText;
            
            this.docListBox.Location = new System.Drawing.Point(2, 2);
            this.docListBox.Name = "docListBox";
            this.docListBox.SelectedIndex = -1;
            this.docListBox.Size = new System.Drawing.Size(199, 200);
            this.docListBox.TabIndex = 5;
            
            

            
            // 
            // DocListView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(238, 275);
            this.Controls.Add(this.docListBox);
            this.Controls.Add(this.m_SelBtn);
            this.Controls.Add(this.m_DnBtn);
            this.Controls.Add(this.m_UpBtn);
            this.Controls.Add(this.m_BackBtn);
            this.ControlBox = false;
            this.Name = "DocListView";
            this.Text = "__CAPTION__";
            this.Load += new System.EventHandler(this.DocListView_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void m_DnBtn_Click(object sender, System.EventArgs e)
		{
            
            int newIndex;
            if(docListBox.SelectedIndex >= 0)
                newIndex = docListBox.SelectedIndex + 1;
            else
                newIndex = 0;

            if (newIndex < docListBox.GetItemCount())
            {
                docListBox.SelectItem(newIndex);
            }
		}

		private void AddDoc(int docno,
                            DateTime loaddate,
                            string hent_alias,
                            int cowCount,
                            Action action,
                            int hentid,
                            string plateNo,
                            int reasonid,
                            string reasoncode)
		{
            Doc doc = new Doc();
            doc.action = action;
            doc.docno = docno;
            doc.loaddate = loaddate;
            doc.hentalias = hent_alias;
            doc.cowcount = cowCount;
            doc.hentid = hentid;
            doc.plateno = plateNo;
            doc.reasonid = reasonid;
            doc.reasoncode = reasoncode;
				
            docListBox.AddItem(doc);
		}


		private void DocListView_Load(object sender, System.EventArgs e)
		{

            string docSelQ = "SELECT action,docno,loaddate,alias,hentid,plateno,reasonid,inoutreasons.reasoncode AS reasoncode" +
                " FROM %0  LEFT JOIN hents ON %0.hent = hents.hentid LEFT JOIN inoutreasons ON %0.reason = inoutreasons.reasonid";
            
            string sqlStmt = SQLBuilder.SQLSprintf(docSelQ,m_tableName);
            DbDataReader doc_reader = null;

            try
            {

                doc_reader = SQLDB.ExecuteQuery(sqlStmt);
                int docno, docnoOrd = doc_reader.GetOrdinal("docno");
                int loaddateOrd = doc_reader.GetOrdinal("loaddate"),
                    aliasOrd = doc_reader.GetOrdinal("alias"),
                    actionOrd = doc_reader.GetOrdinal("action"),
                    hentidOrd = doc_reader.GetOrdinal("hentid"),
                    plateNoOrd = doc_reader.GetOrdinal("plateno"),
                    reasonidOrd = doc_reader.GetOrdinal("reasonid"),
                    reasoncodeOrd = doc_reader.GetOrdinal("reasoncode");
                int cowCount;

                while (doc_reader.Read())
                {
                    docno = doc_reader.GetInt32(docnoOrd);
                    cowCount = (int)SQLDB.ExecuteCount(SQLBuilder.SQLSprintf("SELECT COUNT(*) FROM cattle WHERE %0 = %1", m_cattleDocFieldName, docno));
                    AddDoc(docno, 
                           doc_reader.GetDateTime(loaddateOrd),
                           doc_reader.GetString(aliasOrd),
                           cowCount,
                           Action.FromCharacter(doc_reader.GetString(actionOrd).ToCharArray()[0]),
                           doc_reader.GetInt32(hentidOrd),
                           doc_reader.GetString(plateNoOrd),
                           doc_reader.GetInt32(reasonidOrd),
                           doc_reader.GetString(reasoncodeOrd));
                    
                }
            }
            catch (SystemException sqlEx)
            {
                LOG.DoLog("DocListView_Load(): " + sqlEx.Message);
            }
            finally
            {
                if (doc_reader != null)
                    doc_reader.Close();
                doc_reader = null;
            }
						
		
		}

		private void m_UpBtn_Click(object sender, System.EventArgs e)
		{
            
            int newIndex;
            if (docListBox.SelectedIndex >= 0)
                newIndex = docListBox.SelectedIndex - 1;
            else
                newIndex = docListBox.GetItemCount() - 1;

            if(newIndex >= 0)
            {
                docListBox.SelectItem(newIndex);
            }
		
		}

		private void m_OKBtn_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
			
		}

		private void m_SelBtn_Click(object sender, System.EventArgs e)
		{

            if (docListBox.SelectedIndex >= 0)
            {
                EditDoc((Doc)docListBox.GetItem(docListBox.SelectedIndex));
            }
						
		}

		protected abstract bool EditDoc(Doc doc);
	}
}
