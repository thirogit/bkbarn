using System;
using System.Text;
using System.IO;

using log4net.Layout;
using log4net.Core;
using log4net.Util;

namespace log4net.Appender
{
	public class OutboxDirAppender : BufferingAppenderSkeleton
	{
        public OutboxDirAppender()
		{
		}

		

		
		public string OutboxDir
		{
            get { return m_outboxDir; }
            set { m_outboxDir = value; }
		}

		public SecurityContext SecurityContext 
		{
			get { return m_securityContext; }
			set { m_securityContext = value; }
		}


		override protected void SendBuffer(LoggingEvent[] events) 
		{
			// Note: this code already owns the monitor for this
			// appender. This frees us from needing to synchronize again.
			try 
			{
				string filePath = null;
				StreamWriter writer = null;

				// Impersonate to open the file
				using(SecurityContext.Impersonate(this))
				{
                    filePath = Path.Combine(m_outboxDir, SystemInfo.NewGuid().ToString("N"));
					writer = File.CreateText(filePath);
				}

				if (writer == null)
				{
					ErrorHandler.Error("Failed to create output file for writing ["+filePath+"]", null, ErrorCode.FileOpenFailure);
				}
				else
				{
					using(writer)
					{						
						string t = Layout.Header;
						if (t != null)
						{
							writer.Write(t);
						}

						for(int i = 0; i < events.Length; i++) 
						{
							// Render the event and append the text to the buffer
							RenderLoggingEvent(writer, events[i]);
						}

						t = Layout.Footer;
						if (t != null)
						{
							writer.Write(t);
						}

						
					}
				}
			} 
			catch(Exception e) 
			{
				ErrorHandler.Error("Error occurred while sending e-mail notification.", e);
			}
		}


		override public void ActivateOptions() 
		{	
			base.ActivateOptions();

			if (m_securityContext == null)
			{
				m_securityContext = SecurityContextProvider.DefaultProvider.CreateSecurityContext(this);
			}

			using(SecurityContext.Impersonate(this))
			{
                m_outboxDir = ConvertToFullPath(m_outboxDir.Trim());
			}
		}

		override protected bool RequiresLayout
		{
			get { return true; }
		}


		protected static string ConvertToFullPath(string path)
		{
			return SystemInfo.ConvertToFullPath(path);
		}


		private string m_outboxDir;

		private SecurityContext m_securityContext;

	
	}
}
