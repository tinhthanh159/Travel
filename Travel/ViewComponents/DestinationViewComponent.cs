using Travel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Travel.ViewComponents
{
    public class DestinationViewComponent : ViewComponent
    {
        private readonly TravelTourContext _context;

        public DestinationViewComponent(TravelTourContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = _context.TbDestinations
                .Where(m => m.IsActive == true && m.TopDestination == true)
                .OrderByDescending(m => m.DestinationId)
                .ToList();

            return View(items);
        }
    }
}
