using LavanderiaApp.Data;
using LavanderiaApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LavanderiaApp.Controllers
{
    public class PrendasController : Controller
    {
        private readonly LavanderiaContext _context;

        public PrendasController(LavanderiaContext context)
        {
            _context = context;
        }

        // GET: Prendas
        public async Task<IActionResult> Index()
        {
            var prendas = _context.Prendas.Include(p => p.Propietario).Include(p => p.TipoPrenda).Include(p => p.TipoTela);
            return View(await prendas.ToListAsync());
        }

        // GET: Prendas/Create
        public IActionResult Create()
        {
            ViewData["CedulaPropietario"] = new SelectList(_context.Clientes, "Cedula", "Nombre");
            ViewData["TipoPrendaId"] = new SelectList(_context.TiposPrenda, "Id", "Nombre");
            ViewData["TipoTelaId"] = new SelectList(_context.TiposTela, "Id", "Nombre");
            return View();
        }

        // POST: Prendas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPrenda,CedulaPropietario,TipoPrendaId,TipoTelaId,EspecificacionesLavado")] Prenda prenda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prenda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CedulaPropietario"] = new SelectList(_context.Clientes, "Cedula", "Nombre", prenda.CedulaPropietario);
            ViewData["TipoPrendaId"] = new SelectList(_context.TiposPrenda, "Id", "Nombre", prenda.TipoPrendaId);
            ViewData["TipoTelaId"] = new SelectList(_context.TiposTela, "Id", "Nombre", prenda.TipoTelaId);
            return View(prenda);
        }

        // GET: Prendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Prendas == null)
            {
                return NotFound();
            }

            var prenda = await _context.Prendas.FindAsync(id);
            if (prenda == null)
            {
                return NotFound();
            }
            ViewData["CedulaPropietario"] = new SelectList(_context.Clientes, "Cedula", "Nombre", prenda.CedulaPropietario);
            ViewData["TipoPrendaId"] = new SelectList(_context.TiposPrenda, "Id", "Nombre", prenda.TipoPrendaId);
            ViewData["TipoTelaId"] = new SelectList(_context.TiposTela, "Id", "Nombre", prenda.TipoTelaId);
            return View(prenda);
        }

        // POST: Prendas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPrenda,CedulaPropietario,TipoPrendaId,TipoTelaId,EspecificacionesLavado")] Prenda prenda)
        {
            if (id != prenda.IdPrenda)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prenda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrendaExists(prenda.IdPrenda))
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
            ViewData["CedulaPropietario"] = new SelectList(_context.Clientes, "Cedula", "Nombre", prenda.CedulaPropietario);
            ViewData["TipoPrendaId"] = new SelectList(_context.TiposPrenda, "Id", "Nombre", prenda.TipoPrendaId);
            ViewData["TipoTelaId"] = new SelectList(_context.TiposTela, "Id", "Nombre", prenda.TipoTelaId);
            return View(prenda);
        }

        // GET: Prendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Prendas == null)
            {
                return NotFound();
            }

            var prenda = await _context.Prendas
                .Include(p => p.Propietario)
                .Include(p => p.TipoPrenda)
                .Include(p => p.TipoTela)
                .FirstOrDefaultAsync(m => m.IdPrenda == id);
            if (prenda == null)
            {
                return NotFound();
            }

            return View(prenda);
        }

        // POST: Prendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Prendas == null)
            {
                return Problem("Entity set 'LavanderiaContext.Prendas' is null.");
            }
            var prenda = await _context.Prendas.FindAsync(id);
            if (prenda != null)
            {
                _context.Prendas.Remove(prenda);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrendaExists(int id)
        {
            return _context.Prendas.Any(e => e.IdPrenda == id);
        }
    }
}
