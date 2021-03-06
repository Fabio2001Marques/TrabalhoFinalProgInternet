using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrabalhoFinalProgInternet.Data;
using TrabalhoFinalProgInternet.Models;
using TrabalhoFinalProgInternet.ViewModels;

namespace TrabalhoFinalProgInternet.Controllers
{
    public class ColaboradoresController : Controller
    {
        private readonly GestorProjetosContext _context;

        public ColaboradoresController(GestorProjetosContext context)
        {
            _context = context;
        }

        // GET: Colaboradores
        public async Task<IActionResult> Index(string nome, int page = 1)
        {
            var procuraColaborador = _context.Colaborador
                .Where(b => nome == null || b.Nome.Contains(nome));

            var pagingInfo = new PagingInfo
            {
                CurrentPage = page,
                TotalItems = procuraColaborador.Count()
            };

            if (pagingInfo.CurrentPage > pagingInfo.TotalPages)
            {
                pagingInfo.CurrentPage = pagingInfo.TotalPages;
            }

            if (pagingInfo.CurrentPage < 1)
            {
                pagingInfo.CurrentPage = 1;
            }

            var colaboradores = await procuraColaborador
                            .Include(b => b.Cargo)
                            .OrderBy(b => b.Nome)
                            .Skip((pagingInfo.CurrentPage - 1) * pagingInfo.PageSize)
                            .Take(pagingInfo.PageSize)
                            .ToListAsync();

            return View(
                new ColaboradorListViewModel
                {
                    Colaboradores = colaboradores,
                    PagingInfo = pagingInfo,
                    ProcuraNome = nome
                }
            );
        }

        // GET: Colaboradores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colaborador = await _context.Colaborador
                .Include(c => c.Cargo)
                .FirstOrDefaultAsync(m => m.ColaboradorId == id);
            if (colaborador == null)
            {
                return NotFound();
            }

            return View(colaborador);
        }

        // GET: Colaboradores/Create
        public IActionResult Create()
        {
            ViewData["CargoId"] = new SelectList(_context.Cargo, "CargoId", "Nome");
            return View();
        }

        // POST: Colaboradores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ColaboradorViewModel colaboradorViewModel)
        {
            Colaborador colaborador = new Colaborador();
            
            if (ModelState.IsValid)
            {          
                colaborador.Nome = colaboradorViewModel.Nome;
                colaborador.NumeroCC = colaboradorViewModel.NumeroCC;
                colaborador.Contacto = colaboradorViewModel.Contacto;
                colaborador.Email = colaboradorViewModel.Email;
                colaborador.CargoId = colaboradorViewModel.CargoId;

                if(colaboradorViewModel.NovoCargo != null)
                {
                    Cargo cargo = new Cargo();
                    cargo.Nome = colaboradorViewModel.NovoCargo;
                    _context.Add(cargo);
                    await _context.SaveChangesAsync();
                    colaborador.CargoId = cargo.CargoId;
                }              

                _context.Add(colaborador);
                await _context.SaveChangesAsync();
                ViewBag.Controller = "Colaboradores";
                ViewBag.Title = "Adicionado Colaborador";
                ViewBag.Message = "Colaborador Adicionado com Sucesso";
                return View("Sucesso");
            }
            ViewData["CargoId"] = new SelectList(_context.Cargo, "CargoId", "Nome", colaborador.CargoId);
            return View(colaborador);
        }

        // GET: Colaboradores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colaborador = await _context.Colaborador.FindAsync(id);
            if (colaborador == null)
            {
                return NotFound();
            }
            ViewData["CargoId"] = new SelectList(_context.Cargo, "CargoId", "Nome", colaborador.CargoId);
            ColaboradorViewModel colaboradorViewModel = new ColaboradorViewModel();
            colaboradorViewModel.ColaboradorId = colaborador.ColaboradorId;
            colaboradorViewModel.Nome = colaborador.Nome;
            colaboradorViewModel.NumeroCC = colaborador.NumeroCC;
            colaboradorViewModel.Contacto = colaborador.Contacto;
            colaboradorViewModel.Email = colaborador.Email;
            colaboradorViewModel.CargoId = colaborador.CargoId;
            return View(colaboradorViewModel);
        }

        // POST: Colaboradores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ColaboradorViewModel colaboradorViewModel)
        {
            if (id != colaboradorViewModel.ColaboradorId)
            {
                return NotFound();
            }
            Colaborador colaborador = new Colaborador();
            if (ModelState.IsValid)
            {
                colaborador.ColaboradorId = colaboradorViewModel.ColaboradorId;
                colaborador.Nome = colaboradorViewModel.Nome;
                colaborador.NumeroCC = colaboradorViewModel.NumeroCC;
                colaborador.Contacto = colaboradorViewModel.Contacto;
                colaborador.Email = colaboradorViewModel.Email;
                colaborador.CargoId = colaboradorViewModel.CargoId;

                if (colaboradorViewModel.NovoCargo != null)
                {
                    Cargo cargo = new Cargo();
                    cargo.Nome = colaboradorViewModel.NovoCargo;
                    _context.Add(cargo);
                    await _context.SaveChangesAsync();

                    colaborador.CargoId = cargo.CargoId;
                }
                try
                {
                    _context.Update(colaborador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ColaboradorExists(colaborador.ColaboradorId))
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
            ViewData["CargoId"] = new SelectList(_context.Cargo, "CargoId", "Nome", colaborador.CargoId);
            return View(colaborador);
        }

        // GET: Colaboradores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colaborador = await _context.Colaborador
                .Include(c => c.Cargo)
                .FirstOrDefaultAsync(m => m.ColaboradorId == id);
            if (colaborador == null)
            {
                return NotFound();
            }

            return View(colaborador);
        }

        // POST: Colaboradores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projetos = _context.ColaboradorProjeto.Where(c => c.ColaboradorId == id).FirstOrDefault();
            if (projetos != null) {
                ViewBag.Controller = "Colaboradores";
                ViewBag.Title = "Erro ao eliminar Colaborador";
                ViewBag.Message = "Não pode eliminar um Colaborador que esteja atribuído a um projeto";
                return View("Erro");
            }
            var colaborador = await _context.Colaborador.FindAsync(id);
            _context.Colaborador.Remove(colaborador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ColaboradorExists(int id)
        {
            return _context.Colaborador.Any(e => e.ColaboradorId == id);
        }
    }
}
