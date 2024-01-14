using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using WordWhisper.Core;
using WordWhisper.DataAccess.Concrete.EntityFramework.Contexts;
using WordWhisper.Entities.Concrete;
using WordWhisper.Repository.Concrete;
namespace WordWhisper.Web.Areas.User.Controllers
{
    [Area("User")]
    public class AuthController : Controller
    {
        private readonly IMapper _mapper;
        private WordWhisperEFContext _context;

        public AuthController(IMapper mapper, WordWhisperEFContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }
        
        [HttpGet]
        public IActionResult Register()
        {
            Entities.Concrete.User user = new Entities.Concrete.User();
            UnitOfWork unitOfWork = new UnitOfWork(_context);
            user.Email = "kmturhan@gmail.com";
            user.CreatedDate = DateTime.Now;
            user.Hash = "test";
            user.IsActive = true;
            user.Username = "testuser";
            user.Password = "userpass";
            unitOfWork.UserRepository.Add(user);
            unitOfWork.Complete();
            return View();
        }

        [HttpPost]
        public IActionResult Register(WordWhisper.Entities.Concrete.User user)
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
