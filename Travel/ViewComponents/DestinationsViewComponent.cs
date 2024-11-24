using Microsoft.AspNetCore.Mvc;
using Travel.Models;
using Microsoft.EntityFrameworkCore;

namespace Travel.ViewComponents
{
    public class DestinationsViewComponent : ViewComponent
    {
        private readonly TravelTourContext _context;
        public DestinationsViewComponent(TravelTourContext context)
        {
            _context = context; 
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = _context.TbTours.Include(m => m.Type)
                .Where(m => (bool)m.IsActive).Where(m => (bool)m.IsNew);
            return await Task.FromResult<IViewComponentResult>
                (View(items.OrderByDescending(m => m.TourId).ToList()));
        }
    }
}
