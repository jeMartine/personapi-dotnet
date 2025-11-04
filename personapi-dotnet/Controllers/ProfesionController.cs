using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Interfaces;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Controllers
{
    public class ProfesionController : Controller
    {
        private readonly IProfesionRepository _profesionRepo;

        public ProfesionController(IProfesionRepository profesionRepo)
        {
            _profesionRepo = profesionRepo;
        }

        // GET: Profesion
        public async Task<IActionResult> Index()
        {
            var profesions = await _profesionRepo.GetProfesionesAsync();
            ViewBag.TotalProfesions = profesions.Count();
            return View(profesions);
        }

        // GET: Profesion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesion = await _profesionRepo.GetProfesionByIdAsync(id.Value);

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
        public async Task<IActionResult> Create([Bind("Nom,Des")] Profesion profesion)
        {
            profesion.Id = _profesionRepo.GetProfesiones().Any() ? _profesionRepo.GetProfesiones().Max(p => p.Id) + 1 : 1;

            if (ModelState.IsValid)
            {
                await _profesionRepo.CreateProfesionAsync(profesion);
                return RedirectToAction(nameof(Index));
            }
            return View(profesion);
        }

        // GET: Profesion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesion = await _profesionRepo.GetProfesionByIdAsync(id.Value);

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
                    _profesionRepo.UpdateProfesion(profesion);
                    _profesionRepo.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_profesionRepo.ProfesionExists(profesion.Id))
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
            if (id == null)
            {
                return NotFound();
            }

            var profesion = await _profesionRepo.GetProfesionByIdAsync(id.Value);

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
            var profesion = await _profesionRepo.GetProfesionByIdAsync(id);

            if (profesion != null)
            {
                _profesionRepo.DeleteProfesion(profesion);
            }
            
            _profesionRepo.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
