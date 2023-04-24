using System;

using System.Collections.Generic;
using System.Text;

namespace cowbase
{
    public class CowSex
    {

        private  const int XX_INT = 1;
        private  const int XY_INT = -1;
        private  const int NONE_INT = 0;


        private int m_iSex;
        private string m_sSex;

        public static CowSex XX = new CowSex(XX_INT, "XX");
        public static CowSex XY = new CowSex(XY_INT, "XY");
        public static CowSex NONE = new CowSex(NONE_INT, "BRAK");

        private CowSex(int iSex, string sSex)
        {
            m_iSex = iSex;
            m_sSex = sSex;
        }

        public override int GetHashCode()
        {
            return ToInt();
        }

        public override string ToString()
        {
            return m_sSex;
        }

        public int ToInt()
        {
           
            return m_iSex;
        }

        public override bool Equals(object obj)
        {
            return this == obj;
        }

        public static CowSex FromInt(int iSex)
        {
            switch (iSex)
            {
                case XX_INT:
                    return XX;
                case XY_INT:
                    return XY;
                case NONE_INT:
                    return NONE;
              
            }
            throw new SystemException("Illegal CowAction id");
        }

        
    }
}
