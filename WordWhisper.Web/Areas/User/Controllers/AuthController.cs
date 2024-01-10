using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using WordWhisper.Core;
using WordWhisper.Core.Models;
using WordWhisper.Core.Services;
using WordWhisper.Web.DTO;
namespace WordWhisper.Web.Areas.User.Controllers
{
    [Area("User")]
    public class AuthController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AuthController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }
        
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserDTO user)
        {
            if(ModelState.IsValid)
            {
                var userResource = _mapper.Map<UserDTO, WordWhisper.Core.Models.User>(user);
                userResource.CreatedDate = DateTime.Now;
                var result = await _userService.CreateUser(userResource);
                
                return Redirect("~/user/auth/allUsers");
                
            }
            return Redirect("~/user/auth/register");
        }

        [HttpGet]
        public async Task<IActionResult> AllUsers()
        {
            var result = await _userService.GetAllUsers();
            var userResources = _mapper.Map<IEnumerable<WordWhisper.Core.Models.User>, IEnumerable<UserDTO>>(result);
            return View(userResources);
        }
    }
}
