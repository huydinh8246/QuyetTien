using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuyetTien.Models;
using System.Net;
using System.Data.Entity;

namespace QuyetTien.Controllers
{
    public class CashBillController : Controller
    {
        DmQT08Entities db = new DmQT08Entities();
        // GET: CashBill
        public ActionResult ViewListCB()
        {
            if(Session["acc"] != null)
            {
                var listCashBill = db.CashBills.OrderByDescending(n => n.ID);
                return View(listCashBill);
            }
            return RedirectToAction("Login", "Login");
        }
        public ActionResult AddCB()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCB(CashBill cashbill)
        {
            db.CashBills.Add(cashbill);
            db.SaveChanges();
            return RedirectToAction("ViewListCB");
        }
        public ActionResult UpdateCB(int ? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CashBill cash = db.CashBills.Find(ID);
            if (cash == null)
            {
                return HttpNotFound();
            }
            return View(cash);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateCB(CashBill cash)
        {
            CashBill cashBill = db.CashBills.FirstOrDefault(n => n.ID == cash.ID);
            cashBill.CustomerName = cash.CustomerName;
            cashBill.GrandTotal = cash.GrandTotal;
            cashBill.Note = cash.Note;
            cashBill.Shipper = cash.Shipper;
            cashBill.Date = cash.Date;
            cashBill.Address = cash.Address;
            cashBill.PhoneNumber = cash.PhoneNumber;
            db.Entry(cashBill).State = EntityState.Modified;
            db.SaveChanges();
            Session["cashBill"] = cashBill;
            return RedirectToAction("ViewListCB");
        }
        public ActionResult deleteCB(int? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CashBill cashbill = db.CashBills.Find(ID);
            if (cashbill == null)
            {
                return HttpNotFound();
            }
            return View(cashbill);
        }

        [HttpPost, ActionName("deleteCB")]
        [ValidateAntiForgeryToken]
        public ActionResult deleteConfimedCB(int ID)
        {
            CashBill cashbill = db.CashBills.Find(ID);
            db.CashBills.Remove(cashbill);
            db.SaveChanges();
            return RedirectToAction("ViewListCB");
        }
        public ActionResult PrintCBInput()
        {
            return View();
        }

        public ActionResult PrintCB(int ID)
        {
            var cbd = db.CashBillDetails.Where(n => n.BillID==ID);
            if(cbd == null)
            {
                return Content("Chưa cập nhật hóa đơn chi tiết");
            }
            CashBill cb = db.CashBills.FirstOrDefault(n => n.ID == ID);
            ViewBag.billCode = cb;
            return View(cbd);
        }
    }
}