using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGiaiTrii.Models;

namespace WebGiaiTrii.Areas.Admin.Controllers
{
    public class AnimalsController : Controller
    {
        // GET: Admin/Animals
        public ActionResult List()
        {
            entertainmentEntities2 db = new entertainmentEntities2();
            List<Animal> house = db.Animals.ToList();
            return View(house);
        }


        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Animal model, HttpPostedFileBase file)
        {
            if (file.ContentLength > 0)
            {
                string thuMuc = "/DataIo";
                string name = file.FileName;
                var fullPath = Server.MapPath(thuMuc) + name;
                file.SaveAs(fullPath);
                model.ImageA01 = thuMuc + name;
            }

            entertainmentEntities2 db = new entertainmentEntities2();
            db.Animals.Add(model);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Update(int ID)
        {
            entertainmentEntities2 db = new entertainmentEntities2();
            Animal model222 = db.Animals.Find(ID);

            return View(model222);
        }
        [HttpPost]
        public ActionResult Update(Animal model, HttpPostedFileBase file)
        {
            if (file.ContentLength > 0)
            {
                string thuMuc = "/DataIo";
                string name = file.FileName;
                var fullPath = Server.MapPath(thuMuc) + name;
                file.SaveAs(fullPath);
                model.ImageA01 = thuMuc + name;
            }
            entertainmentEntities2 db = new entertainmentEntities2();
            var updateModel = db.Animals.Find(model.ID);
            updateModel.NameAnimals = model.NameAnimals;
            updateModel.NoteA = model.NoteA;
            updateModel.BlogA = model.BlogA;
            updateModel.ImageA01 = model.ImageA01;
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Drop(int ID)
        {
            entertainmentEntities2 db = new entertainmentEntities2();
            var updateModel = db.Animals.Find(ID);
            db.Animals.Remove(updateModel);
            db.SaveChanges();

            return RedirectToAction("List");
        }
    }
}