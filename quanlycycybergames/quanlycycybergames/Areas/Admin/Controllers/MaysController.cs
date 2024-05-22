using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using quanlycycybergames.Models;

namespace quanlycycybergames.Areas.Admin.Controllers
{
    public class MaysController : Controller
    {
        private QuanLyCYBERGAMESEntities db = new QuanLyCYBERGAMESEntities();

        // GET: Admin/Mays
        public ActionResult Index()
        {
            
            var may = db.May.Include(m => m.TaiKhoan);
            return View(may.ToList());
        }

        // GET: Admin/Mays/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            May may = db.May.Find(id);
            if (may == null)
            {
                return HttpNotFound();
            }
            return View(may);
        }

        // GET: Admin/Mays/Create
        public ActionResult Create()
        {
            List<TaiKhoan> List = db.TaiKhoan.ToList();
            ViewBag.TK = List;
            ViewBag.ID_TaiKhoan = new SelectList(db.TaiKhoan, "ID_TaiKhoan", "TenTaiKhoan");
            return View();
        }

        // POST: Admin/Mays/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_May,TenMay,GiaMay,HoatDong,ThoiGianMo,ThoiGianTat,TongTien,ID_TaiKhoan")] May may)
        {
            if (ModelState.IsValid)
            {
                TimeSpan thoiGianSuDung = (may.ThoiGianTat - may.ThoiGianMo) ?? TimeSpan.Zero;
                decimal? tongTien = Convert.ToDecimal(thoiGianSuDung.TotalHours) * decimal.Parse(may.GiaMay);
                may.TongTien = tongTien;
                TaiKhoan taiKhoan = db.TaiKhoan.Find(may.ID_TaiKhoan);
                if (taiKhoan != null)
                {
                    // Subtract the TongTien from the account balance
                    taiKhoan.SoTienNap -= tongTien;
                    db.Entry(taiKhoan).State = EntityState.Modified;
                }
                db.May.Add(may);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            List<TaiKhoan> List = db.TaiKhoan.ToList();
            ViewBag.TK = List;
            ViewBag.ID_TaiKhoan = new SelectList(db.TaiKhoan, "ID_TaiKhoan", "TenTaiKhoan", may.ID_TaiKhoan);
            return View(may);
        }

        // GET: Admin/Mays/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            May may = db.May.Find(id);
            if (may == null)
            {
                return HttpNotFound();
            }
            List<TaiKhoan> List = db.TaiKhoan.ToList();
            ViewBag.TK = List;
            ViewBag.ID_TaiKhoan = new SelectList(db.TaiKhoan, "ID_TaiKhoan", "TenTaiKhoan", may.ID_TaiKhoan);
            return View(may);
        }

        // POST: Admin/Mays/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_May,TenMay,GiaMay,HoatDong,ThoiGianMo,ThoiGianTat,TongTien,ID_TaiKhoan")] May may)
        {
            if (ModelState.IsValid)
            {
                TimeSpan thoiGianSuDung = (may.ThoiGianTat - may.ThoiGianMo) ?? TimeSpan.Zero;
                decimal? tongTien = Convert.ToDecimal(thoiGianSuDung.TotalHours) * decimal.Parse(may.GiaMay);
                may.TongTien = tongTien;
                TaiKhoan taiKhoan = db.TaiKhoan.Find(may.ID_TaiKhoan);
                if (taiKhoan != null)
                {
                    // Subtract the TongTien from the account balance
                    taiKhoan.SoTienNap -= tongTien;
                    db.Entry(taiKhoan).State = EntityState.Modified;
                }
                db.Entry(may).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            List<TaiKhoan> List = db.TaiKhoan.ToList();
            ViewBag.TK = List;
            ViewBag.ID_TaiKhoan = new SelectList(db.TaiKhoan, "ID_TaiKhoan", "TenTaiKhoan", may.ID_TaiKhoan);
            return View(may);
        }

        // GET: Admin/Mays/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            May may = db.May.Find(id);
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
            May may = db.May.Find(id);
            db.May.Remove(may);
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
