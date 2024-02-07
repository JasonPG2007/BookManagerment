using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Controllers
{
    public class forgotpasswordController : Controller
    {
        // GET: forgotPasswordController
        public ActionResult Index()
        {
            return View();
        }

        // GET: forgotPasswordController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: forgotPasswordController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: forgotPasswordController/Create
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

        // GET: forgotPasswordController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: forgotPasswordController/Edit/5
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

        // GET: forgotPasswordController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: forgotPasswordController/Delete/5
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
