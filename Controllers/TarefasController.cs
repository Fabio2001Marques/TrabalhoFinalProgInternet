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
    public class TarefasController : Controller
    {
        private readonly GestorProjetosContext _context;

        public TarefasController(GestorProjetosContext context)
        {
            _context = context;
        }

        // GET: Tarefas
        public async Task<IActionResult> Index(int? id ,string nome="", int page = 1)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projeto = _context.Projeto.Where(c => c.ProjetoId == id).FirstOrDefault();
            ViewBag.ProjetoNome = projeto.Nome;

            ViewBag.ProjetoId = id;

            var procuraTarefa = _context.Tarefa
                .Where(b => nome == null || b.Nome.Contains(nome));

            var pagingInfo = new PagingInfo
            {
                CurrentPage = page,
                TotalItems = procuraTarefa.Count()
            };

            if (pagingInfo.CurrentPage > pagingInfo.TotalPages)
            {
                pagingInfo.CurrentPage = pagingInfo.TotalPages;
            }

            if (pagingInfo.CurrentPage < 1)
            {
                pagingInfo.CurrentPage = 1;
            }

            var tarefas = await procuraTarefa
                            .Where(b => b.ProjetoId == id)
                            .Include(b => b.Projeto)
                            .Include(b => b.Colaborador)
                            .OrderBy(b => b.Nome)
                            .Skip((pagingInfo.CurrentPage - 1) * pagingInfo.PageSize)
                            .Take(pagingInfo.PageSize)
                            .ToListAsync();

            return View(
                new TarefaListViewModel
                {
                    Tarefas = tarefas,
                    PagingInfo = pagingInfo,
                    ProcuraNome = nome
                }
            );
        }

        // GET: Tarefas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarefa = await _context.Tarefa
               .Include(t => t.Projeto)
               .FirstOrDefaultAsync(m => m.TarefaId == id);


            var projeto = _context.Projeto.Where(c => c.ProjetoId == tarefa.ProjetoId).FirstOrDefault();
            ViewBag.ProjetoNome = projeto.Nome;
            ViewBag.ProId = projeto.ProjetoId;

           
            if (tarefa == null)
            {
                return NotFound();
            }

            return View(tarefa);
        }

        // GET: Tarefas/Create
        public IActionResult Create(int? id)
        {

            var colaboradores = _context.ColaboradorProjeto.Where(p => p.ProjetoId == id).Include(c => c.Colaborador);
            ViewData["ColaboradorNome"] = new SelectList(colaboradores, "ColaboradorId", "Colaborador.Nome");
            //ViewData["ColaboradorId"] = new SelectList(_context.ColaboradorProjeto.Where(p => p.ProjetoId == id), "ColaboradorId", "ColaboradorId");
            var projeto = _context.Projeto.Where(c => c.ProjetoId == id).FirstOrDefault();
            ViewBag.ProjetoNome = projeto.Nome;
            ViewBag.ProId = id;


            return View();
        }

        // POST: Tarefas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id,[Bind("TarefaId,Nome,Descricao,DataPrevistaInicio,DataPrevistaFim,ColaboradorId")] Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                tarefa.ProjetoId = id;
                tarefa.DataInicio = null;
                tarefa.DataFim = null;
                if (tarefa.DataPrevistaFim >= tarefa.DataPrevistaInicio)
                {
                    _context.Add(tarefa);
                    await _context.SaveChangesAsync();
                    ViewBag.Controller = "Tarefas";
                    ViewBag.ProjetoId = tarefa.ProjetoId;
                    ViewBag.Title = "Adicionada Tarefa";
                    ViewBag.Message = "Tarefa adicionada com sucesso ao projeto ";
                    return View("Sucesso");
                }
                else
                {
                    ModelState.AddModelError("DataPrevistaFim", "A Data Prevista de Fim tem de ser maior ou igual á Data Prevista de Início");
                    ViewData["ProjetoId"] = new SelectList(_context.Projeto, "ProjetoId", "Nome", tarefa.ProjetoId);
                    var colaboradores = _context.ColaboradorProjeto.Where(p => p.ProjetoId == id).Include(c => c.Colaborador);
                    ViewData["ColaboradorNome"] = new SelectList(colaboradores, "ColaboradorId", "Colaborador.Nome");
                    var projeto = _context.Projeto.Where(c => c.ProjetoId == id).FirstOrDefault();
                    ViewBag.ProjetoNome = projeto.Nome;
                    ViewBag.ProId = id;
                    return View(tarefa);
                }
            }
            ViewData["ProjetoId"] = new SelectList(_context.Projeto, "ProjetoId", "Nome", tarefa.ProjetoId);
            
            return View(tarefa);
        }

        // GET: Tarefas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.ProId = id;

            var tarefa = await _context.Tarefa.FindAsync(id);
            if (tarefa == null)
            {
                return NotFound();
            }
            ViewData["ProjetoId"] = new SelectList(_context.Projeto, "ProjetoId", "Nome", tarefa.ProjetoId);
            return View(tarefa);
        }

        // POST: Tarefas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TarefaId,Nome,Descricao,DataPrevistaInicio,DataPrevistaFim,DataInicio,DataFim,ProjetoId")] Tarefa tarefa)
        {
            if (id != tarefa.TarefaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (tarefa.DataPrevistaFim >= tarefa.DataPrevistaInicio)
                {
                    try
                    {
                        _context.Update(tarefa);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TarefaExists(tarefa.TarefaId))
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
                    ModelState.AddModelError("DataPrevistaFim", "A Data Prevista de Fim tem de ser maior ou igual á Data Prevista de Início");
                    ViewData["ProjetoId"] = new SelectList(_context.Projeto, "ProjetoId", "Nome", tarefa.ProjetoId);
                    return View(tarefa);
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjetoId"] = new SelectList(_context.Projeto, "ProjetoId", "Nome", tarefa.ProjetoId);
            return View(tarefa);
        }

        // GET: Tarefas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarefa = await _context.Tarefa
               .Include(t => t.Projeto)
               .FirstOrDefaultAsync(m => m.TarefaId == id);

            var projeto = _context.Projeto.Where(c => c.ProjetoId == tarefa.ProjetoId).FirstOrDefault();
            ViewBag.ProjetoNome = projeto.Nome;
            ViewBag.ProId = projeto.ProjetoId;

            if (tarefa == null)
            {
                return NotFound();
            }

            return View(tarefa);
        }

        // POST: Tarefas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tarefa = await _context.Tarefa.FindAsync(id);
            _context.Tarefa.Remove(tarefa);
            await _context.SaveChangesAsync();
            ViewBag.Controller = "Tarefas";
            ViewBag.ProjetoId = tarefa.ProjetoId;
            ViewBag.Title = "Tarefa Eliminada";
            ViewBag.Message = "Tarefa eliminada com sucesso";
            return View("Sucesso");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Iniciar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarefa = await _context.Tarefa
                .FirstOrDefaultAsync(m => m.TarefaId == id);
            if (tarefa == null)
            {
                return NotFound();
            }
            tarefa.DataInicio = DateTime.Now;
            try
            {
                _context.Update(tarefa);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TarefaExists(tarefa.TarefaId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction("Index", "Tarefas", new {id = tarefa.ProjetoId});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Finalizar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarefa = await _context.Tarefa
                .FirstOrDefaultAsync(m => m.TarefaId == id);
            if (tarefa == null)
            {
                return NotFound();
            }
            tarefa.DataFim = DateTime.Now;
            try
            {
                _context.Update(tarefa);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TarefaExists(tarefa.TarefaId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction("Index", "Tarefas", new { id = tarefa.ProjetoId });
        }

        private bool TarefaExists(int id)
        {
            return _context.Tarefa.Any(e => e.TarefaId == id);
        }
    }
}
