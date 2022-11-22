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
    public class AtividadeItemController : Controller
    {
        private readonly DataBaseContext _context;

        public AtividadeItemController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: AtividadeItem
        public async Task<IActionResult> Index()
        {
            var atividadeItemContext = _context.AtividadeItem.Include(a => a.Atividade);
            var list = await atividadeItemContext.ToListAsync();

            return View(list);
        }

        // GET: AtividadeItem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AtividadeItem == null)
            {
                return NotFound();
            }

            var atividadeItem = await _context.AtividadeItem
                .Include(e => e.Atividade)
                .FirstOrDefaultAsync(m => m.IdAtividadeItem == id);
            if (atividadeItem == null)
            {
                return NotFound();
            }

            return View(atividadeItem);
        }

        // GET: AtividadeItem/Create
        public IActionResult Create()
        {
            ViewData["Atividades"] = new SelectList(_context.Atividade.ToList(), "IdAtividade", "Nome");
            return View();
        }

        // POST: AtividadeItem/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAtividadeItem,Pergunta,Resposta,Detalhe,IdAtividade")] AtividadeItem atividadeItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(atividadeItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["Atividades"] = new SelectList(_context.Atividade.ToList(), "IdAtividade", "Nome", atividadeItem.IdAtividade);

            return View(atividadeItem);
        }

        // GET: AtividadeItem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AtividadeItem == null)
            {
                return NotFound();
            }

            var atividadeItem = await _context.AtividadeItem.FindAsync(id);
            if (atividadeItem == null)
            {
                return NotFound();
            }
            ViewData["IdAtividade"] = new SelectList(_context.Atividade, "Id", "Nome", atividadeItem.IdAtividade);

            return View(atividadeItem);
        }

        // POST: AtividadeItem/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAtividadeItem,Pergunta,Resposta,Detalhe,IdAtividade")] AtividadeItem atividadeItem)
        {
            if (id != atividadeItem.IdAtividadeItem)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(atividadeItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtividadeItemExists(atividadeItem.IdAtividadeItem))
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

            ViewData["IdAtividade"] = new SelectList(_context.Atividade, "Id", "Nome", atividadeItem.IdAtividade);

            return View(atividadeItem);
        }

        // GET: AtividadeItem/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AtividadeItem == null)
            {
                return NotFound();
            }

            var atividadeItem = await _context.AtividadeItem
                .Include(a => a.Atividade)
                .FirstOrDefaultAsync(m => m.IdAtividadeItem == id);
            if (atividadeItem == null)
            {
                return NotFound();
            }

            return View(atividadeItem);
        }

        // POST: AtividadeItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AtividadeItem == null)
            {
                return Problem("Entity set 'DataBaseContext.AtividadeItem'  is null.");
            }
            var atividadeItem = await _context.AtividadeItem.FindAsync(id);
            if (atividadeItem != null)
            {
                _context.AtividadeItem.Remove(atividadeItem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AtividadeItemExists(int id)
        {
            return _context.AtividadeItem.Any(e => e.IdAtividadeItem == id);
        }
    }
}
