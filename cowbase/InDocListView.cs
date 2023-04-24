using System;
using System.Windows.Forms;

namespace cowbase
{
	/// <summary>
	/// Summary description for InDocListView.
	/// </summary>
	public class InDocListView : DocListView
	{
		public InDocListView()
		{
			m_tableName = "indocs";
			m_cattleDocFieldName = "docin";
			this.Text = "Podglad PZ";
		}

		protected override bool EditDoc(Doc doc)
		{
			EditInDoc editInDoc = new EditInDoc(doc);
			bool bRet = editInDoc.ShowDialog() == DialogResult.OK;
			editInDoc = null;
			return bRet;

		}
	}
}
