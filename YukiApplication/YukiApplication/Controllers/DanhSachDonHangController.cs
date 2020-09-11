using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YukiApplication.Models;

namespace YukiApplication.Controllers
{

    public class DanhSachDonHangController : Controller
    {
        CS4PET1Entities db = new CS4PET1Entities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DSDonHang()
        {

            var model = db.DonHang.ToList();
            return View(model);

        }
        public ActionResult XacnhanDonHang(int id)
        {
            var model = db.DonHang.Find(id);
            return View(model);
        }
        public ActionResult XacnhanDonHang(GioHang model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DSDonHang");
            }
            else
                return View(model);
        }

    }
}