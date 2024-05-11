using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using quanlycybergams.Models;

namespace quanlycybergams.Areas.Admin.Controllers
{
    public class MaysController : Controller
    {
        private QuanLyCYBERGAMESEntities1 db = new QuanLyCYBERGAMESEntities1();

        // GET: Admin/Mays
        public ActionResult Index()
        {
            return View(db.Mays.ToList());
        }

        // GET: Admin/Mays/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            May may = db.Mays.Find(id);
            if (may == null)
            {
                return HttpNotFound();
            }
            return View(may);
        }

        // GET: Admin/Mays/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Mays/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_May,TenMay,GiaMay,HoatDong,ThoiGianMo,ThoiGianTat,TongTien")] May may)
        {
            if (ModelState.IsValid)
            {
                TimeSpan thoiGianSuDung = (may.ThoiGianTat - may.ThoiGianMo) ?? TimeSpan.Zero;
                decimal? tongTien = Convert.ToDecimal(thoiGianSuDung.TotalHours) * decimal.Parse(may.GiaMay);
                may.TongTien = tongTien;
                db.Mays.Add(may);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(may);
        }

        // GET: Admin/Mays/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            May may = db.Mays.Find(id);
            if (may == null)
            {
                return HttpNotFound();
            }
            return View(may);
        }

        // POST: Admin/Mays/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_May,TenMay,GiaMay,HoatDong,ThoiGianMo,ThoiGianTat,TongTien")] May may)
        {
            if (ModelState.IsValid)
            {
                TimeSpan thoiGianSuDung = (may.ThoiGianTat - may.ThoiGianMo) ?? TimeSpan.Zero;
                decimal? tongTien = Convert.ToDecimal(thoiGianSuDung.TotalHours) * decimal.Parse(may.GiaMay);
                may.TongTien = tongTien;
                db.Entry(may).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(may);
        }

        // GET: Admin/Mays/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            May may = db.Mays.Find(id);
            if (may == null)
            {
                return HttpNotFound();
            }
            return View(may);
        }

        // POST: Admin/Mays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            May may = db.Mays.Find(id);
            db.Mays.Remove(may);
            db.SaveChanges();
            return RedirectToAction("Index");
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
