using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Controllers
{
    public class feedbackController : Controller
    {
        // GET: feedbackController
        public ActionResult Index()
        {
            return View();
        }

        // GET: feedbackController/Details/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult feedback()
        {
            return RedirectToAction(nameof(Index));
        }

        // GET: feedbackController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: feedbackController/Create
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

        // GET: feedbackController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: feedbackController/Edit/5
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

        // GET: feedbackController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: feedbackController/Delete/5
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
