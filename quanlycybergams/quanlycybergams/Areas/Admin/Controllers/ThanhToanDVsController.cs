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
    public class ThanhToanDVsController : Controller
    {
        private QuanLyCYBERGAMESEntities db = new QuanLyCYBERGAMESEntities();

        // GET: Admin/ThanhToanDVs
        public ActionResult Index()
        {
            var thanhToanDVs = db.ThanhToanDVs.Include(t => t.TaiKhoan);
            return View(thanhToanDVs.ToList());
        }

        // GET: Admin/ThanhToanDVs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThanhToanDV thanhToanDV = db.ThanhToanDVs.Find(id);
            if (thanhToanDV == null)
            {
                return HttpNotFound();
            }
            return View(thanhToanDV);
        }

        // GET: Admin/ThanhToanDVs/Create
        public ActionResult Create()
        {
            ViewBag.ID_KhachHang = new SelectList(db.TaiKhoans, "ID_KhachHang", "TenKhachHang");
            return View();
        }

        // POST: Admin/ThanhToanDVs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_TTDV,ID_KhachHang")] ThanhToanDV thanhToanDV)
        {
            if (ModelState.IsValid)
            {
                db.ThanhToanDVs.Add(thanhToanDV);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_KhachHang = new SelectList(db.TaiKhoans, "ID_KhachHang", "TenKhachHang", thanhToanDV.ID_KhachHang);
            return View(thanhToanDV);
        }

        // GET: Admin/ThanhToanDVs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThanhToanDV thanhToanDV = db.ThanhToanDVs.Find(id);
            if (thanhToanDV == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_KhachHang = new SelectList(db.TaiKhoans, "ID_KhachHang", "TenKhachHang", thanhToanDV.ID_KhachHang);
            return View(thanhToanDV);
        }

        // POST: Admin/ThanhToanDVs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_TTDV,ID_KhachHang")] ThanhToanDV thanhToanDV)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thanhToanDV).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_KhachHang = new SelectList(db.TaiKhoans, "ID_KhachHang", "TenKhachHang", thanhToanDV.ID_KhachHang);
            return View(thanhToanDV);
        }

        // GET: Admin/ThanhToanDVs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThanhToanDV thanhToanDV = db.ThanhToanDVs.Find(id);
            if (thanhToanDV == null)
            {
                return HttpNotFound();
            }
            return View(thanhToanDV);
        }

        // POST: Admin/ThanhToanDVs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ThanhToanDV thanhToanDV = db.ThanhToanDVs.Find(id);
            db.ThanhToanDVs.Remove(thanhToanDV);
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
