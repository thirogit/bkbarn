using System;

using System.Collections.Generic;
using System.Text;

namespace cowbase
{
    public class InDocCowGroupAccessor : CowGroupAccessor
    {
        public override int GetGroup(Cow cow)
        {
            return cow.ingrp;
        }
    }
}
