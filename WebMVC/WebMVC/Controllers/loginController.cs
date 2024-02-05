using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Controllers
{
    public class loginController : Controller
    {
        // GET: loginController
        public ActionResult Index()
        {
            if (Request.Cookies.ContainsKey("userName"))
            {
                return RedirectToAction("", "home");
            }
            return View();
        }
  //      [HttpPost]
  //      public async Task<ActionResult> Index()
  //      {
		//	return View();
		//}

        // GET: loginController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: loginController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: loginController/Create
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

        // GET: loginController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: loginController/Edit/5
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

        // GET: loginController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: loginController/Delete/5
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
        public async Task<IActionResult> logout()
        {
            await HttpContext.SignOutAsync("Admin");
            Response.Cookies.Delete("userName");
            return RedirectToAction("", "home");
        }
    }
}
