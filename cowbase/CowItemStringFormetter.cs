using System;

using System.Collections.Generic;
using System.Text;

namespace cowbase
{
    public abstract class CowItemStringFormatter : ItemStringFormatter
    {
        public abstract string GetCowItemString(Cow cow);

        public override string GetItemString(object itemObj)
        {
            return GetCowItemString((Cow)itemObj);
        }

        protected string GetCowGroupString(int grp)
        {
            if (grp != SQLDB.NULL_OUT_GRP)
                return grp.ToString();
            else
                return "---";
        }
    }


}
