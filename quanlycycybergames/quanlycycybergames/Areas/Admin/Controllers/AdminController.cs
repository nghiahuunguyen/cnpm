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
    public class AdminController : Controller
    {
        private QuanLyCYBERGAMESEntities db = new QuanLyCYBERGAMESEntities();

        // GET: Admin/Admin
        public ActionResult Index()
        {
            var may = db.May.Include(m => m.TaiKhoan);
            return View(may.ToList());
        }

       

        
        // GET: Admin/Admin/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            May may = db.May.Find(id);
            if (may == null)
            {
                return HttpNotFound();
            }
            List<TaiKhoan> List = db.TaiKhoan.ToList();
            ViewBag.TK = List;
            ViewBag.ID_TaiKhoan = new SelectList(db.TaiKhoan, "ID_TaiKhoan", "TenTaiKhoan", may.ID_TaiKhoan);
            return View(may);
        }

        // POST: Admin/Admin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_May,TenMay,GiaMay,HoatDong,ThoiGianMo,ThoiGianTat,TongTien,ID_TaiKhoan")] May may)
        {
            if (ModelState.IsValid)
            {
                db.Entry(may).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            List<TaiKhoan> List = db.TaiKhoan.ToList();
            ViewBag.TK = List;
            ViewBag.ID_TaiKhoan = new SelectList(db.TaiKhoan, "ID_TaiKhoan", "TenTaiKhoan", may.ID_TaiKhoan);
            return View(may);
        }

       
    }
}
