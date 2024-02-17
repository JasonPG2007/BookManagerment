using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace WebMVC.Areas.admin.Controllers
{
    public class feedbackadminController : Controller
    {
        private readonly IFeedbackRepository feedbackRepository;
        public feedbackadminController()
        {
            feedbackRepository = new FeedbackRepository();
        }
        // GET: feedbackadminController
        public ActionResult Index()
        {
            var list = feedbackRepository.GetFeedbacks();
            return View(list);
        }

        // GET: feedbackadminController/Details/5
        public ActionResult details(int id)
        {
            var feedback = feedbackRepository.GetFeedBackById(id);
            if (feedback != null)
            {
                return View(feedback);
            }
            return View("erroradmin");
        }

        // GET: feedbackadminController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: feedbackadminController/Create
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

        // GET: feedbackadminController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: feedbackadminController/Edit/5
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

        // GET: feedbackadminController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: feedbackadminController/Delete/5
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
