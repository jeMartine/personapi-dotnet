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
    public class EstudioApiController : ControllerBase
    {
        private readonly persona_dbContext _context;

        public EstudioApiController(persona_dbContext context)
        {
            _context = context;
        }

        // GET: api/EstudioApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estudio>>> GetEstudios()
        {
          if (_context.Estudios == null)
          {
              return NotFound();
          }
            return await _context.Estudios.ToListAsync();
        }

        // GET: api/EstudioApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Estudio>> GetEstudio(int id)
        {
          if (_context.Estudios == null)
          {
              return NotFound();
          }
            var estudio = await _context.Estudios.FindAsync(id);

            if (estudio == null)
            {
                return NotFound();
            }

            return estudio;
        }

        // GET: api/EstudioApi/count
        [HttpGet("count")]
        public async Task<ActionResult<int>> GetTotalCount()
        {
            var total = await _context.Estudios.CountAsync();
            return Ok(total);
        }

        // PUT: api/EstudioApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstudio(int id, Estudio estudio)
        {
            if (id != estudio.IdProf)
            {
                return BadRequest();
            }

            _context.Entry(estudio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstudioExists(id))
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

        // POST: api/EstudioApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Estudio>> PostEstudio(Estudio estudio)
        {
          if (_context.Estudios == null)
          {
              return Problem("Entity set 'persona_dbContext.Estudios'  is null.");
          }
            _context.Estudios.Add(estudio);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EstudioExists(estudio.IdProf))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEstudio", new { id = estudio.IdProf }, estudio);
        }

        // DELETE: api/EstudioApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstudio(int id)
        {
            if (_context.Estudios == null)
            {
                return NotFound();
            }
            var estudio = await _context.Estudios.FindAsync(id);
            if (estudio == null)
            {
                return NotFound();
            }

            _context.Estudios.Remove(estudio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstudioExists(int id)
        {
            return (_context.Estudios?.Any(e => e.IdProf == id)).GetValueOrDefault();
        }
    }
}
