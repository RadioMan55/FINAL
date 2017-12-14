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
        // GET: Product/FilterProducts
        public JsonResult FilterOrders(int? IdFilter,int? EmployeeId)
        {
            using (NMJFoodsEntities db = new NMJFoodsEntities())
            {
                if (IdFilter == null)
                {
                    Response.StatusCode = 400;
                    return Json(new { }, JsonRequestBehavior.AllowGet);
                }
                var Orders = db.Orders.ToList();
                if (IdFilter != null)
                {
                    Orders = Orders.Where(o => o.OrderID == IdFilter).ToList();
                }
                else
                {
                    if (EmployeeId != null)
                    {
                        Orders = Orders.Where(o => o.EmployeeID == EmployeeId).ToList();
                    }
                }
                var OrderDTOs = (from o in Orders
                                 orderby o.OrderID
                                 select new OrderDTOs
                                 {
                                     OrderID = o.OrderID,
                                     OrderDate = o.OrderDate.ToString(),
                                     RequiredDate = o.RequiredDate.ToString(),
                                     ShippedDate = o.ShippedDate.ToString(),
                                     CustomerID = o.CustomerID,
                                     EmployeeID = o.EmployeeID
                                 }).ToList();
                return Json(OrderDTOs, JsonRequestBehavior.AllowGet);
            }
        }
    }
}