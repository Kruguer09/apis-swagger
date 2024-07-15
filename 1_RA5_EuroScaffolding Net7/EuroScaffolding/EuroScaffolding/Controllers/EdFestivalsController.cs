using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EuroScaffolding2.Models;

namespace EuroScaffolding.Controllers
{
    public class EdFestivalsController : Controller
    {
        private readonly MyDbContext _context;

        public EdFestivalsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: EdFestivals
        public async Task<IActionResult> Index()
        {
              return _context.EdFestivales != null ? 
                          View(await _context.EdFestivales.ToListAsync()) :
                          Problem("Entity set 'MyDbContext.EdFestivales'  is null.");
        }

        // GET: EdFestivals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EdFestivales == null)
            {
                return NotFound();
            }

            var edFestival = await _context.EdFestivales
                .FirstOrDefaultAsync(m => m.Identificador == id);
            if (edFestival == null)
            {
                return NotFound();
            }

            return View(edFestival);
        }

        // GET: EdFestivals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EdFestivals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Identificador,Anyo,Ciudad")] EdFestival edFestival)
        {
            if (ModelState.IsValid)
            {
                _context.Add(edFestival);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(edFestival);
        }

        // GET: EdFestivals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EdFestivales == null)
            {
                return NotFound();
            }

            var edFestival = await _context.EdFestivales.FindAsync(id);
            if (edFestival == null)
            {
                return NotFound();
            }
            return View(edFestival);
        }

        // POST: EdFestivals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Identificador,Anyo,Ciudad")] EdFestival edFestival)
        {
            if (id != edFestival.Identificador)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(edFestival);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EdFestivalExists(edFestival.Identificador))
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
            return View(edFestival);
        }

        // GET: EdFestivals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EdFestivales == null)
            {
                return NotFound();
            }

            var edFestival = await _context.EdFestivales
                .FirstOrDefaultAsync(m => m.Identificador == id);
            if (edFestival == null)
            {
                return NotFound();
            }

            return View(edFestival);
        }

        // POST: EdFestivals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EdFestivales == null)
            {
                return Problem("Entity set 'MyDbContext.EdFestivales'  is null.");
            }
            var edFestival = await _context.EdFestivales.FindAsync(id);
            if (edFestival != null)
            {
                _context.EdFestivales.Remove(edFestival);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EdFestivalExists(int id)
        {
          return (_context.EdFestivales?.Any(e => e.Identificador == id)).GetValueOrDefault();
        }
    }
}
