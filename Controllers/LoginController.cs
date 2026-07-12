using Microsoft.AspNetCore.Mvc;

namespace AudioSeller.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
