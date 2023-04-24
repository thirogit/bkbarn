using System;
using System.Collections.Generic;

namespace cowbase
{
	/// <summary>
	/// Summary description for SearchPassInInDocs.
	/// </summary>
	public class SearchPassInInDocs : InDocListView
	{
		public SearchPassInInDocs()
		{			
			this.Text = "Wyszukiwanie paszportów PZ";
		}

		protected override bool EditDoc(Doc doc)
		{
            ICollection<Cow> cows = SQLDB.LoadCows(new cowbase.wheres.InDocNoWhere(doc.docno));
			PassSearchDlg passSearch = new InDocPassSearchDlg(cows);
			passSearch.ShowDialog();
            passSearch = null;
            cows = null;
			return false;
		}
	}
}
