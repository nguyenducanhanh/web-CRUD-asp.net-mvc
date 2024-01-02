using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGiaiTrii.Models;

namespace WebGiaiTrii.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home      
        public entertainmentEntities2 db = new entertainmentEntities2();
        public string message = "";

        public ActionResult NiceHouse()
        {
            var oo = db.Houses.ToList();
            return PartialView(oo);
        }

        public ActionResult NiceHouseDetail(int ID)
        {
            House model2 = db.Houses.Find(ID);
            return View(model2);
        }

        public ActionResult Animal()
        {
            var an = db.Animals.ToList();
            return PartialView(an);
        }

        public ActionResult AnimalDetail(int ID)
        {
            Animal mo = db.Animals.Find(ID);
            return View(mo);
        }

        public ActionResult Nature()
        {
            var oo = db.Natures.ToList();
            return PartialView(oo);
        }

        public ActionResult NatureDetail(int ID)
        {
            Nature model2 = db.Natures.Find(ID);
            return View(model2);
        }
    }
}