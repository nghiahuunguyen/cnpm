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
    public class KhosController : Controller
    {
        private QuanLyCYBERGAMESEntities db = new QuanLyCYBERGAMESEntities();

        // GET: Admin/Khos
        // GET: Admin/Khos
        public ActionResult Index()
        {
            return View(db.Kho.ToList());
        }


        // GET: Admin/Khos/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kho kho = db.Kho.Find(id);
            if (kho == null)
            {
                return HttpNotFound();
            }
            return View(kho);
        }

        // GET: Admin/Khos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Khos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Mathang,TenMatHang,SoLuong,TinhTrang,NgayNhap")] Kho kho)
        {
            if (ModelState.IsValid)
            {
                db.Kho.Add(kho);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kho);
        }

        // GET: Admin/Khos/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kho kho = db.Kho.Find(id);
            if (kho == null)
            {
                return HttpNotFound();
            }
            return View(kho);
        }

        // POST: Admin/Khos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Mathang,TenMatHang,SoLuong,TinhTrang,NgayNhap")] Kho kho)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kho).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kho);
        }

        // GET: Admin/Khos/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kho kho = db.Kho.Find(id);
            if (kho == null)
            {
                return HttpNotFound();
            }
            return View(kho);
        }

        // POST: Admin/Khos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Kho kho = db.Kho.Find(id);
            db.Kho.Remove(kho);
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
