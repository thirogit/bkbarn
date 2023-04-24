using System;

using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace cowbase
{
    public class PassSearchCowListBox : CowListBox
    {
        Font m_foundItemFont;

        public PassSearchCowListBox()
        {
            m_foundItemFont = new Font(this.Font.Name, this.Font.Size, FontStyle.Strikeout);
          
        }

        protected override void DrawItemString(Graphics graphics, object itemObj, Font font, Brush brush, Rectangle bounds)
        {
            PassSearchCowItem cowItem = (PassSearchCowItem)itemObj;

            Font itemFont = this.Font;

            string s = GetItemString(itemObj);

            if (cowItem.passportFound)
                itemFont = m_foundItemFont;


            graphics.DrawString(s, itemFont, brush, bounds);
        }
    }
}
