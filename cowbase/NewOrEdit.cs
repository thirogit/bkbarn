using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace cowbase
{
	/// <summary>
	/// Summary description for NewOrEdit.
	/// </summary>
	public class NewOrEdit : CenterForm //System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button m_NewBtn;
		private System.Windows.Forms.Button m_EditBtn;
		private System.Windows.Forms.Button m_passSearchBtn;
		private System.Windows.Forms.Button m_CancelBtn;
	
		public NewOrEdit(string caption)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			this.Text = caption;			
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
			this.m_NewBtn = new System.Windows.Forms.Button();
			this.m_EditBtn = new System.Windows.Forms.Button();
			this.m_CancelBtn = new System.Windows.Forms.Button();
			this.m_passSearchBtn = new System.Windows.Forms.Button();
			// 
			// m_NewBtn
			// 
			this.m_NewBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
			this.m_NewBtn.Location = new System.Drawing.Point(8, 0);
			this.m_NewBtn.Size = new System.Drawing.Size(208, 56);
			this.m_NewBtn.Text = "Nowa";
			this.m_NewBtn.Click += new System.EventHandler(this.m_NewBtn_Click);
			// 
			// m_EditBtn
			// 
			this.m_EditBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
			this.m_EditBtn.Location = new System.Drawing.Point(8, 64);
			this.m_EditBtn.Size = new System.Drawing.Size(208, 56);
			this.m_EditBtn.Text = "Edycja";
			this.m_EditBtn.Click += new System.EventHandler(this.m_EditBtn_Click);
			// 
			// m_CancelBtn
			// 
			this.m_CancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
			this.m_CancelBtn.Location = new System.Drawing.Point(8, 192);
			this.m_CancelBtn.Size = new System.Drawing.Size(208, 56);
			this.m_CancelBtn.Text = "Anuluj";
			this.m_CancelBtn.Click += new System.EventHandler(this.m_CancelBtn_Click);
			// 
			// m_passSearchBtn
			// 
			this.m_passSearchBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
			this.m_passSearchBtn.Location = new System.Drawing.Point(8, 128);
			this.m_passSearchBtn.Size = new System.Drawing.Size(208, 56);
			this.m_passSearchBtn.Text = "Szukaj paszportów";
			this.m_passSearchBtn.Click += new System.EventHandler(this.m_passSearchBtn_Click);
			// 
			// NewOrEdit
			// 
			this.ClientSize = new System.Drawing.Size(226, 255);
			this.Controls.Add(this.m_passSearchBtn);
			this.Controls.Add(this.m_CancelBtn);
			this.Controls.Add(this.m_EditBtn);
			this.Controls.Add(this.m_NewBtn);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Text = "__NEW_OR_EDIT__";

		}
		#endregion

		private void m_NewBtn_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.Yes;
		}

		private void m_EditBtn_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.No;
		}

		private void m_CancelBtn_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		private void m_passSearchBtn_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.OK;
		}
	}
}
