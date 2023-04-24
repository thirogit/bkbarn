using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace cowbase
{
    public partial class Options : CenterForm
    {
        public Options()
        {
            InitializeComponent();
#if !COWBASEMOCK
            this.setDefaultHostBtn.Image = cowbase.Properties.Resources.activesync;
#endif
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            if (hostipBox.Text.Length > 0)
                Settings.Instance.host = hostipBox.Text;
            else
            {
                BigOKMessageBox.ShowMessage("Puste pole","Pole 'Host' nie moze byc puste");
                return;
            }
            Settings.Instance.usePredefSex = usePredefSexCheck.Checked;
            Settings.Instance.redBirthdateDays = Decimal.ToInt32(redBirthdateDaysScroll.Value);
            Close();
        }

        private void Options_Load(object sender, EventArgs e)
        {
            hostipBox.Text = Settings.Instance.host;
            usePredefSexCheck.Checked = Settings.Instance.usePredefSex;
            redBirthdateDaysScroll.Value = Settings.Instance.redBirthdateDays;
        }

        private void setDefaultHostBtn_Click(object sender, EventArgs e)
        {
            hostipBox.Text = "ppp_peer";   
        }
    }
}