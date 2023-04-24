using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;


namespace cowbasemock
{
    class MockBuzzer : cowbase.BuzzerDevice
    {
        [DllImport("kernel32.dll")]
        public static extern bool Beep(int freq, int duration);

        public override void Buzz(BuzzerSignals signal)
        {
            switch (signal)
            {
                case cowbase.BuzzerDevice.BuzzerSignals.BAD:
                    Beep(cowbase.BuzzerDevice.BadFrequency, cowbase.BuzzerDevice.BadDuration);
                    break;
                case cowbase.BuzzerDevice.BuzzerSignals.GOOD:
                    Beep(cowbase.BuzzerDevice.GoodFrequency, cowbase.BuzzerDevice.GoodDuration);
                    break;
            }
        }

        public override bool InitBuzzer()
        {
            return true;
        }
        public override void DisposeBuzzer()
        {
        }
    }
}
