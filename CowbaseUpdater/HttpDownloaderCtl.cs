// This is a part of DotNetRemoting Library
// Copyright (C) 2002-2008 Amplefile
// All rights reserved.
//
// This source code can be used, distributed or modified
// only under terms and conditions 
// of the accompanying license agreement.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DotNetRemoting
{
   
    public partial class HttpDownloaderCtl : BaseDownloaderControl
    {
        HttpDownloader _HttpDownloader;
        public event UpdateDelegate StatusUpdateEvent;

        public HttpDownloaderCtl()
        {
            InitializeComponent();
            _HttpDownloader = new HttpDownloader();
            _BaseDownloader = _HttpDownloader;
            _HttpDownloader.UpdateStatusEvent += new UpdateDelegate(UpdateStatusEventHandler);
        }

        protected override void EventCaller(string Message, DStatus Status, long FullSize, long CurrentBytes, TimeSpan EstimatedTimeLeft, double Speed)
        {
            if (StatusUpdateEvent != null)
                StatusUpdateEvent(Message, Status, FullSize, CurrentBytes, EstimatedTimeLeft, Speed);
        }

        public Stream OutputStream
        {
            set { _HttpDownloader.OutputStream = value; }
            get
            {
                return _HttpDownloader.OutputStream;
            }
        }

        public string URLDownload
        {
            get { return _HttpDownloader.URLDownload; }
            set { _HttpDownloader.URLDownload = value; }
        }

        public UseProxy ProxyToUse
        {
            get { return _HttpDownloader.ProxyToUse; }
            set { _HttpDownloader.ProxyToUse = value; }
        }

        public void SetProxyInfo(string ProxyURI, string UserName, string Password, string Domain)
        {
            SetProxyInfo(ProxyURI, true, UserName, Password, Domain);
        }

        public void SetProxyInfo(string ProxyURI, bool BypassLocal, string UserName, string Password, string Domain)
        {
            _HttpDownloader.SetProxyInfo(ProxyURI, BypassLocal, UserName, Password, Domain);
        }
    }
}
