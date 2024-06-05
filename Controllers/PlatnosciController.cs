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
    public class PlatnosciController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlatnosciController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Platnosci
        public async Task<IActionResult> Index()
        {
            return View(await _context.Platnosci.ToListAsync());
        }

        // GET: Platnosci/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var platnosci = await _context.Platnosci
                .FirstOrDefaultAsync(m => m.Id == id);
            if (platnosci == null)
            {
                return NotFound();
            }

            return View(platnosci);
        }

        // GET: Platnosci/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Platnosci/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Id_klienta,Status_platnosci")] Platnosci platnosci)
        {
            if (ModelState.IsValid)
            {
                _context.Add(platnosci);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(platnosci);
        }

        // GET: Platnosci/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var platnosci = await _context.Platnosci.FindAsync(id);
            if (platnosci == null)
            {
                return NotFound();
            }
            return View(platnosci);
        }

        // POST: Platnosci/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Id_klienta,Status_platnosci")] Platnosci platnosci)
        {
            if (id != platnosci.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(platnosci);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlatnosciExists(platnosci.Id))
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
            return View(platnosci);
        }

        // GET: Platnosci/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var platnosci = await _context.Platnosci
                .FirstOrDefaultAsync(m => m.Id == id);
            if (platnosci == null)
            {
                return NotFound();
            }

            return View(platnosci);
        }

        // POST: Platnosci/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var platnosci = await _context.Platnosci.FindAsync(id);
            if (platnosci != null)
            {
                _context.Platnosci.Remove(platnosci);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlatnosciExists(int id)
        {
            return _context.Platnosci.Any(e => e.Id == id);
        }
    }
}
