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
            var hoaDons = db.HoaDons.Include(h => h.DonHang).Include(h => h.TaiKhoan);
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
            List<TaiKhoan> list = db.TaiKhoans.ToList();
            ViewBag.KH = list;
            List<DonHang> List = db.DonHangs.ToList();
            ViewBag.DH = List;
            List<May> ist = db.Mays.ToList();
            ViewBag.May = ist;
            ViewBag.MaDH = new SelectList(db.DonHangs, "MaDH", "ID_DV");
            ViewBag.ID_KhachHang = new SelectList(db.TaiKhoans, "ID_KhachHang", "TenKhachHang");
            ViewBag.ID_May = new SelectList(db.Mays, "ID_May", "TenMay");
            return View();
        }

        // POST: Admin/HoaDons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_HoaDon,ID_May,ThoiGianMo,ThoiGianTat,TongTien,TinhTrangHD,ID_KhachHang,MaDH")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                db.HoaDons.Add(hoaDon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            List<TaiKhoan> list = db.TaiKhoans.ToList();
            ViewBag.KH = list;
            List<DonHang> List = db.DonHangs.ToList();
            ViewBag.DH = List;
            List<May> ist = db.Mays.ToList();
            ViewBag.May = ist;
            ViewBag.MaDH = new SelectList(db.DonHangs, "MaDH", "ID_DV", hoaDon.MaDH);
            ViewBag.ID_KhachHang = new SelectList(db.TaiKhoans, "ID_KhachHang", "TenKhachHang", hoaDon.ID_KhachHang);
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
            List<TaiKhoan> list = db.TaiKhoans.ToList();
            ViewBag.KH = list;
            List<DonHang> List = db.DonHangs.ToList();
            ViewBag.DH = List;
            List<May> ist = db.Mays.ToList();
            ViewBag.May = ist;
            ViewBag.MaDH = new SelectList(db.DonHangs, "MaDH", "ID_DV", hoaDon.MaDH);
            ViewBag.ID_KhachHang = new SelectList(db.TaiKhoans, "ID_KhachHang", "TenKhachHang", hoaDon.ID_KhachHang);
            return View(hoaDon);
        }

        // POST: Admin/HoaDons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_HoaDon,ID_May,ThoiGianMo,ThoiGianTat,TongTien,TinhTrangHD,ID_KhachHang,MaDH")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoaDon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDH = new SelectList(db.DonHangs, "MaDH", "ID_DV", hoaDon.MaDH);
            ViewBag.ID_KhachHang = new SelectList(db.TaiKhoans, "ID_KhachHang", "TenKhachHang", hoaDon.ID_KhachHang);
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
