using System;

namespace cowbase
{
#if !COWBASEMOCK
    public class SymbolBCDevice : BCDevice
    {
        private Symbol.Barcode.BarcodeReader m_bcDevice;
        private EventHandler ReadEventHandler;
        
        public SymbolBCDevice()
        {
            m_bcDevice = new Symbol.Barcode.BarcodeReader();
            m_bcDevice.Decoders.D2OF5 = Symbol.Barcode.DisabledEnabled.Enabled;
            m_bcDevice.Decoders.I2OF5 = Symbol.Barcode.DisabledEnabled.Enabled;
            m_bcDevice.Reader.Decoders.I2OF5.MaximumLength = 12;
            m_bcDevice.Reader.Decoders.I2OF5.MinimumLength = 4;            
            ReadEventHandler = new EventHandler(this.ReaderNotify);
            m_bcDevice.Reader.ReadNotify += ReadEventHandler;
        }

        public override void Init()
        {
            m_bcDevice.Start();
        }

        public override void Dispose()
        {
            m_bcDevice.Stop();
            m_bcDevice.Dispose();     
        } 
             


        private string FixEAN(string sEAN)
        {
            if (sEAN.Length <= 12)
            {
                if(!Utils.IsNumeric(sEAN))
                    return null;

                int bcPaddingLen = 12 - sEAN.Length;
                if (bcPaddingLen < 0) bcPaddingLen = 0;

                return "PL" + new string('0', bcPaddingLen) + sEAN;
            }
            else if (sEAN.Length == 14)
            {
                if (Utils.IsStrValidEAN(sEAN))
                    return sEAN;
            }
            return null;           

        }

        private void ReaderNotify(object sender, System.EventArgs e)
        {
            // If it is a successful read
            if (m_bcDevice.ReaderData.Result == Symbol.Results.SUCCESS)
            {
                string sEAN = FixEAN(m_bcDevice.ReaderData.Text);
                if(sEAN != null)
                    NorifyBCRead(sEAN);                  
                

            }
            m_bcDevice.Reader.Actions.Read(m_bcDevice.ReaderData);
            
        }
    }
#endif
}