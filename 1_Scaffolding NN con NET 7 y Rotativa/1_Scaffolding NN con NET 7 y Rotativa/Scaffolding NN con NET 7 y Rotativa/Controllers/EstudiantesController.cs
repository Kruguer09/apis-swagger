using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EF_en_ASP.NET_Core_MVC_con_Scaffolding_y_NN_con_NET_7.Context;
using EF_en_ASP.NET_Core_MVC_con_Scaffolding_y_NN_con_NET_7.Models;
using Rotativa.AspNetCore;

namespace EF_en_ASP.NET_Core_MVC_con_Scaffolding_y_NN_con_NET_7.Controllers
{
    public class EstudiantesController : Controller
    {
        private readonly MyDbContext _context;

        public EstudiantesController(MyDbContext context)
        {
            _context = context;
        }

        //REPORTES
        public async Task<IActionResult> EstudiantePDF()
        {
            var myDbContext = _context.Estudiantes.Include(e => e.Instituto);
            return new ViewAsPdf("EstudiantePDF", await myDbContext.ToListAsync())
            {
                //Nombre de archivo: si lo pongo no se muestra la página y se descarga
                //automáticamente el PDF
                FileName="ListaEstudiantesPDF.pdf",
                //Orientación de la página en horizontal
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape,
                PageSize = Rotativa.AspNetCore.Options.Size.A4,

                //Usamos varias opciones de configuración de la línea de comandos de la herramienta wkhtmltopdf.
                //https://wkhtmltopdf.org/usage/wkhtmltopdf.txt
                CustomSwitches = "--footer-center \"Página \"[page]\" de \"[topage] --footer-right [date] --footer-font-size 12 --header-left \"IES Trassierra\""
                    + " --header-font-size 24 --header-font-name \"Courier New\""
            };
        }

        // GET: Estudiantes
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.Estudiantes.Include(e => e.Instituto);
            return View(await myDbContext.ToListAsync());
        }

        // GET: Estudiantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Estudiantes == null)
            {
                return NotFound();
            }

            var estudiante = await _context.Estudiantes
                .Include(e => e.Instituto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estudiante == null)
            {
                return NotFound();
            }

            return View(estudiante);
        }

        // GET: Estudiantes/Create
        public IActionResult Create()
        {
            ViewData["InstitutoId"] = new SelectList(_context.Institutos, "Id", "Id");
            return View();
        }

        // POST: Estudiantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Edad,InstitutoId")] Estudiante estudiante)
        {

            _context.Add(estudiante);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        // GET: Estudiantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Estudiantes == null)
            {
                return NotFound();
            }

            var estudiante = await _context.Estudiantes.FindAsync(id);
            if (estudiante == null)
            {
                return NotFound();
            }
            ViewData["InstitutoId"] = new SelectList(_context.Institutos, "Id", "Id", estudiante.InstitutoId);
            return View(estudiante);
        }

        // POST: Estudiantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Edad,InstitutoId")] Estudiante estudiante)
        {
            if (id != estudiante.Id)
            {
                return NotFound();
            }


            _context.Update(estudiante);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        // GET: Estudiantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Estudiantes == null)
            {
                return NotFound();
            }

            var estudiante = await _context.Estudiantes
                .Include(e => e.Instituto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estudiante == null)
            {
                return NotFound();
            }

            return View(estudiante);
        }

        // POST: Estudiantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Estudiantes == null)
            {
                return Problem("Entity set 'MyDbContext.Estudiantes'  is null.");
            }
            var estudiante = await _context.Estudiantes.FindAsync(id);
            if (estudiante != null)
            {
                _context.Estudiantes.Remove(estudiante);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstudianteExists(int id)
        {
            return (_context.Estudiantes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
