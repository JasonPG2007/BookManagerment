using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace WebMVC.Controllers
{
    public class eventController : Controller
    {
        private readonly IEventRepository eventRepository;
        public eventController()
        {
            eventRepository = new EventRepository();
        }
        // GET: eventController
        public ActionResult Index()
        {
            var listEvent = eventRepository.GetEvents();
            if (listEvent.Count() == 0)
            {
                TempData["messageEvent"] = "No events have taken place yet.";
            }
            return View(listEvent);
        }

        // GET: eventController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: eventController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: eventController/Create
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

        // GET: eventController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: eventController/Edit/5
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

        // GET: eventController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: eventController/Delete/5
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
