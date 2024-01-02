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
        public ActionResult Nature()
        {
            return View();
        }

      




        public entertainmentEntities2 db = new entertainmentEntities2();
        public string message = "";

        public ActionResult NiceHouse()
        {
            var oo = db.Houses.ToList();

            return PartialView(oo);
        }

      /*  public ActionResult NiceHouseDetail( int ID)
        {
            var ii = db.Houses.Find(ID);
            return PartialView(ii);
        }  */

        public ActionResult NiceHouseDetail(int ID)
        {
            entertainmentEntities2 db = new entertainmentEntities2();
            House model2 = db.Houses.Find(ID);

            return View(model2);
        }


        public ActionResult LovelyAnimals()
        {
            return View();
        }
    }
}