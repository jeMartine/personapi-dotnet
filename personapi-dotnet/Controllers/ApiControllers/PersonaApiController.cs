using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Data;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Controllers.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaApiController : ControllerBase
    {
        private readonly persona_dbContext _context;

        public PersonaApiController(persona_dbContext context)
        {
            _context = context;
        }

        // GET: api/PersonaApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Persona>>> GetPersonas()
        {
          if (_context.Personas == null)
          {
              return NotFound();
          }
            return await _context.Personas.ToListAsync();
        }

        // GET: api/PersonaApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Persona>> GetPersona(int id)
        {
          if (_context.Personas == null)
          {
              return NotFound();
          }
            var persona = await _context.Personas.FindAsync(id);

            if (persona == null)
            {
                return NotFound();
            }

            return persona;
        }

        // GET: api/PersonaApi/count
        [HttpGet("count")]
        public async Task<ActionResult<int>> GetTotalCount()
        {
            var total = await _context.Personas.CountAsync();
            return Ok(total);
        }

        // PUT: api/PersonaApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersona(int id, Persona persona)
        {
            if (id != persona.Cc)
            {
                return BadRequest();
            }

            _context.Entry(persona).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonaExists(id))
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

        // POST: api/PersonaApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Persona>> PostPersona(Persona persona)
        {
          if (_context.Personas == null)
          {
              return Problem("Entity set 'persona_dbContext.Personas'  is null.");
          }
            _context.Personas.Add(persona);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PersonaExists(persona.Cc))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPersona", new { id = persona.Cc }, persona);
        }

        // DELETE: api/PersonaApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersona(int id)
        {
            if (_context.Personas == null)
            {
                return NotFound();
            }
            var persona = await _context.Personas.FindAsync(id);
            if (persona == null)
            {
                return NotFound();
            }

            _context.Personas.Remove(persona);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonaExists(int id)
        {
            return (_context.Personas?.Any(e => e.Cc == id)).GetValueOrDefault();
        }
    }
}
