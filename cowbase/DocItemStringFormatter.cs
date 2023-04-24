using System;

using System.Collections.Generic;
using System.Text;

namespace cowbase
{
    public class DocItemStringFormatter : ItemStringFormatter
    {
        public override string GetItemString(object itemObj)
        {
            return GetDocItemString((Doc)itemObj);
        }

        protected string GetDocItemString(Doc doc)
        {
            string sDocNo;
            if (doc.action.Equals(Action.NEW))
                sDocNo = "----";
            else
                sDocNo = String.Format("{0:0000}", doc.docno);

            string sLoadDate = Utils.FormatDayDate(doc.loaddate);

            string sHentAlias = String.Format("{0,-24}", doc.hentalias);

            return sDocNo + "    " + sHentAlias + "\nData: " + sLoadDate + "     Ilosc: " + doc.cowcount.ToString();

        }
    }
}
