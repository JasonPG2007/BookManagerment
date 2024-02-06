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
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(RegisterViewModel model, string gender)
        {
            if (gender != null)
            {
                bool genderAdd = true;
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
                    userRepository.Register(model.UserName, model.Password, model.PhoneNumber, model.City, model.BirthName, model.Age, model.Address, model.Email, model.Region, genderAdd);
                    return RedirectToAction("", "login");
                }
                else
                {
                    ModelState.AddModelError("", "Confirm password does not match the above password.");
                }
            }
            else
            {
                ModelState.AddModelError("", "Please select gender.");
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
