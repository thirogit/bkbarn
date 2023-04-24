using System;

namespace cowbase
{
	/// <summary>
	/// Summary description for EnterEANForm.
	/// </summary>
	public class EnterEANForm : FindCowByEAN
	{
		public EnterEANForm() : base(false)
		{
			
		}

		protected override void FindCowByEAN_Load(object sender, System.EventArgs e)
		{
			base.FindCowByEAN_Load(sender,e);
			
			eanBox.Text = "PL";
			this.Text = "Wprowadz numer";
			
		}

		protected override void InsertDigit(int digit)
		{
			if(eanBox.TextLength < 14)
			{
				eanBox.Text += digit.ToString();
				m_OKbtn.Enabled = (eanBox.TextLength == 14);
			}
			else
				m_OKbtn.Enabled = true;


			if(m_OKbtn.Enabled)
				m_gotchaEAN = eanBox.Text;
			this.Focus();
		
		}

		protected override void m_delLastNum_Click(object sender, System.EventArgs e)
		{
			if(eanBox.TextLength > 2)
			{
				eanBox.Text = eanBox.Text.Remove(eanBox.TextLength-1,1);
			}
			m_OKbtn.Enabled = false;
			this.Focus();
		}
	}
}
