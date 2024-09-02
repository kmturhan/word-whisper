using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WordWhisper.DataAccess.Abstract;
using WordWhisper.Domain;
using WordWhisper.Entities;
using WordWhisper.Services;
using WordWhisper.Web.Models;

namespace WordWhisper.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IConfiguration _config;
        private IService<User> _userRepo;
        private readonly IRepository<User> _userRepository;
        public HomeController(ILogger<HomeController> logger, IConfiguration config, IRepository<User> userRepository)
        {
            _logger = logger;
            _config = config;
            _userRepository = userRepository;
        }
        
        public IActionResult Index()
        {
            //var userList = _context.Users.ToList();
            var ss = _userRepository.AddAsync(new Domain.User {
                IsActive= true,
                CreatedDate = DateTime.Now,
                Username = "test",
                Password = "testpass",
                Email = "test@gmail.com",
                RoleId = 1
            });
            
            return View();
            
            //var ss = _config.GetValue<string>("ConnectionStrings:SqlServer");
            //_logger.LogInformation("INDEX : " + ss);

            //var testDb = _context.Users.ToList();
            //return View(testDb);
        }
        [Authorize]
        public IActionResult Privacy(string city)
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