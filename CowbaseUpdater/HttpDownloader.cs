// This is a part of DotNetRemoting Library
// Copyright (C) 2002-2008 Amplefile
// All rights reserved.
//
// This source code can be used, distributed or modified
// only under terms and conditions 
// of the accompanying license agreement.

using System;
using System.Collections;
using System.Text;
using System.Threading;
using System.Net;
using System.IO;
using System.Windows.Forms;

namespace DotNetRemoting
{
    class HttpDownloader : BaseDownloader
    {
        private string _UserName;
        private string _UserPassword;
        private string _Domain;
        private UseProxy _ProxyState = UseProxy.NotProxy;
        private string URL;
       
        private HttpWebRequest DNTWebRequest;
        private HttpWebResponse DNTWebResponse;
        private string _proxyUri;
        private bool _ByPassLocal;
        
        protected override void StopProc()
        {
            DNTWebResponse.Close();

            if (UpdateStatusEvent != null)
                UpdateStatusEvent("download aborted", CurrStatus, FileLength, BytesCounter, TimeSpan.Zero, 0);
        }

        //public string LocalFolder
        //{
        //    set { _LocalFolder = value; }
        //    get { return _LocalFolder; }
        //}

        public string URLDownload
        {
            get { return URL; }
            set { URL = value; }
        }

        public UseProxy ProxyToUse
        {
            get { return _ProxyState; }
            set { _ProxyState = value; }
        }

        public void SetProxyInfo(string ProxyURI, string UserName, string Password, string Domain)
        {
            SetProxyInfo(ProxyURI, true, UserName, Password, Domain);
        }

        public void SetProxyInfo(string ProxyURI, bool BypassLocal, string UserName, string Password, string Domain)
        {
            if (_ProxyState != UseProxy.UseProxy)
                throw new Exception("ProxyToUse property must be set to UseProxy first");

            _UserName = UserName;
            _UserPassword = Password;
            _Domain = Domain;

            _proxyUri = ProxyURI;
            _ByPassLocal = BypassLocal;
        }

        protected override void Worker_Thread_01()
        {
            HttpConnect(URL); 
        }

        private void HttpConnect(string Url)
        {
            WebProxy wpxy = null;

            BytesCounter = 0;

            if (UpdateStatusEvent != null)
                UpdateStatusEvent("Download thread started", DStatus.connecting, -1, -1, TimeSpan.Zero, 0);

            try
            {
                switch (_ProxyState)
                {
                    case UseProxy.UseProxy:
                        wpxy = new WebProxy(_proxyUri, _ByPassLocal);
                        wpxy.Credentials = new NetworkCredential(_UserName, _UserPassword, _Domain);
                        if (UpdateStatusEvent != null)
                            UpdateStatusEvent("Using proxy", DStatus.connecting, -1, -1, TimeSpan.Zero, 0);
                        break;

                    case UseProxy.UseDefaultProxy:
                        wpxy = WebProxy.GetDefaultProxy();
                        if (UpdateStatusEvent != null)
                            UpdateStatusEvent("Using default proxy", DStatus.connecting, -1, -1, TimeSpan.Zero, 0);
                        break;
               
                    case UseProxy.NotProxy:
                        break;
                }              

                DNTWebRequest = (HttpWebRequest)WebRequest.Create(Url);

                if(wpxy != null)
                    DNTWebRequest.Proxy = wpxy;

                if (UpdateStatusEvent != null)
                    UpdateStatusEvent("trying to GetResponse()", DStatus.connecting, -1, -1, TimeSpan.Zero, 0);

                DNTWebResponse = (HttpWebResponse)DNTWebRequest.GetResponse();

                if (UpdateStatusEvent != null)
                    UpdateStatusEvent("Response received", DStatus.connected, -1, -1, TimeSpan.Zero, 0);

                //filestream = new FileStream(OutFileName, FileMode.OpenOrCreate, FileAccess.Write);

                FileLength = DNTWebResponse.ContentLength;

                if (FileLength == -1)
                {
                    FileLength = 1;
                }

                string TYpe = DNTWebResponse.ContentType;

                if (UpdateStatusEvent != null)
                    UpdateStatusEvent("Download started", DStatus.started, FileLength, 0, TimeSpan.Zero, 0);

                Stream strm = DNTWebResponse.GetResponseStream();

                TimeStart = DateTime.Now;

                int ArrSize = 10000;

                byte[] barr = new byte[ArrSize];

                while (!ThreadStop)
                {
                    int Result = strm.Read(barr, 0, ArrSize);

                    if (Result == -1 || Result == 0)
                    {
                        break;
                    }
                    if (outputStream != null)
                        outputStream.Write(barr, 0, Result);

                    double Speed = BaseDownloader.CalcSpeed(TimeStart, BytesCounter);

                    if (UpdateStatusEvent != null)
                        UpdateStatusEvent("Downloading OK ", CurrStatus, FileLength, BytesCounter, CalcTimeLeft(TimeStart, FileLength, BytesCounter), Speed);

                    _TimeoutTimer.Enabled = false;
                    _TimeoutTimer.Enabled = true;

                    BytesCounter += Result;

                    CurrStatus = DStatus.transferring;
                }
                
            }
            catch (Exception ex)
            {
                

                CurrStatus = DStatus.error;
                if (UpdateStatusEvent != null)
                    UpdateStatusEvent(ex.Message, CurrStatus, FileLength, BytesCounter, TimeSpan.Zero, 0);
                _TimeoutTimer.Enabled = false;
                return;
            }

            if (AbortFlag)
            {
                CurrStatus = DStatus.aborted;
                if (UpdateStatusEvent != null)
                    UpdateStatusEvent("download aborted", CurrStatus, FileLength, BytesCounter, TimeSpan.Zero, 0);
            }
            else
            {
                CurrStatus = DStatus.complete;
                if (UpdateStatusEvent != null)
                    UpdateStatusEvent("download complete", CurrStatus, FileLength, BytesCounter, TimeSpan.Zero, 0);
            }

            _TimeoutTimer.Enabled = false; 
        }
    }
}
