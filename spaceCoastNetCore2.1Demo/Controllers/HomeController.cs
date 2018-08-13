using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using spaceCoastNetCore2._1Demo.Models;
using spaceCoastNetCore2.Demo.Models;

namespace spaceCoastNetCore2._1Demo.Controllers
{
    public class HomeController : Controller
    {

        private Settings siteSettings;

        IMemoryCache caching = null;

        public HomeController(IOptions<Settings> settings, IMemoryCache cache)
        {
            siteSettings = settings.Value;
            caching = cache;
        }


        public IActionResult Index()
        {
            ViewData["Message"] = siteSettings.TestSetting;
            return View();
        }

        public IActionResult About()
        {
            DateTime currentTime;
            if (!caching.TryGetValue<DateTime>("currentTime", out currentTime))
            {
                currentTime = DateTime.Now;
                caching.Set<DateTime>("currentTime", currentTime, DateTimeOffset.Now.AddMinutes(2));
            }
            ViewData["Message"] = $"Your application description page. {currentTime}";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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
