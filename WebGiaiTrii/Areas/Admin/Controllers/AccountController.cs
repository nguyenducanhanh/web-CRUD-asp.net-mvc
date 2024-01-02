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
        // GET: Admin/Account

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
            var nhanVien = db.Accounts.SingleOrDefault(m => m.Username.ToLower() == user.ToLower() && m.Password == password);
            // check code
            if (nhanVien != null)
            {
                Session["user"] = nhanVien;
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