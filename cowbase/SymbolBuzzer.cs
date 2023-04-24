using System;

using System.Collections.Generic;
using System.Text;

namespace cowbase
{
    class SymbolBuzzer : BuzzerDevice
    {
        private Symbol.Audio.Controller m_SymbolAudioController = null;

        public override void Buzz(BuzzerDevice.BuzzerSignals signal)
        {
            switch (signal)
            {
                case cowbase.BuzzerDevice.BuzzerSignals.BAD:
                    PlayBuzz(BuzzerDevice.BadDuration, BuzzerDevice.BadFrequency);
                    break;
                case cowbase.BuzzerDevice.BuzzerSignals.GOOD:
                    PlayBuzz(BuzzerDevice.GoodDuration, BuzzerDevice.GoodFrequency);
                    break;
            }
        }
        protected void PlayBuzz(int duration, int freq)
        {            
            if(m_SymbolAudioController != null)
            {
                m_SymbolAudioController.PlayAudio(duration, freq);                    
            }
        
        }

        public override bool InitBuzzer()
        {
            Symbol.Audio.Device symbolAudioDevice = (Symbol.Audio.Device)Symbol.StandardForms.SelectDevice.Select(
                Symbol.Audio.Controller.Title,
                Symbol.Audio.Device.AvailableDevices);

            if (symbolAudioDevice != null)
            {
                switch (symbolAudioDevice.AudioType)
                {
                    //if standard device
                    case Symbol.Audio.AudioType.StandardAudio:
                        m_SymbolAudioController = new Symbol.Audio.StandardAudio(symbolAudioDevice);
                        break;

                    //if simulated device
                    case Symbol.Audio.AudioType.SimulatedAudio:
                        m_SymbolAudioController = new Symbol.Audio.SimulatedAudio(symbolAudioDevice);
                        break;

                    default:
                        return false;
                }
                return true;
            }
            return false;
        }
        public override void DisposeBuzzer()
        {
            if (m_SymbolAudioController != null)
                    m_SymbolAudioController.Dispose();
            m_SymbolAudioController = null;
        }
    }
}
