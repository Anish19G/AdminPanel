using ProdCat.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProdCat.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        NobelDBEntities db = new NobelDBEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ManageProduct()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            return View(db.tbProducts.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.tblCategories.ToList(), "CategoryId", "CategoryName");

            return View();
        }

        [HttpPost]
        public ActionResult Create(tbProduct product)
        {
            db.tbProducts.Add(product);

            db.SaveChanges();
            return RedirectToAction("List");
        }


        public ActionResult Edit(int id)
        {
            var data = db.tbProducts.Find(id);
            ViewBag.CategoryID = new SelectList(db.tbProducts.ToList(), "CategoryID", "CategoryName", data.CategoryID);
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tbProduct tb)
        {
            var data = db.tbProducts.Find(tb.ProductID);
                data.ProductName = tb.ProductName;
                data.UnitPrice = tb.UnitPrice;
                data.SellingPrice = tb.SellingPrice;
            db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("List");

        }


        public ActionResult Delete(int? id)
        {
            tbProduct tb = db.tbProducts.Find(id);
            return View(tb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            tbProduct tb = db.tbProducts.Find(id);
            db.tbProducts.Remove(tb);
            db.SaveChanges();
            return RedirectToAction("List");
        }
    }
}