using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuyetTien.Models;

namespace QuyetTien.Controllers
{
    public class LoginController : Controller
    {
        DmQT08Entities db = new DmQT08Entities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
    }
}