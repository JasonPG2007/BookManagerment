using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace WebMVC.Controllers
{
    public class bookController : Controller
    {
        private readonly IBookRepository bookRepository;
        public bookController()
        {
            bookRepository = new BookRepository();
        }
        // GET: bookController
        public ActionResult Index()
        {
            return View();
        }

        // GET: bookController/Details/5
        public ActionResult details(int id)
        {
            var check = bookRepository.GetBookById(id);
            if (check != null)
            {
                return View(check);
            }
            return NotFound();
        }

        // GET: bookController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: bookController/Create
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

        // GET: bookController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: bookController/Edit/5
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

        // GET: bookController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: bookController/Delete/5
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
