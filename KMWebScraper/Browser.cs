using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Xml;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Sgml;

namespace KMWebScraper.Navigation
{
    public class Browser
    {
        private readonly Dictionary<string, string> HeaderContent;
        public readonly Dictionary<string, string> Cookies;
        
        public bool IsNonHtmlPage { get; private set; }
        public XmlDocument PageContent { get; private set; }
        public string UserAgent { get; set; }
        public Uri WebsiteUri { get; set; }
        public Uri Uri { get; private set; }
        
        public Delegate HandleReceivedCookies { get; private set; }
        private static HttpClient _client;

        public Browser()
        {
            _client = new HttpClient()
            {
                BaseAddress = WebsiteUri
            };
            
            _client.DefaultRequestHeaders.Add("User-Agent", UserAgent);
        }
        
        public Browser(Uri websiteUri, string userAgent)
        {
            WebsiteUri = websiteUri;
            UserAgent = userAgent;
            
            _client = new HttpClient()
            {
                BaseAddress = WebsiteUri
            };
            
            _client.DefaultRequestHeaders.Add("User-Agent", UserAgent);
        }
        
        private XmlDocument ConvertToXml(string html)
        {
            SgmlReader sgmlReader = new SgmlReader()
            {
                DocType = "HTML",
                WhitespaceHandling = WhitespaceHandling.All,
                CaseFolding = Sgml.CaseFolding.ToLower,
                InputStream = new StringReader(html)
            };

            XmlDocument document = new XmlDocument
            {
                PreserveWhitespace = true,
                XmlResolver = null
            };
            document.Load(sgmlReader);
            return document;
        }

        public async Task Navigate(Uri uri = null, string subdirectory = null)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(new Uri(uri, subdirectory));
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                
                Uri = new Uri(uri, subdirectory);
                PageContent = ConvertToXml(responseBody);
                
            }
            catch (WebException e)
            {
                Console.WriteLine($"Web exception: {e}");
            }

        }

        private void Post(string content, Encoding encoding, string mediaType)
        {
            HttpRequestMessage request = new HttpRequestMessage()
            {
                Content = new StringContent(content, Encoding.UTF8, mediaType)
            };
        }

        
        /*
        private void Post(Dictionary<string, string> content, Encoding encoding, string mediaType)
        {
            HttpRequestMessage request = new HttpRequestMessage()
            {
                Content = new StringContent(content, Encoding.UTF8, mediaType)
            };
        }
        */
        
        public void PostJson(JObject json)
        {
            Post(json.ToString(), Encoding.UTF8, "application/json");
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