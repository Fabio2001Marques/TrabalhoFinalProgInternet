using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrabalhoFinalProgInternet.Data;
using TrabalhoFinalProgInternet.Models;

namespace TrabalhoFinalProgInternet.Controllers
{
    public class ColaboradorContasController : Controller
    {
        private readonly GestorProjetosContext _context;

        public ColaboradorContasController(GestorProjetosContext context)
        {
            _context = context;
        }

        // GET: ColaboradorContas
        public async Task<IActionResult> Index()
        {
            return View(await _context.ColaboradorConta.ToListAsync());
        }

        // GET: ColaboradorContas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colaboradorConta = await _context.ColaboradorConta
                .FirstOrDefaultAsync(m => m.ColaboradorContaId == id);
            if (colaboradorConta == null)
            {
                return NotFound();
            }

            return View(colaboradorConta);
        }

        // GET: ColaboradorContas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ColaboradorContas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ColaboradorContaId,Name,Email,Phone")] ColaboradorConta colaboradorConta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(colaboradorConta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(colaboradorConta);
        }

        // GET: ColaboradorContas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colaboradorConta = await _context.ColaboradorConta.FindAsync(id);
            if (colaboradorConta == null)
            {
                return NotFound();
            }
            return View(colaboradorConta);
        }

        // POST: ColaboradorContas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ColaboradorContaId,Name,Email,Phone")] ColaboradorConta colaboradorConta)
        {
            if (id != colaboradorConta.ColaboradorContaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(colaboradorConta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ColaboradorContaExists(colaboradorConta.ColaboradorContaId))
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
            return View(colaboradorConta);
        }

        // GET: ColaboradorContas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colaboradorConta = await _context.ColaboradorConta
                .FirstOrDefaultAsync(m => m.ColaboradorContaId == id);
            if (colaboradorConta == null)
            {
                return NotFound();
            }

            return View(colaboradorConta);
        }

        // POST: ColaboradorContas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var colaboradorConta = await _context.ColaboradorConta.FindAsync(id);
            _context.ColaboradorConta.Remove(colaboradorConta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ColaboradorContaExists(int id)
        {
            return _context.ColaboradorConta.Any(e => e.ColaboradorContaId == id);
        }
    }
}
