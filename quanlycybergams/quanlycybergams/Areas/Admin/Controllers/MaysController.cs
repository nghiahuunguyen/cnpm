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
        private QuanLyCYBERGAMESEntities db = new QuanLyCYBERGAMESEntities();

        // GET: Admin/Mays
        public ActionResult Index()
        {
            var mays = db.Mays.Include(m => m.DonGia);
            return View(mays.ToList());
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
            ViewBag.ID_gia = new SelectList(db.DonGias, "ID_gia", "ID_gia");
            return View();
        }

        // POST: Admin/Mays/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_May,TenMay,TinhTrangMay,ID_gia,HoatDong")] May may)
        {
            if (ModelState.IsValid)
            {
                db.Mays.Add(may);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_gia = new SelectList(db.DonGias, "ID_gia", "ID_gia", may.ID_gia);
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
            ViewBag.ID_gia = new SelectList(db.DonGias, "ID_gia", "ID_gia", may.ID_gia);
            return View(may);
        }

        // POST: Admin/Mays/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_May,TenMay,TinhTrangMay,ID_gia,HoatDong")] May may)
        {
            if (ModelState.IsValid)
            {
                db.Entry(may).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_gia = new SelectList(db.DonGias, "ID_gia", "ID_gia", may.ID_gia);
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
