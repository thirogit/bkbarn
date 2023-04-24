using System;
using System.Windows.Forms;

namespace cowbase
{
	/// <summary>
	/// Summary description for OutDocListView.
	/// </summary>
	public class OutDocListView : DocListView 
	{
		public OutDocListView()
		{
			m_tableName = "outdocs";
			m_cattleDocFieldName = "docout";
			this.Text = "Podglad WZ";
		}

		protected override bool EditDoc(Doc doc)
		{
			EditOutDoc editOutDoc = new EditOutDoc(doc);
			bool bRet = editOutDoc.ShowDialog() == DialogResult.OK;
			editOutDoc = null;
			return bRet;
			
		}
	}
}
