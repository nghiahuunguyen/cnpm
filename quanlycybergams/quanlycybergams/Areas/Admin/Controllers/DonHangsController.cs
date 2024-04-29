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
    public class DonHangsController : Controller
    {
        private QuanLyCYBERGAMESEntities db = new QuanLyCYBERGAMESEntities();

        // GET: Admin/DonHangs
        public ActionResult Index()
        {
            var donHangs = db.DonHangs.Include(d => d.DichVu).Include(d => d.TaiKhoan);
            return View(donHangs.ToList());
        }

        // GET: Admin/DonHangs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang donHang = db.DonHangs.Find(id);
            if (donHang == null)
            {
                return HttpNotFound();
            }
            return View(donHang);
        }

        // GET: Admin/DonHangs/Create
        public ActionResult Create()
        {
            ViewBag.ID_DV = new SelectList(db.DichVus, "ID_DV", "TenDV");
            ViewBag.ID_KhachHang = new SelectList(db.TaiKhoans, "ID_KhachHang", "TenKhachHang");
            return View();
        }

        // POST: Admin/DonHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDH,ID_DV,tongGia,ghiChu,ngayDatHang,ID_KhachHang")] DonHang donHang)
        {
            if (ModelState.IsValid)
            {
                db.DonHangs.Add(donHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_DV = new SelectList(db.DichVus, "ID_DV", "TenDV", donHang.ID_DV);
            ViewBag.ID_KhachHang = new SelectList(db.TaiKhoans, "ID_KhachHang", "TenKhachHang", donHang.ID_KhachHang);
            return View(donHang);
        }

        // GET: Admin/DonHangs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang donHang = db.DonHangs.Find(id);
            if (donHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_DV = new SelectList(db.DichVus, "ID_DV", "TenDV", donHang.ID_DV);
            ViewBag.ID_KhachHang = new SelectList(db.TaiKhoans, "ID_KhachHang", "TenKhachHang", donHang.ID_KhachHang);
            return View(donHang);
        }

        // POST: Admin/DonHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDH,ID_DV,tongGia,ghiChu,ngayDatHang,ID_KhachHang")] DonHang donHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_DV = new SelectList(db.DichVus, "ID_DV", "TenDV", donHang.ID_DV);
            ViewBag.ID_KhachHang = new SelectList(db.TaiKhoans, "ID_KhachHang", "TenKhachHang", donHang.ID_KhachHang);
            return View(donHang);
        }

        // GET: Admin/DonHangs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang donHang = db.DonHangs.Find(id);
            if (donHang == null)
            {
                return HttpNotFound();
            }
            return View(donHang);
        }

        // POST: Admin/DonHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DonHang donHang = db.DonHangs.Find(id);
            db.DonHangs.Remove(donHang);
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
