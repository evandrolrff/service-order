using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ODAPI.Database;
using ODAPI.Models;

namespace ODAPI.Controllers
{
    public class ODsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ODsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ODs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.OD.Include(o => o.Cliente);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ODs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oD = await _context.OD
                .Include(o => o.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (oD == null)
            {
                return NotFound();
            }

            return View(oD);
        }

        // GET: ODs/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "CPF");
            return View();
        }

        // POST: ODs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClienteId,Descricao,Valor,DataSolicitacao,DataConclusao,Status,Endereco")] OD oD)
        {
            if (ModelState.IsValid)
            {
                _context.Add(oD);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "CPF", oD.ClienteId);
            return View(oD);
        }

        // GET: ODs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oD = await _context.OD.FindAsync(id);
            if (oD == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "CPF", oD.ClienteId);
            return View(oD);
        }

        // POST: ODs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClienteId,Descricao,Valor,DataSolicitacao,DataConclusao,Status,Endereco")] OD oD)
        {
            if (id != oD.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oD);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ODExists(oD.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "CPF", oD.ClienteId);
            return View(oD);
        }

        // GET: ODs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oD = await _context.OD
                .Include(o => o.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (oD == null)
            {
                return NotFound();
            }

            return View(oD);
        }

        // POST: ODs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var oD = await _context.OD.FindAsync(id);
            if (oD != null)
            {
                _context.OD.Remove(oD);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ODExists(int id)
        {
            return _context.OD.Any(e => e.Id == id);
        }
    }
}
