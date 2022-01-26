using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrabalhoFinalProgInternet.Data;
using TrabalhoFinalProgInternet.Models;

namespace TrabalhoFinalProgInternet
{
    public class ColaboradorProjetosController : Controller
    {
        private readonly GestorProjetosContext _context;

        public ColaboradorProjetosController(GestorProjetosContext context)
        {
            _context = context;
        }

        // GET: ColaboradorProjetos
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var projeto = _context.Projeto.Where(c => c.ProjetoId == id).FirstOrDefault();
            ViewBag.Projeto = projeto;
            var gestorProjetosContext = _context.ColaboradorProjeto.Where(c => c.ProjetoId == id).Include(c => c.Colaborador).Include(c => c.Projeto);

            return View(await gestorProjetosContext.ToListAsync());
        }

        // GET: ColaboradorProjetos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colaboradorProjeto = await _context.ColaboradorProjeto
                .Include(c => c.Colaborador)
                .Include(c => c.Projeto)
                .FirstOrDefaultAsync(m => m.ColaboradorId == id);
            if (colaboradorProjeto == null)
            {
                return NotFound();
            }

            return View(colaboradorProjeto);
        }

        // GET: ColaboradorProjetos/Create
        public  IActionResult Create(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var projeto = _context.Projeto.Where(c => c.ProjetoId == id).FirstOrDefault();
            ViewBag.Projeto = projeto;

            ViewData["ColaboradorNome"] = new SelectList(_context.Colaborador, "ColaboradorId", "Nome");
            ViewData["ProjetoId"] = new SelectList(_context.Projeto, "ProjetoId", "Nome", projeto.ProjetoId);
            //ViewData["ProjetoId"] = new SelectList(_context.Projeto.Where(c => c.ProjetoId == id), "ProjetoId", "Nome");
            return View();
        }

        // POST: ColaboradorProjetos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id,[Bind("ColaboradorId,DataDeInicio,DataDeSaida")] ColaboradorProjeto colaboradorProjeto)
        {
            
            if (ModelState.IsValid)
            {
                colaboradorProjeto.ProjetoId = id;
                _context.Add(colaboradorProjeto);
                await _context.SaveChangesAsync();
                ViewBag.Controller = "ColaboradorProjetos";
                ViewBag.ProjetoId = colaboradorProjeto.ProjetoId;
                ViewBag.Title = "Adicionado Colaborador";
                ViewBag.Message = "Colaborador Adicionado com Sucesso";
                return View("Sucesso");
            }
            ViewData["ColaboradorNome"] = new SelectList(_context.Colaborador, "ColaboradorId", "Nome", colaboradorProjeto.ColaboradorId);
            ViewData["ProjetoId"] = new SelectList(_context.Projeto, "ProjetoId", "Nome", colaboradorProjeto.ProjetoId);
            return View(colaboradorProjeto);
        }

        // GET: ColaboradorProjetos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colaboradorProjeto = await _context.ColaboradorProjeto.FindAsync(id);
            if (colaboradorProjeto == null)
            {
                return NotFound();
            }
            ViewData["ColaboradorId"] = new SelectList(_context.Colaborador, "ColaboradorId", "Contacto", colaboradorProjeto.ColaboradorId);
            ViewData["ProjetoId"] = new SelectList(_context.Projeto, "ProjetoId", "Nome", colaboradorProjeto.ProjetoId);
            return View(colaboradorProjeto);
        }

        // POST: ColaboradorProjetos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ColaboradorId,ProjetoId,DataDeInicio,DataDeSaida")] ColaboradorProjeto colaboradorProjeto)
        {
            if (id != colaboradorProjeto.ColaboradorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(colaboradorProjeto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ColaboradorProjetoExists(colaboradorProjeto.ColaboradorId))
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
            ViewData["ColaboradorId"] = new SelectList(_context.Colaborador, "ColaboradorId", "Contacto", colaboradorProjeto.ColaboradorId);
            ViewData["ProjetoId"] = new SelectList(_context.Projeto, "ProjetoId", "Nome", colaboradorProjeto.ProjetoId);
            return View(colaboradorProjeto);
        }

        // GET: ColaboradorProjetos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colaborador = _context.ColaboradorProjeto.Where(c => c.ColaboradorId == id).FirstOrDefault();
            ViewBag.Colaborador = colaborador;


            var colaboradorProjeto = await _context.ColaboradorProjeto
                .Include(c => c.Colaborador)
                .Include(c => c.Projeto)
                .FirstOrDefaultAsync(m => m.ColaboradorId == id);
            if (colaboradorProjeto == null)
            {
                return NotFound();
            }

            return View(colaboradorProjeto);
        }

        // POST: ColaboradorProjetos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int ColaboradorId, int ProjetoId)
        {
            var tarefas = _context.Tarefa.Where(c => c.ColaboradorId == ColaboradorId).Where(d => d.DataFim == null).FirstOrDefault();
            
            if (tarefas.Nome != null)
            {
                ViewBag.Controller = "ColaboradorProjetos";
                ViewBag.ProjetoId = ProjetoId;
                ViewBag.Title = "Erro ao eliminar Colaborador";
                ViewBag.Message = "Não pode eliminar um Colaborador que tenha uma tarefa ainda pendente";
                return View("Erro");
            }
            var colaboradorProjeto = await _context.ColaboradorProjeto.FirstOrDefaultAsync(m => m.ColaboradorId == ColaboradorId && m.ProjetoId == ProjetoId);
            _context.ColaboradorProjeto.Remove(colaboradorProjeto);
            await _context.SaveChangesAsync();
            ViewBag.Controller = "ColaboradorProjetos";
            ViewBag.ProjetoId = colaboradorProjeto.ProjetoId;
            ViewBag.Title = "Eliminado Colaborador";
            ViewBag.Message = "Colaborador Eliminado com Sucesso";
            return View("Sucesso");
        }

        private bool ColaboradorProjetoExists(int id)
        {
            return _context.ColaboradorProjeto.Any(e => e.ColaboradorId == id);
        }
    }
}
