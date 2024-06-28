using LavanderiaApp.Data;
using LavanderiaApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

public class ServiciosController : Controller
{
    private readonly LavanderiaContext _context;

    public ServiciosController(LavanderiaContext context)
    {
        _context = context;
    }

    // GET: Servicios
    public async Task<IActionResult> Index()
    {
        var servicios = await _context.Servicios
            .Include(s => s.Prenda)
            .Include(s => s.EstadoServicio)
            .ToListAsync();
        return View(servicios);
    }

    // GET: Servicios/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var servicio = await _context.Servicios
            .Include(s => s.Prenda)
            .Include(s => s.EstadoServicio)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (servicio == null)
        {
            return NotFound();
        }

        return View(servicio);
    }

    // GET: Servicios/Create
    public IActionResult Create()
    {
        ViewData["PrendaId"] = new SelectList(_context.Prendas, "IdPrenda", "IdPrenda");
        ViewData["EstadoServicioId"] = new SelectList(_context.EstadosServicio, "Id", "estado");
        return View();
    }

    // POST: Servicios/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,prendaId,cedulaPropietario,fechaRecibo,comentarios,estadoServicioId,fechaDevolucion")] Servicio servicio)
    {
        if (ModelState.IsValid)
        {
            _context.Add(servicio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["PrendaId"] = new SelectList(_context.Prendas, "IdPrenda", "IdPrenda", servicio.prendaId);
        ViewData["EstadoServicioId"] = new SelectList(_context.EstadosServicio, "Id", "estado", servicio.estadoServicioId);
        return View(servicio);
    }

    // GET: Servicios/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var servicio = await _context.Servicios.FindAsync(id);
        if (servicio == null)
        {
            return NotFound();
        }
        ViewData["PrendaId"] = new SelectList(_context.Prendas, "IdPrenda", "IdPrenda", servicio.prendaId);
        ViewData["EstadoServicioId"] = new SelectList(_context.EstadosServicio, "Id", "estado", servicio.estadoServicioId);
        return View(servicio);
    }

    // POST: Servicios/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,prendaId,cedulaPropietario,fechaRecibo,comentarios,estadoServicioId,fechaDevolucion")] Servicio servicio)
    {
        if (id != servicio.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(servicio);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServicioExists(servicio.Id))
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
        ViewData["PrendaId"] = new SelectList(_context.Prendas, "IdPrenda", "IdPrenda", servicio.prendaId);
        ViewData["EstadoServicioId"] = new SelectList(_context.EstadosServicio, "Id", "estado", servicio.estadoServicioId);
        return View(servicio);
    }

    // GET: Servicios/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var servicio = await _context.Servicios
            .Include(s => s.Prenda)
            .Include(s => s.EstadoServicio)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (servicio == null)
        {
            return NotFound();
        }

        return View(servicio);
    }

    // POST: Servicios/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var servicio = await _context.Servicios.FindAsync(id);
        _context.Servicios.Remove(servicio);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ServicioExists(int id)
    {
        return _context.Servicios.Any(e => e.Id == id);
    }
}
