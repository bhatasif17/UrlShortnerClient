using client.URLShortner.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace client.URLShortner.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApiHelper _api;
        // 11ac4ee7fc9be04b804a0d9175da9dd61af74888w
        public HomeController(IApiHelper api)
        {
            _api = api;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ShortenURL(string url)
        {
            ShortLink model = new();
            model.URL = url;

            var response = await _api.POST(model, "shorten");
            ViewBag.url = response;
            return View("Index");
        }
    }
}
