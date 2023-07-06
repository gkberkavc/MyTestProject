using Microsoft.AspNetCore.Mvc;

namespace MyTestProject.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
