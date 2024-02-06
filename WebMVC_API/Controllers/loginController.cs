using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace WebMVC_API.Controllers
{
    public class loginController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly string ApiUrl = "";
        private readonly HttpClient client;
        public loginController()
        {
            client = new HttpClient();
            var typeMedia = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(typeMedia);
            ApiUrl = "https://localhost:7004/api/UserAPI";
            userRepository = new UserRepository();
        }
        // GET: loginController
        public ActionResult Index()
        {
            if (Request.Cookies.ContainsKey("userName"))
            {
                return RedirectToAction("", "home");
            }
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(string userName, string password)
        {
            if (userName != null && password != null)
            {
                HttpResponseMessage responseMessage = await client.GetAsync($"{ApiUrl}/{userName}/{password}");
                if (responseMessage.IsSuccessStatusCode)
                {
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
                    return RedirectToAction("", "home");
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
            Response.Cookies.Delete("userName");
            return RedirectToAction("", "home");
        }
    }
}
