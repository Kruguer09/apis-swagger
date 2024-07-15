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
    public class InstitutosController : Controller
    {
        private readonly MyDbContext _context;

        public InstitutosController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Institutos
        public async Task<IActionResult> Index()
        {
            return _context.Institutos != null ?
                        View(await _context.Institutos.ToListAsync()) :
                        Problem("Entity set 'MyDbContext.Institutos'  is null.");
        }

        // GET: Institutos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Institutos == null)
            {
                return NotFound();
            }

            var instituto = await _context.Institutos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (instituto == null)
            {
                return NotFound();
            }

            return View(instituto);
        }

        // GET: Institutos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Institutos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] Instituto instituto)
        {

            _context.Add(instituto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        // GET: Institutos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Institutos == null)
            {
                return NotFound();
            }

            var instituto = await _context.Institutos.FindAsync(id);
            if (instituto == null)
            {
                return NotFound();
            }
            return View(instituto);
        }

        // POST: Institutos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] Instituto instituto)
        {
            if (id != instituto.Id)
            {
                return NotFound();
            }


            _context.Update(instituto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        // GET: Institutos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Institutos == null)
            {
                return NotFound();
            }

            var instituto = await _context.Institutos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (instituto == null)
            {
                return NotFound();
            }

            return View(instituto);
        }

        // POST: Institutos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Institutos == null)
            {
                return Problem("Entity set 'MyDbContext.Institutos'  is null.");
            }
            var instituto = await _context.Institutos.FindAsync(id);
            if (instituto != null)
            {
                _context.Institutos.Remove(instituto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        
    }
}
