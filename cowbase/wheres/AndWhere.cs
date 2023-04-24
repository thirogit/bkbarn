using System;

using System.Collections.Generic;
using System.Text;

namespace cowbase.wheres
{
    public class AndWhere : CowWhere
    {

        CowWhere[] m_wheres;

        public AndWhere(params CowWhere[] wheres)
        {
            m_wheres = wheres;
        }

        public string getWhere()
        {
            string whereClause = "";
            for (int i = 0; i < m_wheres.Length; i++)
            {
                whereClause += m_wheres[i].getWhere();
                if (i + 1 < m_wheres.Length)
                    whereClause += " AND ";

                
            }
            return whereClause;
        }
    }
}
