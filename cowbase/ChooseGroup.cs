using System;
using System.Collections;


namespace cowbase
{
	/// <summary>
	/// Summary description for ChooseGroup.
	/// </summary>
	public class ChooseGroup : ButtonList
	{
		public ChooseGroup(int selGrp,string caption) : base(null,selGrp,caption) 
		{
			ArrayList a = new ArrayList();

			for(int i = 0;i <= SQLDB.MAX_OUT_GRP;i++)
				a.Add(new DictionaryEntry(i,i.ToString()));
			
			m_optArray = a;
			SetFont(16,true);
			
		}
	
	}
}
