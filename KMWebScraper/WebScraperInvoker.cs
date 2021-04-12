using System;
using System.Threading.Tasks;

namespace KMWebScraper
{
    public class WebScraperInvoker
    {
        public static async Task InvokeScraper(IWebScraper webScraper)
        {
            try
            {
                await webScraper.OnLogon();
                await webScraper.OnContent();
                await webScraper.OnLogout();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}