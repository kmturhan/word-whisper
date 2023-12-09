using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WordWhisper.DataAccess.Concrete.EntityFramework.Contexts;
using WordWhisper.Web.Models;

namespace WordWhisper.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IConfiguration _config;
        private readonly WordWhisperContext _context;
        public HomeController(ILogger<HomeController> logger, IConfiguration config, WordWhisperContext context)
        {
            _logger = logger;
            _config = config;
            _context = context;
        }
        
        public IActionResult Index()
        {
            var userList = _context.Users.ToList();
            return View(userList);
            //var ss = _config.GetValue<string>("ConnectionStrings:SqlServer");
            //_logger.LogInformation("INDEX : " + ss);

            //var testDb = _context.Users.ToList();
            //return View(testDb);
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