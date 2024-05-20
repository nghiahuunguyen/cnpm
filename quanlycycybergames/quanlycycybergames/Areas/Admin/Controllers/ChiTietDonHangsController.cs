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
    public class ChiTietDonHangsController : Controller
    {
        private QuanLyCYBERGAMESEntities db = new QuanLyCYBERGAMESEntities();

        // GET: Admin/ChiTietDonHangs
        public ActionResult Index()
        {
            var chiTietDonHang = db.ChiTietDonHang.Include(c => c.DichVu).Include(c => c.DonHang);
            return View(chiTietDonHang.ToList());
        }

        // GET: Admin/ChiTietDonHangs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietDonHang chiTietDonHang = db.ChiTietDonHang.FirstOrDefault(l => l.MaDH == id);
            if (chiTietDonHang == null)
            {
                return HttpNotFound();
            }
            return View(chiTietDonHang);
        }

        // GET: Admin/ChiTietDonHangs/Create
        public ActionResult Create()
        {
            List<DichVu> List = db.DichVu.ToList();
            ViewBag.DichVu = List;
            ViewBag.ID_DV = new SelectList(db.DichVu, "ID_DV", "TenDV");
            ViewBag.MaDH = new SelectList(db.DonHang, "MaDH", "ID_KhachHang");
            return View();
        }

        // POST: Admin/ChiTietDonHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDH,ID_DV,soluong,tongGia")] ChiTietDonHang chiTietDonHang)
        {
            if (ModelState.IsValid)
            {
                DichVu dichVu = db.DichVu.Find(chiTietDonHang.ID_DV);
                if (dichVu != null && decimal.TryParse(chiTietDonHang.soluong, out decimal soluong))
                {
                    if (dichVu.GiaBan.HasValue)
                    {
                        chiTietDonHang.tongGia = dichVu.GiaBan.Value * soluong;

                        // Kiểm tra số lượng trong kho
                        Kho kho = db.Kho.FirstOrDefault(k => k.ID_Mathang == dichVu.ID_Mathang);
                        if (kho != null)
                        {
                            decimal soLuongKho;
                            if (decimal.TryParse(kho.SoLuong, out soLuongKho))
                            {
                                
                                if (soluong <= soLuongKho)
                                {
                                    // Số lượng trong kho đủ, tiến hành tạo ChiTietDonHang và trừ số lượng trong kho
                                    db.ChiTietDonHang.Add(chiTietDonHang);
                                    db.SaveChanges();

                                    soLuongKho -= soluong;
                                    kho.SoLuong = soLuongKho.ToString();
                                    db.SaveChanges();

                                    return RedirectToAction("Index");
                                }
                                else
                                {
                                    // Số lượng trong kho không đủ, gửi thông báo cho người dùng
                                    ModelState.AddModelError("", "Số lượng trong kho không đủ.");
                                }
                            }
                        }
                    }
                }
            }

            List<DichVu> List = db.DichVu.ToList();
            ViewBag.DichVu = List;
            ViewBag.ID_DV = new SelectList(db.DichVu, "ID_DV", "TenDV", chiTietDonHang.ID_DV);
            ViewBag.MaDH = new SelectList(db.DonHang, "MaDH", "ID_KhachHang", chiTietDonHang.MaDH);
            return View(chiTietDonHang);
        }

        // GET: Admin/ChiTietDonHangs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietDonHang chiTietDonHang = db.ChiTietDonHang.FirstOrDefault(l => l.MaDH == id);
            if (chiTietDonHang == null)
            {
                return HttpNotFound();
            }
            List<DichVu> List = db.DichVu.ToList();
            ViewBag.DichVu = List;
            ViewBag.ID_DV = new SelectList(db.DichVu, "ID_DV", "TenDV", chiTietDonHang.ID_DV);
            ViewBag.MaDH = new SelectList(db.DonHang, "MaDH", "ID_KhachHang", chiTietDonHang.MaDH);
            return View(chiTietDonHang);
        }

        // POST: Admin/ChiTietDonHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDH,ID_DV,soluong,tongGia")] ChiTietDonHang chiTietDonHang)
        {
            if (ModelState.IsValid)
            {
                var existingChiTietDonHang = db.ChiTietDonHang.Find(chiTietDonHang.MaDH, chiTietDonHang.ID_DV);
                if (existingChiTietDonHang == null)
                {
                    return HttpNotFound();
                }

                DichVu dichVu = db.DichVu.Find(chiTietDonHang.ID_DV);
                if (dichVu != null)
                {
                    decimal newSoluong;
                    if (decimal.TryParse(chiTietDonHang.soluong, out newSoluong))
                    {
                        if (dichVu.GiaBan.HasValue)
                        {
                            // Calculate the new total price
                            existingChiTietDonHang.tongGia = dichVu.GiaBan.Value * newSoluong;

                            // Adjust the stock
                            Kho kho = db.Kho.FirstOrDefault(k => k.ID_Mathang == dichVu.ID_Mathang);
                            if (kho != null)
                            {
                                decimal oldSoluong;
                                if (decimal.TryParse(existingChiTietDonHang.soluong, out oldSoluong))
                                {
                                    decimal soLuongKho;
                                    if (decimal.TryParse(kho.SoLuong, out soLuongKho))
                                    {
                                        // Adjust the stock based on the difference between old and new quantity
                                        soLuongKho = soLuongKho + oldSoluong - newSoluong;
                                        kho.SoLuong = soLuongKho.ToString();
                                    }
                                }
                            }

                            // Update the existing entity's quantity
                            existingChiTietDonHang.soluong = newSoluong.ToString();

                            // Mark the existing entity as modified
                            db.Entry(existingChiTietDonHang).State = EntityState.Modified;
                            db.SaveChanges();
                            return RedirectToAction("Index");
                        }
                    }
                }
            }

            List<DichVu> List = db.DichVu.ToList();
            ViewBag.DichVu = List;
            ViewBag.ID_DV = new SelectList(db.DichVu, "ID_DV", "TenDV", chiTietDonHang.ID_DV);
            ViewBag.MaDH = new SelectList(db.DonHang, "MaDH", "ID_KhachHang", chiTietDonHang.MaDH);
            return View(chiTietDonHang);
        }


        // GET: Admin/ChiTietDonHangs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietDonHang chiTietDonHang = db.ChiTietDonHang.FirstOrDefault(l => l.MaDH == id);
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
            ChiTietDonHang chiTietDonHang = db.ChiTietDonHang.FirstOrDefault(l => l.MaDH == id);
            db.ChiTietDonHang.Remove(chiTietDonHang);
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
