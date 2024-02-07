using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace WebMVC.Controllers
{
    public class forgotpasswordController : Controller
    {
        private readonly IAccountRepository accountRepository;
        public forgotpasswordController()
        {
            accountRepository = new AccountRepository();
        }
        // GET: forgotPasswordController
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string username)
        {
            if (username != null)
            {
                var checkUserName = accountRepository.GetUserName(username);
                if (checkUserName)
                {
                    TempData["userName"] = username;
                    TempData.Keep();
                    return RedirectToAction("reset", "forgotpassword");
                }
                else
                {
                    ModelState.AddModelError("", "Username does not exist");
                }
            }
            return View();
        }
        // GET: forgotPasswordController/Details/5
        public ActionResult reset()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult reset(string confirmPassword, string forgotPassword)
        {
            if (confirmPassword.Equals(forgotPassword))
            {
                var check = accountRepository.ResetPassword(TempData["userName"].ToString(), confirmPassword);
                if (check)
                {
                    return RedirectToAction("", "login");
                }
                else
                {
                    ModelState.AddModelError("", "Reset password failed.");
                }
            }
            else
            {
                ModelState.AddModelError("", "Confirm new password does not match the above new password.");
            }
            return View();
        }
        // GET: forgotPasswordController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: forgotPasswordController/Create
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

        // GET: forgotPasswordController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: forgotPasswordController/Edit/5
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

        // GET: forgotPasswordController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: forgotPasswordController/Delete/5
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
