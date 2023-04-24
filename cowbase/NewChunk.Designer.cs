namespace cowbase
{
    partial class NewChunk
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
            this.chunkCowList = new cowbase.CowListBox();
            this.closeChunkBtn = new System.Windows.Forms.Button();
            this.cancelChunkBtn = new System.Windows.Forms.Button();
            this.errorMsgLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chunkCowList
            // 
            this.chunkCowList.BackColor = System.Drawing.SystemColors.Window;
            
            this.chunkCowList.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chunkCowList.Location = new System.Drawing.Point(3, 3);
            this.chunkCowList.Name = "chunkCowList";
            
            this.chunkCowList.Size = new System.Drawing.Size(229, 150);
            this.chunkCowList.TabIndex = 2;
            // 
            // closeChunkBtn
            // 
            this.closeChunkBtn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.closeChunkBtn.Location = new System.Drawing.Point(0, 198);
            this.closeChunkBtn.Name = "closeChunkBtn";
            this.closeChunkBtn.Size = new System.Drawing.Size(119, 39);
            this.closeChunkBtn.TabIndex = 0;
            this.closeChunkBtn.Text = "Zamknij";
            this.closeChunkBtn.Click += new System.EventHandler(this.closeChunkBtn_Click);
            // 
            // cancelChunkBtn
            // 
            this.cancelChunkBtn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.cancelChunkBtn.Location = new System.Drawing.Point(125, 198);
            this.cancelChunkBtn.Name = "cancelChunkBtn";
            this.cancelChunkBtn.Size = new System.Drawing.Size(110, 39);
            this.cancelChunkBtn.TabIndex = 1;
            this.cancelChunkBtn.Text = "Anuluj";
            this.cancelChunkBtn.Click += new System.EventHandler(this.cancelChunkBtn_Click);
            // 
            // errorMsgLbl
            // 
            this.errorMsgLbl.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.errorMsgLbl.Location = new System.Drawing.Point(0, 168);
            this.errorMsgLbl.Name = "errorMsgLbl";
            this.errorMsgLbl.Size = new System.Drawing.Size(235, 27);
            this.errorMsgLbl.Text = "__ERROR__";
            this.errorMsgLbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // NewChunk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 237);
            this.ControlBox = false;
            this.Controls.Add(this.errorMsgLbl);
            this.Controls.Add(this.cancelChunkBtn);
            this.Controls.Add(this.closeChunkBtn);
            this.Controls.Add(this.chunkCowList);
            this.Name = "NewChunk";
            this.Text = "Nowa transza";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button closeChunkBtn;
        private System.Windows.Forms.Button cancelChunkBtn;
        private System.Windows.Forms.Label errorMsgLbl;
        private CowListBox chunkCowList;
    }
}