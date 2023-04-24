using System;

using System.Collections.Generic;
using System.Text;

namespace cowbase
{
    public class Stock
    {
        public int stockId;
        public String stockCode;

        private CowSex m_predefSex = CowSex.NONE;

        public override string ToString()
        {
            return stockCode;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            return stockId == ((Stock)obj).stockId;
        }

        public override int GetHashCode()
        {
            return stockId;
        }

        public CowSex predefSex
        {
            get { return m_predefSex; }
            set
            {
                if (value == null)
                {
                    m_predefSex = CowSex.NONE;
                }
                else
                {
                    m_predefSex = value;
                }
            }
        }
    }
}
