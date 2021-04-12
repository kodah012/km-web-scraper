using System;
using System.Xml;
using System.Threading.Tasks;
using KMWebScraper.Navigation;

namespace KMWebScraper
{
    public class RedditScraper : IWebScraper
    {
        private readonly Browser Browser;

        public RedditScraper()
        {
            Browser = new Browser()
            {
                WebsiteUri = new Uri("https://old.reddit.com"),
                UserAgent = "hi"
                //UserAgent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_10_2) AppleWebKit/537.36(KHTML, like Gecko) Chrome/51.0.2704.84 Safari/537.36"
            };
            
        }
        
        public async Task OnLogon()
        {
            await Browser.Navigate(Browser.WebsiteUri); // Navigate to WebsiteUri (i.e. initial logon page)
        }

        public async Task OnContent()
        {
            await Browser.Navigate(new Uri(Browser.Uri, "/r/all"));
            XmlNodeList redditTitles = Browser.PageContent.SelectNodes("//*[local-name()='a' and contains(@class, 'title')]");
                        
            foreach (XmlNode titleNode in redditTitles)
            {
                Console.WriteLine($"* {titleNode.InnerText}");
            }
        }

        public async Task OnLogout()
        {
            
        }
    }
}