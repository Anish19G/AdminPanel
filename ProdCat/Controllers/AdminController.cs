using ProdCat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProdCat.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        readonly NobelDBEntities db = new NobelDBEntities();
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult ViewMagic()
        {
            
            return View(db.tbProducts.ToList());
        }
    }
}