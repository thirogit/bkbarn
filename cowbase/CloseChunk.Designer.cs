namespace cowbase
{
    partial class CloseChunk
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
            this.okBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.setChunkTotalPriceBtn = new System.Windows.Forms.Button();
            this.setChunkTotalStockBtn = new System.Windows.Forms.Button();
            this.setChunkTotalWeightBtn = new System.Windows.Forms.Button();
            this.totalPriceLabel = new System.Windows.Forms.Label();
            this.stockForAllLabel = new System.Windows.Forms.Label();
            this.totalWeightLabel = new System.Windows.Forms.Label();
            this.setChunkPricePerKgBtn = new System.Windows.Forms.Button();
            this.perKgPriceLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // okBtn
            // 
            this.okBtn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.okBtn.Location = new System.Drawing.Point(3, 174);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(109, 53);
            this.okBtn.TabIndex = 3;
            this.okBtn.Text = "OK";
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.cancelBtn.Location = new System.Drawing.Point(126, 174);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(109, 53);
            this.cancelBtn.TabIndex = 4;
            this.cancelBtn.Text = "Anuluj";
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // setChunkTotalPriceBtn
            // 
            this.setChunkTotalPriceBtn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.setChunkTotalPriceBtn.Location = new System.Drawing.Point(3, 81);
            this.setChunkTotalPriceBtn.Name = "setChunkTotalPriceBtn";
            this.setChunkTotalPriceBtn.Size = new System.Drawing.Size(109, 33);
            this.setChunkTotalPriceBtn.TabIndex = 5;
            this.setChunkTotalPriceBtn.Text = "Wart. netto";
            this.setChunkTotalPriceBtn.Click += new System.EventHandler(this.setChunkTotalPriceBtn_Click);
            // 
            // setChunkTotalStockBtn
            // 
            this.setChunkTotalStockBtn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.setChunkTotalStockBtn.Location = new System.Drawing.Point(3, 120);
            this.setChunkTotalStockBtn.Name = "setChunkTotalStockBtn";
            this.setChunkTotalStockBtn.Size = new System.Drawing.Size(109, 33);
            this.setChunkTotalStockBtn.TabIndex = 6;
            this.setChunkTotalStockBtn.Text = "Rasa";
            this.setChunkTotalStockBtn.Click += new System.EventHandler(this.setChunkTotalStockBtn_Click);
            // 
            // setChunkTotalWeightBtn
            // 
            this.setChunkTotalWeightBtn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.setChunkTotalWeightBtn.Location = new System.Drawing.Point(3, 4);
            this.setChunkTotalWeightBtn.Name = "setChunkTotalWeightBtn";
            this.setChunkTotalWeightBtn.Size = new System.Drawing.Size(109, 33);
            this.setChunkTotalWeightBtn.TabIndex = 7;
            this.setChunkTotalWeightBtn.Text = "Waga";
            this.setChunkTotalWeightBtn.Click += new System.EventHandler(this.setChunkTotalWeightBtn_Click);
            // 
            // totalPriceLabel
            // 
            this.totalPriceLabel.Location = new System.Drawing.Point(126, 87);
            this.totalPriceLabel.Name = "totalPriceLabel";
            this.totalPriceLabel.Size = new System.Drawing.Size(109, 20);
            this.totalPriceLabel.Text = "__TOT_PRICE__";
            // 
            // stockForAllLabel
            // 
            this.stockForAllLabel.Location = new System.Drawing.Point(126, 126);
            this.stockForAllLabel.Name = "stockForAllLabel";
            this.stockForAllLabel.Size = new System.Drawing.Size(109, 20);
            this.stockForAllLabel.Text = "__STOCK__";
            // 
            // totalWeightLabel
            // 
            this.totalWeightLabel.Location = new System.Drawing.Point(126, 10);
            this.totalWeightLabel.Name = "totalWeightLabel";
            this.totalWeightLabel.Size = new System.Drawing.Size(109, 20);
            this.totalWeightLabel.Text = "__WEIGHT__";
            // 
            // setChunkPricePerKgBtn
            // 
            this.setChunkPricePerKgBtn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.setChunkPricePerKgBtn.Location = new System.Drawing.Point(3, 42);
            this.setChunkPricePerKgBtn.Name = "setChunkPricePerKgBtn";
            this.setChunkPricePerKgBtn.Size = new System.Drawing.Size(109, 33);
            this.setChunkPricePerKgBtn.TabIndex = 13;
            this.setChunkPricePerKgBtn.Text = "Cena za kg";
            this.setChunkPricePerKgBtn.Click += new System.EventHandler(this.setChunkPricePerKgBtn_Click);
            // 
            // perKgPriceLabel
            // 
            this.perKgPriceLabel.Location = new System.Drawing.Point(126, 48);
            this.perKgPriceLabel.Name = "perKgPriceLabel";
            this.perKgPriceLabel.Size = new System.Drawing.Size(109, 20);
            this.perKgPriceLabel.Text = "_PERKGPRICE_";
            // 
            // CloseChunk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 230);
            this.ControlBox = false;
            this.Controls.Add(this.perKgPriceLabel);
            this.Controls.Add(this.setChunkPricePerKgBtn);
            this.Controls.Add(this.totalWeightLabel);
            this.Controls.Add(this.stockForAllLabel);
            this.Controls.Add(this.totalPriceLabel);
            this.Controls.Add(this.setChunkTotalWeightBtn);
            this.Controls.Add(this.setChunkTotalStockBtn);
            this.Controls.Add(this.setChunkTotalPriceBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Name = "CloseChunk";
            this.Text = "Zamykanie transzy";
            this.Load += new System.EventHandler(this.CloseChunk_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button setChunkTotalPriceBtn;
        private System.Windows.Forms.Button setChunkTotalStockBtn;
        private System.Windows.Forms.Button setChunkTotalWeightBtn;
        private System.Windows.Forms.Label totalPriceLabel;
        private System.Windows.Forms.Label stockForAllLabel;
        private System.Windows.Forms.Label totalWeightLabel;
        private System.Windows.Forms.Button setChunkPricePerKgBtn;
        private System.Windows.Forms.Label perKgPriceLabel;
    }
}