using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PCShopProjekt.Data;
using PCShopProjekt.Models;

namespace PCShopProjekt.Controllers
{
    [Authorize]
    public class UslugiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UslugiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Uslugi
        public async Task<IActionResult> Index()
        {
            return View(await _context.Uslugi.ToListAsync());
        }

        // GET: Uslugi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uslugi = await _context.Uslugi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (uslugi == null)
            {
                return NotFound();
            }

            return View(uslugi);
        }

        // GET: Uslugi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Uslugi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nazwa_uslugi")] Uslugi uslugi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(uslugi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(uslugi);
        }

        // GET: Uslugi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uslugi = await _context.Uslugi.FindAsync(id);
            if (uslugi == null)
            {
                return NotFound();
            }
            return View(uslugi);
        }

        // POST: Uslugi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nazwa_uslugi")] Uslugi uslugi)
        {
            if (id != uslugi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(uslugi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UslugiExists(uslugi.Id))
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
            return View(uslugi);
        }

        // GET: Uslugi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uslugi = await _context.Uslugi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (uslugi == null)
            {
                return NotFound();
            }

            return View(uslugi);
        }

        // POST: Uslugi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var uslugi = await _context.Uslugi.FindAsync(id);
            if (uslugi != null)
            {
                _context.Uslugi.Remove(uslugi);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UslugiExists(int id)
        {
            return _context.Uslugi.Any(e => e.Id == id);
        }
    }
}
