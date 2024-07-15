using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EuroScaffolding2.Models;

namespace EuroScaffolding2.Controllers
{
    public class CancionesController : Controller
    {
        private readonly MyDbContext _context;

        public CancionesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Canciones
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.Canciones.Include(c => c.EdFestival);
            return View(await myDbContext.ToListAsync());
        }

        // GET: Canciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
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

        // GET: Canciones/Create
        public IActionResult Create()
        {
            ViewData["EdFestivalId"] = new SelectList(_context.EdFestivales, "Identificador", "Identificador");
            return View();
        }

        // POST: Canciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Identificador,Titulo,EdFestivalId")] Cancion cancion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cancion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EdFestivalId"] = new SelectList(_context.EdFestivales, "Identificador", "Identificador", cancion.EdFestivalId);
            return View(cancion);
        }

        // GET: Canciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
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

        // POST: Canciones/Edit/5
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

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cancion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CancionExists(cancion.Identificador))
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
            ViewData["EdFestivalId"] = new SelectList(_context.EdFestivales, "Identificador", "Identificador", cancion.EdFestivalId);
            return View(cancion);
        }

        // GET: Canciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
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

        // POST: Canciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cancion = await _context.Canciones.FindAsync(id);
            _context.Canciones.Remove(cancion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CancionExists(int id)
        {
            return _context.Canciones.Any(e => e.Identificador == id);
        }
    }
}
