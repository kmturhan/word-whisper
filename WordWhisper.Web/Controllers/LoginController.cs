using Microsoft.AspNetCore.Mvc;

namespace WordWhisper.Web.Controllers
{
    
    public class LoginController : Controller
    {
        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        [Route("register")]
        public IActionResult Register()
        {
            return View();
        }
    }
}
