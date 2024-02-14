using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ObjectBusiness;
using Repository;

namespace WebMVC.Areas.admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class categorybookadminController : Controller
    {
        private readonly ICategoryBookRepository categoryBookRepository;
        public categorybookadminController()
        {
            categoryBookRepository = new CategoryBookRepository();
        }
        // GET: categorybookadminController
        public ActionResult Index()
        {
            var list = categoryBookRepository.GetCategories();
            return View(list);
        }

        // GET: categorybookadminController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: categorybookadminController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: categorybookadminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryBook category)
        {
            try
            {
                Random random = new Random();
                if (ModelState.IsValid)
                {
                    category.CategoryId = random.Next();
                    category.DateTime = DateTime.Now;
                    var isSuccessfully = categoryBookRepository.InsertCategory(category);
                    if (isSuccessfully)
                    {
                        return Redirect("~/admin/categorybookadmin");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Create failed. Try again.");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Please fill all information.");
                }
                return View();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET: categorybookadminController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: categorybookadminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return Redirect("~/admin/categorybookadmin");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET: categorybookadminController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: categorybookadminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return Redirect("~/admin/categorybookadmin");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
