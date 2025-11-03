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
    public class EstudioController : Controller
    {
        private readonly persona_dbContext _context;

        public EstudioController(persona_dbContext context)
        {
            _context = context;
        }

        // GET: Estudio
        public async Task<IActionResult> Index()
        {
            var persona_dbContext = _context.Estudios.Include(e => e.CcPerNavigation).Include(e => e.IdProfNavigation);
            return View(await persona_dbContext.ToListAsync());
        }

        // GET: Estudio/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Estudios == null)
            {
                return NotFound();
            }

            var estudio = await _context.Estudios
                .Include(e => e.CcPerNavigation)
                .Include(e => e.IdProfNavigation)
                .FirstOrDefaultAsync(m => m.IdProf == id);
            if (estudio == null)
            {
                return NotFound();
            }

            return View(estudio);
        }

        // GET: Estudio/Create
        public IActionResult Create()
        {
            ViewData["CcPer"] = new SelectList(_context.Personas, "Cc", "Cc");
            ViewData["IdProf"] = new SelectList(_context.Profesions, "Id", "Id");
            return View();
        }

        // POST: Estudio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProf,CcPer,Fecha,Univer")] Estudio estudio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estudio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CcPer"] = new SelectList(_context.Personas, "Cc", "Cc", estudio.CcPer);
            ViewData["IdProf"] = new SelectList(_context.Profesions, "Id", "Id", estudio.IdProf);
            return View(estudio);
        }

        // GET: Estudio/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Estudios == null)
            {
                return NotFound();
            }

            var estudio = await _context.Estudios.FindAsync(id);
            if (estudio == null)
            {
                return NotFound();
            }
            ViewData["CcPer"] = new SelectList(_context.Personas, "Cc", "Cc", estudio.CcPer);
            ViewData["IdProf"] = new SelectList(_context.Profesions, "Id", "Id", estudio.IdProf);
            return View(estudio);
        }

        // POST: Estudio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProf,CcPer,Fecha,Univer")] Estudio estudio)
        {
            if (id != estudio.IdProf)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estudio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstudioExists(estudio.IdProf))
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
            ViewData["CcPer"] = new SelectList(_context.Personas, "Cc", "Cc", estudio.CcPer);
            ViewData["IdProf"] = new SelectList(_context.Profesions, "Id", "Id", estudio.IdProf);
            return View(estudio);
        }

        // GET: Estudio/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Estudios == null)
            {
                return NotFound();
            }

            var estudio = await _context.Estudios
                .Include(e => e.CcPerNavigation)
                .Include(e => e.IdProfNavigation)
                .FirstOrDefaultAsync(m => m.IdProf == id);
            if (estudio == null)
            {
                return NotFound();
            }

            return View(estudio);
        }

        // POST: Estudio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Estudios == null)
            {
                return Problem("Entity set 'persona_dbContext.Estudios'  is null.");
            }
            var estudio = await _context.Estudios.FindAsync(id);
            if (estudio != null)
            {
                _context.Estudios.Remove(estudio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstudioExists(int id)
        {
          return (_context.Estudios?.Any(e => e.IdProf == id)).GetValueOrDefault();
        }
    }
}
