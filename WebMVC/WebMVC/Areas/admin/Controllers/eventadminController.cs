using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ObjectBusiness;
using Repository;

namespace WebMVC.Areas.admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class eventadminController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IEventRepository eventRepository;
        private readonly IAccountRepository accountRepository;
        private readonly IEventCategoryRepository eventCategoryRepository;
        public eventadminController(IWebHostEnvironment webHostEnvironment)
        {
            accountRepository = new AccountRepository();
            eventCategoryRepository = new EventCategoryRepository();
            this.webHostEnvironment = webHostEnvironment;
            eventRepository = new EventRepository();
        }
        // GET: eventadminController
        public ActionResult Index()
        {
            var list = eventRepository.GetEvents();
            return View(list);
        }

        // GET: eventadminController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: eventadminController/Create
        public ActionResult Create()
        {
            // dropdown category
            var listCategory = eventCategoryRepository.GetEventCategory();
            var seletList = new List<SelectListItem>();
            foreach (var item in listCategory)
            {
                seletList.Add(new SelectListItem { Text = item.CategoryName, Value = item.CategoryId.ToString() });
            }
            if (seletList.Count() > 0)
            {
                ViewBag.ItemsCategory = seletList;
            }

            // dropdown account
            var listAccount = accountRepository.GetAccount();
            var seletListAccount = new List<SelectListItem>();
            foreach (var item in listAccount)
            {
                seletListAccount.Add(new SelectListItem { Text = item.UserName, Value = item.AccountId.ToString() });
            }
            if (seletListAccount.Count() > 0)
            {
                ViewBag.ItemsAccount = seletListAccount;
            }

            return View();
        }

        // POST: eventadminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Event events)
        {
            try
            {
                Random random = new Random();
                events.EventId = random.Next();
                events.DateCreated = DateTime.Now;
                if (events.ImagesEvent != null)
                {
                    events.Picture = UploadedFile(events);
                }

                var isSuccessfully = eventRepository.InsertEvent(events);
                if (isSuccessfully)
                {
                    return Redirect("~/admin/eventadmin");
                }
                else
                {
                    ModelState.AddModelError("", "Insert event failed.");
                }
                return View();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET: eventadminController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: eventadminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Event events)
        {
            try
            {
                return Redirect("~/admin/eventadmin");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET: eventadminController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: eventadminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return Redirect("~/admin/eventadmin");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #region UploadedFile
        private string UploadedFile(Event events)
        {
            //string uniqueFileName = UploadedFile(hh);
            //Save image to wwwroot/image
            string wwwRootPath = webHostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(events.ImagesEvent.FileName);
            string extension = Path.GetExtension(events.ImagesEvent.FileName);
            //files.NameFile = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            events.Picture = fileName = fileName + extension;
            string path = Path.Combine(wwwRootPath + "/Upload/Images/", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                events.ImagesEvent.CopyTo(fileStream);
            }
            ViewBag.Images = events.ImagesEvent;
            return fileName;
        }
        #endregion
    }
}
