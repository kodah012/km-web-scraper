using System.Threading.Tasks;
using KMWebScraper.Navigation;

namespace KMWebScraper
{
    public interface IWebScraper
    {
        Task OnLogon();
        Task OnContent();
        Task OnLogout();
    }
}