using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WordWhisper.DataAccess.Concrete.EntityFramework.Contexts;
using WordWhisper.Domain;
using WordWhisper.Entities.Concrete;
using WordWhisper.Repository.Abstract;
using WordWhisper.Repository.Concrete;
using WordWhisper.Services;
namespace WordWhisper.Web.Areas.User.Controllers
{
    [Area("User")]
    public class AuthController : Controller
    {
        private readonly IMapper _mapper;
        private WordWhisperEFContext _context;
        private readonly IUnitOfWork _uow;
        private readonly IService<WordWhisper.Domain.User> _userService;

        public AuthController(IMapper mapper, WordWhisperEFContext context, UnitOfWork uow, IService<WordWhisper.Domain.User> userService)
        {
            _mapper = mapper;
            _context = context;
            _uow = uow;
            _userService = userService;
        }
        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }

        [HttpGet]

        public IActionResult Register()
        {
            WordWhisper.Domain.User user = new WordWhisper.Domain.User();
            
            user.Email = "kmturhan@gmail.com";
            user.CreatedDate = DateTime.Now;
            user.IsActive = true;
            user.Username = "testuser";
            user.Password = "userpass";
            _userService.AddAsync(user);
            // _userService.AddAsync(user);
            // _uow.Complete();
            return View();
        }

        [HttpPost]
        public IActionResult Register(WordWhisper.Entities.Concrete.User user)
        {
            _uow.UserRepository.Register(user);
            _uow.Complete();
            return View();
        }

        [HttpGet]

        public async Task<IActionResult> Login()
        {

            //var result = await _userService.GetAllUsers();
            //var userResources = _mapper.Map<IEnumerable<WordWhisper.Core.Models.User>, IEnumerable<UserDTO>>(result);
            //return View(userResources);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(WordWhisper.Entities.Concrete.User user)
        {
            var loginUser = _uow.UserRepository.Login(user.Username, user.Password);
            if (loginUser != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, loginUser.Role.RoleName)
                    // İsteğe bağlı olarak başka iddialar da ekleyebilirsin
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.Now.AddMinutes(2)
                    // İsteğe bağlı olarak oturum süresi, çıkış sayfası vb. belirtilebilir
                };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
                return Redirect("~/home/index");

            }

            return Redirect("~/error");
        }

    }
}
