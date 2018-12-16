using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuyetTien.Models;

namespace QuyetTien.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        DmQT08Entities db = new DmQT08Entities();
        public ActionResult viewListProduct()
        {
            var listproduct = db.Products.OrderByDescending(n => n.ID).Where(n=>n.Status==true);
            return View(listproduct);
        }
        
        public ActionResult addProduct()
        {
            ViewBag.ProductTypeID = new SelectList(db.ProductTypes, "ProductTypeCode", "ProductTypeName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult addProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                product.Status = true;
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("viewListProduct");
            }
            return View(product);
        }


    }
}