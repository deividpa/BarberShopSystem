using BarberShopSystem.Models;
using BarberShopSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BarberShopSystem.Controllers
{
    public class ProfesionalesController : Controller
    {
        // Inyección de dependencia del servicio de profesionales.
        private readonly ProfesionalesService _profesionalesService;
        private readonly ServiciosService _serviciosService;


        // Constructor para inyectar el servicio en el controlador.
        public ProfesionalesController(ProfesionalesService profesionalesService, ServiciosService serviciosService)
        {
            _profesionalesService = profesionalesService;
            _serviciosService = serviciosService;
        }
        // GET: ProfesionalesController
        public ActionResult Index()
        {
            // Se utiliza el servicio para obtener la lista de profesionales.
            List<Profesional> profesionales = _profesionalesService.ObtenerListaDeProfesionales();
            return View(profesionales);
        }

        // GET: ProfesionalesController/Details/5
        public ActionResult Details(int id)
        {    
            return View();
        }

        // GET: ProfesionalesController/Create
        public ActionResult Create()
        {
            ViewBag.Servicios = _serviciosService.ObtenerListaDeServicios();
            return View();
        }

        // POST: ProfesionalesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Profesional nuevoProfesional)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Asigna los servicios seleccionados al profesional antes de agregarlo
                    nuevoProfesional.ProfesionalServicios = nuevoProfesional.ServiciosSeleccionados
                        .Select(servicioId => new ProfesionalServicio { ServicioId = servicioId })
                        .ToList();

                    _profesionalesService.AgregarProfesional(nuevoProfesional);
                    return RedirectToAction(nameof(Index));
                }

                // Recarga la lista de servicios para la vista
                ViewBag.Servicios = _serviciosService.ObtenerListaDeServicios();
                return View(nuevoProfesional);
            }
            catch
            {
                return View();
            }
        }

        // GET: ProfesionalesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProfesionalesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProfesionalesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProfesionalesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
