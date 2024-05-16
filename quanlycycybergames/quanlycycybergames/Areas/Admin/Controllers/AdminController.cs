using quanlycycybergames.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace quanlycycybergames.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        private QuanLyCYBERGAMESEntities db = new QuanLyCYBERGAMESEntities();
        // GET: Admin/Admin
        public ActionResult Index()
        {
            return View(db.May.ToList());
        }
        
    }
}