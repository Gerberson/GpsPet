using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pet.Models;

namespace Pet.Controllers
{
    public class RastreadorController : Controller
    {
        private readonly PetContext _context;

        public RastreadorController(PetContext context)
        {
            _context = context;
        }

        // GET: Rastreador
        public async Task<IActionResult> Index()
        {
            return View(await _context.Rastreador.ToListAsync());
        }

        // GET: Rastreador/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rastreador = await _context.Rastreador
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rastreador == null)
            {
                return NotFound();
            }

            return View(rastreador);
        }

        // GET: Rastreador/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rastreador/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NumeroDeSerie,LocalizacaoId")] Rastreador rastreador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rastreador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rastreador);
        }

        // GET: Rastreador/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rastreador = await _context.Rastreador.FindAsync(id);
            if (rastreador == null)
            {
                return NotFound();
            }
            return View(rastreador);
        }

        // POST: Rastreador/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NumeroDeSerie,LocalizacaoId")] Rastreador rastreador)
        {
            if (id != rastreador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rastreador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RastreadorExists(rastreador.Id))
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
            return View(rastreador);
        }

        // GET: Rastreador/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rastreador = await _context.Rastreador
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rastreador == null)
            {
                return NotFound();
            }

            return View(rastreador);
        }

        // POST: Rastreador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rastreador = await _context.Rastreador.FindAsync(id);
            _context.Rastreador.Remove(rastreador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RastreadorExists(int id)
        {
            return _context.Rastreador.Any(e => e.Id == id);
        }
    }
}
