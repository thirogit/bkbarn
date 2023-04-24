using System;

using System.Collections.Generic;
using System.Text;

namespace cowbase.wheres
{
    public class CowInStockWhere : CowWhere
    {
        public string getWhere()
        {
            return "docout IS NULL";
        }
    }
}
