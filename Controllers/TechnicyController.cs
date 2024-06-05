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
    public class TechnicyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TechnicyController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Technicy
        public async Task<IActionResult> Index()
        {
            return View(await _context.Technicy.ToListAsync());
        }

        // GET: Technicy/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var technicy = await _context.Technicy
                .FirstOrDefaultAsync(m => m.Id == id);
            if (technicy == null)
            {
                return NotFound();
            }

            return View(technicy);
        }

        // GET: Technicy/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Technicy/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Imie,Nazwisko,Email,Numer_telefonu")] Technicy technicy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(technicy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(technicy);
        }

        // GET: Technicy/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var technicy = await _context.Technicy.FindAsync(id);
            if (technicy == null)
            {
                return NotFound();
            }
            return View(technicy);
        }

        // POST: Technicy/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Imie,Nazwisko,Email,Numer_telefonu")] Technicy technicy)
        {
            if (id != technicy.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(technicy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TechnicyExists(technicy.Id))
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
            return View(technicy);
        }

        // GET: Technicy/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var technicy = await _context.Technicy
                .FirstOrDefaultAsync(m => m.Id == id);
            if (technicy == null)
            {
                return NotFound();
            }

            return View(technicy);
        }

        // POST: Technicy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var technicy = await _context.Technicy.FindAsync(id);
            if (technicy != null)
            {
                _context.Technicy.Remove(technicy);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TechnicyExists(int id)
        {
            return _context.Technicy.Any(e => e.Id == id);
        }
    }
}
