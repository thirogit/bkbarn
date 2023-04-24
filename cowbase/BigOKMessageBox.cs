using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Reflection;

namespace cowbase
{
	/// <summary>
	/// Summary description for BigOKMessageBox.
	/// </summary>
	public class BigOKMessageBox : CenterForm
	{
		private System.Windows.Forms.Label m_messageLabel;
		private System.Windows.Forms.Button OKBtn;

        public static void ShowMessage(string message)
        {
            AssemblyName assemNm = Assembly.GetExecutingAssembly().GetName();
            BigOKMessageBox bigOK = new BigOKMessageBox(assemNm.Name, message);
            bigOK.ShowDialog();
            bigOK = null;
        }

		public static void ShowMessage(string caption,string message)
		{
			BigOKMessageBox bigOK = new BigOKMessageBox(caption,message);
			bigOK.ShowDialog();
			bigOK = null;
		}
		private BigOKMessageBox(string caption,string message)
		{
			InitializeComponent();
			this.Text = caption;
			m_messageLabel.Text = message;	
			this.KeyPress += new KeyPressEventHandler(BigOKMessageBox_KeyPress);
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
            this.m_messageLabel = new System.Windows.Forms.Label();
            this.OKBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_messageLabel
            // 
            this.m_messageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.m_messageLabel.Location = new System.Drawing.Point(0, 0);
            this.m_messageLabel.Name = "m_messageLabel";
            this.m_messageLabel.Size = new System.Drawing.Size(238, 216);
            this.m_messageLabel.Text = "__MESSAGE__";
            this.m_messageLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // OKBtn
            // 
            this.OKBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.OKBtn.Location = new System.Drawing.Point(0, 219);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(238, 56);
            this.OKBtn.TabIndex = 0;
            this.OKBtn.Text = "OK";
            this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
            // 
            // BigOKMessageBox
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(238, 275);
            this.Controls.Add(this.OKBtn);
            this.Controls.Add(this.m_messageLabel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BigOKMessageBox";
            this.Text = "__CAPTION__";
            this.ResumeLayout(false);

		}
		#endregion

		private void OKBtn_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

		private void BigOKMessageBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if(e.KeyChar == (char)0x0D)
			{
				OKBtn_Click(null,null);
				e.Handled = true;
			}

		}
	}
}
