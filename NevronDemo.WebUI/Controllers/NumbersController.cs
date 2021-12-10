using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NevronDemo.WebUI.Controllers
{
    public class NumbersController : Controller
    {
        // GET: NumbersController
        public ActionResult Index()
        {
            return View();
        }

        // GET: NumbersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NumbersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NumbersController/Create
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

        // GET: NumbersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NumbersController/Edit/5
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

        // GET: NumbersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NumbersController/Delete/5
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
