using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.Threading.Tasks;
using Travel.Models;

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
        //  [Route("Tour/AddReview")]
        public async Task<IActionResult> Create(string name, string email, string title, string detail, int tourId, int star)
        {
            try
            {
                TbTourComment contact = new TbTourComment
                {
                    Name = name,
                    Star = star, // Assign the selected star rating
                    Email = email,
                    Title = title,
                    Detail = detail,
                    CreatedDate = DateTime.Now,
                    TourId = tourId,
                    IsActive = true,
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
