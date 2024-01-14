using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using WordWhisper.Core;
namespace WordWhisper.Web.Areas.User.Controllers
{
    [Area("User")]
    public class AuthController : Controller
    {
        private readonly IMapper _mapper;

        public AuthController(IMapper mapper)
        {
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

        

        [HttpGet]
        public async Task<IActionResult> AllUsers()
        {
            //var result = await _userService.GetAllUsers();
            //var userResources = _mapper.Map<IEnumerable<WordWhisper.Core.Models.User>, IEnumerable<UserDTO>>(result);
            //return View(userResources);
            return View();
        }
    }
}
