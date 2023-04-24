using System;

namespace cowbase
{
    public abstract class BCDevice
    {
        private EventHandler OnBarcodeRead;
                
        public abstract void Init();
        public abstract void Dispose();

        public void RegisterReadHander(EventHandler readHandler)
        {
            OnBarcodeRead += readHandler;
        }

        public void UnregisterReadHander(EventHandler readHandler)
        {
            OnBarcodeRead -= readHandler;
        }

        protected void NorifyBCRead(string BC)
        {
            OnBarcodeRead(BC, null);
        }


    }
}