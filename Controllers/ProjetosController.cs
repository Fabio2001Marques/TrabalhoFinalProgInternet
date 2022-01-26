using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrabalhoFinalProgInternet.Data;
using TrabalhoFinalProgInternet.Models;
using TrabalhoFinalProgInternet.ViewModels;

namespace TrabalhoFinalProgInternet
{
    public class ProjetosController : Controller
    {
        private readonly GestorProjetosContext _context;

        public ProjetosController(GestorProjetosContext context)
        {
            _context = context;
        }

        // GET: Projetos
        public async Task<IActionResult> Index(string nome, int page = 1)
        {
            var procuraProjeto = _context.Projeto
                .Where(b => nome == null || b.Nome.Contains(nome));

            var pagingInfo = new PagingInfo
            {
                CurrentPage = page,
                TotalItems = procuraProjeto.Count()
            };

            if (pagingInfo.CurrentPage > pagingInfo.TotalPages)
            {
                pagingInfo.CurrentPage = pagingInfo.TotalPages;
            }

            if (pagingInfo.CurrentPage < 1)
            {
                pagingInfo.CurrentPage = 1;
            }

            var projetos = await procuraProjeto
                            .Include(b => b.colaborador)
                            .OrderBy(b => b.Nome)
                            .Skip((pagingInfo.CurrentPage - 1) * pagingInfo.PageSize)
                            .Take(pagingInfo.PageSize)
                            .ToListAsync();

            return View(
                new ProjetoListViewModel
                {
                    Projetos = projetos,
                    PagingInfo = pagingInfo,
                    ProcuraNome = nome
                }
            );
        }

        // GET: Projetos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projeto = await _context.Projeto.Include(t => t.colaborador)
                .FirstOrDefaultAsync(m => m.ProjetoId == id);
            if (projeto == null)
            {
                return NotFound();
            }

            return View(projeto);
        }

        // GET: Projetos/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
             var Colaboradores = new SelectList(_context.Colaborador.Where<Colaborador>(s =>s.Cargo.Nome =="Gestor"), "ColaboradorId", "Nome", "Cargo") ;


            ViewData["ColaboradorId"] = Colaboradores;


            return View();
        }

        // POST: Projetos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjetoId,Nome,DataInicialPrevista,DataFinalPrevista,ColaboradorId")] Projeto projeto)
        {


            if (ModelState.IsValid)
            {
                projeto.DataFinal = null;
                projeto.DataInicio = null;
                if (projeto.DataFinalPrevista >= projeto.DataInicialPrevista)
                {

                    _context.Add(projeto);
                    await _context.SaveChangesAsync();
                    ViewBag.Controller = "Projetos";
                    ViewBag.Title = "Adicionado Projeto";
                    ViewBag.Message = "Projeto Adicioado com Sucesso";
                    return View("Sucesso");
                }
                else
                {
                    ModelState.AddModelError("DataFinalPrevista", "A Data Prevista de Fim tem de ser maior ou igual á Data Prevista de Início");
                    var Colaboradores = new SelectList(_context.Colaborador.Where<Colaborador>(s => s.Cargo.Nome == "Gestor"), "ColaboradorId", "Nome", "Cargo");
                    ViewData["ColaboradorId"] = Colaboradores;
                    return View(projeto);
                }
            }
            return View(projeto);
        }

        // GET: Projetos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

          
            if (id == null)
            {
                return NotFound();
            }

            var projeto = await _context.Projeto.FindAsync(id);
            if (projeto == null)
            {
                return NotFound();
            }
            var Colaboradores = new SelectList(_context.Colaborador.Where<Colaborador>(s => s.Cargo.Nome == "Gestor"), "ColaboradorId", "Nome", "Cargo");


            ViewData["ColaboradorId"] = Colaboradores;

            return View(projeto);
        }

        // POST: Projetos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProjetoId,Nome,DataInicio,DataFinal,DataInicialPrevista,DataFinalPrevista,ColaboradorId")] Projeto projeto)
        {
            if (id != projeto.ProjetoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (projeto.DataFinalPrevista >= projeto.DataInicialPrevista)
                {
                    try
                    {
                        _context.Update(projeto);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ProjetoExists(projeto.ProjetoId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("DataFinalPrevista", "A Data Prevista de Fim tem de ser maior ou igual á Data Prevista de Início");
                    
                    return View(projeto);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(projeto);
        }

        // GET: Projetos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projeto = await _context.Projeto
                .FirstOrDefaultAsync(m => m.ProjetoId == id);
            if (projeto == null)
            {
                return NotFound();
            }

            return View(projeto);
        }

        // POST: Projetos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var colaboradores = _context.ColaboradorProjeto.Where(c => c.ProjetoId == id).FirstOrDefault();           
            if (colaboradores != null)
            {
                ViewBag.Controller = "Projetos";
                ViewBag.Title = "Erro ao eliminar Projeto";
                ViewBag.Message = "Não pode eliminar um Projeto que já tenha tido atividade ";
                return View("Erro");
            }
            var projeto = await _context.Projeto.FindAsync(id);
            _context.Projeto.Remove(projeto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Iniciar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projeto = await _context.Projeto
                .FirstOrDefaultAsync(m => m.ProjetoId == id);
            if (projeto == null)
            {
                return NotFound();
            }
            projeto.DataInicio = DateTime.Now;
            try
            {
                _context.Update(projeto);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjetoExists(projeto.ProjetoId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Finalizar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projeto = await _context.Projeto
                .FirstOrDefaultAsync(m => m.ProjetoId == id);
            if (projeto == null)
            {
                return NotFound();
            }
            projeto.DataFinal = DateTime.Now;
            try
            {
                _context.Update(projeto);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjetoExists(projeto.ProjetoId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction("Index");
        }






        private bool ProjetoExists(int id)
        {
            return _context.Projeto.Any(e => e.ProjetoId == id);
        }
    }
}
