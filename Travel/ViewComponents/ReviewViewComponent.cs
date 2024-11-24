using Travel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Travel.ViewComponents
{
    public class ReviewViewComponent : ViewComponent
    {
        private readonly TravelTourContext _context;
        public ReviewViewComponent(TravelTourContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var review = await _context.TbTourComments
                .Where(g => g.IsActive)
                .OrderBy(g => g.Name)
                .ToListAsync();

            return View(review);
        }
    }
}
