using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WordWhisper.Entities;
using WordWhisper.Web.Models;

namespace WordWhisper.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IConfiguration _config;
        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }
        
        public IActionResult Index()
        {
            //var userList = _context.Users.ToList();
            
            return View();
            //var ss = _config.GetValue<string>("ConnectionStrings:SqlServer");
            //_logger.LogInformation("INDEX : " + ss);

            //var testDb = _context.Users.ToList();
            //return View(testDb);
        }
        [Route("~/test/{city}")]
        public IActionResult Privacy(string city, User user)
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