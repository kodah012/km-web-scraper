using System;
using System.Collections.Generic;
using System.Xml;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace KMWebScraper.Navigation
{
    public class Browser
    {
        public bool IsNonHtmlPage { get; private set; }
        public XmlNode PageContent { get; private set; }
        public string UserAgent { get; private set; }
        private readonly Dictionary<string, string> HeaderContent;
        private readonly Dictionary<string, string> Cookies;
        public Uri uri { get; private set; }
        
        public Delegate HandleReceivedCookies { get; private set; }
        private readonly HttpClient client;

        public Browser()
        {
            client = new HttpClient();
        }

        public async Task<bool> Navigate(Uri uri = null, string subdirectory = null)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(new Uri(uri, subdirectory));
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                HtmlDocument someDoc = new HtmlDocument();
                someDoc.LoadHtml(responseBody);
                HtmlNodeCollection nodes =
                    someDoc.DocumentNode.SelectNodes("//*[local-name()='a' and contains(@class, 'title')]");
                //Console.WriteLine(someDoc.DocumentNode
                //    .SelectSingleNode("//*[local-name()='a' and contains(@class, 'title') and contains(.,'100,000')]")?.InnerText);

                foreach (var node in nodes)
                {
                    Console.WriteLine($"* {node.InnerText}");
                }
                
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Web exception: {e}");
            }

            return false;
        }


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