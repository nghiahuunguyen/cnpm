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
    public class DichVusController : Controller
    {
        private QuanLyCYBERGAMESEntities db = new QuanLyCYBERGAMESEntities();

        // GET: Admin/DichVus
        public ActionResult Index(string searchName)
        {
            var dichVu = db.DichVu.Include(d => d.Kho);
            if (!string.IsNullOrEmpty(searchName))
            {
                dichVu = dichVu.Where(t => t.TenDV.Contains(searchName));
            }

            bool noResults = !dichVu.Any();
            ViewBag.NoResults = noResults;

            return View(dichVu.ToList());
        }


        // GET: Admin/DichVus/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DichVu dichVu = db.DichVu.Find(id);
            if (dichVu == null)
            {
                return HttpNotFound();
            }
            return View(dichVu);
        }

        // GET: Admin/DichVus/Create
        public ActionResult Create()
        {
            List<Kho> List = db.Kho.ToList();
            ViewBag.DichVu = List;
            ViewBag.ID_Mathang = new SelectList(db.Kho, "ID_Mathang", "TenMatHang");
            return View();
        }

        // POST: Admin/DichVus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_DV,TenDV,AnhSP,GiaBan,ID_Mathang")] DichVu dichVu)
        {
            if (ModelState.IsValid)
            {
                db.DichVu.Add(dichVu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            List<Kho> List = db.Kho.ToList();
            ViewBag.DichVu = List;
            ViewBag.ID_Mathang = new SelectList(db.Kho, "ID_Mathang", "TenMatHang", dichVu.ID_Mathang);
            return View(dichVu);
        }

        // GET: Admin/DichVus/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DichVu dichVu = db.DichVu.Find(id);
            if (dichVu == null)
            {
                return HttpNotFound();
            }
            List<Kho> List = db.Kho.ToList();
            ViewBag.DichVu = List;
            ViewBag.ID_Mathang = new SelectList(db.Kho, "ID_Mathang", "TenMatHang", dichVu.ID_Mathang);
            return View(dichVu);
        }

        // POST: Admin/DichVus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_DV,TenDV,AnhSP,GiaBan,ID_Mathang")] DichVu dichVu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dichVu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            List<Kho> List = db.Kho.ToList();
            ViewBag.DichVu = List;
            ViewBag.ID_Mathang = new SelectList(db.Kho, "ID_Mathang", "TenMatHang", dichVu.ID_Mathang);
            return View(dichVu);
        }

        // GET: Admin/DichVus/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DichVu dichVu = db.DichVu.Find(id);
            if (dichVu == null)
            {
                return HttpNotFound();
            }
            return View(dichVu);
        }

        // POST: Admin/DichVus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DichVu dichVu = db.DichVu.Find(id);
            db.DichVu.Remove(dichVu);
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
