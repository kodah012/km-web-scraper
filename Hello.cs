using System;
using System.Net.Http;
using System.Linq;
using HtmlAgilityPack;

namespace km_web_scraper
{
    public class Program
    {
        public static void Main(string[] args)
        {
            GetHtmlAsync();
    
            Console.ReadLine();
        }

        private static async void GetHtmlAsync()
        {
            string url = "https://www.ebay.com/sch/i.html?_from=R40&_trksid=p2380057.m570.l1313&_nkw=sword&_sacat=0";

            HttpClient httpClient = new HttpClient();
            string html = await httpClient.GetStringAsync(url);

            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var productList = htmlDocument.DocumentNode.Descendants("ul")
                .Where(node => node.GetAttributeValue("class", "id")
                .Equals("srp-results srp-list clearfix")).ToList();

            Console.WriteLine();

        }
    }
}