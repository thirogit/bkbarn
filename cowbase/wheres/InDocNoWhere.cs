using System;

using System.Collections.Generic;
using System.Text;

namespace cowbase.wheres
{
    public class InDocNoWhere : CowWhere
    {
        private int m_InDocNo;

        public InDocNoWhere(int indocno)
        {
            m_InDocNo = indocno;
        }

        public string getWhere()
        {
            return "docin = " + Utils.FormatIntegerSQL(m_InDocNo);
        }
    }
}
