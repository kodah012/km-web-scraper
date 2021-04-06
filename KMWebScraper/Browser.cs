using System;
using System.Collections.Generic;
using System.Xml;

namespace KMWebScraper.Browser
{
    public class Browser
    {
        public bool IsNonHtmlPage { get; private set; }
        public XmlNode PageContent { get; private set; }
        public string UserAgent { get; private set; }
        private readonly Dictionary<string, string> HeaderContent;
        private readonly Dictionary<string, string> Cookies;
        
        public Delegate HandleReceivedCookies { get; private set; }

        private void Post()
        {
            
        }

        private void Get()
        {
            
        }

        private void GetCookiesReceived()
        {
            
        }

        private void SendExtraHeaders()
        {
            
        }

        private XmlNode GetPageXml()
        {
            return null;
        }
    }
}