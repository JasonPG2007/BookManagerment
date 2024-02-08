using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace WebMVC.Controllers
{
    [Authorize(Roles = "Admin, User, Staff")]
    [Authorize(AuthenticationSchemes = "Admin, User, Staff")]
    public class profileController : Controller
    {
        private readonly IAccountRepository accountRepository;
        private readonly IUserRepository userRepository;
        public profileController()
        {
            userRepository = new UserRepository();
            accountRepository = new AccountRepository();
        }
        // GET: profileController1
        public ActionResult Index(int id)
        {
            if (id <= 0)
            {
                return View("error");
            }
            var list = accountRepository.GetUserByIdAccount(id);
            if (list.Count() <= 0)
            {
                return View("error");
            }
            return View(list);
        }

        // GET: profileController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: profileController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: profileController1/Create
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

        // GET: profileController1/Edit/5
        public ActionResult edit(int id)
        {
            var checkContains = accountRepository.GetAccountById(id);
            if (checkContains != null)
            {
                return View(checkContains);
            }
            return View("error");
        }

        // POST: profileController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult edit(int id, IFormCollection collection)
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

        // GET: profileController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: profileController1/Delete/5
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
