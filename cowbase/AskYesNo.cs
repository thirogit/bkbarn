using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace cowbase
{
	/// <summary>
	/// Summary description for AskYesNo.
	/// </summary>
	public class AskYesNo : CenterForm//System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button m_YesBtn;
		private System.Windows.Forms.Button m_NoBtn;
		private System.Windows.Forms.Label m_askLabel;
		private string m_caption;
	

		public static bool Ask(string question)
		{
			AskYesNo ask = new AskYesNo(question);
			return ask.ShowDialog() == DialogResult.Yes;
		}
		public AskYesNo(string caption)
		{
			
			InitializeComponent();
			DialogResult = DialogResult.No;
			m_caption = (string)caption.Clone();
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
            this.m_askLabel = new System.Windows.Forms.Label();
            this.m_YesBtn = new System.Windows.Forms.Button();
            this.m_NoBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_askLabel
            // 
            this.m_askLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_askLabel.Location = new System.Drawing.Point(0, 0);
            this.m_askLabel.Name = "m_askLabel";
            this.m_askLabel.Size = new System.Drawing.Size(238, 172);
            this.m_askLabel.Text = "__QUESTION_TEXT__";
            // 
            // m_YesBtn
            // 
            this.m_YesBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.m_YesBtn.Location = new System.Drawing.Point(0, 175);
            this.m_YesBtn.Name = "m_YesBtn";
            this.m_YesBtn.Size = new System.Drawing.Size(120, 40);
            this.m_YesBtn.TabIndex = 1;
            this.m_YesBtn.Text = "TAK";
            this.m_YesBtn.Click += new System.EventHandler(this.m_YesBtn_Click);
            // 
            // m_NoBtn
            // 
            this.m_NoBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.m_NoBtn.Location = new System.Drawing.Point(118, 175);
            this.m_NoBtn.Name = "m_NoBtn";
            this.m_NoBtn.Size = new System.Drawing.Size(120, 40);
            this.m_NoBtn.TabIndex = 0;
            this.m_NoBtn.Text = "NIE";
            this.m_NoBtn.Click += new System.EventHandler(this.m_NoBtn_Click);
            // 
            // AskYesNo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(238, 215);
            this.Controls.Add(this.m_NoBtn);
            this.Controls.Add(this.m_YesBtn);
            this.Controls.Add(this.m_askLabel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AskYesNo";
            this.Text = "Pytanie";
            this.Load += new System.EventHandler(this.AskYesNo_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void m_YesBtn_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.Yes;
			Close();
		}

		private void m_NoBtn_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.No;
			Close();
		}

		private void AskYesNo_Load(object sender, System.EventArgs e)
		{
			m_askLabel.Text = m_caption;
		}
	}
}
