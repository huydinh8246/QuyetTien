using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuyetTien.Models;
using System.Data;
using System.Data.Entity;
using System.Net;
using System.IO;


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
            ViewBag.ProductTypeID = new SelectList(db.ProductTypes, "ID", "ProductTypeName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult addProduct(Product product, HttpPostedFileBase Avatar)
        {
            Product pd = db.Products.Add(product);
            db.SaveChanges();
            if (ModelState.IsValid)
            {
                if (Avatar.ContentLength > 0 && Avatar != null)
                {
                    try
                    {
                        string fileName = pd.ID + Path.GetExtension(Avatar.FileName);
                        string path = Path.Combine(Server.MapPath("~/Content/Admin/images/"), fileName);
                        Avatar.SaveAs(path);
                        pd.Avatar = fileName;
                    }
                    catch (Exception ex)
                    {
                        return Content("Upload lỗi" + ex);
                    }

                }
                pd.Status = true;
                db.Entry(pd).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("viewListProduct");
            }
            return View(product);
        }

        public ActionResult updateProduct(int ? ID)
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
            ViewBag.ProductTypeID = new SelectList(db.ProductTypes, "ID", "ProductTypeName");
            return View(product);
        }

        [HttpPost]
        public ActionResult updateProduct(Product product, HttpPostedFileBase Avatar)
        {   
            Product pd = db.Products.FirstOrDefault(n => n.ID == product.ID);
            pd.ProductName = product.ProductName;
            pd.SalePrice = product.SalePrice;
            pd.OriginPrice = product.OriginPrice;
            pd.InstallmentPrice = product.InstallmentPrice;
            pd.Quantity = product.Quantity;
            if (Avatar.ContentLength > 0 && Avatar != null)
            {
                try
                {
                    string fileName = pd.ID + Path.GetExtension(Avatar.FileName);
                    string path = Path.Combine(Server.MapPath("~/Content/Admin/images/"), fileName);
                    Avatar.SaveAs(path);
                    pd.Avatar = fileName;
                }
                catch (Exception ex)
                {
                    return Content("Upload lỗi" + ex);
                }

            }
            pd.Status = true;
            db.Entry(pd).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("viewListProduct");
        }

        public ActionResult deleteProduct(int? ID)
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
            return View(product);
        }

        [HttpPost, ActionName("deleteProduct")]
        [ValidateAntiForgeryToken]
        public ActionResult deleteProduct(int ID)
        {
            Product product = db.Products.Find(ID);
            product.Status = false;
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("viewListProduct");
        }

    }
}