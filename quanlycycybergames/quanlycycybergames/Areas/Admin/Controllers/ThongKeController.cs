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
                    .Select(nt => DbFunctions.TruncateTime(nt.ThoiGianGiaNhap))
                    .Distinct()
                    .ToList();

                var thongKeList = new List<ThongKeTongHop>();

                foreach (DateTime ngay in ngayDatHangList.Union(ngayNapList))
                {
                    DateTime ngayDatHang = ngay;
                    DateTime ThoiGianGiaNhap = ngay;

                    decimal? tongDoanhThuDonHang = dbContext.ChiTietDonHang
                        .Where(c => DbFunctions.TruncateTime(c.DonHang.ngayDatHang) == ngayDatHang)
                        .Sum(c => c.tongGia);

                    decimal? tongSoTienNap = dbContext.TaiKhoan
                        .Where(nt => DbFunctions.TruncateTime(nt.ThoiGianGiaNhap) == ThoiGianGiaNhap)
                        .Sum(nt => nt.GiaMay);

                    decimal tongDoanhThuDonHangNgay = tongDoanhThuDonHang ?? 0;
                    decimal tongSoTienNapNgay = tongSoTienNap ?? 0;

                    var thongKe = new ThongKeTongHop
                    {
                        NgayThongKe = ngay,
                        TongDoanhThuDonHang = tongDoanhThuDonHangNgay,
                        TongSoTienNap = tongSoTienNapNgay
                    };

                    thongKeList.Add(thongKe);
                }
                decimal totalSum = thongKeList.Sum(item => item.TongDoanhThuDonHang + item.TongSoTienNap);
                ViewBag.TotalSum = totalSum;
                ViewBag.ThongKeList = thongKeList;

                return View();
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
                    .Select(nt => DbFunctions.TruncateTime(nt.ThoiGianGiaNhap))
                    .Distinct()
                    .ToList();

                // Tạo một danh sách để lưu trữ thông tin thống kê
                var thongKeList = new List<ThongKeDoanhThu>();

                foreach (DateTime ngayNap in ngayNapList)
                {
                    // Tính tổng số tiền nạp cho mỗi ngày
                    decimal? tongSoTienNap = dbContext.TaiKhoan
                        .Where(nt => DbFunctions.TruncateTime(nt.ThoiGianGiaNhap) == ngayNap)
                        .Sum(nt => nt.GiaMay);

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