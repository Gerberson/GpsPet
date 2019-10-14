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
    public class DonoController : Controller
    {
        private readonly PetContext _context;

        public DonoController(PetContext context)
        {
            _context = context;
        }

        // GET: Dono
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dono.ToListAsync());
        }

        // GET: Dono/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dono = await _context.Dono
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dono == null)
            {
                return NotFound();
            }

            return View(dono);
        }

        // GET: Dono/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dono/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cpf,Sobrenome,AnimalId,Id,Nome,Endereco,DataNascimento,DataDeCadastro,Sexo")] Dono dono)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dono);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dono);
        }

        // GET: Dono/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dono = await _context.Dono.FindAsync(id);
            if (dono == null)
            {
                return NotFound();
            }
            return View(dono);
        }

        // POST: Dono/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Cpf,Sobrenome,AnimalId,Id,Nome,Endereco,DataNascimento,DataDeCadastro,Sexo")] Dono dono)
        {
            if (id != dono.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dono);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonoExists(dono.Id))
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
            return View(dono);
        }

        // GET: Dono/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dono = await _context.Dono
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dono == null)
            {
                return NotFound();
            }

            return View(dono);
        }

        // POST: Dono/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dono = await _context.Dono.FindAsync(id);
            _context.Dono.Remove(dono);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DonoExists(int id)
        {
            return _context.Dono.Any(e => e.Id == id);
        }
    }
}
