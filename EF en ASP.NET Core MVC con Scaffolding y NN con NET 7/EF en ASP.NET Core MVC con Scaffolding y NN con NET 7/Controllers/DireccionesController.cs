using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EF_en_ASP.NET_Core_MVC_con_Scaffolding_y_NN_con_NET_7.Context;
using EF_en_ASP.NET_Core_MVC_con_Scaffolding_y_NN_con_NET_7.Models;

namespace EF_en_ASP.NET_Core_MVC_con_Scaffolding_y_NN_con_NET_7.Controllers
{
    public class DireccionesController : Controller
    {
        private readonly MyDbContext _context;

        public DireccionesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Direcciones
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.Direcciones.Include(d => d.Estudiante);
            return View(await myDbContext.ToListAsync());
        }

        // GET: Direcciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Direcciones == null)
            {
                return NotFound();
            }

            var direccion = await _context.Direcciones
                .Include(d => d.Estudiante)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (direccion == null)
            {
                return NotFound();
            }

            return View(direccion);
        }

        // GET: Direcciones/Create
        public IActionResult Create()
        {
            ViewData["EstudianteId"] = new SelectList(_context.Estudiantes, "Id", "Id");
            return View();
        }

        // POST: Direcciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Calle,EstudianteId")] Direccion direccion)
        {

            _context.Add(direccion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        // GET: Direcciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Direcciones == null)
            {
                return NotFound();
            }

            var direccion = await _context.Direcciones.FindAsync(id);
            if (direccion == null)
            {
                return NotFound();
            }
            ViewData["EstudianteId"] = new SelectList(_context.Estudiantes, "Id", "Id", direccion.EstudianteId);
            return View(direccion);
        }

        // POST: Direcciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Calle,EstudianteId")] Direccion direccion)
        {
            if (id != direccion.Id)
            {
                return NotFound();
            }


            _context.Update(direccion);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        // GET: Direcciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Direcciones == null)
            {
                return NotFound();
            }

            var direccion = await _context.Direcciones
                .Include(d => d.Estudiante)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (direccion == null)
            {
                return NotFound();
            }

            return View(direccion);
        }

        // POST: Direcciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Direcciones == null)
            {
                return Problem("Entity set 'MyDbContext.Direcciones'  is null.");
            }
            var direccion = await _context.Direcciones.FindAsync(id);
            if (direccion != null)
            {
                _context.Direcciones.Remove(direccion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        
    }
}
