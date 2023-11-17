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
    /*SOLID: Principio de resposabilidad única**/
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
            var applicationDbContext = _context.Reservas.Include(r => r.Cliente)/*.Include(r => r.Cupo)*/.Include(r => r.Profesional).Include(r => r.Servicio);
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
                // .Include(r => r.Cupo)
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
        public async Task<IActionResult> Create([Bind("Id,Fecha,ProfesionalId,CupoId,ServicioId,ClienteId,EstadoReserva,Novedad")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                // Se establece la fecha de creación
                reserva.FechaCreacion = DateTime.Now;

                _context.Add(reserva);
                await _context.SaveChangesAsync();

                // TODO: Corregir Lógica de Cupos 
                // Se actualiza el estado del cupo seleccionado
                // var cupoSeleccionado = _context.Cupos.FirstOrDefault(c => c.Id == reserva.CupoId);
                /*
                if (cupoSeleccionado != null)
                {
                    cupoSeleccionado.EstadoCupo = false;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    // Manejo de error si no se encuentra el cupo
                    ModelState.AddModelError("CupoId", "El cupo seleccionado no es válido.");
                    ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nombre", reserva.ClienteId);
                    ViewData["ServicioId"] = new SelectList(_context.Servicios, "Id", "Descripcion", reserva.ServicioId);
                    ViewData["ProfesionalId"] = ObtenerListaDeProfesionales();
                    return View(reserva);
                }*/

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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nombre", reserva.ClienteId);
            //ViewData["CupoId"] = new SelectList(_context.Cupos, "Id", "Id", reserva.CupoId);
            ViewData["ProfesionalId"] = new SelectList(_context.Profesionales, "Id", "Nombre", reserva.ProfesionalId);
            ViewData["ServicioId"] = new SelectList(_context.Servicios, "Id", "Descripcion", reserva.ServicioId);
            return View(reserva);
        }

        // POST: Reservas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fecha,ProfesionalId,ServicioId,ClienteId,EstadoReserva,Novedad")] Reserva reserva)
        {
            if (id != reserva.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Obtener la reserva existente del contexto
                    var reservaExistente = await _context.Reservas.FindAsync(reserva.Id);

                    if (reservaExistente == null)
                    {
                        return NotFound();
                    }

                    // Copiar las propiedades modificadas de la nueva reserva a la reserva existente
                    _context.Entry(reservaExistente).CurrentValues.SetValues(reserva);

                    // No actualices la propiedad FechaCreacion
                    reservaExistente.FechaCreacion = reserva.FechaCreacion;

                    // Se establece la fecha de actualización
                    reservaExistente.FechaActualizacion = DateTime.Now;

                    // Actualizar la entidad existente en el contexto
                    _context.Update(reservaExistente);

                    // Guardar cambios en la base de datos
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

            // Cargar datos necesarios para Cliente, Profesional y Servicio
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nombre", reserva.ClienteId);
            ViewData["ProfesionalId"] = new SelectList(_context.Profesionales, "Id", "Nombre", reserva.ProfesionalId);
            ViewData["ServicioId"] = new SelectList(_context.Servicios, "Id", "Descripcion", reserva.ServicioId);

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
                // .Include(r => r.Cupo)
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
        /*
        [HttpGet]
        public JsonResult ObtenerCuposDisponibles(int profesionalId, DateTime fecha)
        {
            var fechaSinHora = fecha.Date; // Eliminar la información de la hora

            // Verificar si hay algún cupo existente para la fecha proporcionada
            var existeCupo = _context.Cupos
                .Any(c => c.ProfesionalId == profesionalId && c.Fecha.Date == fechaSinHora && c.EstadoCupo);

            List<string> intervalosDisponibles;

            if (existeCupo)
            {
                // Obtener los intervalos de 30 minutos disponibles basados en los cupos existentes
                intervalosDisponibles = ObtenerIntervalosDisponibles(profesionalId, fechaSinHora);
            }
            else
            {
                // Si no hay cupos existentes, mostrar todos los intervalos del día
                intervalosDisponibles = ObtenerTodosLosIntervalosDelDia();
            }

            return Json(intervalosDisponibles);
        } */

        // Función para obtener intervalos disponibles basados en los cupos existentes
        /*
        private List<string> ObtenerIntervalosDisponibles(int profesionalId, DateTime fecha)
        {
            // Lógica para obtener intervalos disponibles
            // ...

            // En este ejemplo, se devuelve una lista de intervalos fijos para la demostración
            return new List<string> { "8:30 am", "9:00 am", "9:30 am", "10:00 am", "10:30 am", "11:00 am", "11:30 am", "12:00 pm" };
        }

        // Función para obtener todos los intervalos del día (para fechas sin cupos existentes)
        private List<string> ObtenerTodosLosIntervalosDelDia()
        {
            // Lógica para obtener todos los intervalos del día
            // ...

            // En este ejemplo, se devuelve una lista de intervalos fijos para la demostración
            return new List<string> { "8:30 am", "9:00 am", "9:30 am", "10:00 am", "10:30 am", "11:00 am", "11:30 am", "12:00 pm", "12:30 pm", "1:00 pm", "1:30 pm", "2:00 pm", "2:30 pm", "3:00 pm", "3:30 pm", "4:00 pm", "4:30 pm" };
        }*/
    }
}
