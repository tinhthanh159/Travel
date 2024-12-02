using Travel.Areas.Admin.Models;
using Travel.Models;
using Travel.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Travel.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        public readonly TravelTourContext _context;
        public LoginController(TravelTourContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]

        public IActionResult Index(Travel.Models.TbAdminUser user)
        {
            if (user == null)
            {
                return NotFound();
            }

            string pw = Function.MD5Password(user.Password);

            var check = _context.TbAdminUsers.Where(m => (m.Email == user.Email) && (m.Password == pw)).FirstOrDefault();
            if (check == null)
            {
                Function._Message = "Invalid User or password";
                return RedirectToAction("Index", "Login");
            }


            Function._Message = string.Empty;
            Function._UserID = check.UserId;
            Function._Username = string.IsNullOrEmpty(check.UserName) ? string.Empty : check.UserName;
            Function._Email = string.IsNullOrEmpty(check.Email) ? string.Empty : check.Email;

            return RedirectToAction("Index", "Home");
        }
    }
}