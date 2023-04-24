using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gma.UserActivityMonitor;
using System.Windows.Forms;

namespace cowbasemock
{
    class MockBCDevice : cowbase.BCDevice
    {
        private bool m_bShowing;
        public override void Init()
        {
            HookManager.KeyPress += HookManager_KeyPress;
            m_bShowing = false;
        }
        public override void Dispose()
        {
            HookManager.KeyPress -= HookManager_KeyPress;
        }

        private void HookManager_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!m_bShowing && e.KeyChar =='`')
            {
                m_bShowing = true;

                BCManualInput bcManualInput = new BCManualInput();
                if(bcManualInput.ShowDialog() == DialogResult.OK)
                {
                    string bc = bcManualInput.BarcodeValue;
                    if(bc.Length == 14)
                        NorifyBCRead(bcManualInput.BarcodeValue);
                }

                m_bShowing = false;
            }
        } 

    }
}
