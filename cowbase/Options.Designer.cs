namespace cowbase
{
    partial class Options
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.hostipLbl = new System.Windows.Forms.Label();
            this.hostipBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.redBirthdateDaysScroll = new System.Windows.Forms.NumericUpDown();
            this.usePredefSexCheck = new System.Windows.Forms.CheckBox();
            this.OKBtn = new System.Windows.Forms.Button();
            this.setDefaultHostBtn = new OpenNETCF.Windows.Forms.Button2();
            this.SuspendLayout();
            // 
            // hostipLbl
            // 
            this.hostipLbl.Location = new System.Drawing.Point(1, 3);
            this.hostipLbl.Name = "hostipLbl";
            this.hostipLbl.Size = new System.Drawing.Size(55, 22);
            this.hostipLbl.Text = "Host:";
            // 
            // hostipBox
            // 
            this.hostipBox.Location = new System.Drawing.Point(53, 2);
            this.hostipBox.MaxLength = 15;
            this.hostipBox.Name = "hostipBox";
            this.hostipBox.Size = new System.Drawing.Size(144, 23);
            this.hostipBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 31);
            this.label1.Text = "Wyró¿niaj gdy wiek w dniach przekroczy:";
            // 
            // redBirthdateDaysScroll
            // 
            this.redBirthdateDaysScroll.Location = new System.Drawing.Point(153, 39);
            this.redBirthdateDaysScroll.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.redBirthdateDaysScroll.Name = "redBirthdateDaysScroll";
            this.redBirthdateDaysScroll.Size = new System.Drawing.Size(69, 24);
            this.redBirthdateDaysScroll.TabIndex = 4;
            // 
            // usePredefSexCheck
            // 
            this.usePredefSexCheck.Location = new System.Drawing.Point(3, 79);
            this.usePredefSexCheck.Name = "usePredefSexCheck";
            this.usePredefSexCheck.Size = new System.Drawing.Size(210, 20);
            this.usePredefSexCheck.TabIndex = 5;
            this.usePredefSexCheck.Text = "Uzywaj predefiniowanej plci";
            // 
            // OKBtn
            // 
            this.OKBtn.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.OKBtn.Location = new System.Drawing.Point(2, 219);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(234, 31);
            this.OKBtn.TabIndex = 6;
            this.OKBtn.Text = "OK";
            this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
            // 
            // setDefaultHostBtn
            // 
            this.setDefaultHostBtn.Location = new System.Drawing.Point(203, 3);
            this.setDefaultHostBtn.Name = "setDefaultHostBtn";
            this.setDefaultHostBtn.Size = new System.Drawing.Size(32, 23);
            this.setDefaultHostBtn.TabIndex = 9;
            this.setDefaultHostBtn.Click += new System.EventHandler(this.setDefaultHostBtn_Click);
            
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 253);
            this.Controls.Add(this.setDefaultHostBtn);
            this.Controls.Add(this.OKBtn);
            this.Controls.Add(this.usePredefSexCheck);
            this.Controls.Add(this.redBirthdateDaysScroll);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hostipBox);
            this.Controls.Add(this.hostipLbl);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Options";
            this.Text = "Opcje";
            this.Load += new System.EventHandler(this.Options_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label hostipLbl;
        private System.Windows.Forms.TextBox hostipBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown redBirthdateDaysScroll;
        private System.Windows.Forms.CheckBox usePredefSexCheck;
        private System.Windows.Forms.Button OKBtn;
        private OpenNETCF.Windows.Forms.Button2 setDefaultHostBtn;

    }
}