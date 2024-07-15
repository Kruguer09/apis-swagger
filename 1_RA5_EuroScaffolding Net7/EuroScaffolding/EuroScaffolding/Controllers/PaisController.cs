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
    public class PaisController : Controller
    {
        private readonly MyDbContext _context;

        public PaisController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Pais
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.Paises.Include(p => p.Cancion);
            return View(await myDbContext.ToListAsync());
        }

        // GET: Pais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Paises == null)
            {
                return NotFound();
            }

            var pais = await _context.Paises
                .Include(p => p.Cancion)
                .FirstOrDefaultAsync(m => m.CancionIdentificador == id);
            if (pais == null)
            {
                return NotFound();
            }

            return View(pais);
        }

        // GET: Pais/Create
        public IActionResult Create()
        {
            ViewData["CancionIdentificador"] = new SelectList(_context.Canciones, "Identificador", "Identificador");
            return View();
        }

        // POST: Pais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nombre,CancionIdentificador")] Pais pais)
        {

            _context.Add(pais);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        // GET: Pais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Paises == null)
            {
                return NotFound();
            }

            var pais = await _context.Paises.FindAsync(id);
            if (pais == null)
            {
                return NotFound();
            }
            ViewData["CancionIdentificador"] = new SelectList(_context.Canciones, "Identificador", "Identificador", pais.CancionIdentificador);
            return View(pais);
        }

        // POST: Pais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nombre,CancionIdentificador")] Pais pais)
        {
            if (id != pais.CancionIdentificador)
            {
                return NotFound();
            }


            _context.Update(pais);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        // GET: Pais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Paises == null)
            {
                return NotFound();
            }

            var pais = await _context.Paises
                .Include(p => p.Cancion)
                .FirstOrDefaultAsync(m => m.CancionIdentificador == id);
            if (pais == null)
            {
                return NotFound();
            }

            return View(pais);
        }

        // POST: Pais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Paises == null)
            {
                return Problem("Entity set 'MyDbContext.Paises'  is null.");
            }
            var pais = await _context.Paises.FindAsync(id);
            if (pais != null)
            {
                _context.Paises.Remove(pais);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaisExists(int id)
        {
            return (_context.Paises?.Any(e => e.CancionIdentificador == id)).GetValueOrDefault();
        }
    }
}
