using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Herupu.DAL.Context;
using Herupu.DAO.Entidades;

namespace Herupu.Adminitrativo.Web.Controllers
{
    public class AtividadeController : Controller
    {
        private readonly DataBaseContext _context;

        public AtividadeController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: Atividades
        public async Task<IActionResult> Index()
        {
            return View(await _context.Atividade.ToListAsync());
        }

        // GET: Atividades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Atividade == null)
            {
                return NotFound();
            }

            var atividade = await _context.Atividade
                .FirstOrDefaultAsync(m => m.IdAtividade == id);
            if (atividade == null)
            {
                return NotFound();
            }

            return View(atividade);
        }

        // GET: Atividades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Atividades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAtividade,Nome,Descricao,Instrucao,IdadeSugerida")] Atividade atividade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(atividade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(atividade);
        }

        // GET: Atividades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Atividade == null)
            {
                return NotFound();
            }

            var atividade = await _context.Atividade.FindAsync(id);
            if (atividade == null)
            {
                return NotFound();
            }
            return View(atividade);
        }

        // POST: Atividades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAtividade,Nome,Descricao,Instrucao,IdadeSugerida")] Atividade atividade)
        {
            if (id != atividade.IdAtividade)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(atividade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtividadeExists(atividade.IdAtividade))
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
            return View(atividade);
        }

        // GET: Atividades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Atividade == null)
            {
                return NotFound();
            }

            var atividade = await _context.Atividade
                .FirstOrDefaultAsync(m => m.IdAtividade == id);
            if (atividade == null)
            {
                return NotFound();
            }

            return View(atividade);
        }

        // POST: Atividades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Atividade == null)
            {
                return Problem("Entity set 'DataBaseContext.Atividade'  is null.");
            }
            var atividade = await _context.Atividade.FindAsync(id);
            if (atividade != null)
            {
                _context.Atividade.Remove(atividade);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AtividadeExists(int id)
        {
            return _context.Atividade.Any(e => e.IdAtividade == id);
        }
    }
}
