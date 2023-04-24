using System;
using System.Collections.Generic;
using System.Text;

namespace cowbase
{
    public abstract class BuzzerDevice
    {
        public enum BuzzerSignals
        {
            GOOD,
            BAD
        };

        public static readonly int GoodDuration = 400, BadDuration = 600;//millisec
        public static readonly int GoodFrequency = 3500, BadFrequency = 2500;//hz

        public abstract void Buzz(BuzzerSignals signal);

        public abstract bool InitBuzzer();
        public abstract void DisposeBuzzer();
      
    }
}
