using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ObjectBusiness;
using Repository;

namespace WebMVC.Areas.admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class eventcategoryadminController : Controller
    {
        private readonly IEventCategoryRepository eventCategoryRepository;
        public eventcategoryadminController()
        {
            eventCategoryRepository = new EventCategoryRepository();
        }
        // GET: eventcategoryController
        public ActionResult Index()
        {
            var list = eventCategoryRepository.GetEventCategory();
            return View(list);
        }

        // GET: eventcategoryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: eventcategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: eventcategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventCategory category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Random random = new Random();
                    category.CategoryId = random.Next();
                    category.DateCreated = DateTime.Now;

                    var isSuccessfully = eventCategoryRepository.InsertCategory(category);
                    if (isSuccessfully)
                    {
                        return Redirect("~/admin/eventcategoryadmin");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Insert category event failed.");
                    }
                }
                return View();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET: eventcategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: eventcategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return Redirect("~/admin/eventcategoryadmin");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET: eventcategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: eventcategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return Redirect("~/admin/eventcategoryadmin");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
