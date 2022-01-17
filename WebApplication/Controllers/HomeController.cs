using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication.Models;
using System.Diagnostics;
using WebApplication.Services;
using MimeKit;
using MailKit.Net.Smtp;
using System.Linq;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public RestService _rs { get; set; }
        private readonly EmployeeContext _context;
        public HomeController(ILogger<HomeController> logger, EmployeeContext context)
        {
            _logger = logger;
            _context = context;
            _rs = new RestService(_context);
        }

        public IActionResult Index()
        {
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
   
        public IActionResult WeatherData(string id)
        {
            string weatherapiData = "https://api.openweathermap.org/data/2.5/weather?q=+" + id + "&units=metric&appid=7b415af837daa9f56ea28425c81f0966";
            WeatherData results = _rs.GetWeatherData(weatherapiData).Result;
       
            return View(results);
        }
    }
}
