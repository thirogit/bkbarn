using System;
using System.Collections;

namespace cowbase
{
	/// <summary>
	/// Summary description for ChooseSex.
	/// </summary>
	public class ChooseSex : ButtonList
	{
		public ChooseSex(CowSex selSex,string caption) : base(null,selSex,caption) 
		{
			ArrayList a = new ArrayList();
            a.Add(new DictionaryEntry(CowSex.XY, CowSex.XY.ToString()));
            a.Add(new DictionaryEntry(CowSex.NONE, CowSex.NONE.ToString()));
            a.Add(new DictionaryEntry(CowSex.XX, CowSex.XX.ToString()));

			m_optArray = a;
			SetFont(16,true);
			
		}
	}
}
