using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CaseExsitec.Data;
using CaseExsitec.Models;
using Microsoft.AspNetCore.Authorization;

namespace CaseExsitec.Controllers
{
    public class InnOgUtleveransesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InnOgUtleveransesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: InnOgUtleveranses
        public async Task<IActionResult> Index()
        {
              return _context.InnOgUtleveranse != null ? 
                          View(await _context.InnOgUtleveranse.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.InnOgUtleveranse'  is null.");
        }

        //GET: Lagersaldo
        public async Task<IActionResult> ShowLagersaldo()
        {
            return _context.InnOgUtleveranse != null ?
                         View(await _context.InnOgUtleveranse.ToListAsync()) :
                         Problem("Entity set 'ApplicationDbContext.InnOgUtleveranse'  is null.");
        }

        // GET: InnOgUtleveranses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.InnOgUtleveranse == null)
            {
                return NotFound();
            }

            var innOgUtleveranse = await _context.InnOgUtleveranse
                .FirstOrDefaultAsync(m => m.Id == id);
            if (innOgUtleveranse == null)
            {
                return NotFound();
            }

            return View(innOgUtleveranse);
        }

        // GET: InnOgUtleveranses/Create

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: InnOgUtleveranses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Dato,Produkt,TilFra,Antall,InngåendeLagersaldo")] InnOgUtleveranse innOgUtleveranse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(innOgUtleveranse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(innOgUtleveranse);
        }

        // GET: InnOgUtleveranses/Edit/5

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.InnOgUtleveranse == null)
            {
                return NotFound();
            }

            var innOgUtleveranse = await _context.InnOgUtleveranse.FindAsync(id);
            if (innOgUtleveranse == null)
            {
                return NotFound();
            }
            return View(innOgUtleveranse);
        }

        // POST: InnOgUtleveranses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Dato,Produkt,TilFra,Antall,InngåendeLagersaldo")] InnOgUtleveranse innOgUtleveranse)
        {
            if (id != innOgUtleveranse.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(innOgUtleveranse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InnOgUtleveranseExists(innOgUtleveranse.Id))
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
            return View(innOgUtleveranse);
        }

        // GET: InnOgUtleveranses/Delete/5

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.InnOgUtleveranse == null)
            {
                return NotFound();
            }

            var innOgUtleveranse = await _context.InnOgUtleveranse
                .FirstOrDefaultAsync(m => m.Id == id);
            if (innOgUtleveranse == null)
            {
                return NotFound();
            }

            return View(innOgUtleveranse);
        }

        // POST: InnOgUtleveranses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.InnOgUtleveranse == null)
            {
                return Problem("Entity set 'ApplicationDbContext.InnOgUtleveranse'  is null.");
            }
            var innOgUtleveranse = await _context.InnOgUtleveranse.FindAsync(id);
            if (innOgUtleveranse != null)
            {
                _context.InnOgUtleveranse.Remove(innOgUtleveranse);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InnOgUtleveranseExists(int id)
        {
          return (_context.InnOgUtleveranse?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
