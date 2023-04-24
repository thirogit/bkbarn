using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Reflection;

namespace cowbase
{
    class Settings
    {

        public String host = "ppp_peer";

        public int redBirthdateDays
        {
            get { return m_redBirthdateDays; }
            set 
            { 
                if(value > 365)
                    m_redBirthdateDays = 365;
                else
                {
                    if (value < 0)
                        m_redBirthdateDays = 0;
                    else
                        m_redBirthdateDays = value;
                }

            }
        }        
        public bool usePredefSex = true;

        private int m_redBirthdateDays = 0;

        private Settings () { Load(); }

        ~Settings()
        {
            Save();
        }

        static Settings instance;

        public static Settings Instance
        {
            get
            {
                lock (typeof(Settings))
                {
                    if (instance == null)
                        instance = new Settings();

                    lock (instance)
                    {
                        return instance;
                    }
                }
            }
        }

        public void Log()
        {
            LOG.DoLog("Settings: Host=" + host + ", UsePredefSex=" + usePredefSex.ToString() + ", RedBirthdateDays=" + m_redBirthdateDays.ToString() + "}");
        }

        string GetCfgFilePath()
        {
            string cfgFilePath = Utils.GetApplicationDirectory();
            cfgFilePath += "\\cfg.xml";
            return cfgFilePath;
        }

        /// <summary>
        /// Read settings file.
        /// </summary>
        public void Load()
		{			
			// open settings file
            string _filePath = GetCfgFilePath();

			if (File.Exists(_filePath))
			{
				XmlTextReader reader = new XmlTextReader(_filePath);

				// go through file and read the xml file and 
				// populate internal list with 'add' elements
                try
                {

                    reader.ReadStartElement("cowbase");
                    reader.ReadStartElement("host");
                    host = reader.ReadString();
                    reader.ReadEndElement();

                    reader.ReadStartElement("redBirthdateDays");
                    redBirthdateDays = Utils.ParseInteger(reader.ReadString());
                    reader.ReadEndElement();

                    reader.ReadStartElement("usePredefSex");
                    usePredefSex = bool.Parse(reader.ReadString());
                    reader.ReadEndElement();
                    reader.ReadEndElement();
                }
                catch (Exception e)
                {
                    LOG.DoLog("XML: " + e.Message);
                }
                finally
                {
                    reader.Close();
                }
			}
		}

    public void Save()
    {
        string cfgFilePath = GetCfgFilePath();
        XmlTextWriter writer = new XmlTextWriter(cfgFilePath, null);
        //Write the root element
        writer.WriteStartElement("cowbase");
        //Write sub-elements
        writer.WriteElementString("host", host);
        writer.WriteElementString("redBirthdateDays", m_redBirthdateDays.ToString());
        writer.WriteElementString("usePredefSex", usePredefSex.ToString());
        // end the root element
        writer.WriteEndElement();                 
        //Write the XML to file and close the writer
        writer.Close();  
    }




    }
}
