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
    public class TelefonoController : Controller
    {
        private readonly ITelefonoRepository _telefonoRepo;
        private readonly IPersonaRepository _personaRepo;

        public TelefonoController
            (
            ITelefonoRepository telefonoRepo,
            IPersonaRepository personaRepo
            )
        {
            _telefonoRepo = telefonoRepo;
            _personaRepo = personaRepo;
        }

        // GET: Telefono
        public async Task<IActionResult> Index()
        {
            var telefonos = await _telefonoRepo.GetTelefonosAsync();
            ViewBag.TotalTelefonos = telefonos.Count();
            return View(telefonos);
        }

        // GET: Telefono/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefono = await _telefonoRepo.GetTelefonoByIdAsync(id);
            if (telefono == null)
            {
                return NotFound();
            }

            return View(telefono);
        }

        // GET: Telefono/Create
        public IActionResult Create()
        {
            ViewData["Duenio"] = new SelectList(_personaRepo.GetPersonas(), "Cc", "Cc");
            return View();
        }

        // POST: Telefono/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Num,Oper,Duenio")] Telefono telefono)
        {
            if (ModelState.IsValid)
            {
                await _telefonoRepo.CreateTelefonoAsync(telefono);
                return RedirectToAction(nameof(Index));
            }
            ViewData["Duenio"] = new SelectList(await _personaRepo.GetPersonasAsync(), "Cc", "Cc", telefono.Duenio);
            return View(telefono);
        }

        // GET: Telefono/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefono = await _telefonoRepo.GetTelefonoByIdAsync(id);

            if (telefono == null)
            {
                return NotFound();
            }
            ViewData["Duenio"] = new SelectList(await _personaRepo.GetPersonasAsync(), "Cc", "Cc", telefono.Duenio);
            return View(telefono);
        }

        // POST: Telefono/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Num,Oper,Duenio")] Telefono telefono)
        {
            if (id != telefono.Num)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _telefonoRepo.UpdateTelefono(telefono);
                    _telefonoRepo.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_telefonoRepo.TelefonoExists(telefono.Num))
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
            ViewData["Duenio"] = new SelectList(await _personaRepo.GetPersonasAsync(), "Cc", "Cc", telefono.Duenio);
            return View(telefono);
        }

        // GET: Telefono/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefono = await _telefonoRepo.GetTelefonoByIdAsync(id);

            if (telefono == null)
            {
                return NotFound();
            }

            return View(telefono);
        }

        // POST: Telefono/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var telefono = await _telefonoRepo.GetTelefonoByIdAsync(id);

            if (telefono != null)
            {
                _telefonoRepo.DeleteTelefono(telefono);
            }

            _telefonoRepo.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
