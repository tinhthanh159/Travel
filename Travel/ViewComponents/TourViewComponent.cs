using Travel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Travel.ViewComponents
{
    public class TourViewComponent : ViewComponent
    {
        private readonly TravelTourContext _context;

        public TourViewComponent(TravelTourContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Lấy 3 tour có giá thấp nhất
            var tours = await _context.TbTours
                .OrderBy(t => t.Price) // Sắp xếp theo Price tăng dần
                .Take(3)              // Lấy 3 mục đầu tiên
                .ToListAsync();

            // Trả dữ liệu vào View
            return View(tours);
        }





    }
}
