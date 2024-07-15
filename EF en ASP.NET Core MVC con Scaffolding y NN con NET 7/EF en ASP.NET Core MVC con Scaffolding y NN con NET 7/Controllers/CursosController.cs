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
    public class CursosController : Controller
    {
        private readonly MyDbContext _context;

        public CursosController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Cursos
        public async Task<IActionResult> Index()
        {
            return _context.Cursos != null ?
                        View(await _context.Cursos.ToListAsync()) :
                        Problem("Entity set 'MyDbContext.Cursos'  is null.");
        }

        // GET: Cursos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cursos == null)
            {
                return NotFound();
            }

            var curso = await _context.Cursos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }

        // GET: Cursos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cursos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] Curso curso)
        {

            _context.Add(curso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        // GET: Cursos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cursos == null)
            {
                return NotFound();
            }

            var curso = await _context.Cursos.FindAsync(id);
            if (curso == null)
            {
                return NotFound();
            }
            return View(curso);
        }

        // POST: Cursos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] Curso curso)
        {
            if (id != curso.Id)
            {
                return NotFound();
            }


            _context.Update(curso);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        // GET: Cursos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cursos == null)
            {
                return NotFound();
            }

            var curso = await _context.Cursos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }

        // POST: Cursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cursos == null)
            {
                return Problem("Entity set 'MyDbContext.Cursos'  is null.");
            }
            var curso = await _context.Cursos.FindAsync(id);
            if (curso != null)
            {
                _context.Cursos.Remove(curso);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        
    }
}
