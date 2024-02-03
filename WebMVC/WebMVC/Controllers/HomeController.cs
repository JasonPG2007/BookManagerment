using Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;

namespace WebMVC.Controllers
{
    public class homeController : Controller
    {
        // GET: HomeController
        public ActionResult Index()
        {
            //MailUtils.SendMailGoogleSmtp("ngocdng08@gmail.com", "baoandng07@gmail.com", "Hello", "Demo", "ngocdng08@gmail.com", "baoan123.cntt");
            return View();
        }
        //[HttpPost]
        //public ActionResult Index(string receiver, string subject, string message)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var senderEmail = new MailAddress("baoandng07@gmail.com", "Jamil");
        //            var receiverEmail = new MailAddress(receiver, "Receiver");
        //            var password = "BAOan@67899";
        //            var sub = subject;
        //            var body = message;
        //            var smtp = new SmtpClient
        //            {
        //                Host = "smtp.gmail.com",
        //                Port = 587,
        //                EnableSsl = true,
        //                DeliveryMethod = SmtpDeliveryMethod.Network,
        //                UseDefaultCredentials = false,
        //                Credentials = new NetworkCredential(senderEmail.Address, password)
        //            };
        //            using (var mess = new MailMessage(senderEmail, receiverEmail)
        //            {
        //                Subject = subject,
        //                Body = body
        //            })
        //            {
        //                smtp.Send(mess);
        //            }
        //            return View();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        ViewBag.Error = "Some Error";
        //    }
        //    return View();
        //}
        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HomeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController/Create
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

        // GET: HomeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController/Edit/5
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

        // GET: HomeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController/Delete/5
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
