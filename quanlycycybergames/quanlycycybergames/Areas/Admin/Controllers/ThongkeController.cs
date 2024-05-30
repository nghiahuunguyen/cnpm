using quanlycycybergames.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace quanlycycybergames.Areas.Admin.Controllers
{
    public class ThongkeController : Controller
    {
        // GET: Admin/Thongke
        public ActionResult Index()
        {
            using (var dbContext = new QuanLyCYBERGAMESEntities())
            {
                var ngayDatHangList = dbContext.DonHang
                    .Select(dh => DbFunctions.TruncateTime(dh.ngayDatHang))
                    .Distinct()
                    .ToList();

                var ngayNapList = dbContext.TaiKhoan
                    .Select(nt => DbFunctions.TruncateTime(nt.ThoiGianNap))
                    .Distinct()
                    .ToList();

                var thongKeList = new List<ThongKeTongHop>();

                foreach (DateTime ngay in ngayDatHangList.Union(ngayNapList))
                {
                    DateTime ngayDatHang = ngay;
                    DateTime ThoiGianGiaNhap = ngay;

                    var tongDoanhThuDonHang = dbContext.ChiTietDonHang
                        .Where(c => DbFunctions.TruncateTime(c.DonHang.ngayDatHang) == ngayDatHang)
                        .Sum(c => c.tongGia) ?? 0;

                    var tongSoTienNap = dbContext.TaiKhoan
                        .Where(nt => DbFunctions.TruncateTime(nt.ThoiGianNap) == ThoiGianGiaNhap)
                        .Sum(nt => nt.SoTienNap) ?? 0;

                    var thongKe = new ThongKeTongHop
                    {
                        NgayThongKe = ngay,
                        TongDoanhThuDonHang = tongDoanhThuDonHang,
                        TongSoTienNap = tongSoTienNap
                    };

                    thongKeList.Add(thongKe);
                }

                ViewBag.ThongKeList = thongKeList;

                return View(thongKeList);
            }
        }



        public ActionResult ThongKeDoanhThuTheoDonHang()
        {
            // Kết nối tới cơ sở dữ liệu
            using (var dbContext = new QuanLyCYBERGAMESEntities())
            {
                // Lấy danh sách ngày từ trường ngayDatHang trong bảng DonHang
                var ngayDatHangList = dbContext.DonHang
                    .Select(dh => DbFunctions.TruncateTime(dh.ngayDatHang))
                    .Distinct()
                    .ToList();
                // Tạo một danh sách để lưu trữ thông tin thống kê
                var thongKeList = new List<ThongKeDoanhThu>();

                foreach (DateTime ngayDatHang in ngayDatHangList)
                {
                    // Tính tổng doanh thu cho mỗi ngày
                    decimal? tongDoanhThu = dbContext.ChiTietDonHang
                        .Where(c => DbFunctions.TruncateTime(c.DonHang.ngayDatHang) == ngayDatHang)
                        .Sum(c => c.tongGia);

                    // Gán giá trị cho tongDoanhThu
                    decimal tongDoanhThuDonHang = tongDoanhThu ?? 0;

                    // Tạo đối tượng ThongKeDoanhThu để lưu trữ thông tin thống kê
                    var thongKe = new ThongKeDoanhThu
                    {
                        NgayThongKe = ngayDatHang,
                        TongDoanhThu = tongDoanhThuDonHang
                    };

                    // Thêm vào danh sách thống kê
                    thongKeList.Add(thongKe);
                }

                // Truyền danh sách thông kê vào ViewBag
                ViewBag.ThongKeList = thongKeList;

                return View();
            }
        }
        public ActionResult ThongKeSoTienNap()
        {
            // Kết nối tới cơ sở dữ liệu
            using (var dbContext = new QuanLyCYBERGAMESEntities())
            {
                // Lấy danh sách ngày từ trường ngayNap trong bảng NapTien
                var ngayNapList = dbContext.TaiKhoan
                    .Select(nt => DbFunctions.TruncateTime(nt.ThoiGianNap))
                    .Distinct()
                    .ToList();

                // Tạo một danh sách để lưu trữ thông tin thống kê
                var thongKeList = new List<ThongKeDoanhThu>();

                foreach (DateTime ngayNap in ngayNapList)
                {
                    // Tính tổng số tiền nạp cho mỗi ngày
                    decimal? tongSoTienNap = dbContext.TaiKhoan
                        .Where(nt => DbFunctions.TruncateTime(nt.ThoiGianNap) == ngayNap)
                        .Sum(nt => nt.SoTienNap);

                    // Gán giá trị cho tongSoTienNap
                    decimal tongSoTienNapNgay = tongSoTienNap ?? 0;

                    // Tạo đối tượng ThongKeSoTienNap để lưu trữ thông tin thống kê
                    var thongKe = new ThongKeDoanhThu
                    {
                        NgayThongKe = ngayNap,
                        TongDoanhThu = tongSoTienNapNgay
                    };

                    // Thêm vào danh sách thống kê
                    thongKeList.Add(thongKe);
                }

                // Truyền danh sách thông kê vào ViewBag
                ViewBag.ThongKeList = thongKeList;

                return View();
            }
        }
    }
}