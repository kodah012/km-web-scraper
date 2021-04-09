using System;
using System.Threading.Tasks;
using KMWebScraper.Navigation;

namespace KMWebScraper
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Browser browser = new Browser();
            browser.Navigate(new Uri("https://old.reddit.com/"), "r/all/").GetAwaiter().GetResult();
        }
    }
}