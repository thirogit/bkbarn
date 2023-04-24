using System;

using System.Collections.Generic;
using System.Text;

namespace cowbase.wheres
{
    public class EanWhere : CowWhere
    {
        private string m_sEan;
        public EanWhere(string sEAN)
        {
            m_sEan = sEAN;
        }

        public string getWhere()
        {
            return "ean = '" + m_sEan + '\'';
        }
    }
}
