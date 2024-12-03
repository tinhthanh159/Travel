using Travel.Areas.Admin.Models;
using Travel.Models;
using Travel.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Harmic.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RegisterController : Controller
    {
        private readonly TravelTourContext _context;

        public RegisterController(TravelTourContext context)
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


            var check = _context.TbAccounts.Where(m => m.Email == user.Email).FirstOrDefault();
            if (check != null)
            {
                Function._MessageEmail = "Duplicate Email!";
                return RedirectToAction("Index", "Register");
            }

            Function._MessageEmail = string.Empty;
            user.Password = Function.MD5Password(user.Password);
            _context.Add(user);
            _context.SaveChanges();

            return RedirectToAction("Index", "Login");
        }
    }
}