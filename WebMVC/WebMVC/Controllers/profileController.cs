using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ObjectBusiness;
using Repository;

namespace WebMVC.Controllers
{
    [Authorize(Roles = "Admin, User, Staff")]
    [Authorize(AuthenticationSchemes = "Admin, User, Staff")]
    public class profileController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IAccountRepository accountRepository;
        private readonly IUserRepository userRepository;
        public profileController(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
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
                return View();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET: profileController1/Edit/5
        public ActionResult edit(int id)
        {
            var checkContains = accountRepository.GetUserByIdAccount(id);
            if (checkContains != null)
            {
                return View(checkContains.FirstOrDefault());
            }
            return View("error");
        }

        // POST: profileController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult edit(Account account)
        {
            try
            {
                var userId = Convert.ToInt32(Request.Cookies["idUser"]);
                var accountId = Convert.ToInt32(Request.Cookies["idAccount"]);

                User user = new User();
                user.UserId = userId;
                user.Email = account.Email;
                if (account.Picture != null)
                {
                    user.Picture = UploadedAvatar(account);
                }
                user.PhoneNumber = account.PhoneNumber;
                user.Address = account.Address;
                user.City = account.City;
                user.Region = account.Region;
                user.Age = account.Age;
                user.FullName = account.FullName;
                //user.Gender = account.Gender;

                Account account2 = new Account();
                account2.AccountId = accountId;
                account2.UserId = Convert.ToInt32(userId);
                account2.UserName = account.UserName;
                account2.Password = account.Password;

                var isAccountUpdated = accountRepository.UpdateAccount(account2);
                var isUserUpdated = userRepository.UpdateUser(user);
                if (isAccountUpdated && isUserUpdated)
                {
                    TempData["message"] = "Update successfully.";
                    TempData["bgcolor"] = "#11cdef";
                    TempData["color"] = "white";
                    return RedirectToAction("", "profile", new { id = accountId });
                }
                else
                {
                    TempData["bgcolor"] = "red";
                    TempData["color"] = "white";
                    TempData["message"] = "Update failed. Please try again.";
                }
                var checkContains = accountRepository.GetUserByIdAccount(accountId);
                if (checkContains != null)
                {
                    return View(checkContains.FirstOrDefault());
                }
                return View();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
                return View();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #region UploadedAvatar
        private string UploadedAvatar(Account account)
        {
            //string uniqueFileName = UploadedFile(hh);
            //Save image to wwwroot/image
            string wwwRootPath = webHostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(account.AvatarImages.FileName);
            string extension = Path.GetExtension(account.AvatarImages.FileName);
            //files.NameFile = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            account.Picture = fileName = fileName + extension;
            string path = Path.Combine(wwwRootPath + "/Upload/Images/", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                account.AvatarImages.CopyTo(fileStream);
            }
            ViewBag.Images = account.AvatarImages;
            return fileName;
        }
        #endregion

        #region Delete Id
        //[HttpPost]
        //public JsonResult DeleteId(int id)
        //{
        //    try
        //    {
        //        var record = newsRepository.GetNewsById(id);
        //        if (record == null)
        //        {
        //            return Json(new { success = false, message = "Không tìm thấy tin tức này." });
        //        }
        //        newsRepository.DeleteNews(id);
        //        /*return Json(new { success = true, id = id});*/
        //        return Json(new
        //        {
        //            status = true
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { success = false, message = ex.Message });
        //    }
        //}
        #endregion
    }
}
