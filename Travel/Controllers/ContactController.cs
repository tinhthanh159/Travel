using Travel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Harmic.Controllers
{
    public class ContactController : Controller
    {
        private readonly TravelTourContext _context;

        public ContactController(TravelTourContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Create(string name, string phone, string email, string message)
        {
            try
            {
                TbContact contact = new TbContact
                {
                    Name = name,
                    Phone = phone,
                    Email = email,
                    Message = message,
                    CreatedDate = DateTime.Now
                };

                await _context.AddAsync(contact);
                await _context.SaveChangesAsync();
                return Json(new { status = true });
            }
            catch
            {
                return Json(new { status = false });
            }
        }

    }
}
