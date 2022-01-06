using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SingletonASP.Configuration;
using SingletonASP.Models;
using System.Diagnostics;
using Tools;

namespace SingletonASP.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOptions<MyConfig> _config; 
        public HomeController(IOptions<MyConfig> config)
        {
            _config = config;
        }

        public IActionResult Index()
        {
            Log.GetInstance(_config.Value.PathLog).Save("Vista Index");
            return View();
        }

        public IActionResult Privacy()
        {
            Log.GetInstance(_config.Value.PathLog).Save("Vista Privacy");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}