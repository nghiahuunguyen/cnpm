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
    public class ChiTietDonHangsController : Controller
    {
        private QuanLyCYBERGAMESEntities1 db = new QuanLyCYBERGAMESEntities1();

        // GET: Admin/ChiTietDonHangs
        public ActionResult Index()
        {
<<<<<<< HEAD
            var chiTietDonHangs = db.ChiTietDonHangs.Include(c => c.DichVu).Include(c => c.DonHang);
            return View(chiTietDonHangs.ToList());
=======
<<<<<<<< HEAD:quanlycybergams/quanlycybergams/Areas/Admin/Controllers/DonHangsController.cs
            var donHangs = db.DonHangs.Include(d => d.TaiKhoan);
            return View(donHangs.ToList());
========
            var chiTietDonHangs = db.ChiTietDonHangs.Include(c => c.DichVu).Include(c => c.DonHang);
            return View(chiTietDonHangs.ToList());
>>>>>>>> 58896a978fbc5910d88e4176419133ab5d25ef10:quanlycybergams/quanlycybergams/Areas/Admin/Controllers/ChiTietDonHangsController.cs
>>>>>>> 58896a978fbc5910d88e4176419133ab5d25ef10
        }

        // GET: Admin/ChiTietDonHangs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietDonHang chiTietDonHang = db.ChiTietDonHangs.Find(id);
            if (chiTietDonHang == null)
            {
                return HttpNotFound();
            }
            return View(chiTietDonHang);
        }

        // GET: Admin/ChiTietDonHangs/Create
        public ActionResult Create()
        {
<<<<<<< HEAD
            List<DichVu> List = db.DichVus.ToList();
            ViewBag.DichVu = List;
            ViewBag.ID_DV = new SelectList(db.DichVus, "ID_DV", "TenDV");
            ViewBag.MaDH = new SelectList(db.DonHangs, "MaDH", "ID_KhachHang");
=======
<<<<<<<< HEAD:quanlycybergams/quanlycybergams/Areas/Admin/Controllers/DonHangsController.cs
            List<TaiKhoan> List = db.TaiKhoans.ToList();
            ViewBag.KH = List;
            ViewBag.ID_KhachHang = new SelectList(db.TaiKhoans, "ID_KhachHang", "TenKhachHang");
========
            ViewBag.ID_DV = new SelectList(db.DichVus, "ID_DV", "TenDV");
            ViewBag.MaDH = new SelectList(db.DonHangs, "MaDH", "ID_KhachHang");
>>>>>>>> 58896a978fbc5910d88e4176419133ab5d25ef10:quanlycybergams/quanlycybergams/Areas/Admin/Controllers/ChiTietDonHangsController.cs
>>>>>>> 58896a978fbc5910d88e4176419133ab5d25ef10
            return View();
        }

        // POST: Admin/ChiTietDonHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
