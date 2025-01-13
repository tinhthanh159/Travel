using Travel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Travel.Controllers
{
    public class DestinationController : Controller
    {
        private readonly TravelTourContext _context;
        public DestinationController(TravelTourContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("/destination/-{id}.html")]

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TbDestinations == null)
            {
                return NotFound();
            }
            var blog = await _context.TbDestinations
                .FirstOrDefaultAsync(m => m.DestinationId == id);
            if (blog == null)
            {
                return NotFound();
            }
            
            return View(blog);
        }


    }
}
