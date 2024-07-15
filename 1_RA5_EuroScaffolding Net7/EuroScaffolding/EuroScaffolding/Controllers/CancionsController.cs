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
    public class CancionsController : Controller
    {
        private readonly MyDbContext _context;

        public CancionsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Cancions
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.Canciones.Include(c => c.EdFestival);
            return View(await myDbContext.ToListAsync());
        }

        // GET: Cancions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Canciones == null)
            {
                return NotFound();
            }

            var cancion = await _context.Canciones
                .Include(c => c.EdFestival)
                .FirstOrDefaultAsync(m => m.Identificador == id);
            if (cancion == null)
            {
                return NotFound();
            }

            return View(cancion);
        }

        // GET: Cancions/Create
        public IActionResult Create()
        {
            ViewData["EdFestivalId"] = new SelectList(_context.EdFestivales, "Identificador", "Identificador");
            return View();
        }

        // POST: Cancions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Identificador,Titulo,EdFestivalId")] Cancion cancion)
        {

            _context.Add(cancion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        // GET: Cancions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Canciones == null)
            {
                return NotFound();
            }

            var cancion = await _context.Canciones.FindAsync(id);
            if (cancion == null)
            {
                return NotFound();
            }
            ViewData["EdFestivalId"] = new SelectList(_context.EdFestivales, "Identificador", "Identificador", cancion.EdFestivalId);
            return View(cancion);
        }

        // POST: Cancions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Identificador,Titulo,EdFestivalId")] Cancion cancion)
        {
            if (id != cancion.Identificador)
            {
                return NotFound();
            }


            _context.Update(cancion);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        // GET: Cancions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Canciones == null)
            {
                return NotFound();
            }

            var cancion = await _context.Canciones
                .Include(c => c.EdFestival)
                .FirstOrDefaultAsync(m => m.Identificador == id);
            if (cancion == null)
            {
                return NotFound();
            }

            return View(cancion);
        }

        // POST: Cancions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Canciones == null)
            {
                return Problem("Entity set 'MyDbContext.Canciones'  is null.");
            }
            var cancion = await _context.Canciones.FindAsync(id);
            if (cancion != null)
            {
                _context.Canciones.Remove(cancion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CancionExists(int id)
        {
            return (_context.Canciones?.Any(e => e.Identificador == id)).GetValueOrDefault();
        }
    }
}
