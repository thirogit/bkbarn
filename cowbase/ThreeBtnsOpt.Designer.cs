namespace cowbase
{
    partial class ThreeBtnsOpt
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.Opt1Btn = new System.Windows.Forms.Button();
            this.Opt2Btn = new System.Windows.Forms.Button();
            this.Opt3Btn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Opt1Btn
            // 
            this.Opt1Btn.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.Opt1Btn.Location = new System.Drawing.Point(13, 3);
            this.Opt1Btn.Name = "Opt1Btn";
            this.Opt1Btn.Size = new System.Drawing.Size(198, 45);
            this.Opt1Btn.TabIndex = 0;
            this.Opt1Btn.Text = "__OPT1__";
            this.Opt1Btn.Click += new System.EventHandler(this.Opt1Btn_Click);
            // 
            // Opt2Btn
            // 
            this.Opt2Btn.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.Opt2Btn.Location = new System.Drawing.Point(13, 54);
            this.Opt2Btn.Name = "Opt2Btn";
            this.Opt2Btn.Size = new System.Drawing.Size(198, 45);
            this.Opt2Btn.TabIndex = 1;
            this.Opt2Btn.Text = "__OPT2__";
            this.Opt2Btn.Click += new System.EventHandler(this.Opt2Btn_Click);
            // 
            // Opt3Btn
            // 
            this.Opt3Btn.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.Opt3Btn.Location = new System.Drawing.Point(13, 105);
            this.Opt3Btn.Name = "Opt3Btn";
            this.Opt3Btn.Size = new System.Drawing.Size(198, 45);
            this.Opt3Btn.TabIndex = 2;
            this.Opt3Btn.Text = "__OPT3__";
            this.Opt3Btn.Click += new System.EventHandler(this.Opt3Btn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.CancelBtn.Location = new System.Drawing.Point(0, 170);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(225, 45);
            this.CancelBtn.TabIndex = 3;
            this.CancelBtn.Text = "Anuluj";
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // ThreeBtnsOpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(225, 215);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.Opt3Btn);
            this.Controls.Add(this.Opt2Btn);
            this.Controls.Add(this.Opt1Btn);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ThreeBtnsOpt";
            this.Text = "Wybierz opcje";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Opt1Btn;
        private System.Windows.Forms.Button Opt2Btn;
        private System.Windows.Forms.Button Opt3Btn;
        private System.Windows.Forms.Button CancelBtn;
    }
}