using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YukiApplication.Models;

namespace Web.Controllers
{
    public class GioHangController : Controller
    {
        CS4PET1Entities db = new CS4PET1Entities();
        public ActionResult Index()
        {
            var model = new List<GioHang>();
            if (Session["GioHang"] != null)
            {
                model = Session["GioHang"] as List<GioHang>;
            }
            return View(model);
        }

        public ActionResult Create(int productId)
        {
            // Get GioHang
            var GioHang = new List<GioHang>();
            if (Session["GioHang"] != null)
            {
                GioHang = Session["GioHang"] as List<GioHang>;
            }
            // Create new item
            var model = new GioHang();
            model.SanPham = db.SanPham.Find(productId);
            // Add to GioHang
            GioHang.Add(model);
            Session["GioHang"] = GioHang;
            return RedirectToAction("Index");
        }

        public ActionResult Thongtinkhachhang()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}