using System;

using System.Collections.Generic;
using System.Text;

namespace cowbase
{
    class OutDocCowGroupAccessor : CowGroupAccessor
    {
        public override int GetGroup(Cow cow)
        {
            return cow.outgrp;
        }
    }
}
