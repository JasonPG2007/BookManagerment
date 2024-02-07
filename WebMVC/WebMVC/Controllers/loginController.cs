using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System.Security.Claims;

namespace WebMVC.Controllers
{
    public class loginController : Controller
    {
        private readonly IUserRepository userRepository;
        public loginController()
        {
            userRepository = new UserRepository();
        }
        // GET: loginController
        public ActionResult Index(string change_account)
        {
            if (change_account == null)
            {
                if (Request.Cookies.ContainsKey("userName"))
                {
                    return RedirectToAction("", "home");
                }
            }
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(string userName, string password)
        {
            if (userName != null && password != null)
            {
                var checkUser = userRepository.Login(userName, password);
                if (checkUser != "This account does not exist.")
                {
                    switch (checkUser)
                    {
                        case "Admin":

                            Response.Cookies.Append("userName", "Admin");
                            var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, userName),
                        new Claim(ClaimTypes.Role,"Admin")
                    };
                            var identity = new ClaimsIdentity(claims, "Admin");
                            var principal = new ClaimsPrincipal(identity);
                            await HttpContext.SignInAsync("Admin", principal, new AuthenticationProperties()
                            {
                                IsPersistent = true
                            });
                            return Redirect("~/admin/manager");
                        case "User":
                            var getUserName = userRepository.GetFullName(userName, password);
                            Response.Cookies.Append("userName", getUserName);
                            var claimsUser = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, userName),
                        new Claim(ClaimTypes.Role,"User")
                    };
                            var identityUser = new ClaimsIdentity(claimsUser, "User");
                            var principalUser = new ClaimsPrincipal(identityUser);
                            await HttpContext.SignInAsync("User", principalUser, new AuthenticationProperties()
                            {
                                IsPersistent = true
                            });
                            return RedirectToAction("", "home");
                        case "Staff":
                            Response.Cookies.Append("userName", "Staff");
                            var claimsStaff = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, userName),
                        new Claim(ClaimTypes.Role,"Staff")
                    };
                            var identityStaff = new ClaimsIdentity(claimsStaff, "Staff");
                            var principalStaff = new ClaimsPrincipal(identityStaff);
                            await HttpContext.SignInAsync("Staff", principalStaff, new AuthenticationProperties()
                            {
                                IsPersistent = true
                            });
                            return RedirectToAction("", "home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "username or password is not correct.");
                }
            }
            return View();
        }

        // GET: loginController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: loginController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: loginController/Create
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

        // GET: loginController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: loginController/Edit/5
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

        // GET: loginController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: loginController/Delete/5
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
        public async Task<IActionResult> logout()
        {
            await HttpContext.SignOutAsync("Admin");
            await HttpContext.SignOutAsync("User");
            await HttpContext.SignOutAsync("Staff");
            Response.Cookies.Delete("userName");
            return RedirectToAction("", "home");
        }
    }
}
