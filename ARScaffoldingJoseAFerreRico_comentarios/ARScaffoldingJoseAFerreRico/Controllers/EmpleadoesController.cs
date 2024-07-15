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
    public class EmpleadoesController : ControllerBase
    {
        private readonly EmpresaContext _context;

        public EmpleadoesController(EmpresaContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Obtiene los empleados con sus datos y la empresa a la que pertenece.
        /// </summary>
        /// <returns></returns>
        // GET: api/Empleadoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empleado>>> GetEmpleados()
        {
          if (_context.Empleados == null)
          {
              return NotFound();
          }
            return await _context.Empleados.ToListAsync();
        }
        /// <summary>
        /// Obtiene los datos del empleado/a que tenga el id que se le pase
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Empleadoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Empleado>> GetEmpleado(string id)
        {
          if (_context.Empleados == null)
          {
              return NotFound();
          }
            var empleado = await _context.Empleados.FindAsync(id);

            if (empleado == null)
            {
                return NotFound();
            }

            return empleado;
        }
        /// <summary>
        /// Modifica los datos del empleado/a cuyo id se le pasa como parámetro
        /// </summary>
        /// <param name="id"></param>
        /// <param name="empleado"></param>
        /// <response code="409">La solicitud no se puedo procesar por un conflicto</response>
        /// <response code="500">Hubo un error interni en el servidor mientras de procesaba la solicitud</response>
        /// <returns></returns>
        // PUT: api/Empleadoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(Empresa), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> PutEmpleado(string id, Empleado empleado)
        {
            if (id != empleado.Dni)
            {
                return BadRequest();
            }

            _context.Entry(empleado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadoExists(id))
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
        ///     POST /Empleados
        ///     {
        ///         "dni": "12345678A",
        ///        "nombre": "María García Díaz",
        ///       "direccion": "Avd Valencia 32 n 3",
        ///       "sexo": "Mujer",
        ///       "empresaId: 2
        ///     }
        /// </remarks>
        /// <param name="empresa"></param>
        /// <response code="201">Si crea bien el objeto</response>
        /// <response code="400">Si no encuentra la ruta</response>
        /// <response code="403">Si la llamada no está autenticada</response>
        /// <response code="500">Si se produce un error</response>
        /// <returns></returns>
        // POST: api/Empleadoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Empleado>> PostEmpleado(Empleado empleado)
        {
          if (_context.Empleados == null)
          {
              return Problem("Entity set 'EmpresaContext.Empleados'  is null.");
          }
            _context.Empleados.Add(empleado);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmpleadoExists(empleado.Dni))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEmpleado", new { id = empleado.Dni }, empleado);
        }
        /// <summary>
        /// Elimina un/a empleado/a de la api
        /// </summary>
        /// <param name="id"></param>
        /// <remarks>
        /// ¡¡Atención!! Esta operación es irreversible
        /// </remarks>
        /// <returns></returns>
        // DELETE: api/Empleadoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpleado(string id)
        {
            if (_context.Empleados == null)
            {
                return NotFound();
            }
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }

            _context.Empleados.Remove(empleado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmpleadoExists(string id)
        {
            return (_context.Empleados?.Any(e => e.Dni == id)).GetValueOrDefault();
        }
    }
}
