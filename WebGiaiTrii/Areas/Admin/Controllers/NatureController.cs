using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGiaiTrii.Models;

namespace WebGiaiTrii.Areas.Admin.Controllers
{
    public class NatureController : Controller
    {
        // GET: Admin/Nature
        entertainmentEntities2 db = new entertainmentEntities2();
        public ActionResult ListNatures()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                List<Nature> animal = db.Natures.ToList();
                return View(animal);
            }
        }

        public ActionResult Create()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Create(Nature model, HttpPostedFileBase file1, HttpPostedFileBase file2, HttpPostedFileBase file3, HttpPostedFileBase file4)
        {
            if (file1 != null && file1.ContentLength > 0 && file2 != null && file2.ContentLength > 0 && file3 != null && file3.ContentLength > 0 && file4 != null && file4.ContentLength > 0)
            {
                string thuMuc = "/DataI";

                // Save the first image
                string name1 = Path.GetFileName(file1.FileName);
                var fullPath1 = Path.Combine(Server.MapPath(thuMuc), name1);
                file1.SaveAs(fullPath1);
                model.Image = Path.Combine(thuMuc, name1);

                // Save the second image
                string name2 = Path.GetFileName(file2.FileName);
                var fullPath2 = Path.Combine(Server.MapPath(thuMuc), name2);
                file2.SaveAs(fullPath2);
                model.Imagee = Path.Combine(thuMuc, name2);

                // Save the second image
                string name3 = Path.GetFileName(file3.FileName);
                var fullPath3 = Path.Combine(Server.MapPath(thuMuc), name3);
                file3.SaveAs(fullPath3);
                model.Image03 = Path.Combine(thuMuc, name3);

                // Save the second image
                string name4 = Path.GetFileName(file4.FileName);
                var fullPath4 = Path.Combine(Server.MapPath(thuMuc), name4);
                file4.SaveAs(fullPath4);
                model.Image04 = Path.Combine(thuMuc, name4);
            }


            db.Natures.Add(model);
            db.SaveChanges();

            return RedirectToAction("ListNatures");
        }

        public ActionResult Update(int ID)
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                Nature model2 = db.Natures.Find(ID);
                return View(model2);
            }
        }

        [HttpPost]
        public ActionResult Update(Nature model, HttpPostedFileBase file1, HttpPostedFileBase file2, HttpPostedFileBase file3, HttpPostedFileBase file4)
        {
            if (file1 != null && file1.ContentLength > 0)
            {
                string thuMuc = "/DataI";
                string name1 = Path.GetFileName(file1.FileName);
                var fullPath1 = Path.Combine(Server.MapPath(thuMuc), name1);
                file1.SaveAs(fullPath1);
                model.Image = Path.Combine(thuMuc, name1);
            }

            if (file2 != null && file2.ContentLength > 0)
            {
                string thuMuc = "/DataI";
                string name2 = Path.GetFileName(file2.FileName);
                var fullPath2 = Path.Combine(Server.MapPath(thuMuc), name2);
                file2.SaveAs(fullPath2);
                model.Imagee = Path.Combine(thuMuc, name2);
            }

            if (file3 != null && file3.ContentLength > 0)
            {
                string thuMuc = "/DataI";
                string name3 = Path.GetFileName(file3.FileName);
                var fullPath3 = Path.Combine(Server.MapPath(thuMuc), name3);
                file3.SaveAs(fullPath3);
                model.Image03 = Path.Combine(thuMuc, name3);
            }
            if (file4 != null && file4.ContentLength > 0)
            {
                string thuMuc = "/DataI";
                string name4 = Path.GetFileName(file4.FileName);
                var fullPath4 = Path.Combine(Server.MapPath(thuMuc), name4);
                file4.SaveAs(fullPath4);
                model.Image04 = Path.Combine(thuMuc, name4);
            }

            var updateModel = db.Natures.Find(model.ID);
            updateModel.Name = model.Name;
            updateModel.Note = model.Note;
            updateModel.Blog = model.Blog;
            updateModel.Image = model.Image;
            updateModel.Imagee = model.Imagee;
            updateModel.Image03 = model.Image03;
            updateModel.Image04 = model.Image04;

            db.SaveChanges();
            return RedirectToAction("ListNatures");
        }


        public ActionResult Drop(int ID)
        {
            var updateModel = db.Natures.Find(ID);
            db.Natures.Remove(updateModel);
            db.SaveChanges();

            return RedirectToAction("ListNatures");
        }

    }
}