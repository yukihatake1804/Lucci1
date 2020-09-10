using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YukiApplication.Models;

namespace YukiApplication.Controllers
{
    public class HomeController : Controller
    {
        CS4PET1Entities db = new CS4PET1Entities();
        public ActionResult Index()
        {
            return View();
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

        public ActionResult Female()
        {
            var model = db.SanPham.ToList();
            return View(model);
        }

        public ActionResult Male()
        {
            ViewBag.Message = "Your men page.";

            return View();
        }

        public ActionResult SingleProduct()
        {
            ViewBag.Message = "Your men page.";

            return View();
        }

        public ActionResult Category()
        {
            ViewBag.Message = "Your men page.";

            return View();
        }

        public ActionResult List()
        {
            var model = db.SanPham.ToList();
            return View(model);
        }
    }
}