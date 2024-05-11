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
        private QuanLyCYBERGAMESEntities1 db = new QuanLyCYBERGAMESEntities1();
        // GET: Admin/Admin
        public ActionResult Index()
        {
            return View(db.Mays.ToList());
        }
    }
}