using System;

using System.Collections.Generic;
using System.Text;

namespace cowbase
{
    public class InDocPassSearchDlg : PassSearchDlg
    {
        public InDocPassSearchDlg(ICollection<Cow> cowArray) : base(cowArray,new InDocCowGroupAccessor())
        {
            
        }
        
    }
}
