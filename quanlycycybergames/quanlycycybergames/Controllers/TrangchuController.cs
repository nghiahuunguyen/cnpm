﻿using quanlycycybergames.Models;
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
            var user = db.TaiKhoan.FirstOrDefault(u => u.TenDN == username && u.Matkhau == password);

            if (user != null)
            {
                if (user.ID_KhachHang == "Admin")
                {
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ViewBag.ErrorMessage = "You are not authorized to access the admin area.";
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