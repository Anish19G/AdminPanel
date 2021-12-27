using System;
using ProdCat.Models;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProdCat.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        NobelDBEntities db = new NobelDBEntities();


        public ActionResult ManageCategory()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            return View(db.tblCategories.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(tblCategory category)
        {
            db.tblCategories.Add(category);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Edit(int id)
        {
            var data = db.tblCategories.Find(id);
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tblCategory tbl)
        {
            var data = db.tblCategories.Find(tbl.CategoryID);
            data.CategoryName = tbl.CategoryName;
            db.Entry(data).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Delete(int? id)
        {
            tblCategory category = db.tblCategories.Find(id);
            return View(category);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            tblCategory data = db.tblCategories.Find(id);
            db.tblCategories.Remove(data);
            db.SaveChanges();
            return RedirectToAction("List");
        }
    }
}