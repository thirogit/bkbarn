using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace cowbase
{
    public abstract class MyListbox : ListBox
    {

        SolidBrush selectedItemBkBrush = new SolidBrush(SystemColors.Highlight);
        SolidBrush selectedItemTxtBrush = new SolidBrush(SystemColors.HighlightText);

        SolidBrush normalItemBkBrush;
        SolidBrush normalItemTxtBrush = new SolidBrush(SystemColors.WindowText);
        Pen greyPen = new Pen(Color.Gray);


        public void SelectItem(int iIndex)
        {
            this.SelectedIndex = iIndex;
        }

        public MyListbox()
        {
            this.DrawMode = DrawMode.OwnerDrawVariable;
            this.ScrollAlwaysVisible = true;
            normalItemBkBrush = new SolidBrush(BackColor);
            
        }

        public override Color BackColor 
        {
            get { return base.BackColor; }
            set 
            { 
                base.BackColor = value;
                normalItemBkBrush = new SolidBrush(BackColor);
            }
        }

        public void AddItem(object itemObj)
        {
            Items.Add(itemObj);
        }

        public int GetItemCount()
        {
            return Items.Count;
        }

        public object GetItem(int index)
        {
            return Items[index];
        }

        public void RemoveItemAt(int index)
        {
            Items.RemoveAt(index);
        }

        protected abstract string GetItemString(object itemObj);
        protected abstract void DrawItemString(Graphics graphics, object itemObj, Font font, Brush brush, Rectangle bounds);
        protected abstract void DrawItemRectangle(Graphics graphics, Brush brush, Rectangle bounds);

        protected override void OnMeasureItem(MeasureItemEventArgs e)
        {
            if (Site != null)
                return;
            if (e.Index > -1)
            {
                string s = GetItemString(Items[e.Index]);
                SizeF sf = e.Graphics.MeasureString(s, Font, Width);
                int htex = 4;
                e.ItemHeight = (int)sf.Height + htex;
                e.ItemWidth = Width;
            }
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (Site != null)
                return;
            if (e.Index > -1)
            {

                
                if ((e.State & DrawItemState.Selected) != 0 || (e.State & DrawItemState.Focus) != 0)
                {
                    DrawItemRectangle(e.Graphics, selectedItemBkBrush, e.Bounds);
                    DrawItemString(e.Graphics, Items[e.Index], Font, selectedItemTxtBrush, e.Bounds);
                }
                else
                {
                    DrawItemRectangle(e.Graphics, normalItemBkBrush, e.Bounds);
                    DrawItemString(e.Graphics, Items[e.Index], Font, normalItemTxtBrush, e.Bounds);

                }

                e.Graphics.DrawRectangle(greyPen, e.Bounds);
            }
        }    
    }
}
