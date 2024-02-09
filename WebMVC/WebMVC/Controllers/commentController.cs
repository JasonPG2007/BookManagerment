using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ObjectBusiness;
using Repository;

namespace WebMVC.Controllers
{
    public class commentController : Controller
    {
        private readonly ICommentRepository commentRepository;
        private readonly IAccountRepository accountRepository;
        public commentController()
        {
            accountRepository = new AccountRepository();
            commentRepository = new CommentRepository();
        }
        // GET: commentController
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Event events)
        {
            Random random = new Random();
            var idAccount = Convert.ToInt32(Request.Cookies["idAccount"]);
            var idEvent = RouteData.Values["id"];

            Comment comment = new Comment();
            comment.Content = events.Content;
            comment.CommentId = random.Next();
            comment.DateComment = DateTime.Now;
            comment.AccountId = idAccount;

            Account account = new Account();
            var getAccount = accountRepository.GetAccountById(idAccount);
            account = getAccount;
            account.Point = account.Point + 1;

            var isSuccessfullyAccount = accountRepository.UpdateAccount(account);
            var isSuccessfullyComment = commentRepository.InsertComment(comment);
            if (isSuccessfullyComment)
            {
                if (isSuccessfullyAccount)
                {
                    HttpContext.Session.SetString("commentStatus", "Comment successfully.");
                    return RedirectToAction("details", "event", new { id = idEvent });
                }
                else
                {
                    HttpContext.Session.SetString("commentStatus", "Update point account failed.");
                    return RedirectToAction("details", "event", new { id = idEvent });
                }
            }
            else
            {
                HttpContext.Session.SetString("commentStatus", "Comment failed. Please try again.");
                return RedirectToAction("details", "event", new { id = idEvent });
            }
        }
        // GET: commentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: commentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: commentController/Create
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

        // GET: commentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: commentController/Edit/5
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

        // GET: commentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: commentController/Delete/5
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
