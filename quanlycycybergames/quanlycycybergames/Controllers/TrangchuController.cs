using quanlycycybergames.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace quanlycycybergames.Controllers
{
    public class TrangchuController : Controller
    {
        private QuanLyCYBERGAMESEntities db = new QuanLyCYBERGAMESEntities();

        // GET: Trangchu
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string username, string password)
        {
            var user = db.TaiKhoan.FirstOrDefault(u => u.TenTaiKhoan == username && u.Matkhau == password);

            if (user != null)
            {
                if (user.ID_TaiKhoan == "Admin")
                {
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ViewBag.ErrorMessage = "Bạn không được phép truy cập vào khu vực quản trị.";
                    return View();
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Sai tên đăng nhập hoặc tên mật khẩu";
                return View();
            }
        }
    }
}