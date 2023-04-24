using System;

using System.Collections.Generic;
using System.Text;
using System.Drawing;
using OpenNETCF.Windows.Forms;
using System.Collections;

namespace cowbase
{
    public abstract class MyListbox : OpenNETCF.Windows.Forms.ListBox2
    {
        protected abstract string GetItemString(object itemObj);
        protected abstract void DrawItemString(Graphics graphics, object itemObj, Font font, Brush brush, Rectangle bounds);
        protected abstract void DrawItemRectangle(Graphics graphics, Brush brush, Rectangle bounds);

        SolidBrush selectedItemBkBrush = new SolidBrush(SystemColors.Highlight);
        SolidBrush selectedItemTxtBrush = new SolidBrush(SystemColors.HighlightText);

        SolidBrush normalItemBkBrush;
        SolidBrush normalItemTxtBrush = new SolidBrush(SystemColors.WindowText);
        Pen greyPen = new Pen(Color.Gray);

        const int itemPadding = 2;

        ArrayList m_itemObjs = new ArrayList();

        public MyListbox()
        {
            this.DrawItem += new DrawItemEventHandler(DoDrawItem);
            this.LineColor = Color.Black;
            this.ItemHeight = 38;
            this.ShowLines = true;
            this.DrawMode = DrawMode.OwnerDrawFixed;
            normalItemBkBrush = new SolidBrush(BackColor);
            this.ShowScrollbar = true;
            //this.docListBox.EvenItemColor = System.Drawing.SystemColors.Control;
            //this.cowListBox.WrapText = false;
        }

        public void SelectItem(int iIndex)
        {
            this.SelectedIndex = iIndex;
            EnsureVisible(iIndex);
            Invalidate();
        }


        public void AddItem(object itemObj)
        {
            BeginUpdate();
            m_itemObjs.Add(itemObj);            
            Items.Add(new ListItem());
            EndUpdate();
        }

        public void RemoveItemAt(int index)
        {
            BeginUpdate();
            m_itemObjs.RemoveAt(index);
            Items.RemoveAt(index);
            EndUpdate();
        }

        public object GetItem(int index)
        {
            return m_itemObjs[index];
        }

        public int GetItemCount() 
        {
            return m_itemObjs.Count;
        }

        protected void DoDrawItem(object sender, DrawItemEventArgs e)
        {
          

            // custom draw the item
            e.Graphics.Clip = new Region(e.Bounds);

            if (e.Index > -1)
            {
                Rectangle paddedBounds = new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
                paddedBounds.Inflate(-itemPadding, -itemPadding);

                object itemObj = m_itemObjs[e.Index];
                if ((e.State & DrawItemState.Selected) != 0 || (e.State & DrawItemState.Focus) != 0)
                {
                    DrawItemRectangle(e.Graphics, selectedItemBkBrush, e.Bounds);

                    DrawItemString(e.Graphics, itemObj, Font, selectedItemTxtBrush, paddedBounds);
                }
                else
                {
                    DrawItemRectangle(e.Graphics, normalItemBkBrush, e.Bounds);

                    DrawItemString(e.Graphics, itemObj, Font, normalItemTxtBrush, paddedBounds);

                }

                e.Graphics.DrawRectangle(greyPen, e.Bounds);
            }

           

            e.Graphics.ResetClip();
        }

    }
}
