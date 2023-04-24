using System;

using System.Collections.Generic;
using System.Text;

namespace cowbase
{
    public class OutDocCowItemStringFormatter : CowItemStringFormatter
    {
        public override string GetCowItemString(Cow cow)
        {
            return cow.EAN + "  " + cow.sex.ToString() +
                "  " + cow.stock.stockCode + " " + cow.weight.ToString() + "kg" +
                "\nGrupa: " + GetCowGroupString(cow.outgrp) + "  Od: " + cow.hentalias;
        }
    }
}
