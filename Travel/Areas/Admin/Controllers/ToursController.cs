using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Travel.Models;

namespace Travel.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ToursController : Controller
    {
        private readonly TravelTourContext _context;

        public ToursController(TravelTourContext context)
        {
            _context = context;
        }

        // GET: Admin/Tours
        public async Task<IActionResult> Index()
        {
            var travelTourContext = _context.TbTours.Include(t => t.Type);
            return View(await travelTourContext.ToListAsync());
        }

        // GET: Admin/Tours/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbTour = await _context.TbTours
                .Include(t => t.Type)
                .FirstOrDefaultAsync(m => m.TourId == id);
            if (tbTour == null)
            {
                return NotFound();
            }

            return View(tbTour);
        }

        // GET: Admin/Tours/Create
        public IActionResult Create()
        {
            ViewData["TypeId"] = new SelectList(_context.TbTourTypes, "TypeId", "Title");
            return View();
        }

        // POST: Admin/Tours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TourId,TypeId,Title,Alias,Detail,Price,PriceSale,Description,Image,Destination,TopDestination,IsBestTour,IsNew,Country,TourDuration,Assess,IsActive,Star")] TbTour tbTour)
        {
            if (ModelState.IsValid)
            {
                tbTour.Alias = Travel.Utilities.Function.TitleSlugGenerationAlias(tbTour.Title);
                _context.Add(tbTour);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TypeId"] = new 
                SelectList(_context.TbTourTypes, "TypeId", "TypeId", tbTour.TypeId);
            return View(tbTour);
        }

        // GET: Admin/Tours/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbTour = await _context.TbTours.FindAsync(id);
            if (tbTour == null)
            {
                return NotFound();
            }
            ViewData["TypeId"] = new 
                SelectList(_context.TbTourTypes, "TypeId", "Title", tbTour.TypeId);
            return View(tbTour);
        }

        // POST: Admin/Tours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TourId,TypeId,Title,Alias,Detail,Price,PriceSale,Description,Image,Destination,TopDestination,IsBestTour,IsNew,Country,TourDuration,Assess,IsActive,Star")] TbTour tbTour)
        {
            if (id != tbTour.TourId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbTour);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbTourExists(tbTour.TourId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["TypeId"] = new SelectList(_context.TbTourTypes, "TypeId", "TypeId", tbTour.TypeId);
            return View(tbTour);
        }

        // GET: Admin/Tours/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbTour = await _context.TbTours
                .Include(t => t.Type)
                .FirstOrDefaultAsync(m => m.TourId == id);
            if (tbTour == null)
            {
                return NotFound();
            }

            return View(tbTour);
        }

        // POST: Admin/Tours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbTour = await _context.TbTours.FindAsync(id);
            if (tbTour != null)
            {
                _context.TbTours.Remove(tbTour);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbTourExists(int id)
        {
            return _context.TbTours.Any(e => e.TourId == id);
        }
    }
}
