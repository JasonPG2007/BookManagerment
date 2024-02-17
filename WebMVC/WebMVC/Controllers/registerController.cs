using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class registerController : Controller
    {
        private readonly IUserRepository userRepository;
        public registerController()
        {
            userRepository = new UserRepository();
        }
        // GET: registerController
        public ActionResult Index(string change_account)
        {
            if (change_account != null)
            {
                TempData["change_account"] = "true";
                TempData.Keep();
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(RegisterViewModel model, string gender)
        {
            if (gender != null)
            {
                bool genderAdd = false;
                switch (gender)
                {
                    case "true":
                        genderAdd = true;
                        break;
                    case "false":
                        genderAdd = false;
                        break;
                }
                if (model.ConfirmPassword.Equals(model.Password))
                {
                    string hashPassword = Common.EncryptMD5(model.Password);
                    var isRegister = userRepository.Register(model.UserName, hashPassword, model.PhoneNumber, model.City, model.BirthName, model.Age, model.Address, model.Email, model.Region, genderAdd);
                    if (isRegister == "")
                    {
                        if (TempData["change_account"] != null)
                        {
                            return RedirectToAction("", "login", new { change_account = "true" });
                        }
                        return RedirectToAction("", "login");
                    }
                    else
                    {
                        ModelState.AddModelError("", $"{isRegister}");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Confirm password does not match the above password.");
                }
            }
            return View();
        }

        // GET: registerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: registerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: registerController/Create
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

        // GET: registerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: registerController/Edit/5
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

        // GET: registerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: registerController/Delete/5
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
