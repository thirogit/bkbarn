using System;

using System.Collections.Generic;
using System.Text;

namespace cowbase
{
    public class InDocCowItemStringFormetter : CowItemStringFormatter
    {
        public override string GetCowItemString(Cow cow)
        {
            return cow.EAN + "    " + cow.sex.ToString() +
                "    " + cow.stock.stockCode + "\n" + cow.weight.ToString() + "kg" + "    Grupa: " + GetCowGroupString(cow.ingrp);
        }
    }
}
