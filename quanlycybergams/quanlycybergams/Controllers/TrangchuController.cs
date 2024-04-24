using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using quanlycybergams.Models;

namespace quanlycybergams.Controllers
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
            var user = db.TaiKhoans.FirstOrDefault(u => u.TenDN == username && u.Matkhau == password);

            if (user != null)
            {
                // Check if the user is an admin (assuming the admin user has a specific ID_TK value, e.g., 1)
                if (user.ID_KhachHang == "Admin")
                {
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    // Handle non-admin user case
                    // For example, redirect to a different page or display an error message
                    ViewBag.ErrorMessage = "You are not authorized to access the admin area.";
                    return View();
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid username or password";
                return View();
            }
        }
    }
}