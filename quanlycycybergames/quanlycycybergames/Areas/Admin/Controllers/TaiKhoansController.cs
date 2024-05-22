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
    public class TaiKhoansController : Controller
    {
        private QuanLyCYBERGAMESEntities db = new QuanLyCYBERGAMESEntities();

        // GET: Admin/TaiKhoans
        public ActionResult Index(string searchString)
        {
            var taiKhoans = db.TaiKhoan.ToList();

            if (!string.IsNullOrEmpty(searchString))
            {
                taiKhoans = taiKhoans.Where(t =>t.TenTaiKhoan.Equals(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return View(taiKhoans);
        }

        // GET: Admin/TaiKhoans/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoan taiKhoan = db.TaiKhoan.Find(id);
            if (taiKhoan == null)
            {
                return HttpNotFound();
            }
            return View(taiKhoan);
        }

        // GET: Admin/TaiKhoans/Create
        public ActionResult Create()
        {
            List<KhachHang> List = db.KhachHang.ToList();
            ViewBag.KH = List;
            ViewBag.ID_KhachHang = new SelectList(db.KhachHang, "ID_KhachHang", "TenKhachHang");
            return View();
        }

        // POST: Admin/TaiKhoans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_TaiKhoan,TenTaiKhoan,Matkhau,ThoiGianNap,SoTienNap,ID_KhachHang")] TaiKhoan taiKhoan)
        {
            if (ModelState.IsValid)
            {
                if (db.TaiKhoan.Any(t => t.TenTaiKhoan.Equals(taiKhoan.TenTaiKhoan, StringComparison.OrdinalIgnoreCase)))
                {
                    ModelState.AddModelError("TenTaiKhoan", "Tên này đã có người dùng.");
                    ViewBag.KH = db.KhachHang.ToList();
                    ViewBag.ID_KhachHang = new SelectList(db.KhachHang, "ID_KhachHang", "TenKhachHang", taiKhoan.ID_KhachHang);
                    return View(taiKhoan);
                }

                db.TaiKhoan.Add(taiKhoan);
                db.SaveChanges();

                TempData["NotificationMessage"] = "Tạo mới tài khoản thành công";
                return RedirectToAction("Index");
            }

            ViewBag.KH = db.KhachHang.ToList();
            ViewBag.ID_KhachHang = new SelectList(db.KhachHang, "ID_KhachHang", "TenKhachHang", taiKhoan.ID_KhachHang);
            return View(taiKhoan);
        }

        // GET: Admin/TaiKhoans/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoan taiKhoan = db.TaiKhoan.Find(id);
            if (taiKhoan == null)
            {
                return HttpNotFound();
            }
            List<KhachHang> List = db.KhachHang.ToList();
            ViewBag.KH = List;
            ViewBag.ID_KhachHang = new SelectList(db.KhachHang, "ID_KhachHang", "TenKhachHang", taiKhoan.ID_KhachHang);
            return View(taiKhoan);
        }

        // POST: Admin/TaiKhoans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_TaiKhoan,TenTaiKhoan,Matkhau,ThoiGianNap,SoTienNap,ID_KhachHang")] TaiKhoan taiKhoan)
        {
            if (ModelState.IsValid)
            {
                var existingTaiKhoan = db.TaiKhoan.FirstOrDefault(t => t.ID_TaiKhoan != taiKhoan.ID_TaiKhoan && t.TenTaiKhoan.Equals(taiKhoan.TenTaiKhoan, StringComparison.OrdinalIgnoreCase));
                if (existingTaiKhoan != null)
                {
                    ModelState.AddModelError("TenTaiKhoan", "Tên này đã có người dùng.");
                    ViewBag.KH = db.KhachHang.ToList();
                    ViewBag.ID_KhachHang = new SelectList(db.KhachHang, "ID_KhachHang", "TenKhachHang", taiKhoan.ID_KhachHang);
                    return View(taiKhoan);
                }

                db.Entry(taiKhoan).State = EntityState.Modified;
                db.SaveChanges();

                TempData["NotificationMessage"] = "Cập nhật tài khoản thành công";
                return RedirectToAction("Index");
            }

            ViewBag.KH = db.KhachHang.ToList();
            ViewBag.ID_KhachHang = new SelectList(db.KhachHang, "ID_KhachHang", "TenKhachHang", taiKhoan.ID_KhachHang);
            return View(taiKhoan);
        }

        // GET: Admin/TaiKhoans/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoan taiKhoan = db.TaiKhoan.Find(id);
            if (taiKhoan == null)
            {
                return HttpNotFound();
            }
            return View(taiKhoan);
        }

        // POST: Admin/TaiKhoans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TaiKhoan taiKhoan = db.TaiKhoan.Find(id);
            db.TaiKhoan.Remove(taiKhoan);
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
