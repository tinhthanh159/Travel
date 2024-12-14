using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Travel.Models;

namespace Travel.Controllers
{
    public class DestinationController : Controller
    {
        private readonly TravelTourContext _context;

        public  DestinationController(TravelTourContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Route("/Destination/{id}.html")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TbDestinations == null)
            {
                return NotFound();
            }
            var destination = await _context.TbDestinations
            .FirstOrDefaultAsync(m => m.DestinationId == id);
            if (destination == null)
            {
                return NotFound();
            }
               
           
            return View(destination);


        }

    }
}
