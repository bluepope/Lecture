using Lecture.DapperWebDemo.Models;
using Lecture.Lib.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lecture.DapperWebDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var db = new SqlDapperHelper())
            {
                return View(BoardModel.GetList(db, ""));
            }
        }
        public ActionResult BoardInput(BoardModel input)
        {
            if (ModelState.IsValid)
            {
                //적합함
                //input.Insert(db);
            }

            return Json(new { msg = "OK" }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}