using quanlycybergams.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace quanlycybergams.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        private QuanLyCYBERGAMESEntities db = new QuanLyCYBERGAMESEntities();
        // GET: Admin/Admin
        public ActionResult Index()
        {
            return View(db.Mays.ToList());
        }
    }
}