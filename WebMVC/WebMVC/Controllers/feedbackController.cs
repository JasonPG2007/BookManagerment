using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ObjectBusiness;

namespace WebMVC.Controllers
{
    public class feedbackController : Controller
    {
        // GET: feedbackController
        public ActionResult Index()
        {
            TempData["notification"] = TempData["status"];
            return View();
        }

        // GET: feedbackController/Details/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult feedback(string content, string rating, string selectService, string otherService, Feedback feedback, Service service)
        {
            TempData["status"] = "Feedback successfully.";
            TempData.Keep();
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
