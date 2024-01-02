using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGiaiTrii.Models;

namespace WebGiaiTrii.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        entertainmentEntities2 db = new entertainmentEntities2();
        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string user, string password)
        {
            var acc = db.Accounts.SingleOrDefault(m => m.Username.ToLower() == user.ToLower() && m.Password == password);
            // check code
            if (acc != null)
            {
                Session["user"] = acc;
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "ko dung ";
                return View();
            }
        }

    }
}