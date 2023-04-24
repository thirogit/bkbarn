using System;
using System.Windows.Forms;
using System.Drawing;

namespace cowbase
{
	/// <summary>
	/// Summary description for CenterForm.
	/// </summary>
	public class CenterForm : System.Windows.Forms.Form
	{
		public CenterForm()
		{
			this.Load += new System.EventHandler(this.CenterOnLoad);
			
		}

		protected void CenterOnLoad(object sender, System.EventArgs e)
		{
			Rectangle _screen = Screen.PrimaryScreen.WorkingArea; 
			this.Location =new Point(((_screen.Width - this.Width) / 2),
				((_screen.Height - this.Height) / 2));
		}

		
	}
}
