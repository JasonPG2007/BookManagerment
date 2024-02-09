using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using X.PagedList;

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
        public ActionResult Index(int? page)
        {
            var listEvent = eventRepository.GetEvents().ToPagedList(page ?? 1, 10);
            if (listEvent.Count() == 0)
            {
                TempData["messageEvent"] = "No events have taken place yet.";
            }
            return View(listEvent);
        }

        // GET: eventController/Details/5
        public ActionResult details(int id)
        {
            if (HttpContext.Session.GetString("commentStatus") != null)
            {
                TempData["commentStatus"] = HttpContext.Session.GetString("commentStatus");
            }
            var events = eventRepository.GetEventById(id);
            if (events != null)
            {
                return View(events);
            }
            return View("error");
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
