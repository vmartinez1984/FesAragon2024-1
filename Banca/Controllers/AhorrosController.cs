using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Banca.Entities;

namespace Banca.Controllers
{
    public class AhorrosController : Controller
    {
        private readonly BancaContext _context;

        public AhorrosController(BancaContext context)
        {
            _context = context;
        }

        // GET: Ahorros
        public async Task<IActionResult> Index()
        {
            var bancaContext = _context.Ahorros.Include(a => a.IdNavigation);
            return View(await bancaContext.ToListAsync());
        }

        // GET: Ahorros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ahorros == null)
            {
                return NotFound();
            }

            var ahorro = await _context.Ahorros
                .Include(a => a.IdNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ahorro == null)
            {
                return NotFound();
            }

            return View(ahorro);
        }

        // GET: Ahorros/Create
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_context.Clientes, "Id", "Id");
            return View();
        }

        // POST: Ahorros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Balance,ClienteId,Nota,FechaDeRegistro,EstaActivo")] Ahorro ahorro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ahorro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.Clientes, "Id", "Id", ahorro.Id);
            return View(ahorro);
        }

        // GET: Ahorros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ahorros == null)
            {
                return NotFound();
            }

            var ahorro = await _context.Ahorros.FindAsync(id);
            if (ahorro == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.Clientes, "Id", "Id", ahorro.Id);
            return View(ahorro);
        }

        // POST: Ahorros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Balance,ClienteId,Nota,FechaDeRegistro,EstaActivo")] Ahorro ahorro)
        {
            if (id != ahorro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ahorro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AhorroExists(ahorro.Id))
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
            ViewData["Id"] = new SelectList(_context.Clientes, "Id", "Id", ahorro.Id);
            return View(ahorro);
        }

        // GET: Ahorros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ahorros == null)
            {
                return NotFound();
            }

            var ahorro = await _context.Ahorros
                .Include(a => a.IdNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ahorro == null)
            {
                return NotFound();
            }

            return View(ahorro);
        }

        // POST: Ahorros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ahorros == null)
            {
                return Problem("Entity set 'BancaContext.Ahorros'  is null.");
            }
            var ahorro = await _context.Ahorros.FindAsync(id);
            if (ahorro != null)
            {
                _context.Ahorros.Remove(ahorro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AhorroExists(int id)
        {
          return (_context.Ahorros?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
