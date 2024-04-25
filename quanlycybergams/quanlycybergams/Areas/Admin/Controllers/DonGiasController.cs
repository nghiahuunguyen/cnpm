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
    public class DonGiasController : Controller
    {
        private QuanLyCYBERGAMESEntities db = new QuanLyCYBERGAMESEntities();

        // GET: Admin/DonGias
        public ActionResult Index()
        {
            return View(db.DonGias.ToList());
        }

        // GET: Admin/DonGias/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonGia donGia = db.DonGias.Find(id);
            if (donGia == null)
            {
                return HttpNotFound();
            }
            return View(donGia);
        }

        // GET: Admin/DonGias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/DonGias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_gia,GiaMay")] DonGia donGia)
        {
            if (ModelState.IsValid)
            {
                db.DonGias.Add(donGia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(donGia);
        }

        // GET: Admin/DonGias/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonGia donGia = db.DonGias.Find(id);
            if (donGia == null)
            {
                return HttpNotFound();
            }
            return View(donGia);
        }

        // POST: Admin/DonGias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_gia,GiaMay")] DonGia donGia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donGia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(donGia);
        }

        // GET: Admin/DonGias/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonGia donGia = db.DonGias.Find(id);
            if (donGia == null)
            {
                return HttpNotFound();
            }
            return View(donGia);
        }

        // POST: Admin/DonGias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DonGia donGia = db.DonGias.Find(id);
            db.DonGias.Remove(donGia);
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
