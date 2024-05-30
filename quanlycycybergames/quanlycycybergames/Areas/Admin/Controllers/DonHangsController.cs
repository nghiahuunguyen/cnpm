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
    public class DonHangsController : Controller
    {
        private QuanLyCYBERGAMESEntities db = new QuanLyCYBERGAMESEntities();

        // GET: Admin/DonHangs
        public ActionResult Index(string searchName)
        {
            var donHangs = db.DonHang.Include(d => d.KhachHang);
            if (!string.IsNullOrEmpty(searchName))
            {
                donHangs = donHangs.Where(d => d.KhachHang.TenKhachHang.Contains(searchName));
            }

            foreach (var donHang in donHangs)
            {
                donHang.tongGia = db.ChiTietDonHang.Where(c => c.MaDH == donHang.MaDH).Sum(c => c.tongGia);
            }
            return View(donHangs.ToList());
        }

        // GET: Admin/DonHangs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang donHang = db.DonHang.Find(id);
            if (donHang == null)
            {
                return HttpNotFound();
            }
            donHang.tongGia = db.ChiTietDonHang.Where(c => c.MaDH == donHang.MaDH).Sum(c => c.tongGia);
            return View(donHang);
        }

        // GET: Admin/DonHangs/Create
        public ActionResult Create()
        {
            List<KhachHang> List = db.KhachHang.ToList();
            ViewBag.KH = List;
            ViewBag.ID_KhachHang = new SelectList(db.KhachHang, "ID_KhachHang", "TenKhachHang");
            return View();
        }

        // POST: Admin/DonHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDH,ngayDatHang,ID_KhachHang,tongGia")] DonHang donHang)
        {
            if (ModelState.IsValid)
            {
                db.DonHang.Add(donHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            List<KhachHang> List = db.KhachHang.ToList();
            ViewBag.KH = List;
            ViewBag.ID_KhachHang = new SelectList(db.KhachHang, "ID_KhachHang", "TenKhachHang", donHang.ID_KhachHang);
            return View(donHang);
        }

        // GET: Admin/DonHangs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang donHang = db.DonHang.Find(id);
            if (donHang == null)
            {
                return HttpNotFound();
            }
            List<KhachHang> List = db.KhachHang.ToList();
            ViewBag.KH = List;
            ViewBag.ID_KhachHang = new SelectList(db.KhachHang, "ID_KhachHang", "TenKhachHang", donHang.ID_KhachHang);
            return View(donHang);
        }

        // POST: Admin/DonHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDH,ngayDatHang,ID_KhachHang,tongGia")] DonHang donHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            List<KhachHang> List = db.KhachHang.ToList();
            ViewBag.KH = List;
            ViewBag.ID_KhachHang = new SelectList(db.KhachHang, "ID_KhachHang", "TenKhachHang", donHang.ID_KhachHang);
            return View(donHang);
        }

        // GET: Admin/DonHangs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang donHang = db.DonHang.Find(id);
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
            DonHang donHang = db.DonHang.Find(id);
            db.DonHang.Remove(donHang);
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
