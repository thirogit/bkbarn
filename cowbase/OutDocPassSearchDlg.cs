using System;

using System.Collections.Generic;
using System.Text;

namespace cowbase
{
    public class OutDocPassSearchDlg : PassSearchDlg
    {
        public OutDocPassSearchDlg(ICollection<Cow> cowArray)
            : base(cowArray,new OutDocCowGroupAccessor())
        {

        }
        
    }
}
