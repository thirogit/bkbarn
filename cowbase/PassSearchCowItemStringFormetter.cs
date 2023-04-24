using System;

using System.Collections.Generic;
using System.Text;

namespace cowbase
{
    class PassSearchCowItemStringFormetter : CowItemStringFormatter
    {
        private CowGroupAccessor cowGroupAccessor;

        public PassSearchCowItemStringFormetter(CowGroupAccessor aCowGroupAccessor)
        {
            SetCowGroupAccessor(aCowGroupAccessor);
        }

        public void SetCowGroupAccessor(CowGroupAccessor aCowGroupAccessor)
        {
            cowGroupAccessor = aCowGroupAccessor;
        }

        public override string GetItemString(object itemObj)
        {
            return GetCowItemString(((PassSearchCowItem)itemObj).cow);
        }

        public override string GetCowItemString(Cow cow)
        {
            return cow.EAN + "    " + cow.sex.ToString() +
                "    " + cow.stock.stockCode + "    " + cow.weight.ToString() + "kg" +
                "    Grupa: " + GetCowGroupString(GetCowGroup(cow));
        }

        protected int GetCowGroup(Cow cow)
        {
            if (cowGroupAccessor == null)
                return SQLDB.NULL_OUT_GRP;
            return cowGroupAccessor.GetGroup(cow);
        }
    }
}
