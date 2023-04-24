using System;

using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

namespace cowbase
{
    public abstract class OwnerDataListBox : MyListbox
    {      

         private ItemStringFormatter itemFormatter;


         public void SetFormatter(ItemStringFormatter aItemFormater)
         {
             this.itemFormatter = aItemFormater;
         }

         protected override string GetItemString(object itemObj)
         {
             if (itemFormatter != null)
                 return itemFormatter.GetItemString(itemObj);
             else
                 return itemObj.ToString();
         }
                 

         protected override void DrawItemString(Graphics graphics, object itemObj, Font font, Brush brush, Rectangle bounds)
         {
            string s = GetItemString(itemObj);
            graphics.DrawString(s, font, brush, bounds);
         }

         protected override void DrawItemRectangle(Graphics graphics, Brush brush, Rectangle bounds)
         {
             graphics.FillRectangle(brush, bounds);
         }    
       

        
    }
}
