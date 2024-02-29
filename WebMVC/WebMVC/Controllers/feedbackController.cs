using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ObjectBusiness;
using Repository;

namespace WebMVC.Controllers
{
    [Authorize(Roles = "Admin, User, Staff")]
    [Authorize(AuthenticationSchemes = "Admin, User, Staff")]
    public class feedbackController : Controller
    {
        private readonly IFeedbackRepository feedbackRepository;
        private readonly IServiceRepository serviceRepository;
        public feedbackController()
        {
            serviceRepository = new ServiceRepository();
            feedbackRepository = new FeedbackRepository();
        }
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
            Random random = new Random();

            feedback.FeedbackId = random.Next();
            feedback.Content = content;
            feedback.Evaluate = Convert.ToInt32(rating);
            feedback.DateFeedBack = DateTime.Now;
            feedback.AccountId = Convert.ToInt32(Request.Cookies["idAccount"]);

            if (otherService == null)
            {
                feedback.ServiceId = Convert.ToInt32(selectService);
                bool isSuccessfully = feedbackRepository.InsertFeedBack(feedback);

                if (isSuccessfully)
                {
                    TempData["status"] = "Feedback successfully.";
                }
                else
                {
                    TempData["status"] = "Feedback failed. Try again.";
                }
            }
            else
            {
                service.ServiceId = random.Next();
                service.OtherNameService = otherService;
                service.DateTime = DateTime.Now;

                bool isServiceAdded = serviceRepository.InsertService(service);
                if (isServiceAdded)
                {
                    feedback.ServiceId = service.ServiceId;
                    bool isFeedbacked = feedbackRepository.InsertFeedBack(feedback);
                    if (isFeedbacked)
                    {
                        TempData["status"] = "Feedback successfully.";
                    }
                    else
                    {
                        TempData["status"] = "Feedback failed. Try again.";
                    }
                }
                else
                {
                    TempData["status"] = "Add other service failed so cannot add feedback. Try again.";
                }
            }
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
