using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ObjectBusiness;
using Repository;
using X.PagedList;

namespace WebMVC.Controllers
{
    public class eventController : Controller
    {
        private readonly IEventRepository eventRepository;
        private readonly IAccountRepository accountRepository;
        private readonly ICommentRepository commentRepository;
        public eventController()
        {
            commentRepository = new CommentRepository();
            accountRepository = new AccountRepository();
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
            var events = eventRepository.GetEventById(id);
            if (events != null)
            {
                TempData["idEvent"] = id;
                TempData.Keep();
                return View(events);
            }
            return View("error");
        }

        #region Comment
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult comment(Event events)
        {
            Random random = new Random();
            var idAccount = Convert.ToInt32(Request.Cookies["idAccount"]);
            var idEvent = Convert.ToInt32(TempData["idEvent"]);

            Comment comment = new Comment();
            comment.Content = events.Content;
            comment.CommentId = random.Next();
            comment.DateComment = DateTime.Now;
            comment.EventId = idEvent;

            Account account = new Account();
            var getAccount = accountRepository.GetAccountById(idAccount);
            account = getAccount;
            account.Point = account.Point + 1;

            var isSuccessfullyComment = commentRepository.InsertComment(comment);
            if (isSuccessfullyComment)
            {
                var isSuccessfullyAccount = accountRepository.UpdateAccount(account);
                if (isSuccessfullyAccount)
                {
                    TempData["commentStatus"] = "Comment successfully.";
                    return RedirectToAction("details", "event", new { id = TempData["idEvent"] });
                }
                else
                {
                    TempData["commentStatus"] = "Update point account failed.";
                    return RedirectToAction("details", "event", new { id = TempData["idEvent"] });
                }
            }
            else
            {
                TempData["commentStatus"] = "Comment failed. Please try again.";
                return RedirectToAction("details", "event", new { id = TempData["idEvent"] });
            }
        }
        #endregion

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
