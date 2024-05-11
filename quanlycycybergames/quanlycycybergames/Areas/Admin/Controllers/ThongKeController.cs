using quanlycycybergames.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace quanlycycybergames.Areas.Admin.Controllers
{
    public class ThongKeController : Controller
    {
        private QuanLyCYBERGAMESEntities db = new QuanLyCYBERGAMESEntities();
        // GET: Admin/ThongKe
        public ActionResult Index(DateTime? date = null)
        {
            if (date == null)
            {
                date = DateTime.Now.Date;
            }

            // Lấy danh sách đơn hàng dựa trên ngày đặt hàng
            var donHangs = db.DonHang.Where(d => d.ngayDatHang.HasValue && DbFunctions.TruncateTime(d.ngayDatHang.Value) == date.Value.Date).ToList();

            // Tính tổng giá của các đơn hàng
            decimal? tongGiaTatCa = donHangs.Sum(d => d.tongGia);

            decimal tongGiaTatCaConverted = (decimal)(tongGiaTatCa ?? 0);

            ViewBag.Date = date.Value.ToString("yyyy-MM-dd");
            ViewBag.TongGiaTatCa = tongGiaTatCaConverted;

            return View(donHangs);
        }
    }
}