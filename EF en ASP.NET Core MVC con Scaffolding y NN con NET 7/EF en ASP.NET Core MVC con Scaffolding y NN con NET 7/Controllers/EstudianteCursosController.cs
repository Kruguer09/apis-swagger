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
    public class EstudianteCursosController : Controller
    {
        private readonly MyDbContext _context;

        public EstudianteCursosController(MyDbContext context)
        {
            _context = context;
        }

        // GET: EstudianteCursos
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.EstudiantesCursos.Include(e => e.Curso).Include(e => e.Estudiante);
            return View(await myDbContext.ToListAsync());
        }

        // GET: EstudianteCursos/Details/5
        public async Task<IActionResult> Details(int? cursoId, int? estudianteId)
        {
            //MODIFICADO POR ELISA
            if (estudianteId == null || cursoId == null)
            {
                return NotFound();
            }


            var estudianteCurso = await _context.EstudiantesCursos
                .Include(e => e.Curso)
                .Include(e => e.Estudiante)
                //MODIFICADO
                .FirstOrDefaultAsync(m => m.CursoId == cursoId && m.EstudianteId == estudianteId);
            if (estudianteCurso == null)
            {
                return NotFound();
            }

            return View(estudianteCurso);
        }

        // GET: EstudianteCursos/Create
        public IActionResult Create()
        {
            ViewData["CursoId"] = new SelectList(_context.Cursos, "Id", "Id");
            ViewData["EstudianteId"] = new SelectList(_context.Estudiantes, "Id", "Id");
            return View();
        }

        // POST: EstudianteCursos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EstudianteId,CursoId,Activo")] EstudianteCurso estudianteCurso)
        {

            _context.Add(estudianteCurso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        // GET: EstudianteCursos/Edit/5
        public async Task<IActionResult> Edit(int? estudianteId, int? cursoId)
        {
            if (estudianteId == null || cursoId == null)
            {
                return NotFound();
            }

            var estudianteCurso = await _context.EstudiantesCursos.FindAsync(cursoId, estudianteId);
            if (estudianteCurso == null)
            {
                return NotFound();
            }
            ViewData["CursoId"] = new SelectList(_context.Cursos, "Id", "Id", estudianteCurso.CursoId);
            ViewData["EstudianteId"] = new SelectList(_context.Estudiantes, "Id", "Id", estudianteCurso.EstudianteId);
            return View(estudianteCurso);
        }

        // POST: EstudianteCursos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int estudianteId, int cursoId, [Bind("EstudianteId,CursoId,Activo")] EstudianteCurso estudianteCurso)
        {
            if (estudianteId != estudianteCurso.EstudianteId || cursoId != estudianteCurso.CursoId)
            {
                return NotFound();
            }

            _context.Update(estudianteCurso);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: EstudianteCursos/Delete/5
        public async Task<IActionResult> Delete(int? cursoId, int? estudianteId)
        {
            if (cursoId == null || estudianteId == null)
            {
                return NotFound();
            }

            var estudianteCurso = await _context.EstudiantesCursos
                .Include(e => e.Curso)
                .Include(e => e.Estudiante)
                .FirstOrDefaultAsync(m => m.CursoId == cursoId && m.EstudianteId == estudianteId);
            if (estudianteCurso == null)
            {
                return NotFound();
            }

            return View(estudianteCurso);
        }

        // POST: EstudianteCursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int cursoId, int estudianteId)
        {

            var estudianteCurso = await _context.EstudiantesCursos.FindAsync(cursoId, estudianteId);
            if (estudianteCurso != null)
            {
                _context.EstudiantesCursos.Remove(estudianteCurso);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
