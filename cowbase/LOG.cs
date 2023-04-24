using System;
using System.IO;
using log4net;
using log4net.Layout;
using log4net.Appender;
using log4net.Core;
using log4net.Repository.Hierarchy;
//using WinToolZone.CSLMail;


namespace cowbase
{
	public class LOG
	{
        private class CriticalEventTriggeringEvaluator : ITriggeringEventEvaluator
        {
            public bool IsTriggeringEvent(LoggingEvent loggingEvent)
            {
                return loggingEvent.Level == Level.Critical;
            }
        }



        private Logger _root;

		private static readonly string LOG_FILE_NAME = "LOGS\\COWBASE.log";
        private PatternLayout logMsgLayout = new PatternLayout("%date - %message%newline");
        private static LOG logger;
        private int memStatCount = 0;
        private MemoryUsage mu = new MemoryUsage();
		
		private LOG()
        {
            try
            {
                _root = ((log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository()).Root;
                _root.Level = Level.Debug;
               
                _root.AddAppender(CreateFileAppender());
                _root.AddAppender(CreateOutboxAppender());
                _root.Repository.Configured = true;
            }
            catch (Exception e)
            {
                e.ToString();
            }

             
		}

        private static LOG GetLOG()
        {
            if(logger == null)
                logger = new LOG();
            return logger;

        }

        public static string GetLogFileName()
        {
            return Utils.GetApplicationDirectory() + '\\' + LOG_FILE_NAME;
        }

        public static string GetOutboxDirectoryPath()
        {
            return Utils.GetApplicationDirectory() + '\\' + "OUTBOX";
        }

        public static void DoLog(string sMessageToLog)
		{
            GetLOG().Log(Level.Debug, sMessageToLog);           
		}

        public static void DoLogCritical(string sMessageToLog)
        {
            GetLOG().Log(Level.Critical, sMessageToLog);           
        }

        private void Log(Level level, string sMessageToLog)
        {
           // string sMessageToLogNoCR = removeCR(sMessageToLog);
           // string sMessageToLogNoLFCR = sMessageToLogNoCR.Replace('\n', '|');

            memStatCount++;
            if (memStatCount > 5)
            {
                mu.Refresh();
                _root.Log(Level.Debug,mu.ToString(),null);
                memStatCount = 0;
            }

            _root.Log(level, sMessageToLog, null); 
        }

        private void LogMemoryUsage()
        {

        }

        private static string removeCR(string s)
        {
            string ss = s;
            char[] CR = { '\r' };
            int iCR = 0;
            while((iCR = ss.IndexOfAny(CR,iCR)) > 0)
            {
                ss = ss.Remove(iCR, 1);
            }
            return ss;
        }

        public static void End()
        {
            LogManager.Shutdown();
        }

        private OutboxDirAppender CreateOutboxAppender()
        {
            OutboxDirAppender outboxAppender = new OutboxDirAppender();
            outboxAppender.BufferSize = 100;
            outboxAppender.Lossy = true;
            outboxAppender.Evaluator = new CriticalEventTriggeringEvaluator();

            string outboxDirectory = GetOutboxDirectoryPath();
            if(!Directory.Exists(outboxDirectory))
                Directory.CreateDirectory(outboxDirectory);

            outboxAppender.OutboxDir = outboxDirectory;
           
            outboxAppender.Layout = logMsgLayout;
            outboxAppender.ActivateOptions();

            
            return outboxAppender;
        }


        private RollingFileAppender CreateFileAppender()
        {
            //
            // Use a basic pattern that
            // includes just the message and a CR/LF.
            //
            

            //
            // Create the new appender
            //
            RollingFileAppender appender = new RollingFileAppender();

            appender.Layout = logMsgLayout;
            appender.File = GetLogFileName();
            appender.MaximumFileSize = "500KB";
            appender.MaxSizeRollBackups = 4;
            appender.CountDirection = +1;
            appender.RollingStyle = RollingFileAppender.RollingMode.Size;
            appender.LockingModel = new FileAppender.ExclusiveLock();

            appender.ActivateOptions();

            return appender;
        }



	}
}
