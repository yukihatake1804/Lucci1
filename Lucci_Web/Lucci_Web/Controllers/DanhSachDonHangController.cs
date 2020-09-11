using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lucci_Web.Models;
namespace Lucci_Web.Controllers
{
    public class DanhSachDonHangController : Controller
    {
        CS4PET1Entities db = new CS4PET1Entities();
        // GET: DanhSachDonHang
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DSDonHang()
        {

            var model = db.DonHangs.ToList();
            return View(model);

        }
        public ActionResult XacnhanDonHang(int id)
        {
            var model = db.DonHangs.Find(id);
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
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(DonHang model)
        {
            if (ModelState.IsValid)
            {
                db.DonHangs.Add(model);
                db.SaveChanges();
                return RedirectToAction("DSDonHang");
            }
            else
                return View(model);
        }

        public ActionResult Delete(int id)
        {
            var model = db.DonHangs.Find(id);
            return View(model);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            DonHang model = db.DonHangs.Find(id);
            db.DonHangs.Remove(model);
            db.SaveChanges();
            return RedirectToAction("DSDonHang");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}