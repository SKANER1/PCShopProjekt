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
    public class KlienciController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KlienciController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Klienci
        public async Task<IActionResult> Index()
        {
            return View(await _context.Klienci.ToListAsync());
        }

        // GET: Klienci/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klienci = await _context.Klienci
                .FirstOrDefaultAsync(m => m.Id == id);
            if (klienci == null)
            {
                return NotFound();
            }

            return View(klienci);
        }

        // GET: Klienci/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Klienci/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Imie,Nazwisko,Email,Numer_telefonu,Adres,Kod_pocztowy")] Klienci klienci)
        {
            if (ModelState.IsValid)
            {
                _context.Add(klienci);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(klienci);
        }

        // GET: Klienci/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klienci = await _context.Klienci.FindAsync(id);
            if (klienci == null)
            {
                return NotFound();
            }
            return View(klienci);
        }

        // POST: Klienci/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Imie,Nazwisko,Email,Numer_telefonu,Adres,Kod_pocztowy")] Klienci klienci)
        {
            if (id != klienci.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(klienci);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KlienciExists(klienci.Id))
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
            return View(klienci);
        }

        // GET: Klienci/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klienci = await _context.Klienci
                .FirstOrDefaultAsync(m => m.Id == id);
            if (klienci == null)
            {
                return NotFound();
            }

            return View(klienci);
        }

        // POST: Klienci/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var klienci = await _context.Klienci.FindAsync(id);
            if (klienci != null)
            {
                _context.Klienci.Remove(klienci);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KlienciExists(int id)
        {
            return _context.Klienci.Any(e => e.Id == id);
        }
    }
}
