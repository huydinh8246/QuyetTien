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
            var listproduct = db.Products.OrderByDescending(n => n.ID);
            return View(listproduct);
        }
    }
}