using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Controllers
{
    public class ProfesionController : Controller
    {
        private readonly persona_dbContext _context;

        public ProfesionController(persona_dbContext context)
        {
            _context = context;
        }

        // GET: Profesion
        public async Task<IActionResult> Index()
        {
              return _context.Profesions != null ? 
                          View(await _context.Profesions.ToListAsync()) :
                          Problem("Entity set 'persona_dbContext.Profesions'  is null.");
        }

        // GET: Profesion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Profesions == null)
            {
                return NotFound();
            }

            var profesion = await _context.Profesions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profesion == null)
            {
                return NotFound();
            }

            return View(profesion);
        }

        // GET: Profesion/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Profesion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Des")] Profesion profesion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(profesion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(profesion);
        }

        // GET: Profesion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Profesions == null)
            {
                return NotFound();
            }

            var profesion = await _context.Profesions.FindAsync(id);
            if (profesion == null)
            {
                return NotFound();
            }
            return View(profesion);
        }

        // POST: Profesion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Des")] Profesion profesion)
        {
            if (id != profesion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profesion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfesionExists(profesion.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(profesion);
        }

        // GET: Profesion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Profesions == null)
            {
                return NotFound();
            }

            var profesion = await _context.Profesions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profesion == null)
            {
                return NotFound();
            }

            return View(profesion);
        }

        // POST: Profesion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Profesions == null)
            {
                return Problem("Entity set 'persona_dbContext.Profesions'  is null.");
            }
            var profesion = await _context.Profesions.FindAsync(id);
            if (profesion != null)
            {
                _context.Profesions.Remove(profesion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfesionExists(int id)
        {
          return (_context.Profesions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
