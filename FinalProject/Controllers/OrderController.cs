using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;
using System.Net;

namespace FinalProject.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult OrderManager()
        {
            using (NMJFoodsEntities db = new NMJFoodsEntities())
            {
                return View(db.Orders.OrderByDescending(o => o.OrderDate).ToList());
            }
        }
    }
}