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
using Rotativa.AspNetCore.Options;

namespace EF_en_ASP.NET_Core_MVC_con_Scaffolding_y_NN_con_NET_7.Controllers
{
    public class CursosController : Controller
    {
        private readonly MyDbContext _context;

        public CursosController(MyDbContext context)
        {
            _context = context;
        }

        //REPORTES

        public IActionResult CursoHeaderPDF()
        {
            return View("CursoHeaderPDF");
        }

        public IActionResult CursoFooterPDF()
        {
            return View("CursoFooterPDF");
        }
        public async Task<IActionResult> CursoPDF()
        {
            //Cuando accedamos a este método del controlador
            //se nos devolverá el resultado de convertir a PDF
            //el contenido que hay en nuestra tabla Cursos
            //con el formato que se le haya dado en la vista (el archivo
            //CursoPDF.cshtml) + lo que especifiquemos en el método
            //ViewAsPdf

            //Define la URL de la Cabecera si ejecutamos nuestro proyecto con HTTPS
            //Si lo hiciéramos con HTTP, habría que cambiar la línea de abajo por ésta:
            // string _headerUrl = Url.Action("CursoHeaderPDF", "Cursos", null, //"http");
            string _headerUrl = Url.Action("CursoHeaderPDF", "Cursos", null, "https");
            // Define la URL del Pie de página (se aplica lo mismo si en vez de HTTPS 
            // es HTTP
            string _footerUrl = Url.Action("CursoFooterPDF", "Cursos", null, "https");

            return new ViewAsPdf("CursoPDF", await _context.Cursos.ToListAsync())
            {
                //Orientación de la página horizontal
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
                PageSize = Rotativa.AspNetCore.Options.Size.A4,
                //Bottom=30 => espacio para el footer, Top=70 =>espacio para el header
                PageMargins = new Margins { Bottom = 30, Left = 10, Right = 10, Top = 70 },
                //Se va a mostrar en escala de grises
                IsGrayScale = true,
                //Establecemos las vistas de cabecera y pie de página en el encabezado
                //y pie de página de nuestro documento
                CustomSwitches = "--header-html " + _headerUrl + " --header-spacing 10 "
                               + "--footer-html " + _footerUrl + " --footer-spacing 10"

            };
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
