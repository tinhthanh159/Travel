using Travel.Models;
using Microsoft.AspNetCore.Mvc;

namespace Travel.ViewComponents
{
    public class MenuTopViewComponent : ViewComponent
    {
        private readonly TravelTourContext _context;

        public MenuTopViewComponent(TravelTourContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = _context.TbMenus.Where(m => (bool)m.IsActive).OrderBy(m => m.Position).ToList();
            return await Task.FromResult<IViewComponentResult>(View(items));
        }
    }
}
