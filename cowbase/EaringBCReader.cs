using System;

namespace cowbase
{
    public class EaringBCReader
    {
        private static EaringBCReader m_BCReader = null;
        public EventHandler OnRead;
        private BCDevice m_bcDevice;
        private EventHandler m_bcReadEventHandler;

        private EaringBCReader()
        {

        }
               

        public void Init()
        {
            if (m_bcDevice == null)
            {
#if COWBASEMOCK
                m_bcDevice = new cowbasemock.MockBCDevice();
#else
                m_bcDevice = new SymbolBCDevice();
#endif
                m_bcReadEventHandler = new EventHandler(this.BarcodeReadNotify);

                m_bcDevice.Init();
                m_bcDevice.RegisterReadHander(m_bcReadEventHandler);
            }
        }

        public void Finish()
        {
            if (m_bcDevice != null)
            {
                m_bcDevice.UnregisterReadHander(m_bcReadEventHandler);
                m_bcDevice.Dispose();
                m_bcDevice = null;
            }
        }

        public static EaringBCReader GetInstance()
        {
            if (m_BCReader == null)
                m_BCReader = new EaringBCReader();
            return m_BCReader;
        }         

        private void BarcodeReadNotify(object sender, System.EventArgs e)
        {
            string ean = (string)sender;
            OnRead(ean, null);

        }
    }
}
