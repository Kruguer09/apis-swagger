using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiRestConSwagger.Models;
using System.Net;

namespace ApiRestConSwagger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private readonly HeroContext _context;

        public HeroesController(HeroContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Obtiene todos los heroes registrados en la aplicación
        /// </summary>
        /// <returns></returns>
        // GET: api/Heroes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hero>>> GetHeroes()
        {
            return await _context.Heroes.ToListAsync();
        }
        /// <summary>
        /// Obtiene los datos del heroe que tenga el id que se le pase
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Heroes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hero>> GetHero(long id)
        {
            var hero = await _context.Heroes.FindAsync(id);

            if (hero == null)
            {
                return NotFound();
            }

            return hero;
        }
        /// <summary>
        /// Modifica los datos del héroe cuyo id se le pasa como parámetro
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hero"></param>
        /// <returns></returns>
        // PUT: api/Heroes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHero(long id, Hero hero)
        {
            if (id != hero.Id)
            {
                return BadRequest();
            }

            _context.Entry(hero).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HeroExists(id))
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
        /// Agrega un nuevo heroe a la aplicación
        /// </summary>

        /// <remarks>
        /// Sample request:
        ///     POST /heroes
        ///     {
        ///        "Name": "Batman",
        ///       "IsBad": false,
        ///       "HomeId": 1
        ///     }
        /// </remarks>
        /// <param name="hero"></param>
        ///<response code="201">Si crea bien el objeto</response>
        /// <response code="400">Si no encuentra la ruta</response>
        /// <response code="403">Si la llamada no está autenticada</response>
        /// <response code="500">Si se produce un error</response>
        /// <returns></returns>
        //También podríamos haberle pasado un XML DE EJEMPLO arriba
        // POST: api/Heroes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(Hero), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Hero>> PostHero(Hero hero)
        {
            _context.Heroes.Add(hero);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHero", new { id = hero.Id }, hero);
        }
        /// <summary>
        /// Borra el heróe cuyo id le pasamos como parámetro
        /// </summary>
        /// <param name="id"></param>
        /// <remarks>
        /// Texto JSON o XML informativo
        /// </remarks>
        /// <returns></returns>
        // DELETE: api/Heroes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHero(long id)
        {
            var hero = await _context.Heroes.FindAsync(id);
            if (hero == null)
            {
                return NotFound();
            }

            _context.Heroes.Remove(hero);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HeroExists(long id)
        {
            return _context.Heroes.Any(e => e.Id == id);
        }
    }
}
