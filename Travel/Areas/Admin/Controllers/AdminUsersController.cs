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
    public class AdminUsersController : Controller
    {
        private readonly TravelTourContext _context;

        public AdminUsersController(TravelTourContext context)
        {
            _context = context;
        }

        // GET: Admin/AdminUsers
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbAdminUsers.ToListAsync());
        }

        // GET: Admin/AdminUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbAdminUser = await _context.TbAdminUsers
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (tbAdminUser == null)
            {
                return NotFound();
            }

            return View(tbAdminUser);
        }

        // GET: Admin/AdminUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,UserName,Email,Password,IsAcctive")] TbAdminUser tbAdminUser)
        {
            if (ModelState.IsValid)
            {
               
                _context.Add(tbAdminUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbAdminUser);
        }

        // GET: Admin/AdminUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbAdminUser = await _context.TbAdminUsers.FindAsync(id);
            if (tbAdminUser == null)
            {
                return NotFound();
            }
            return View(tbAdminUser);
        }

        // POST: Admin/AdminUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,UserName,Email,Password,IsAcctive")] TbAdminUser tbAdminUser)
        {
            if (id != tbAdminUser.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbAdminUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbAdminUserExists(tbAdminUser.UserId))
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
            return View(tbAdminUser);
        }

        // GET: Admin/AdminUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbAdminUser = await _context.TbAdminUsers
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (tbAdminUser == null)
            {
                return NotFound();
            }

            return View(tbAdminUser);
        }

        // POST: Admin/AdminUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbAdminUser = await _context.TbAdminUsers.FindAsync(id);
            if (tbAdminUser != null)
            {
                _context.TbAdminUsers.Remove(tbAdminUser);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbAdminUserExists(int id)
        {
            return _context.TbAdminUsers.Any(e => e.UserId == id);
        }
    }
}
