using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PCShopProjekt.Data;
using PCShopProjekt.Models;
using Microsoft.AspNetCore.Authorization;

namespace PCShopProjekt.Controllers
{
    [Authorize]
    public class ZleceniaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ZleceniaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Zlecenia
        public async Task<IActionResult> Index()
        {
            var zleceniaWithDetails = from zlec in _context.Zlecenia
                                      join kl in _context.Klienci on zlec.Id_klienta equals kl.Id
                                      join urz in _context.Urzadzenia on zlec.Id_urzadzenia equals urz.Id
                                      join tech in _context.Technicy on zlec.Id_technika equals tech.Id into techDetails
                                      from subTech in techDetails.DefaultIfEmpty()
                                      join plat in _context.Platnosci on zlec.Id_platnosci equals plat.Id
                                      join usl in _context.Uslugi on zlec.Id_uslugi equals usl.Id into uslDetails
                                      from subUsl in uslDetails.DefaultIfEmpty()
                                      select new ZleceniaViewModel
                                      {
                                          Id = zlec.Id,
                                          KlientFullName = kl.Imie + " " + kl.Nazwisko,
                                          KlientId = kl.Id,
                                          UrzadzenieId = urz.Id,
                                          UrzadzenieDetails = urz.Producent + " " + urz.Nazwa_urzadzenia,
                                          TechnikId = subTech != null ? subTech.Id : (int?)null,
                                          TechnikFullName = subTech != null ? subTech.Imie + " " + subTech.Nazwisko : "Technik nieprzypsiany",
                                          StatusPlatnosci = plat.Status_platnosci,
                                          DataPrzyjecia = zlec.Data_przyjecia,
                                          OpisUsterki = zlec.Opis_usterki,
                                          NazwaUslugi = subUsl != null ? subUsl.Nazwa_uslugi : "Usługa nieprzypisana",
                                          Status = zlec.Status
                                      };

            return View(await zleceniaWithDetails.ToListAsync());
        }



        // GET: Zlecenia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zlecenia = await _context.Zlecenia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zlecenia == null)
            {
                return NotFound();
            }

            return View(zlecenia);
        }

        // GET: Zlecenia/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zlecenia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Id_urzadzenia,Id_klienta,Id_technika,Id_uslugi,Id_platnosci,Data_przyjecia,Opis_usterki,Status")] Zlecenia zlecenia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zlecenia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zlecenia);
        }

        // GET: Zlecenia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zlecenia = await _context.Zlecenia.FindAsync(id);
            if (zlecenia == null)
            {
                return NotFound();
            }
            return View(zlecenia);
        }

        // POST: Zlecenia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Id_urzadzenia,Id_klienta,Id_technika,Id_uslugi,Id_platnosci,Data_przyjecia,Opis_usterki,Status")] Zlecenia zlecenia)
        {
            if (id != zlecenia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zlecenia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZleceniaExists(zlecenia.Id))
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
            return View(zlecenia);
        }

        // GET: Zlecenia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zlecenia = await _context.Zlecenia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zlecenia == null)
            {
                return NotFound();
            }

            return View(zlecenia);
        }

        // POST: Zlecenia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zlecenia = await _context.Zlecenia.FindAsync(id);
            if (zlecenia != null)
            {
                _context.Zlecenia.Remove(zlecenia);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZleceniaExists(int id)
        {
            return _context.Zlecenia.Any(e => e.Id == id);
        }
    }
}
