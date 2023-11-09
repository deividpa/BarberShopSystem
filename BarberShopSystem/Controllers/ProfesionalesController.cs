using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BarberShopSystem.Controllers
{
    public class ProfesionalesController : Controller
    {
        // GET: ProfesionalesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProfesionalesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProfesionalesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProfesionalesController/Create
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
