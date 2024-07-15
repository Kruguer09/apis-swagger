using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFconASPyMVC.Context;
using EFconASPyMVC.Models;

namespace EFconASPyMVC.Controllers
{
    // Controlador de la tabla de pistas
    // Se encarga de gestionar las pistas
    // Permite crear, editar, eliminar y ver las pistas
    // Modificada para mostrar los datos de los centros deportivos en editar y crear
    public class PistasController : Controller
    {
        private readonly MyContext _context;

        public PistasController(MyContext context)
        {
            _context = context;
        }

        // GET: Pistas
        public async Task<IActionResult> Index()
        {
              return _context.Pistas != null ? 
                          View(await _context.Pistas.ToListAsync()) :
                          Problem("Entity set 'MyContext.Pistas'  is null.");
        }

        // GET: Pistas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Pistas == null)
            {
                return NotFound();
            }

            var pista = await _context.Pistas
                .FirstOrDefaultAsync(m => m.PistaNombre == id);
            if (pista == null)
            {
                return NotFound();
            }

            return View(pista);
        }

        // GET: Pistas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pistas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PistaNombre,Aforo,CentroDeportivoId")] Pista pista)
        {

                _context.Add(pista);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

        }

        // GET: Pistas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Pistas == null)
            {
                return NotFound();
            }

            var pista = await _context.Pistas.FindAsync(id);
            if (pista == null)
            {
                return NotFound();
            }
            return View(pista);
        }

        // POST: Pistas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PistaNombre,Aforo,CentroDeportivoId")] Pista pista)
        {
            if (id != pista.PistaNombre)
            {
                return NotFound();
            }


                    _context.Update(pista);
                    await _context.SaveChangesAsync();
    
                return RedirectToAction(nameof(Index));
 
        }

        // GET: Pistas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Pistas == null)
            {
                return NotFound();
            }

            var pista = await _context.Pistas
                .FirstOrDefaultAsync(m => m.PistaNombre == id);
            if (pista == null)
            {
                return NotFound();
            }

            return View(pista);
        }

        // POST: Pistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Pistas == null)
            {
                return Problem("Entity set 'MyContext.Pistas'  is null.");
            }
            var pista = await _context.Pistas.FindAsync(id);
            if (pista != null)
            {
                _context.Pistas.Remove(pista);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PistaExists(string id)
        {
          return (_context.Pistas?.Any(e => e.PistaNombre == id)).GetValueOrDefault();
        }
    }
}
