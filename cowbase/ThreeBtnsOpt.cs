using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace cowbase
{
    public partial class ThreeBtnsOpt : CenterForm
    {
        private int m_selectedOpt;

        public ThreeBtnsOpt(String opt1BtnText, bool bOpt1BtnEnabled,
                            String opt2BtnText, bool bOpt2BtnEnabled,
                            String opt3BtnText, bool bOpt3BtnEnabled)
        {
            InitializeComponent();
            m_selectedOpt = 0;

            Opt1Btn.Text = opt1BtnText;
            Opt1Btn.Enabled = bOpt1BtnEnabled;

            Opt2Btn.Text = opt2BtnText;
            Opt2Btn.Enabled = bOpt2BtnEnabled;

            Opt3Btn.Text = opt3BtnText;
            Opt3Btn.Enabled = bOpt3BtnEnabled;
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            
        }

        private void Opt1Btn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            m_selectedOpt = 1;
            Close();
        }

        private void Opt2Btn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            m_selectedOpt = 2;
            Close();
        }

        private void Opt3Btn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            m_selectedOpt = 3;
            Close();
        }

        public int GetSelectedOpt()
        {
            return m_selectedOpt;
        }
    }
}