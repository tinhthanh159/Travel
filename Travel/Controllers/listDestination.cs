using Microsoft.AspNetCore.Mvc;
using Travel.Models;

namespace Travel.Controllers
{
    public class listDestination : Controller
    {
        private readonly TravelTourContext  _destination;

        public listDestination(TravelTourContext destination ) 
        { 
            _destination = destination;
        }

        
        public async Task<IActionResult>  Index()
        {
            var listDestination =  _destination.TbDestinations.ToList();
            return View(listDestination);
        }
    }
}
