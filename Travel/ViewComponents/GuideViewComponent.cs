
using Travel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Travel.ViewComponents
{
    public class GuideViewComponent : ViewComponent
    {
        private readonly TravelTourContext _context;
        public GuideViewComponent(TravelTourContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var guides = await _context.TbTourGuides
                .Where(g => g.IsActive)
                .OrderBy(g => g.FullName)
                .ToListAsync();

            return View(guides);
        }
    }
}
