using BarberShopSystem.Models;
using BarberShopSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BarberShopSystem.Controllers
{
    public class ReservasController : Controller
    {
        // Inyección de dependencia del servicio de reservas.
        private readonly ReservasService _reservasService;

        // Constructor para inyectar el servicio en el controlador.
        public ReservasController(ReservasService reservasService)
        {
            _reservasService = reservasService;
        }

        // GET: ReservasController
        public ActionResult Index()
        {
            // Se utiliza el servicio para obtener la lista de reservas.
            List<Reserva> reservas = _reservasService.ObtenerListaDeReservas();
            return View(reservas);
        }

        // GET: ReservasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ReservasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReservasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: ReservasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReservasController/Edit/5
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

        // GET: ReservasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReservasController/Delete/5
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
