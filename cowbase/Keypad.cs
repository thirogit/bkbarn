using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace cowbase
{
	/// <summary>
	/// Summary description for Keypad.
	/// </summary>
    public class Keypad : CenterForm
	{
		private System.Windows.Forms.Button m_keyA;
		private System.Windows.Forms.Button m_keyB;
		private System.Windows.Forms.Button m_keyC;
		private System.Windows.Forms.Button m_keyD;
		private System.Windows.Forms.Button m_keyH;
		private System.Windows.Forms.Button m_keyG;
		private System.Windows.Forms.Button m_keyF;
		private System.Windows.Forms.Button m_keyE;
		private System.Windows.Forms.Button m_keyL;
		private System.Windows.Forms.Button m_keyK;
		private System.Windows.Forms.Button m_keyJ;
		private System.Windows.Forms.Button m_keyI;
		private System.Windows.Forms.Button m_keyP;
		private System.Windows.Forms.Button m_keyO;
		private System.Windows.Forms.Button m_keyN;
		private System.Windows.Forms.Button m_keyU;
		private System.Windows.Forms.Button m_keyT;
		private System.Windows.Forms.Button m_keyS;
		private System.Windows.Forms.Button m_keyR;
		private System.Windows.Forms.Button m_keyZ;
		private System.Windows.Forms.Button m_keyY;
		private System.Windows.Forms.Button m_keyX;
		private System.Windows.Forms.Button m_keyW;
		private System.Windows.Forms.TextBox m_inputText;
		private System.Windows.Forms.Button m_OKBtn;
		private System.Windows.Forms.Button m_backBtn;
		private System.Windows.Forms.Button m_keySpace;
		private System.Windows.Forms.Button m_keyBackSpace;
		private System.Windows.Forms.Button m_keyQ;
		private System.Windows.Forms.Button m_keyV;
		private System.Windows.Forms.Button m_key0;
		private System.Windows.Forms.Button m_key5;
		private System.Windows.Forms.Button m_key9;
		private System.Windows.Forms.Button m_key4;
		private System.Windows.Forms.Button m_key8;
		private System.Windows.Forms.Button m_key3;
		private System.Windows.Forms.Button m_key7;
		private System.Windows.Forms.Button m_key2;
		private System.Windows.Forms.Button m_key6;
		private System.Windows.Forms.Button m_key1;
		private System.Windows.Forms.Button m_keyM;

		private int m_maxlen;
	
		public Keypad(int maxlen,string caption)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_maxlen = maxlen;
			if(maxlen <= 0) throw new ArgumentException("maxlen <= 0");
			if(caption != null)
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
            this.m_keyA = new System.Windows.Forms.Button();
            this.m_keyB = new System.Windows.Forms.Button();
            this.m_keyC = new System.Windows.Forms.Button();
            this.m_keyD = new System.Windows.Forms.Button();
            this.m_keyH = new System.Windows.Forms.Button();
            this.m_keyG = new System.Windows.Forms.Button();
            this.m_keyF = new System.Windows.Forms.Button();
            this.m_keyE = new System.Windows.Forms.Button();
            this.m_keyL = new System.Windows.Forms.Button();
            this.m_keyK = new System.Windows.Forms.Button();
            this.m_keyJ = new System.Windows.Forms.Button();
            this.m_keyI = new System.Windows.Forms.Button();
            this.m_keyP = new System.Windows.Forms.Button();
            this.m_keyO = new System.Windows.Forms.Button();
            this.m_keyN = new System.Windows.Forms.Button();
            this.m_keyM = new System.Windows.Forms.Button();
            this.m_keyU = new System.Windows.Forms.Button();
            this.m_keyT = new System.Windows.Forms.Button();
            this.m_keyS = new System.Windows.Forms.Button();
            this.m_keyR = new System.Windows.Forms.Button();
            this.m_keyZ = new System.Windows.Forms.Button();
            this.m_keyY = new System.Windows.Forms.Button();
            this.m_keyX = new System.Windows.Forms.Button();
            this.m_keyW = new System.Windows.Forms.Button();
            this.m_inputText = new System.Windows.Forms.TextBox();
            this.m_OKBtn = new System.Windows.Forms.Button();
            this.m_backBtn = new System.Windows.Forms.Button();
            this.m_keySpace = new System.Windows.Forms.Button();
            this.m_keyBackSpace = new System.Windows.Forms.Button();
            this.m_keyQ = new System.Windows.Forms.Button();
            this.m_keyV = new System.Windows.Forms.Button();
            this.m_key0 = new System.Windows.Forms.Button();
            this.m_key5 = new System.Windows.Forms.Button();
            this.m_key9 = new System.Windows.Forms.Button();
            this.m_key4 = new System.Windows.Forms.Button();
            this.m_key8 = new System.Windows.Forms.Button();
            this.m_key3 = new System.Windows.Forms.Button();
            this.m_key7 = new System.Windows.Forms.Button();
            this.m_key2 = new System.Windows.Forms.Button();
            this.m_key6 = new System.Windows.Forms.Button();
            this.m_key1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_keyA
            // 
            this.m_keyA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_keyA.Location = new System.Drawing.Point(0, 0);
            this.m_keyA.Name = "m_keyA";
            this.m_keyA.Size = new System.Drawing.Size(34, 32);
            this.m_keyA.TabIndex = 40;
            this.m_keyA.Text = "A";
            this.m_keyA.Click += new System.EventHandler(this.m_keyA_Click);
            // 
            // m_keyB
            // 
            this.m_keyB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_keyB.Location = new System.Drawing.Point(34, 0);
            this.m_keyB.Name = "m_keyB";
            this.m_keyB.Size = new System.Drawing.Size(34, 32);
            this.m_keyB.TabIndex = 39;
            this.m_keyB.Text = "B";
            this.m_keyB.Click += new System.EventHandler(this.m_keyB_Click);
            // 
            // m_keyC
            // 
            this.m_keyC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_keyC.Location = new System.Drawing.Point(68, 0);
            this.m_keyC.Name = "m_keyC";
            this.m_keyC.Size = new System.Drawing.Size(34, 32);
            this.m_keyC.TabIndex = 38;
            this.m_keyC.Text = "C";
            this.m_keyC.Click += new System.EventHandler(this.m_keyC_Click);
            // 
            // m_keyD
            // 
            this.m_keyD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_keyD.Location = new System.Drawing.Point(102, 0);
            this.m_keyD.Name = "m_keyD";
            this.m_keyD.Size = new System.Drawing.Size(34, 32);
            this.m_keyD.TabIndex = 37;
            this.m_keyD.Text = "D";
            this.m_keyD.Click += new System.EventHandler(this.m_keyD_Click);
            // 
            // m_keyH
            // 
            this.m_keyH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_keyH.Location = new System.Drawing.Point(68, 32);
            this.m_keyH.Name = "m_keyH";
            this.m_keyH.Size = new System.Drawing.Size(34, 32);
            this.m_keyH.TabIndex = 33;
            this.m_keyH.Text = "H";
            this.m_keyH.Click += new System.EventHandler(this.m_keyH_Click);
            // 
            // m_keyG
            // 
            this.m_keyG.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_keyG.Location = new System.Drawing.Point(34, 32);
            this.m_keyG.Name = "m_keyG";
            this.m_keyG.Size = new System.Drawing.Size(34, 32);
            this.m_keyG.TabIndex = 34;
            this.m_keyG.Text = "G";
            this.m_keyG.Click += new System.EventHandler(this.m_keyG_Click);
            // 
            // m_keyF
            // 
            this.m_keyF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_keyF.Location = new System.Drawing.Point(0, 32);
            this.m_keyF.Name = "m_keyF";
            this.m_keyF.Size = new System.Drawing.Size(34, 32);
            this.m_keyF.TabIndex = 35;
            this.m_keyF.Text = "F";
            this.m_keyF.Click += new System.EventHandler(this.m_keyF_Click);
            // 
            // m_keyE
            // 
            this.m_keyE.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_keyE.Location = new System.Drawing.Point(136, 0);
            this.m_keyE.Name = "m_keyE";
            this.m_keyE.Size = new System.Drawing.Size(34, 32);
            this.m_keyE.TabIndex = 36;
            this.m_keyE.Text = "E";
            this.m_keyE.Click += new System.EventHandler(this.m_keyE_Click);
            // 
            // m_keyL
            // 
            this.m_keyL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_keyL.Location = new System.Drawing.Point(34, 64);
            this.m_keyL.Name = "m_keyL";
            this.m_keyL.Size = new System.Drawing.Size(34, 32);
            this.m_keyL.TabIndex = 29;
            this.m_keyL.Text = "L";
            this.m_keyL.Click += new System.EventHandler(this.m_keyL_Click);
            // 
            // m_keyK
            // 
            this.m_keyK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_keyK.Location = new System.Drawing.Point(0, 64);
            this.m_keyK.Name = "m_keyK";
            this.m_keyK.Size = new System.Drawing.Size(34, 32);
            this.m_keyK.TabIndex = 30;
            this.m_keyK.Text = "K";
            this.m_keyK.Click += new System.EventHandler(this.m_keyK_Click);
            // 
            // m_keyJ
            // 
            this.m_keyJ.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_keyJ.Location = new System.Drawing.Point(136, 32);
            this.m_keyJ.Name = "m_keyJ";
            this.m_keyJ.Size = new System.Drawing.Size(34, 32);
            this.m_keyJ.TabIndex = 31;
            this.m_keyJ.Text = "J";
            this.m_keyJ.Click += new System.EventHandler(this.m_keyJ_Click);
            // 
            // m_keyI
            // 
            this.m_keyI.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_keyI.Location = new System.Drawing.Point(102, 32);
            this.m_keyI.Name = "m_keyI";
            this.m_keyI.Size = new System.Drawing.Size(34, 32);
            this.m_keyI.TabIndex = 32;
            this.m_keyI.Text = "I";
            this.m_keyI.Click += new System.EventHandler(this.m_keyI_Click);
            // 
            // m_keyP
            // 
            this.m_keyP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_keyP.Location = new System.Drawing.Point(0, 96);
            this.m_keyP.Name = "m_keyP";
            this.m_keyP.Size = new System.Drawing.Size(34, 32);
            this.m_keyP.TabIndex = 25;
            this.m_keyP.Text = "P";
            this.m_keyP.Click += new System.EventHandler(this.m_keyP_Click);
            // 
            // m_keyO
            // 
            this.m_keyO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_keyO.Location = new System.Drawing.Point(136, 64);
            this.m_keyO.Name = "m_keyO";
            this.m_keyO.Size = new System.Drawing.Size(34, 32);
            this.m_keyO.TabIndex = 26;
            this.m_keyO.Text = "O";
            this.m_keyO.Click += new System.EventHandler(this.m_keyO_Click);
            // 
            // m_keyN
            // 
            this.m_keyN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_keyN.Location = new System.Drawing.Point(102, 64);
            this.m_keyN.Name = "m_keyN";
            this.m_keyN.Size = new System.Drawing.Size(34, 32);
            this.m_keyN.TabIndex = 27;
            this.m_keyN.Text = "N";
            this.m_keyN.Click += new System.EventHandler(this.m_keyN_Click);
            // 
            // m_keyM
            // 
            this.m_keyM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_keyM.Location = new System.Drawing.Point(68, 64);
            this.m_keyM.Name = "m_keyM";
            this.m_keyM.Size = new System.Drawing.Size(34, 32);
            this.m_keyM.TabIndex = 28;
            this.m_keyM.Text = "M";
            this.m_keyM.Click += new System.EventHandler(this.m_keyM_Click);
            // 
            // m_keyU
            // 
            this.m_keyU.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_keyU.Location = new System.Drawing.Point(0, 128);
            this.m_keyU.Name = "m_keyU";
            this.m_keyU.Size = new System.Drawing.Size(34, 32);
            this.m_keyU.TabIndex = 21;
            this.m_keyU.Text = "U";
            this.m_keyU.Click += new System.EventHandler(this.m_keyU_Click);
            // 
            // m_keyT
            // 
            this.m_keyT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_keyT.Location = new System.Drawing.Point(136, 96);
            this.m_keyT.Name = "m_keyT";
            this.m_keyT.Size = new System.Drawing.Size(34, 32);
            this.m_keyT.TabIndex = 22;
            this.m_keyT.Text = "T";
            this.m_keyT.Click += new System.EventHandler(this.m_keyT_Click);
            // 
            // m_keyS
            // 
            this.m_keyS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_keyS.Location = new System.Drawing.Point(102, 96);
            this.m_keyS.Name = "m_keyS";
            this.m_keyS.Size = new System.Drawing.Size(34, 32);
            this.m_keyS.TabIndex = 23;
            this.m_keyS.Text = "S";
            this.m_keyS.Click += new System.EventHandler(this.m_keyS_Click);
            // 
            // m_keyR
            // 
            this.m_keyR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_keyR.Location = new System.Drawing.Point(68, 96);
            this.m_keyR.Name = "m_keyR";
            this.m_keyR.Size = new System.Drawing.Size(34, 32);
            this.m_keyR.TabIndex = 24;
            this.m_keyR.Text = "R";
            this.m_keyR.Click += new System.EventHandler(this.m_keyR_Click);
            // 
            // m_keyZ
            // 
            this.m_keyZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_keyZ.Location = new System.Drawing.Point(0, 160);
            this.m_keyZ.Name = "m_keyZ";
            this.m_keyZ.Size = new System.Drawing.Size(34, 32);
            this.m_keyZ.TabIndex = 17;
            this.m_keyZ.Text = "Z";
            this.m_keyZ.Click += new System.EventHandler(this.m_keyZ_Click);
            // 
            // m_keyY
            // 
            this.m_keyY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_keyY.Location = new System.Drawing.Point(136, 128);
            this.m_keyY.Name = "m_keyY";
            this.m_keyY.Size = new System.Drawing.Size(34, 32);
            this.m_keyY.TabIndex = 18;
            this.m_keyY.Text = "Y";
            this.m_keyY.Click += new System.EventHandler(this.m_keyY_Click);
            // 
            // m_keyX
            // 
            this.m_keyX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_keyX.Location = new System.Drawing.Point(102, 128);
            this.m_keyX.Name = "m_keyX";
            this.m_keyX.Size = new System.Drawing.Size(34, 32);
            this.m_keyX.TabIndex = 19;
            this.m_keyX.Text = "X";
            this.m_keyX.Click += new System.EventHandler(this.m_keyX_Click);
            // 
            // m_keyW
            // 
            this.m_keyW.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_keyW.Location = new System.Drawing.Point(68, 128);
            this.m_keyW.Name = "m_keyW";
            this.m_keyW.Size = new System.Drawing.Size(34, 32);
            this.m_keyW.TabIndex = 20;
            this.m_keyW.Text = "W";
            this.m_keyW.Click += new System.EventHandler(this.m_keyW_Click);
            // 
            // m_inputText
            // 
            this.m_inputText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_inputText.Location = new System.Drawing.Point(0, 192);
            this.m_inputText.Name = "m_inputText";
            this.m_inputText.Size = new System.Drawing.Size(238, 25);
            this.m_inputText.TabIndex = 16;
            this.m_inputText.Text = "__TEXT__";
            // 
            // m_OKBtn
            // 
            this.m_OKBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_OKBtn.Location = new System.Drawing.Point(0, 217);
            this.m_OKBtn.Name = "m_OKBtn";
            this.m_OKBtn.Size = new System.Drawing.Size(153, 56);
            this.m_OKBtn.TabIndex = 15;
            this.m_OKBtn.Text = "OK";
            this.m_OKBtn.Click += new System.EventHandler(this.m_OKBtn_Click);
            // 
            // m_backBtn
            // 
            this.m_backBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_backBtn.Location = new System.Drawing.Point(159, 217);
            this.m_backBtn.Name = "m_backBtn";
            this.m_backBtn.Size = new System.Drawing.Size(79, 56);
            this.m_backBtn.TabIndex = 14;
            this.m_backBtn.Text = "Wstecz";
            this.m_backBtn.Click += new System.EventHandler(this.m_backBtn_Click);
            // 
            // m_keySpace
            // 
            this.m_keySpace.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_keySpace.Location = new System.Drawing.Point(34, 160);
            this.m_keySpace.Name = "m_keySpace";
            this.m_keySpace.Size = new System.Drawing.Size(136, 32);
            this.m_keySpace.TabIndex = 13;
            this.m_keySpace.Text = "Spacja";
            this.m_keySpace.Click += new System.EventHandler(this.m_keySpace_Click);
            // 
            // m_keyBackSpace
            // 
            this.m_keyBackSpace.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_keyBackSpace.Location = new System.Drawing.Point(170, 160);
            this.m_keyBackSpace.Name = "m_keyBackSpace";
            this.m_keyBackSpace.Size = new System.Drawing.Size(68, 32);
            this.m_keyBackSpace.TabIndex = 12;
            this.m_keyBackSpace.Text = "<<";
            this.m_keyBackSpace.Click += new System.EventHandler(this.m_keyBackSpace_Click);
            // 
            // m_keyQ
            // 
            this.m_keyQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_keyQ.Location = new System.Drawing.Point(34, 96);
            this.m_keyQ.Name = "m_keyQ";
            this.m_keyQ.Size = new System.Drawing.Size(34, 32);
            this.m_keyQ.TabIndex = 11;
            this.m_keyQ.Text = "Q";
            this.m_keyQ.Click += new System.EventHandler(this.m_keyQ_Click);
            // 
            // m_keyV
            // 
            this.m_keyV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_keyV.Location = new System.Drawing.Point(34, 128);
            this.m_keyV.Name = "m_keyV";
            this.m_keyV.Size = new System.Drawing.Size(34, 32);
            this.m_keyV.TabIndex = 10;
            this.m_keyV.Text = "V";
            this.m_keyV.Click += new System.EventHandler(this.m_keyV_Click);
            // 
            // m_key0
            // 
            this.m_key0.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_key0.Location = new System.Drawing.Point(204, 128);
            this.m_key0.Name = "m_key0";
            this.m_key0.Size = new System.Drawing.Size(34, 32);
            this.m_key0.TabIndex = 0;
            this.m_key0.Text = "0";
            this.m_key0.Click += new System.EventHandler(this.m_key0_Click);
            // 
            // m_key5
            // 
            this.m_key5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_key5.Location = new System.Drawing.Point(170, 128);
            this.m_key5.Name = "m_key5";
            this.m_key5.Size = new System.Drawing.Size(34, 32);
            this.m_key5.TabIndex = 1;
            this.m_key5.Text = "5";
            this.m_key5.Click += new System.EventHandler(this.m_key5_Click);
            // 
            // m_key9
            // 
            this.m_key9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_key9.Location = new System.Drawing.Point(204, 96);
            this.m_key9.Name = "m_key9";
            this.m_key9.Size = new System.Drawing.Size(34, 32);
            this.m_key9.TabIndex = 2;
            this.m_key9.Text = "9";
            this.m_key9.Click += new System.EventHandler(this.m_key9_Click);
            // 
            // m_key4
            // 
            this.m_key4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_key4.Location = new System.Drawing.Point(170, 96);
            this.m_key4.Name = "m_key4";
            this.m_key4.Size = new System.Drawing.Size(34, 32);
            this.m_key4.TabIndex = 3;
            this.m_key4.Text = "4";
            this.m_key4.Click += new System.EventHandler(this.m_key4_Click);
            // 
            // m_key8
            // 
            this.m_key8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_key8.Location = new System.Drawing.Point(204, 64);
            this.m_key8.Name = "m_key8";
            this.m_key8.Size = new System.Drawing.Size(34, 32);
            this.m_key8.TabIndex = 4;
            this.m_key8.Text = "8";
            this.m_key8.Click += new System.EventHandler(this.m_key8_Click);
            // 
            // m_key3
            // 
            this.m_key3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_key3.Location = new System.Drawing.Point(170, 64);
            this.m_key3.Name = "m_key3";
            this.m_key3.Size = new System.Drawing.Size(34, 32);
            this.m_key3.TabIndex = 5;
            this.m_key3.Text = "3";
            this.m_key3.Click += new System.EventHandler(this.m_key3_Click);
            // 
            // m_key7
            // 
            this.m_key7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_key7.Location = new System.Drawing.Point(204, 32);
            this.m_key7.Name = "m_key7";
            this.m_key7.Size = new System.Drawing.Size(34, 32);
            this.m_key7.TabIndex = 6;
            this.m_key7.Text = "7";
            this.m_key7.Click += new System.EventHandler(this.m_key7_Click);
            // 
            // m_key2
            // 
            this.m_key2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_key2.Location = new System.Drawing.Point(170, 32);
            this.m_key2.Name = "m_key2";
            this.m_key2.Size = new System.Drawing.Size(34, 32);
            this.m_key2.TabIndex = 7;
            this.m_key2.Text = "2";
            this.m_key2.Click += new System.EventHandler(this.m_key2_Click);
            // 
            // m_key6
            // 
            this.m_key6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_key6.Location = new System.Drawing.Point(204, 0);
            this.m_key6.Name = "m_key6";
            this.m_key6.Size = new System.Drawing.Size(34, 32);
            this.m_key6.TabIndex = 8;
            this.m_key6.Text = "6";
            this.m_key6.Click += new System.EventHandler(this.m_key6_Click);
            // 
            // m_key1
            // 
            this.m_key1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.m_key1.Location = new System.Drawing.Point(170, 0);
            this.m_key1.Name = "m_key1";
            this.m_key1.Size = new System.Drawing.Size(34, 32);
            this.m_key1.TabIndex = 9;
            this.m_key1.Text = "1";
            this.m_key1.Click += new System.EventHandler(this.m_key1_Click);
            // 
            // Keypad
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(238, 274);
            this.Controls.Add(this.m_key0);
            this.Controls.Add(this.m_key5);
            this.Controls.Add(this.m_key9);
            this.Controls.Add(this.m_key4);
            this.Controls.Add(this.m_key8);
            this.Controls.Add(this.m_key3);
            this.Controls.Add(this.m_key7);
            this.Controls.Add(this.m_key2);
            this.Controls.Add(this.m_key6);
            this.Controls.Add(this.m_key1);
            this.Controls.Add(this.m_keyV);
            this.Controls.Add(this.m_keyQ);
            this.Controls.Add(this.m_keyBackSpace);
            this.Controls.Add(this.m_keySpace);
            this.Controls.Add(this.m_backBtn);
            this.Controls.Add(this.m_OKBtn);
            this.Controls.Add(this.m_inputText);
            this.Controls.Add(this.m_keyZ);
            this.Controls.Add(this.m_keyY);
            this.Controls.Add(this.m_keyX);
            this.Controls.Add(this.m_keyW);
            this.Controls.Add(this.m_keyU);
            this.Controls.Add(this.m_keyT);
            this.Controls.Add(this.m_keyS);
            this.Controls.Add(this.m_keyR);
            this.Controls.Add(this.m_keyP);
            this.Controls.Add(this.m_keyO);
            this.Controls.Add(this.m_keyN);
            this.Controls.Add(this.m_keyM);
            this.Controls.Add(this.m_keyL);
            this.Controls.Add(this.m_keyK);
            this.Controls.Add(this.m_keyJ);
            this.Controls.Add(this.m_keyI);
            this.Controls.Add(this.m_keyH);
            this.Controls.Add(this.m_keyG);
            this.Controls.Add(this.m_keyF);
            this.Controls.Add(this.m_keyE);
            this.Controls.Add(this.m_keyD);
            this.Controls.Add(this.m_keyC);
            this.Controls.Add(this.m_keyB);
            this.Controls.Add(this.m_keyA);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Keypad";
            this.Text = "Klawiatura";
            this.Load += new System.EventHandler(this.Keypad_Load);
            this.ResumeLayout(false);

		}
		#endregion

		public string TextTyped
		{
			get {return m_inputText.Text;}
			set {m_inputText.Text = value;}
		}

		void InsertChar(char character)
		{
			if(m_inputText.TextLength < m_maxlen)
			m_inputText.Text += character;
			this.Focus();

		}
		private void m_keyA_Click(object sender, System.EventArgs e)
		{
			InsertChar('A');
		}

		private void m_keyB_Click(object sender, System.EventArgs e)
		{
			InsertChar('B');
		}

		private void m_keyC_Click(object sender, System.EventArgs e)
		{
			InsertChar('C');
		}

		private void m_keyD_Click(object sender, System.EventArgs e)
		{
			InsertChar('D');
		}

		private void m_keyH_Click(object sender, System.EventArgs e)
		{
			InsertChar('H');
		}

		private void m_keyG_Click(object sender, System.EventArgs e)
		{
			InsertChar('G');
		}

		private void m_keyF_Click(object sender, System.EventArgs e)
		{
			InsertChar('F');
		}

		private void m_keyE_Click(object sender, System.EventArgs e)
		{
			InsertChar('E');
		}

		private void m_keyI_Click(object sender, System.EventArgs e)
		{
			InsertChar('I');
		}

		private void m_keyJ_Click(object sender, System.EventArgs e)
		{
			InsertChar('J');
		}

		private void m_keyK_Click(object sender, System.EventArgs e)
		{
			InsertChar('K');
		}

		private void m_keyL_Click(object sender, System.EventArgs e)
		{
			InsertChar('L');
		}

		private void m_keyM_Click(object sender, System.EventArgs e)
		{
			InsertChar('M');
		}

		private void m_keyN_Click(object sender, System.EventArgs e)
		{
			InsertChar('N');
		}

		private void m_keyO_Click(object sender, System.EventArgs e)
		{
			InsertChar('O');
		}

		private void m_keyP_Click(object sender, System.EventArgs e)
		{
			InsertChar('P');
		}

		private void m_keyQ_Click(object sender, System.EventArgs e)
		{
			InsertChar('Q');
		}

		private void m_keyR_Click(object sender, System.EventArgs e)
		{
			InsertChar('R');
		}

		private void m_keyS_Click(object sender, System.EventArgs e)
		{
			InsertChar('S');
		}

		private void m_keyT_Click(object sender, System.EventArgs e)
		{
			InsertChar('T');
		}

		private void m_keyU_Click(object sender, System.EventArgs e)
		{
			InsertChar('U');
		}

		private void m_keyW_Click(object sender, System.EventArgs e)
		{
			InsertChar('W');
		}

		private void m_keyX_Click(object sender, System.EventArgs e)
		{
			InsertChar('X');
		}

		private void m_keyY_Click(object sender, System.EventArgs e)
		{
			InsertChar('Y');
		}

		private void m_keyZ_Click(object sender, System.EventArgs e)
		{
			InsertChar('Z');
		}

		private void m_keySpace_Click(object sender, System.EventArgs e)
		{
			InsertChar(' ');
		}

		private void Keypad_Load(object sender, System.EventArgs e)
		{
			m_inputText.Text = String.Empty;
			this.KeyPress += new KeyPressEventHandler(Keypad_KeyPress);
		}

		private void m_keyBackSpace_Click(object sender, System.EventArgs e)
		{
			if(m_inputText.TextLength > 0)
				m_inputText.Text = m_inputText.Text.Remove(m_inputText.TextLength-1,1);
			this.Focus();
		}

		private void m_OKBtn_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

		private void m_backBtn_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void m_keyV_Click(object sender, System.EventArgs e)
		{
			InsertChar('V');		
		}

		private void m_key1_Click(object sender, System.EventArgs e)
		{
			InsertChar('1');		
		}

		private void m_key6_Click(object sender, System.EventArgs e)
		{
			InsertChar('6');
		}

		private void m_key2_Click(object sender, System.EventArgs e)
		{
			InsertChar('2');
		}

		private void m_key7_Click(object sender, System.EventArgs e)
		{
			InsertChar('7');
		}

		private void m_key3_Click(object sender, System.EventArgs e)
		{
			InsertChar('3');
		}

		private void m_key8_Click(object sender, System.EventArgs e)
		{
			InsertChar('8');
		}

		private void m_key4_Click(object sender, System.EventArgs e)
		{
			InsertChar('4');
		}

		private void m_key9_Click(object sender, System.EventArgs e)
		{
			InsertChar('9');
		}

		private void m_key5_Click(object sender, System.EventArgs e)
		{
			InsertChar('5');
		}

		private void m_key0_Click(object sender, System.EventArgs e)
		{
			InsertChar('0');
		}

		private void Keypad_KeyPress(object sender, KeyPressEventArgs e)
		{
			char chr = char.ToUpper(e.KeyChar);
			
			if((chr >= '0' && chr <= '9') || (chr >= 'A' && chr <= 'Z') || chr == ' ')
				InsertChar(chr);
			else
			{
				switch(chr)
				{
					case (char)0x08: //backspace
						m_keyBackSpace_Click(null,null);
						break;
					case (char)0x0D: //enter
						m_OKBtn_Click(null,null);
						break;
					case (char)0x1B: //escape
						m_backBtn_Click(null,null);
						break;

				}
			}			
		}
	}
}
