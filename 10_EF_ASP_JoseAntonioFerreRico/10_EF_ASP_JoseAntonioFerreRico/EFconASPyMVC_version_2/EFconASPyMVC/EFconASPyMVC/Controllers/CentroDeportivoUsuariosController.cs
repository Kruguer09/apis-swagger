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
    // Controlador de la tabla intermedia entre usuarios y centros deportivos
    // Se encarga de gestionar las relaciones entre usuarios y centros deportivos
    // Permite crear, editar, eliminar y ver las relaciones entre usuarios y centros deportivos
    // Modificada para mostrar los datos de los usuarios y centros deportivos en editar y crear
    public class CentroDeportivoUsuariosController : Controller
    {
        private readonly MyContext _context;

        public CentroDeportivoUsuariosController(MyContext context)
        {
            _context = context;
        }

        // GET: CentroDeportivoUsuarios
        public async Task<IActionResult> Index()
        {
            var myContext = _context.CentrosUsuarios.Include(c => c.Usuario).Include(c => c.CentroDeportivo);
            return View(await myContext.ToListAsync());
        }

        // GET: CentroDeportivoUsuarios/Details/5
        public async Task<IActionResult> Details(string? UsuarioDniUsuario, int? CentroDeportivoId)
        {
            if (UsuarioDniUsuario == null || CentroDeportivoId == null)
            {
                return NotFound();
            }

            var centroDeportivoUsuario = await _context.CentrosUsuarios
                .Include(c => c.CentroDeportivo)
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.UsuarioDniUsuario == UsuarioDniUsuario && m.CentroDeportivoId == CentroDeportivoId);
            if (centroDeportivoUsuario == null)
            {
                return NotFound();
            }

            return View(centroDeportivoUsuario);
        }

        // GET: CentroDeportivoUsuarios/Create
        public IActionResult Create()
        {
            ViewData["CentroDeportivoId"] = new SelectList(_context.CentrosDeportivos, "Id", "Id");
            ViewData["UsuarioDniUsuario"] = new SelectList(_context.Usuarios, "DniUsuario", "DniUsuario");
            return View();
        }

        // POST: CentroDeportivoUsuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UsuarioDniUsuario,CentroDeportivoId")] CentroDeportivoUsuario centroDeportivoUsuario)
        {
           
                _context.Add(centroDeportivoUsuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
        
        }

        // GET: CentroDeportivoUsuarios/Edit/5
        public async Task<IActionResult> Edit(string? UsuarioDniUsuario, int? CentroDeportivoId)
        {
            if (UsuarioDniUsuario == null || CentroDeportivoId == null)
            {
                return NotFound();
            }

            var centroDeportivoUsuario = await _context.CentrosUsuarios.FindAsync(UsuarioDniUsuario, CentroDeportivoId);
            if (centroDeportivoUsuario == null)
            {
                return NotFound();
            }
            ViewData["CentroDeportivoId"] = new SelectList(_context.CentrosDeportivos, "Id", "Id", centroDeportivoUsuario.CentroDeportivoId);
            ViewData["UsuarioDniUsuario"] = new SelectList(_context.Usuarios, "DniUsuario", "DniUsuario", centroDeportivoUsuario.UsuarioDniUsuario);
            return View(centroDeportivoUsuario);
        }

        // POST: CentroDeportivoUsuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string UsuarioDniUsuario, int CentroDeportivoId, [Bind("UsuarioDniUsuario,CentroDeportivoId")] CentroDeportivoUsuario centroDeportivoUsuario)
        {
            if (UsuarioDniUsuario != centroDeportivoUsuario.UsuarioDniUsuario || CentroDeportivoId != centroDeportivoUsuario.CentroDeportivoId)
            {
                return NotFound();
            }

 

                    _context.Update(centroDeportivoUsuario);
                    await _context.SaveChangesAsync();
         
                return RedirectToAction(nameof(Index));
     
        }

        // GET: CentroDeportivoUsuarios/Delete/5
        public async Task<IActionResult> Delete(string? UsuarioDniUsuario, int? CentroDeportivoId)
        {
            if (UsuarioDniUsuario == null || CentroDeportivoId == null)
            {
                return NotFound();
            }

            var centroDeportivoUsuario = await _context.CentrosUsuarios
                .Include(c => c.CentroDeportivo)
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.UsuarioDniUsuario == UsuarioDniUsuario && m.CentroDeportivoId == CentroDeportivoId);
            if (centroDeportivoUsuario == null)
            {
                return NotFound();
            }

            return View(centroDeportivoUsuario);
        }

        // POST: CentroDeportivoUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string? UsuarioDniUsuario, int? CentroDeportivoId)
        {

            var centroDeportivoUsuario = await _context.CentrosUsuarios.FindAsync(UsuarioDniUsuario, CentroDeportivoId);
            if (centroDeportivoUsuario != null)
            {
                _context.CentrosUsuarios.Remove(centroDeportivoUsuario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
