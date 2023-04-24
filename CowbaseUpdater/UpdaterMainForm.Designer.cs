namespace CowbaseUpdater
{
    partial class UpdaterMainForm
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
            this.dwnlAndInstallBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.currentVersionNumber = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.newVersionLbl = new System.Windows.Forms.Label();
            this.downloadProgress = new System.Windows.Forms.ProgressBar();
            this.downloadTimeLeftStaticLbl = new System.Windows.Forms.Label();
            this.downloadSpeedStaticLbl = new System.Windows.Forms.Label();
            this.downloadSpeedLbl = new System.Windows.Forms.Label();
            this.downloadTimeLeftLbl = new System.Windows.Forms.Label();
            this.abortBtn = new System.Windows.Forms.Button();
            this.httpDownloader1 = new DotNetRemoting.HttpDownloaderCtl();

            this.SuspendLayout();
            // 
            // dwnlAndInstallBtn
            // 
            this.dwnlAndInstallBtn.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.dwnlAndInstallBtn.Location = new System.Drawing.Point(3, 80);
            this.dwnlAndInstallBtn.Name = "dwnlAndInstallBtn";
            this.dwnlAndInstallBtn.Size = new System.Drawing.Size(232, 64);
            this.dwnlAndInstallBtn.TabIndex = 0;
            this.dwnlAndInstallBtn.Text = "Pobierz i zainstaluj";
            this.dwnlAndInstallBtn.Click += new System.EventHandler(this.dwnlAndInstallBtn_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(0, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 23);
            this.label1.Text = "Obecna wersja:";
            // 
            // currentVersionNumber
            // 
            this.currentVersionNumber.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.currentVersionNumber.Location = new System.Drawing.Point(148, 15);
            this.currentVersionNumber.Name = "currentVersionNumber";
            this.currentVersionNumber.Size = new System.Drawing.Size(87, 23);
            this.currentVersionNumber.Text = "XXXX";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(0, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 23);
            this.label2.Text = "Nowa wersja:";
            // 
            // newVersionLbl
            // 
            this.newVersionLbl.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.newVersionLbl.Location = new System.Drawing.Point(148, 54);
            this.newVersionLbl.Name = "newVersionLbl";
            this.newVersionLbl.Size = new System.Drawing.Size(87, 23);
            this.newVersionLbl.Text = "XXXX";
            // 
            // downloadProgress
            // 
            this.downloadProgress.Location = new System.Drawing.Point(3, 194);
            this.downloadProgress.Name = "downloadProgress";
            this.downloadProgress.Size = new System.Drawing.Size(232, 20);
            // 
            // downloadTimeLeftStaticLbl
            // 
            this.downloadTimeLeftStaticLbl.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.downloadTimeLeftStaticLbl.Location = new System.Drawing.Point(3, 171);
            this.downloadTimeLeftStaticLbl.Name = "downloadTimeLeftStaticLbl";
            this.downloadTimeLeftStaticLbl.Size = new System.Drawing.Size(110, 20);
            this.downloadTimeLeftStaticLbl.Text = "Pozostały czas:";
            // 
            // downloadSpeedStaticLbl
            // 
            this.downloadSpeedStaticLbl.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.downloadSpeedStaticLbl.Location = new System.Drawing.Point(3, 151);
            this.downloadSpeedStaticLbl.Name = "downloadSpeedStaticLbl";
            this.downloadSpeedStaticLbl.Size = new System.Drawing.Size(110, 20);
            this.downloadSpeedStaticLbl.Text = "Prędkość:";
            // 
            // downloadSpeedLbl
            // 
            this.downloadSpeedLbl.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.downloadSpeedLbl.Location = new System.Drawing.Point(125, 151);
            this.downloadSpeedLbl.Name = "downloadSpeedLbl";
            this.downloadSpeedLbl.Size = new System.Drawing.Size(110, 20);
            this.downloadSpeedLbl.Text = "XXXX kbps";
            // 
            // downloadTimeLeftLbl
            // 
            this.downloadTimeLeftLbl.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.downloadTimeLeftLbl.Location = new System.Drawing.Point(125, 171);
            this.downloadTimeLeftLbl.Name = "downloadTimeLeftLbl";
            this.downloadTimeLeftLbl.Size = new System.Drawing.Size(110, 20);
            this.downloadTimeLeftLbl.Text = "XXXX min.";
            // 
            // abortBtn
            // 
            this.abortBtn.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.abortBtn.Location = new System.Drawing.Point(3, 220);
            this.abortBtn.Name = "abortBtn";
            this.abortBtn.Size = new System.Drawing.Size(232, 55);
            this.abortBtn.TabIndex = 14;
            this.abortBtn.Text = "Wyjdź";
            this.abortBtn.Click += new System.EventHandler(this.abortBtn_Click);
            // 
            // httpDownloader1
            // 
            this.httpDownloader1.BackColor = System.Drawing.SystemColors.Info;
            this.httpDownloader1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;          
            this.httpDownloader1.Location = new System.Drawing.Point(150, 12);
            this.httpDownloader1.Name = "httpDownloader1";
            this.httpDownloader1.ProgrBar = this.downloadProgress;
            this.httpDownloader1.ProgressLabel = null;
            this.httpDownloader1.ProxyToUse = DotNetRemoting.UseProxy.NotProxy;
            this.httpDownloader1.Size = new System.Drawing.Size(116, 32);
            this.httpDownloader1.TabIndex = 0;
            this.httpDownloader1.TimeOut = 5000;
            this.httpDownloader1.URLDownload = null;
            this.httpDownloader1.Visible = false;
            this.httpDownloader1.StatusUpdateEvent += new DotNetRemoting.UpdateDelegate(this.httpDownloader1_StatusUpdateEvent);
            // 
            // UpdaterMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 275);
            this.Controls.Add(this.abortBtn);
            this.Controls.Add(this.downloadTimeLeftLbl);
            this.Controls.Add(this.downloadSpeedLbl);
            this.Controls.Add(this.downloadSpeedStaticLbl);
            this.Controls.Add(this.downloadTimeLeftStaticLbl);
            this.Controls.Add(this.downloadProgress);
            this.Controls.Add(this.newVersionLbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.currentVersionNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dwnlAndInstallBtn);
            this.MaximizeBox = false;
            this.Name = "UpdaterMainForm";
            this.Text = "Aktualizacja BK 2011";
            this.Load += new System.EventHandler(this.UpdaterMainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DotNetRemoting.HttpDownloaderCtl httpDownloader1;
        private System.Windows.Forms.Button dwnlAndInstallBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label currentVersionNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label newVersionLbl;
        private System.Windows.Forms.ProgressBar downloadProgress;
        private System.Windows.Forms.Label downloadTimeLeftStaticLbl;
        private System.Windows.Forms.Label downloadSpeedStaticLbl;
        private System.Windows.Forms.Label downloadSpeedLbl;
        private System.Windows.Forms.Label downloadTimeLeftLbl;
        private System.Windows.Forms.Button abortBtn;
    }
}

