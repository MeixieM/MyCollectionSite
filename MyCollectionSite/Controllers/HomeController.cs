using Microsoft.AspNetCore.Mvc;
using MyCollectionSite.Models;
using System.Diagnostics;
using System.Text.Json;

namespace MyCollectionSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            using var jsonFile = System.IO.
                File.OpenRead("Data/collection.json");

            var items = JsonSerializer
                .Deserialize<CollectionItem[]>(jsonFile);

            return View(items);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}