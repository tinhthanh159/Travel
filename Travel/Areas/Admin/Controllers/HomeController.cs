using Microsoft.AspNetCore.Mvc;
using Travel.Utilities;

namespace Travel.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            if (!Function.IsLogin())
                return RedirectToAction("Index", "Login");
            return View();
        }
        public IActionResult Logout()
        {
            // Clear session or user data
            Function._UserId = 0;
            Function._UserName = string.Empty;
            Function._Email = string.Empty;
            Function._Message = string.Empty;
            Function._MessageEmail = string.Empty;

            // Redirect the user to the homepage
            return RedirectToAction("Index", "Login");
        }

    }
}
