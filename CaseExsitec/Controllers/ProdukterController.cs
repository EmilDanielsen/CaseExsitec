using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CaseExsitec.Data;
using CaseExsitec.Models;


namespace CaseExsitec.Controllers
{
    public class ProdukterController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProdukterController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Produkter
        public async Task<IActionResult> Index()
        {
              return _context.Produkter != null ? 
                          View(await _context.Produkter.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Produkter'  is null.");
        }

        // GET: Produkter/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Produkter == null)
            {
                return NotFound();
            }

            var produkter = await _context.Produkter
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produkter == null)
            {
                return NotFound();
            }

            return View(produkter);
        }

        // GET: Produkter/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produkter/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Produktnr,Produkt,Pris")] Produkter produkter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produkter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produkter);
        }

        // GET: Produkter/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Produkter == null)
            {
                return NotFound();
            }

            var produkter = await _context.Produkter.FindAsync(id);
            if (produkter == null)
            {
                return NotFound();
            }
            return View(produkter);
        }

        // POST: Produkter/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Produktnr,Produkt,Pris")] Produkter produkter)
        {
            if (id != produkter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produkter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdukterExists(produkter.Id))
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
            return View(produkter);
        }

        // GET: Produkter/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Produkter == null)
            {
                return NotFound();
            }

            var produkter = await _context.Produkter
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produkter == null)
            {
                return NotFound();
            }

            return View(produkter);
        }

        // POST: Produkter/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Produkter == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Produkter'  is null.");
            }
            var produkter = await _context.Produkter.FindAsync(id);
            if (produkter != null)
            {
                _context.Produkter.Remove(produkter);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdukterExists(int id)
        {
          return (_context.Produkter?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
