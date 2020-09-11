using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lucci_Web.Models;
namespace Lucci_Web.Controllers
{
    public class GioHangController : Controller
    {
        CS4PET1Entities db = new CS4PET1Entities();
        // GET: GioHang
        public ActionResult DSGioHang()
        {

            var model = db.GioHangs.ToList();
            return View(model);

        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(GioHang model)
        {
            if (ModelState.IsValid)
            {
                db.GioHangs.Add(model);
                db.SaveChanges();
                return RedirectToAction("DSGioHang");
            }
            else
                return View(model);
        }
        public ActionResult Edit(int id)
        {
            var model = db.GioHangs.Find(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(GioHang model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DSGioHang");
            }
            else
                return View(model);
        }

        public ActionResult Delete(int id)
        {
            var model = db.GioHangs.Find(id);
            return View(model);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            GioHang model = db.GioHangs.Find(id);
            db.GioHangs.Remove(model);
            db.SaveChanges();
            return RedirectToAction("DSGioHang");
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