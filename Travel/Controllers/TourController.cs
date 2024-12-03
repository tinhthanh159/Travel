using Travel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Travel.Controllers
{
    public class TourController : Controller
    {
        private readonly TravelTourContext _context;
        public TourController(TravelTourContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("/Tour/{alias}-{id}.html")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TbTours == null)
            {
                return NotFound();
            }
            var tour = await _context.TbTours.Include(i => i.Type)
            .FirstOrDefaultAsync(m => m.TourId == id);
            if (tour == null)
            {
                return NotFound();
            }
            ViewBag.tourComment = _context.TbTourComments.
            Where(i => i.TourId == id && i.IsActive).ToList();
            ViewBag.tourRelated = _context.TbTours.
            Where(i => i.TourId != id && i.TypeId == tour.TypeId).Take(5).
            OrderByDescending(i => i.TourId).ToList();
            return View(tour);
        }
    }
}
