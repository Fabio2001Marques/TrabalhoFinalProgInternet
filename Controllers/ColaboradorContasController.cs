using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrabalhoFinalProgInternet.Data;
using TrabalhoFinalProgInternet.Models;
using TrabalhoFinalProgInternet.ViewModels;

namespace TrabalhoFinalProgInternet.Controllers
{
    public class ColaboradorContasController : Controller
    {
        private readonly GestorProjetosContext _context;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public ColaboradorContasController(
            GestorProjetosContext context,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: ColaboradorContas

        [Authorize(Roles ="admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.ColaboradorConta.ToListAsync());
        }

        // GET: ColaboradorContas/Details/5
        [Authorize(Roles = "admin")]
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

        // GET: ColaboradorContas/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: ColaboradorContas/Register
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterColaboradorContaViewModel colaboradorConta)
        {
            if (!ModelState.IsValid)
            {
                return View(colaboradorConta);
            }

            string username = colaboradorConta.Email;

            IdentityUser user = await _userManager.FindByNameAsync(username);

            if (user != null)
            {
                ModelState.AddModelError("Email", "Já existe um Colaborador com esse email.");
                return View(colaboradorConta);
            }


             user = new IdentityUser { UserName = colaboradorConta.Email, Email = colaboradorConta.Email };
                var result = await _userManager.CreateAsync(user, colaboradorConta.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Colaborador");
                    await _signInManager.SignInAsync(user,isPersistent: false);
                    _context.Add( new ColaboradorConta { 
                    Email = colaboradorConta.Email,
                    Name = colaboradorConta.Name,
                    Phone = colaboradorConta.Phone

                    });

                
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index), "Home");
            }

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                
                return RedirectToAction(nameof(Index));
            
        }

        // GET: ColaboradorContas/Edit/5
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
