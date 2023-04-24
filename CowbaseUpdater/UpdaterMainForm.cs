using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Xml;

namespace CowbaseUpdater
{
    public partial class UpdaterMainForm : Form
    {

        private int m_currentCowbaseVersion = 0;
        private int m_newCowbaseVersion = 0;

         OpenNETCF.Threading.NamedMutex m_singleInstanceMutex; 
           

        public UpdaterMainForm()
        {
            InitializeComponent();
           
        }

        protected void CenterForm()
        {
            Rectangle _screen = Screen.PrimaryScreen.WorkingArea;
            this.Location = new Point(((_screen.Width - this.Width) / 2),
                ((_screen.Height - this.Height) / 2));
        }

        public static string GetApplicationDirectory()
        {
            return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName);
        }

        private void UpdaterMainForm_Load(object sender, EventArgs e)
        {

            m_singleInstanceMutex = new OpenNETCF.Threading.NamedMutex(false, "COWBASE");
             if (!m_singleInstanceMutex.WaitOne(5, false))
            {
                MessageBox.Show("Wyłącz BK2011.");
                Close();
                return;
            }


            ShowDownloadControls(false);
            m_currentCowbaseVersion = GetCurrentCowbaseVersion();
            m_newCowbaseVersion = GetNewCowbaseVersion();

            if(m_currentCowbaseVersion != 0 && m_newCowbaseVersion != 0 &
                m_newCowbaseVersion > m_currentCowbaseVersion)
            {

                currentVersionNumber.Text = m_currentCowbaseVersion.ToString();
                newVersionLbl.Text = m_newCowbaseVersion.ToString();
                CenterForm();

            }
            else
            {
                RunCowbase();
                Close();
            }          
        }

        private void httpDownloader1_StatusUpdateEvent(string Message, DotNetRemoting.DStatus Status, long FullSize, long CurrentBytes, TimeSpan EstimatedTimeLeft, double Speed)
        {

            downloadTimeLeftLbl.Text = DotNetRemoting.BaseDownloader.TimeSpanToString(EstimatedTimeLeft);
            downloadSpeedLbl.Text = Speed.ToString("F1") + " Kb/s";

            switch(Status)
            {
                case  DotNetRemoting.DStatus.complete:

                    abortBtn.Enabled = false;
                    try
                    {
                        httpDownloader1.OutputStream.Seek(0, System.IO.SeekOrigin.Begin);
                        string dir = GetApplicationDirectory();
                        using (var zip1 = Ionic.Zip.ZipFile.Read(httpDownloader1.OutputStream))
                        {
                            foreach (var entry in zip1)
                            {
                                entry.Extract(dir, Ionic.Zip.ExtractExistingFileAction.OverwriteSilently);
                            }
                        }
                        RunCowbase();
                        Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        httpDownloader1.OutputStream.Close();
                    }
                    break;

                case DotNetRemoting.DStatus.error:
                case DotNetRemoting.DStatus.timeout:
                    httpDownloader1.OutputStream.Close();
                    MessageBox.Show("Błąd podczas pobierania aktualizacji.");
                    dwnlAndInstallBtn.Enabled = true;
                    ShowDownloadControls(false);
                    break;
          

            
            }
        }

        private void ShowDownloadControls(bool bVisible)
        {
            downloadSpeedStaticLbl.Visible = bVisible;
            downloadTimeLeftStaticLbl.Visible = bVisible;
            downloadSpeedLbl.Visible = bVisible;
            downloadTimeLeftLbl.Visible = bVisible;
            downloadProgress.Visible = bVisible;
        }

        private int GetCurrentCowbaseVersion()
        {
            string cowbaseVersionFilePath = GetApplicationDirectory() + "\\cowbase_version.xml";
            return GetCowbaseVersion(cowbaseVersionFilePath);
            
        }

        private string GetUpdatesURLRoot()
        {
            return "http://dobek.lh.pl/bk_updates/bk2010_dobek/symbol/";
        }

        private int GetNewCowbaseVersion()
        {
            string newVersionXmlUrl = GetUpdatesURLRoot() + "bk_update.xml";
            return GetCowbaseVersion(newVersionXmlUrl);
        }
        private int GetCowbaseVersion(string uri)
        {
            int cowbaseVerion = 0;
            try
            {
                XmlTextReader reader = new XmlTextReader(uri);
                try
                {

                    reader.ReadStartElement("cowbaseUpdate");
                    reader.ReadStartElement("version");
                    cowbaseVerion = reader.ReadContentAsInt();
                    reader.ReadEndElement();
                    reader.ReadEndElement();
                }
                catch (Exception e)
                {
                    cowbaseVerion = 0;
                }
                finally
                {
                    reader.Close();
                }
            }
            catch (Exception e)
            {
                cowbaseVerion = 0;
            }

            return cowbaseVerion;
        }

        private void RunCowbase()
        {
            m_singleInstanceMutex.ReleaseMutex();
            System.Diagnostics.Process.Start(GetApplicationDirectory() + "\\cowbase.exe","");
        }
        private void DownloadAndInstall()
        {
            
            System.IO.MemoryStream memStream = new System.IO.MemoryStream(100 * 1024);
            httpDownloader1.URLDownload = GetUpdatesURLRoot() + "zips/" + m_newCowbaseVersion.ToString() + ".zip";
            httpDownloader1.OutputStream = memStream;
            httpDownloader1.Start();

       }


        private void abortBtn_Click(object sender, EventArgs e)
        {
            httpDownloader1.Abort();
            RunCowbase();
            Close();
        }

        private void dwnlAndInstallBtn_Click(object sender, EventArgs e)
        {
            dwnlAndInstallBtn.Enabled = false;
            ShowDownloadControls(true);
            DownloadAndInstall();
           // RunCowbase();
           // Close();
        }

      
    }
}