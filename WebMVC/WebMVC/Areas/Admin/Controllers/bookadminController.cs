using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ObjectBusiness;
using Repository;

namespace WebMVC.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class bookadminController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IBookRepository bookRepository;
        private readonly ICategoryBookRepository categoryBookRepository;
        public bookadminController(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
            categoryBookRepository = new CategoryBookRepository();
            bookRepository = new BookRepository();
        }
        // GET: bookadminController
        public ActionResult Index()
        {
            var list = bookRepository.GetBooks();
            return View(list);
        }

        // GET: bookadminController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: bookadminController/Create
        public ActionResult Create()
        {
            var listCategory = categoryBookRepository.GetCategories();
            var selectItem = new List<SelectListItem>();
            foreach (var item in listCategory)
            {
                selectItem.Add(new SelectListItem { Text = item.CategoryName, Value = item.CategoryId.ToString() });
            }
            if (selectItem.Count() > 0)
            {
                ViewBag.ItemsCategory = selectItem;
            }
            return View();
        }

        // POST: bookadminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            Random random = new Random();
            try
            {
                book.Picture = UploadedFile(book);
                book.DateTime = DateTime.Now;
                book.BookId = random.Next();
                if (book.Price > 0)
                {
                    book.Charges = true;
                }
                var isSuccessfuly = bookRepository.InsertBook(book);
                if (isSuccessfuly)
                {
                    return Redirect("~/admin/bookadmin");
                }
                else
                {
                    ModelState.AddModelError("", "Create failed. Try again.");
                }
                return View();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET: bookadminController/Edit/5
        public ActionResult Edit(int id)
        {
            var checkContains = bookRepository.GetBookById(id);
            if (checkContains == null)
            {
                return View("error");
            }
            var listCategory = categoryBookRepository.GetCategories();
            var selectItem = new List<SelectListItem>();
            foreach (var item in listCategory)
            {
                selectItem.Add(new SelectListItem { Text = item.CategoryName, Value = item.CategoryId.ToString() });
            }
            if (selectItem.Count() > 0)
            {
                ViewBag.ItemsCategory = selectItem;
            }
            TempData["idBook"] = id;
            TempData.Keep();
            return View(checkContains);
        }

        // POST: bookadminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book book)
        {
            try
            {
                if (book.Images != null)
                {
                    book.Picture = UploadedFile(book);
                }
                var getBook = bookRepository.GetBookById(Convert.ToInt32(TempData["idBook"]));
                book.DateTime = getBook.DateTime;
                if (book.Price > 0)
                {
                    book.Charges = true;
                }
                if (book.Price <= 0)
                {
                    book.Charges = false;
                }
                var isSuccessfully = bookRepository.UpdateBook(book);
                if (isSuccessfully)
                {
                    return Redirect("~/admin/bookadmin");
                }
                else
                {
                    ModelState.AddModelError("", "Edit failed. Try again.");
                }
                return Redirect($"~/admin/bookadmin/edit/{TempData["idBook"]}");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET: bookadminController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: bookadminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return Redirect("~/admin/bookadmin");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #region UploadedFile
        private string UploadedFile(Book book)
        {
            //string uniqueFileName = UploadedFile(hh);
            //Save image to wwwroot/image
            string wwwRootPath = webHostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(book.Images.FileName);
            string extension = Path.GetExtension(book.Images.FileName);
            //files.NameFile = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            book.Picture = fileName = fileName + extension;
            string path = Path.Combine(wwwRootPath + "/Upload/Images/", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                book.Images.CopyTo(fileStream);
            }
            ViewBag.Images = book.Images;
            return fileName;
        }
        #endregion

        #region Delete Id
        [HttpPost]
        public JsonResult DeleteId(int id)
        {
            try
            {
                var record = bookRepository.GetBookById(id);
                if (record == null)
                {
                    return Json(new { success = false, message = "This book could not be found." });
                }
                bookRepository.DeleteBook(id);
                /*return Json(new { success = true, id = id});*/
                return Json(new
                {
                    status = true
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
        #endregion
    }
}
