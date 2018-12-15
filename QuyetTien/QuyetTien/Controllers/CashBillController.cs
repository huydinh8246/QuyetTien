﻿using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}