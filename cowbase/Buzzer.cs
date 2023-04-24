using System;

namespace cowbase
{
    class Buzzer
    {
        BuzzerDevice m_buzzDevice;

        public Buzzer()
        {
#if COWBASEMOCK
            m_buzzDevice = new cowbasemock.MockBuzzer();
#else
            m_buzzDevice = new SymbolBuzzer();
#endif                       
        }

        public bool InitBuzzer()
        {
            return m_buzzDevice.InitBuzzer();
        }
        public void DisposeBuzzer()
        {
            m_buzzDevice.DisposeBuzzer();
        }
        public void Buzz(BuzzerDevice.BuzzerSignals signal)
        {
            m_buzzDevice.Buzz(signal);
        }
    }
}