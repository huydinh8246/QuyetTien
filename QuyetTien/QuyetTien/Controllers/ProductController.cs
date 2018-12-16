using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuyetTien.Models;
using System.Data;
using System.Data.Entity;
using System.Net;


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

        public ActionResult editProduct(int ? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(ID);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductTypeID = new SelectList(db.ProductTypes, "ProductTypeCode", "ProductTypeName");
            return View(product);
        }

        [HttpPost]
        public ActionResult editProduct(Product product)
        {   
            Product pd = db.Products.FirstOrDefault(n => n.ID == product.ID);
                pd.ProductName = product.ProductName;
                pd.SalePrice = product.SalePrice;
                pd.OriginPrice = product.OriginPrice;
                pd.InstallmentPrice = product.InstallmentPrice;
                pd.Quantity = product.Quantity;
                pd.Avatar = product.Avatar;
                pd.Status = product.Status;
            db.Entry(pd).State = EntityState.Modified;
            db.SaveChanges();
            Session["pd"] = pd;
            return RedirectToAction("viewListProduct");
        }
    }
}