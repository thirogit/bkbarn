using System;
namespace cowbase
{
	public class OUTDOCSSyncState : DOCSyncState
	{
		public OUTDOCSSyncState(string stateParam,SyncState callingState) : base("outdocs",stateParam,callingState)
		{
		}
	}
}
