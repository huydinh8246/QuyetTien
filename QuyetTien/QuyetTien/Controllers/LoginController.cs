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
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection tv)
        {
            string txtUserName = tv["txtUserName"];
            string txtPassword = tv["txtPassword"];
            Account acc = db.Accounts.SingleOrDefault(n => n.Username == txtUserName && n.Password == txtPassword);
            if (acc != null && acc.ToString() != "")
            {
                Session["acc"] = acc;
                return RedirectToAction("viewListProduct","Product");
            }
            ViewBag.thongbao = "Tên đăng nhập hoặc mật khẩu không đúng";
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(FormCollection account)
        {
            string UserName = account["UserName"];
            Account acc = db.Accounts.SingleOrDefault(n => n.Username == UserName);
            if (acc != null && acc.ToString() != "")
            {
                ViewBag.thongbao = "ten dang nhap bi trung";
                return View();
            }
            acc.Username = UserName;
            acc.Password = account["Password"];
            acc.Fullname = account["FullName"];
            Session["acc"] = acc;
            db.Accounts.Add(acc);
            db.SaveChanges();
            return RedirectToAction("viewListProduct","Product");
        }
        public ActionResult LogOut()
        {
            Session["acc"] = null;
            return RedirectToAction("Login","Login");
        }
    }
}