<<<<<<< HEAD
        public ActionResult Create([Bind(Include = "MaDH,ID_DV,soluong,tongGia")] ChiTietDonHang chiTietDonHang)
        {
            if (ModelState.IsValid)
            {
                List<DichVu> List = db.DichVus.ToList();
                ViewBag.DichVu = List;
=======
<<<<<<<< HEAD:quanlycybergams/quanlycybergams/Areas/Admin/Controllers/DonHangsController.cs
        public ActionResult Create([Bind(Include = "MaDH,ngayDatHang,ID_KhachHang,tongGia")] DonHang donHang)
========
        public ActionResult Create([Bind(Include = "MaDH,ID_DV,soluong,tongGia")] ChiTietDonHang chiTietDonHang)
>>>>>>>> 58896a978fbc5910d88e4176419133ab5d25ef10:quanlycybergams/quanlycybergams/Areas/Admin/Controllers/ChiTietDonHangsController.cs
        {
            if (ModelState.IsValid)
            {
>>>>>>> 58896a978fbc5910d88e4176419133ab5d25ef10
                db.ChiTietDonHangs.Add(chiTietDonHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
<<<<<<< HEAD
=======
<<<<<<<< HEAD:quanlycybergams/quanlycybergams/Areas/Admin/Controllers/DonHangsController.cs
            List<TaiKhoan> List = db.TaiKhoans.ToList();
            ViewBag.KH = List;
            ViewBag.ID_KhachHang = new SelectList(db.TaiKhoans, "ID_KhachHang", "TenKhachHang", donHang.ID_KhachHang);
            return View(donHang);
========
>>>>>>> 58896a978fbc5910d88e4176419133ab5d25ef10

            ViewBag.ID_DV = new SelectList(db.DichVus, "ID_DV", "TenDV", chiTietDonHang.ID_DV);
            ViewBag.MaDH = new SelectList(db.DonHangs, "MaDH", "ID_KhachHang", chiTietDonHang.MaDH);
            return View(chiTietDonHang);
<<<<<<< HEAD
=======
>>>>>>>> 58896a978fbc5910d88e4176419133ab5d25ef10:quanlycybergams/quanlycybergams/Areas/Admin/Controllers/ChiTietDonHangsController.cs
>>>>>>> 58896a978fbc5910d88e4176419133ab5d25ef10
        }

        // GET: Admin/ChiTietDonHangs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietDonHang chiTietDonHang = db.ChiTietDonHangs.Find(id);
            if (chiTietDonHang == null)
            {
                return HttpNotFound();
            }
<<<<<<< HEAD
            ViewBag.ID_DV = new SelectList(db.DichVus, "ID_DV", "TenDV", chiTietDonHang.ID_DV);
            ViewBag.MaDH = new SelectList(db.DonHangs, "MaDH", "ID_KhachHang", chiTietDonHang.MaDH);
            return View(chiTietDonHang);
=======
<<<<<<<< HEAD:quanlycybergams/quanlycybergams/Areas/Admin/Controllers/DonHangsController.cs
            List<TaiKhoan> List = db.TaiKhoans.ToList();
            ViewBag.KH = List;
            ViewBag.ID_KhachHang = new SelectList(db.TaiKhoans, "ID_KhachHang", "TenKhachHang", donHang.ID_KhachHang);
            return View(donHang);
========
            ViewBag.ID_DV = new SelectList(db.DichVus, "ID_DV", "TenDV", chiTietDonHang.ID_DV);
            ViewBag.MaDH = new SelectList(db.DonHangs, "MaDH", "ID_KhachHang", chiTietDonHang.MaDH);
            return View(chiTietDonHang);
>>>>>>>> 58896a978fbc5910d88e4176419133ab5d25ef10:quanlycybergams/quanlycybergams/Areas/Admin/Controllers/ChiTietDonHangsController.cs
>>>>>>> 58896a978fbc5910d88e4176419133ab5d25ef10
        }

        // POST: Admin/ChiTietDonHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
<<<<<<< HEAD
        public ActionResult Edit([Bind(Include = "MaDH,ID_DV,soluong,tongGia")] ChiTietDonHang chiTietDonHang)
=======
<<<<<<<< HEAD:quanlycybergams/quanlycybergams/Areas/Admin/Controllers/DonHangsController.cs
        public ActionResult Edit([Bind(Include = "MaDH,ngayDatHang,ID_KhachHang,tongGia")] DonHang donHang)
========
        public ActionResult Edit([Bind(Include = "MaDH,ID_DV,soluong,tongGia")] ChiTietDonHang chiTietDonHang)
>>>>>>>> 58896a978fbc5910d88e4176419133ab5d25ef10:quanlycybergams/quanlycybergams/Areas/Admin/Controllers/ChiTietDonHangsController.cs
>>>>>>> 58896a978fbc5910d88e4176419133ab5d25ef10
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiTietDonHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
<<<<<<< HEAD
            ViewBag.ID_DV = new SelectList(db.DichVus, "ID_DV", "TenDV", chiTietDonHang.ID_DV);
            ViewBag.MaDH = new SelectList(db.DonHangs, "MaDH", "ID_KhachHang", chiTietDonHang.MaDH);
            return View(chiTietDonHang);
=======
<<<<<<<< HEAD:quanlycybergams/quanlycybergams/Areas/Admin/Controllers/DonHangsController.cs
            List<TaiKhoan> List = db.TaiKhoans.ToList();
            ViewBag.KH = List;
            ViewBag.ID_KhachHang = new SelectList(db.TaiKhoans, "ID_KhachHang", "TenKhachHang", donHang.ID_KhachHang);
            return View(donHang);
========
            ViewBag.ID_DV = new SelectList(db.DichVus, "ID_DV", "TenDV", chiTietDonHang.ID_DV);
            ViewBag.MaDH = new SelectList(db.DonHangs, "MaDH", "ID_KhachHang", chiTietDonHang.MaDH);
            return View(chiTietDonHang);
>>>>>>>> 58896a978fbc5910d88e4176419133ab5d25ef10:quanlycybergams/quanlycybergams/Areas/Admin/Controllers/ChiTietDonHangsController.cs
>>>>>>> 58896a978fbc5910d88e4176419133ab5d25ef10
        }

        // GET: Admin/ChiTietDonHangs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietDonHang chiTietDonHang = db.ChiTietDonHangs.Find(id);
            if (chiTietDonHang == null)
            {
                return HttpNotFound();
            }
            return View(chiTietDonHang);
        }

        // POST: Admin/ChiTietDonHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ChiTietDonHang chiTietDonHang = db.ChiTietDonHangs.Find(id);
            db.ChiTietDonHangs.Remove(chiTietDonHang);
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
