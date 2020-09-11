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
            var model = db.SanPham.ToList();
            return View(model);
        }

        public ActionResult Category()
        {
            var model = db.SanPham.ToList();
            return View(model);
        }

        public ActionResult List()
        {
            var model = db.SanPham.ToList();
            return View(model);
        }

        //GioHang
        public ActionResult Cart()
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
            return RedirectToAction("Category");
        }

        public ActionResult Delete(int id)
        {
            var model = db.GioHang.Find(id);
            if (id != null)
            {
                db.GioHang.Remove(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

            public ActionResult Confirm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BillCreate(DonHang model)
        {
            if (ModelState.IsValid)
            {
                model.NgayGio = DateTime.Now;   
                model.TrangThai = "Chưa xác nhận";
                
                db.DonHang.Add(model);
                db.SaveChanges();

                var GioHang = Session["GioHang"] as List<GioHang>;
                foreach (var monHang in GioHang)
                {
                    var gioHang = new GioHang();
                    gioHang.id = model.id;
                    gioHang.DonGia = monHang.SanPham.DonGia;
                    gioHang.SoLuong = 1;
                    gioHang.idSanPham = monHang.SanPham.id;
                    db.GioHang.Add(gioHang);
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else return View(model);
        }


    }
}