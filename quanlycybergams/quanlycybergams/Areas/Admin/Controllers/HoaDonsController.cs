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
    public class HoaDonsController : Controller
    {
        private QuanLyCYBERGAMESEntities db = new QuanLyCYBERGAMESEntities();

        // GET: Admin/HoaDons
        public ActionResult Index()
        {
            var hoaDons = db.HoaDons.Include(h => h.TaiKhoan).Include(h => h.May).Include(h => h.ThanhToanDV);
            return View(hoaDons.ToList());
        }

        // GET: Admin/HoaDons/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon);
        }

        // GET: Admin/HoaDons/Create
        public ActionResult Create()
        {
            ViewBag.ID_KhachHang = new SelectList(db.TaiKhoans, "ID_KhachHang", "TenKhachHang");
            ViewBag.ID_May = new SelectList(db.Mays, "ID_May", "TenMay");
            ViewBag.ID_TTDV = new SelectList(db.ThanhToanDVs, "ID_TTDV", "ID_KhachHang");
            return View();
        }

        // POST: Admin/HoaDons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_HoaDon,ID_TTDV,ID_May,ThoiGianMo,ThoiGianTat,TongTien,TinhTrangHD,ID_KhachHang")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                db.HoaDons.Add(hoaDon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_KhachHang = new SelectList(db.TaiKhoans, "ID_KhachHang", "TenKhachHang", hoaDon.ID_KhachHang);
            ViewBag.ID_May = new SelectList(db.Mays, "ID_May", "TenMay", hoaDon.ID_May);
            ViewBag.ID_TTDV = new SelectList(db.ThanhToanDVs, "ID_TTDV", "ID_KhachHang", hoaDon.ID_TTDV);
            return View(hoaDon);
        }

        // GET: Admin/HoaDons/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_KhachHang = new SelectList(db.TaiKhoans, "ID_KhachHang", "TenKhachHang", hoaDon.ID_KhachHang);
            ViewBag.ID_May = new SelectList(db.Mays, "ID_May", "TenMay", hoaDon.ID_May);
            ViewBag.ID_TTDV = new SelectList(db.ThanhToanDVs, "ID_TTDV", "ID_KhachHang", hoaDon.ID_TTDV);
            return View(hoaDon);
        }

        // POST: Admin/HoaDons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_HoaDon,ID_TTDV,ID_May,ThoiGianMo,ThoiGianTat,TongTien,TinhTrangHD,ID_KhachHang")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoaDon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_KhachHang = new SelectList(db.TaiKhoans, "ID_KhachHang", "TenKhachHang", hoaDon.ID_KhachHang);
            ViewBag.ID_May = new SelectList(db.Mays, "ID_May", "TenMay", hoaDon.ID_May);
            ViewBag.ID_TTDV = new SelectList(db.ThanhToanDVs, "ID_TTDV", "ID_KhachHang", hoaDon.ID_TTDV);
            return View(hoaDon);
        }

        // GET: Admin/HoaDons/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon);
        }

        // POST: Admin/HoaDons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HoaDon hoaDon = db.HoaDons.Find(id);
            db.HoaDons.Remove(hoaDon);
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
