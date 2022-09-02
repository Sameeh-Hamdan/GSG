using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class SameehController : Controller
    {
        // GET: SameehController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SameehController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SameehController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SameehController/Create
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

        // GET: SameehController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SameehController/Edit/5
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

        // GET: SameehController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SameehController/Delete/5
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
