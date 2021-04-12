using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KMWebScraper.Navigation;

namespace KMWebScraper
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IWebScraper redditScraper = new RedditScraper();
            await WebScraperInvoker.InvokeScraper(redditScraper); // Executes the Reddit Scraper (SHOULD NOT BE ASYNC!!!!!!)
        }
    }
}