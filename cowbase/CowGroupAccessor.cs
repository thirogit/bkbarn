using System;

using System.Collections.Generic;
using System.Text;

namespace cowbase
{
    public abstract class CowGroupAccessor
    {
        public abstract int GetGroup(Cow cow);
    }
}
