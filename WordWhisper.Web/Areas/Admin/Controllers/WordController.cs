using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace WordWhisper.Web.Areas.Admin.Controllers
{
    [Area("admin")]
    public class WordController : Controller
    {
        private readonly IMapper _mapper;
        public WordController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult test()
        {
            return View();
        }
    }
}
