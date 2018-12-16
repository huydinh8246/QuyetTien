using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuyetTien.Models;

namespace QuyetTien.Controllers
{
    public class CashBillController : Controller
    {
        DmQT08Entities db = new DmQT08Entities();
        // GET: CashBill
        public ActionResult ViewListCB()
        {
            var listCashBill = db.CashBills.OrderByDescending(n => n.ID);
            return View(listCashBill);
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
    }
}