using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Travel.Models;
using Microsoft.EntityFrameworkCore;

namespace Travel.Controllers
{
    public class HomeController : Controller
    {
        private readonly TravelTourContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(TravelTourContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.tourType = _context.TbTourTypes.ToList();
            ViewBag.tourNew = _context.TbTours.Where(m => m.IsBestTour == true).ToList();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
