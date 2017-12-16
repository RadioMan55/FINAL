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
                return View(db.Orders.OrderByDescending(o => o.OrderID).ToList());
            }
        }
        // GET: Product/FilterProducts
        public JsonResult FilterOrders(int? IdFilter,int? EmployeeID, int? CustomerID)
        {
            using (NMJFoodsEntities db = new NMJFoodsEntities())
            {
                var Orders = db.Orders.ToList();

                if (IdFilter == null && EmployeeID == null && CustomerID == null)
                {
                    //keep all orders in Orders
                    Orders = db.Orders.ToList();
                }
                
                if (IdFilter != null && EmployeeID == null && CustomerID == null)
                {
                    Orders = Orders.Where(o => o.OrderID == IdFilter).ToList();
                }
                else if (IdFilter != null && EmployeeID != null && CustomerID == null)
                {
                    Orders = Orders.Where(o => o.OrderID == IdFilter).ToList();
                    Orders = Orders.Where(o => o.EmployeeID == EmployeeID).ToList();
                }
                else if (IdFilter != null && EmployeeID != null && CustomerID != null)
                {
                    Orders = Orders.Where(o => o.OrderID == IdFilter).ToList();
                    Orders = Orders.Where(o => o.EmployeeID == EmployeeID).ToList();
                    Orders = Orders.Where(o => o.CustomerID == CustomerID).ToList();
                }
                else if (IdFilter == null && EmployeeID != null && CustomerID == null)
                {
                    Orders = Orders.Where(o => o.EmployeeID == EmployeeID).ToList();
                }
                else if (IdFilter == null && EmployeeID != null && CustomerID != null)
                {
                    Orders = Orders.Where(o => o.EmployeeID == EmployeeID).ToList();
                    Orders = Orders.Where(o => o.CustomerID == CustomerID).ToList();
                }
                else if (IdFilter != null && EmployeeID == null && CustomerID != null)
                {
                    Orders = Orders.Where(o => o.OrderID == IdFilter).ToList();
                    Orders = Orders.Where(o => o.CustomerID == CustomerID).ToList();
                }
                else if (IdFilter == null && EmployeeID == null && CustomerID != null)
                {
                    Orders = Orders.Where(o => o.CustomerID == CustomerID).ToList();
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
                                 }).OrderByDescending(o => o.OrderID).ToList();
                return Json(OrderDTOs, JsonRequestBehavior.AllowGet);
            }
        }
    }
}