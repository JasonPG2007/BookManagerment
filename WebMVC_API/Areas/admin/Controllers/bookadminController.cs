using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace WebMVC_API.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class bookadminController : Controller
    {
        private readonly IBookRepository bookRepository;
        public bookadminController()
        {
            bookRepository = new BookRepository();
        }
        // GET: bookadminController
        public ActionResult Index()
        {
            var list = bookRepository.GetBooks();
            return View(list);
        }

        // GET: bookadminController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: bookadminController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: bookadminController/Create
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

        // GET: bookadminController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: bookadminController/Edit/5
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

        // GET: bookadminController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: bookadminController/Delete/5
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
