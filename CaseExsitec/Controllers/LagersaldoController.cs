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
    public class LagersaldoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LagersaldoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Lagersaldo
        public async Task<IActionResult> Index()
        {
              return _context.LagersaldoModel != null ? 
                          View(await _context.LagersaldoModel.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.LagersaldoModel'  is null.");
        }

        // GET: Lagersaldo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LagersaldoModel == null)
            {
                return NotFound();
            }

            var lagersaldoModel = await _context.LagersaldoModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lagersaldoModel == null)
            {
                return NotFound();
            }

            return View(lagersaldoModel);
        }

        // GET: Lagersaldo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lagersaldo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Produkt,Varelager,Lagersaldo")] LagersaldoModel lagersaldoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lagersaldoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lagersaldoModel);
        }

        // GET: Lagersaldo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LagersaldoModel == null)
            {
                return NotFound();
            }

            var lagersaldoModel = await _context.LagersaldoModel.FindAsync(id);
            if (lagersaldoModel == null)
            {
                return NotFound();
            }
            return View(lagersaldoModel);
        }

        // POST: Lagersaldo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Produkt,Varelager,Lagersaldo")] LagersaldoModel lagersaldoModel)
        {
            if (id != lagersaldoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lagersaldoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LagersaldoModelExists(lagersaldoModel.Id))
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
            return View(lagersaldoModel);
        }

        // GET: Lagersaldo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LagersaldoModel == null)
            {
                return NotFound();
            }

            var lagersaldoModel = await _context.LagersaldoModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lagersaldoModel == null)
            {
                return NotFound();
            }

            return View(lagersaldoModel);
        }

        // POST: Lagersaldo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LagersaldoModel == null)
            {
                return Problem("Entity set 'ApplicationDbContext.LagersaldoModel'  is null.");
            }
            var lagersaldoModel = await _context.LagersaldoModel.FindAsync(id);
            if (lagersaldoModel != null)
            {
                _context.LagersaldoModel.Remove(lagersaldoModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LagersaldoModelExists(int id)
        {
          return (_context.LagersaldoModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
