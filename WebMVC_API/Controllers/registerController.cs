using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC_API.Controllers
{
    public class registerController : Controller
    {
        // GET: registerController
        public ActionResult Index()
        {
            return View();
        }

        // GET: registerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: registerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: registerController/Create
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

        // GET: registerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: registerController/Edit/5
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

        // GET: registerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: registerController/Delete/5
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
