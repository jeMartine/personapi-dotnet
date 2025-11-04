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
    public class EstudioController : Controller
    {
        private readonly IEstudioRepository _estudioRepo;
        private readonly IPersonaRepository _personaRepo;
        private readonly IProfesionRepository _profesionRepo;

        public EstudioController
            (
            IEstudioRepository estudioRepo,
            IPersonaRepository personaRepo,
            IProfesionRepository profesionRepo
            )
        {
            _estudioRepo = estudioRepo;
            _personaRepo = personaRepo;
            _profesionRepo = profesionRepo;
        }

        // GET: Estudio
        public async Task<IActionResult> Index()
        {
            var estudios = await _estudioRepo.GetEstudiosAsync();
            ViewBag.TotalEstudios = estudios.Count();
            return View(estudios);
        }

        // GET: Estudio/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudio = await _estudioRepo.GetEstudioByIdAsync(id.Value);

            if (estudio == null)
            {
                return NotFound();
            }

            return View(estudio);
        }

        // GET: Estudio/Create
        public IActionResult Create()
        {
            ViewData["CcPer"] = new SelectList(_personaRepo.GetPersonas(), "Cc", "Cc");
            ViewData["IdProf"] = new SelectList(_profesionRepo.GetProfesiones(), "Id", "Id");
            return View();
        }

        // POST: Estudio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProf,CcPer,Fecha,Univer")] Estudio estudio)
        {
            if (await _estudioRepo.ExistsAsync(estudio.CcPer, estudio.IdProf))
            {
                ModelState.AddModelError(string.Empty, $"Person identified with CC: {estudio.CcPer} is already related with profession: {estudio.IdProf}");

            }

            if (ModelState.IsValid)
            {
                await _estudioRepo.CreateEstudioAsync(estudio);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CcPer"] = new SelectList(await _personaRepo.GetPersonasAsync(), "Cc", "Cc", estudio.CcPer);
            ViewData["IdProf"] = new SelectList(await _profesionRepo.GetProfesionesAsync(), "Id", "Id", estudio.IdProf);
            return View(estudio);
        }

        // GET: Estudio/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudio = await _estudioRepo.GetEstudioByIdAsync(id.Value);
            if (estudio == null)
            {
                return NotFound();
            }
            ViewData["CcPer"] = new SelectList(await _personaRepo.GetPersonasAsync(), "Cc", "Cc", estudio.CcPer);
            ViewData["IdProf"] = new SelectList(await _profesionRepo.GetProfesionesAsync(), "Id", "Id", estudio.IdProf);
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
                    _estudioRepo.UpdateEstudio(estudio);
                    _estudioRepo.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_estudioRepo.EstudioExists(estudio.IdProf))
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
            ViewData["CcPer"] = new SelectList(await _personaRepo.GetPersonasAsync(), "Cc", "Cc", estudio.CcPer);
            ViewData["IdProf"] = new SelectList(await _profesionRepo.GetProfesionesAsync(), "Id", "Id", estudio.IdProf);
            return View(estudio);
        }

        // GET: Estudio/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudio = await _estudioRepo.GetEstudioByIdAsync(id.Value);
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
            var estudio = await _estudioRepo.GetEstudioByIdAsync(id);
            if (estudio != null)
            {
                _estudioRepo.DeleteEstudio(estudio);
            }

            _estudioRepo.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
