using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BarberShopSystem.Models;

namespace BarberShopSystem.Controllers
{
    public class ReservasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reservas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Reservas.Include(r => r.Cliente).Include(r => r.Cupo).Include(r => r.Profesional).Include(r => r.Servicio);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Reservas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Reservas == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas
                .Include(r => r.Cliente)
                .Include(r => r.Cupo)
                .Include(r => r.Profesional)
                .Include(r => r.Servicio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // GET: Reservas/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nombre");
            //ViewData["CupoId"] = new SelectList(_context.Cupos, "Id", "Descripcion");
            ViewData["ServicioId"] = new SelectList(_context.Servicios, "Id", "Descripcion");
            //ViewData["ProfesionalId"] = ObtenerListaDeProfesionales();
            var profesionales = _context.Profesionales.ToList();
            ViewData["ProfesionalId"] = new SelectList(profesionales, "Id", "Nombre");
            return View();
        }

        // POST: Reservas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fecha,ProfesionalId,CupoId,ServicioId,ClienteId,EstadoReserva,FechaCreacion,FechaActualizacion,Novedad")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reserva);
                await _context.SaveChangesAsync();

                // Actualizar el estado del cupo seleccionado
                var cupoSeleccionado = _context.Cupos.FirstOrDefault(c => c.Id == reserva.CupoId);

                if (cupoSeleccionado != null)
                {
                    cupoSeleccionado.EstadoCupo = false;
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nombre", reserva.ClienteId);
            ViewData["ServicioId"] = new SelectList(_context.Servicios, "Id", "Descripcion", reserva.ServicioId);
            ViewData["ProfesionalId"] = ObtenerListaDeProfesionales();

            return View(reserva);
        }

        // GET: Reservas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Reservas == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Id", reserva.ClienteId);
            ViewData["CupoId"] = new SelectList(_context.Cupos, "Id", "Id", reserva.CupoId);
            ViewData["ProfesionalId"] = new SelectList(_context.Profesionales, "Id", "Id", reserva.ProfesionalId);
            ViewData["ServicioId"] = new SelectList(_context.Servicios, "Id", "Id", reserva.ServicioId);
            return View(reserva);
        }

        // POST: Reservas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fecha,ProfesionalId,CupoId,ServicioId,ClienteId,EstadoReserva,FechaCreacion,FechaActualizacion,Novedad")] Reserva reserva)
        {
            if (id != reserva.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reserva);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaExists(reserva.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Id", reserva.ClienteId);
            ViewData["CupoId"] = new SelectList(_context.Cupos, "Id", "Id", reserva.CupoId);
            ViewData["ProfesionalId"] = new SelectList(_context.Profesionales, "Id", "Id", reserva.ProfesionalId);
            ViewData["ServicioId"] = new SelectList(_context.Servicios, "Id", "Id", reserva.ServicioId);
            return View(reserva);
        }

        // GET: Reservas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Reservas == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas
                .Include(r => r.Cliente)
                .Include(r => r.Cupo)
                .Include(r => r.Profesional)
                .Include(r => r.Servicio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // POST: Reservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Reservas == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Reservas'  is null.");
            }
            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva != null)
            {
                _context.Reservas.Remove(reserva);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaExists(int id)
        {
          return (_context.Reservas?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        // Método para obtener la lista de profesionales
        private SelectList ObtenerListaDeProfesionales()
        {
            return new SelectList(_context.Profesionales, "Id", "Nombre");
        }
    }
}
