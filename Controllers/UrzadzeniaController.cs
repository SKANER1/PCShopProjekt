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
    public class UrzadzeniaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UrzadzeniaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Urzadzenia
        public async Task<IActionResult> Index()
        {
            return View(await _context.Urzadzenia.ToListAsync());
        }

        // GET: Urzadzenia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var urzadzenia = await _context.Urzadzenia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (urzadzenia == null)
            {
                return NotFound();
            }

            return View(urzadzenia);
        }

        // GET: Urzadzenia/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Urzadzenia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Id_klienta,Producent,Nazwa_urzadzenia,Data_zakupu")] Urzadzenia urzadzenia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(urzadzenia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(urzadzenia);
        }

        // GET: Urzadzenia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var urzadzenia = await _context.Urzadzenia.FindAsync(id);
            if (urzadzenia == null)
            {
                return NotFound();
            }
            return View(urzadzenia);
        }

        // POST: Urzadzenia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Id_klienta,Producent,Nazwa_urzadzenia,Data_zakupu")] Urzadzenia urzadzenia)
        {
            if (id != urzadzenia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(urzadzenia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UrzadzeniaExists(urzadzenia.Id))
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
            return View(urzadzenia);
        }

        // GET: Urzadzenia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var urzadzenia = await _context.Urzadzenia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (urzadzenia == null)
            {
                return NotFound();
            }

            return View(urzadzenia);
        }

        // POST: Urzadzenia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var urzadzenia = await _context.Urzadzenia.FindAsync(id);
            if (urzadzenia != null)
            {
                _context.Urzadzenia.Remove(urzadzenia);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UrzadzeniaExists(int id)
        {
            return _context.Urzadzenia.Any(e => e.Id == id);
        }
    }
}
