using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Controllers.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesionApiController : ControllerBase
    {
        private readonly persona_dbContext _context;

        public ProfesionApiController(persona_dbContext context)
        {
            _context = context;
        }

        // GET: api/ProfesionApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Profesion>>> GetProfesions()
        {
          if (_context.Profesions == null)
          {
              return NotFound();
          }
            return await _context.Profesions.ToListAsync();
        }

        // GET: api/ProfesionApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Profesion>> GetProfesion(int id)
        {
          if (_context.Profesions == null)
          {
              return NotFound();
          }
            var profesion = await _context.Profesions.FindAsync(id);

            if (profesion == null)
            {
                return NotFound();
            }

            return profesion;
        }

        // GET: api/ProfesionApi/count
        [HttpGet("count")]
        public async Task<ActionResult<int>> GetTotalCount()
        {
            var total = await _context.Profesions.CountAsync();
            return Ok(total);
        }

        // PUT: api/ProfesionApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfesion(int id, Profesion profesion)
        {
            if (id != profesion.Id)
            {
                return BadRequest();
            }

            _context.Entry(profesion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfesionExists(id))
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

        // POST: api/ProfesionApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Profesion>> PostProfesion(Profesion profesion)
        {
          if (_context.Profesions == null)
          {
              return Problem("Entity set 'persona_dbContext.Profesions'  is null.");
          }
            _context.Profesions.Add(profesion);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProfesionExists(profesion.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProfesion", new { id = profesion.Id }, profesion);
        }

        // DELETE: api/ProfesionApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfesion(int id)
        {
            if (_context.Profesions == null)
            {
                return NotFound();
            }
            var profesion = await _context.Profesions.FindAsync(id);
            if (profesion == null)
            {
                return NotFound();
            }

            _context.Profesions.Remove(profesion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProfesionExists(int id)
        {
            return (_context.Profesions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
