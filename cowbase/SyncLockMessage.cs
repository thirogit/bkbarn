using System;

namespace cowbase
{
	public class SyncLockMessage 
	{
		private SyncLockMessage()
		{			
		}
		public static bool CheckSyncLock()
		{
			if(SQLDB.IsSyncLocked())
			{
				BigOKMessageBox.ShowMessage("Kolektor zablokowany",
					"Dodawanie nowych rekordow i modyfikacja\nistniejacych jest zablokowana.\nZschynchronizuj terminal z baza.");
				return false;
			}
			return true;
		}
	}
}
