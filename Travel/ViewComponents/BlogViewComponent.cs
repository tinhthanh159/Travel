using Travel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Travel.ViewComponents
{
    public class BlogViewComponent : ViewComponent
    {
        private readonly TravelTourContext _context;

        public BlogViewComponent(TravelTourContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = _context.TbBlogs.Include(m => m.Account)
                .Where(m => (bool)m.IsActive);
            return await Task.FromResult<IViewComponentResult>
                (View(items.OrderByDescending(m => m.BlogId).ToList()));
        }
    }
}
