using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ARScaffoldingJoseAFerreRico.Context;
using ARScaffoldingJoseAFerreRico.Models;
using System.Net;

namespace ARScaffoldingJoseAFerreRico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        private readonly EmpresaContext _context;

        public EmpresasController(EmpresaContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Obtiene todos las empresas registradas en la aplicación
        /// </summary>
        /// <returns></returns>
        // GET: api/Empresas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empresa>>> GetEmpresas()
        {
          if (_context.Empresas == null)
          {
              return NotFound();
          }
            return await _context.Empresas.ToListAsync();
        }
        /// <summary>
        /// Obtiene los datos de la empresa que tenga el id que se le pase
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Empresas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Empresa>> GetEmpresa(int id)
        {
          if (_context.Empresas == null)
          {
              return NotFound();
          }
            var empresa = await _context.Empresas.FindAsync(id);

            if (empresa == null)
            {
                return NotFound();
            }

            return empresa;
        }
        /// <summary>
        /// Modifica los datos de la empresa cuyo id se le pasa como parámetro
        /// </summary>
        /// <param name="id"></param>
        /// <param name="empresa"></param>
        /// <response code="409">La solicitud no se puedo procesar por un conflicto</response>
        /// <response code="500">Hubo un error interni en el servidor mientras de procesaba la solicitud</response>
        /// <returns></returns>
        // PUT: api/Empresas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(Empresa), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> PutEmpresa(int id, Empresa empresa)
        {
            if (id != empresa.Id)
            {
                return BadRequest();
            }

            _context.Entry(empresa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpresaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        /// <summary>
        /// Añade una nueva empresa a la api
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///     POST /Empresas
        ///     {
        ///        "Nombre": "Mercadona",
        ///       "Direccion": "Avd Valencia",
        ///       "NumeroEmpleados": 10250
        ///     }
        /// </remarks>
        /// <param name="empresa"></param>
        /// <response code="201">Si crea bien el objeto</response>
        /// <response code="400">Si no encuentra la ruta</response>
        /// <response code="403">Si la llamada no está autenticada</response>
        /// <response code="500">Si se produce un error</response>
        /// <returns></returns>
        // POST: api/Empresas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(Empresa), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Empresa>> PostEmpresa(Empresa empresa)
        {
          if (_context.Empresas == null)
          {
              return Problem("Entity set 'EmpresaContext.Empresas'  is null.");
          }
            _context.Empresas.Add(empresa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmpresa", new { id = empresa.Id }, empresa);
        }
        /// <summary>
        /// Elimina una empresa de la api
        /// </summary>
        /// <param name="id"></param>
        /// <remarks>
        /// ¡¡Atención!! Esta operación es irreversible
        /// </remarks>
        /// <returns></returns>
        // DELETE: api/Empresas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpresa(int id)
        {
            if (_context.Empresas == null)
            {
                return NotFound();
            }
            var empresa = await _context.Empresas.FindAsync(id);
            if (empresa == null)
            {
                return NotFound();
            }

            _context.Empresas.Remove(empresa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmpresaExists(int id)
        {
            return (_context.Empresas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
