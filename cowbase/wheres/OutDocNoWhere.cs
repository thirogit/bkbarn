using System;

using System.Collections.Generic;
using System.Text;

namespace cowbase.wheres
{  

    public class OutDocNoWhere : CowWhere
    {
        private int m_OutDocNo;

        public OutDocNoWhere(int outdocno)
        {
            m_OutDocNo = outdocno;
        }

        public string getWhere()
        {
            return "docout = " + Utils.FormatIntegerSQL(m_OutDocNo);
        }
    }
}
