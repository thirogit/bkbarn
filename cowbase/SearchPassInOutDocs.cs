using System;
using System.Collections.Generic;

namespace cowbase
{
	public class SearchPassInOutDocs : OutDocListView
	{
		public SearchPassInOutDocs()
		{
			this.Text = "Wyszukiwanie paszportów WZ";
		}

		protected override bool EditDoc(Doc doc)
		{
            ICollection<Cow> cows = SQLDB.LoadCows(new cowbase.wheres.OutDocNoWhere(doc.docno));
			PassSearchDlg passSearch = new OutDocPassSearchDlg(cows);
			passSearch.ShowDialog();
			passSearch = null;
			return false;
			
		}
	}
}
