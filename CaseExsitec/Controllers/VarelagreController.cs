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
    public class VarelagreController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VarelagreController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Varelagre
        public async Task<IActionResult> Index()
        {
              return _context.Varelagre != null ? 
                          View(await _context.Varelagre.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Varelagre'  is null.");
        }

        // GET: Varelagre/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Varelagre == null)
            {
                return NotFound();
            }

            var varelagre = await _context.Varelagre
                .FirstOrDefaultAsync(m => m.Id == id);
            if (varelagre == null)
            {
                return NotFound();
            }

            return View(varelagre);
        }

        // GET: Varelagre/Create
        
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Varelagre/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Lagernr,Sted")] Varelagre varelagre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(varelagre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(varelagre);
        }

        // GET: Varelagre/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Varelagre == null)
            {
                return NotFound();
            }

            var varelagre = await _context.Varelagre.FindAsync(id);
            if (varelagre == null)
            {
                return NotFound();
            }
            return View(varelagre);
        }

        // POST: Varelagre/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Lagernr,Sted")] Varelagre varelagre)
        {
            if (id != varelagre.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(varelagre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VarelagreExists(varelagre.Id))
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
            return View(varelagre);
        }

        // GET: Varelagre/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Varelagre == null)
            {
                return NotFound();
            }

            var varelagre = await _context.Varelagre
                .FirstOrDefaultAsync(m => m.Id == id);
            if (varelagre == null)
            {
                return NotFound();
            }

            return View(varelagre);
        }

        // POST: Varelagre/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Varelagre == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Varelagre'  is null.");
            }
            var varelagre = await _context.Varelagre.FindAsync(id);
            if (varelagre != null)
            {
                _context.Varelagre.Remove(varelagre);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VarelagreExists(int id)
        {
          return (_context.Varelagre?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
