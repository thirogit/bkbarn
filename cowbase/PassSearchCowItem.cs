using System;

using System.Collections.Generic;
using System.Text;

namespace cowbase
{
    public class PassSearchCowItem 
    {
        public bool passportFound = false;
        public Cow cow = null;

        public PassSearchCowItem(Cow aCow)
        {
            cow = aCow;
        }
    }
}
