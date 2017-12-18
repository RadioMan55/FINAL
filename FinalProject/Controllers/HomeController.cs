using FinalProject.Models;
using FinalProject.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FinalProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var db = new NMJFoodsEntities())
            {
                ViewBag.EmployeeID = new SelectList(db.Employees.OrderBy(e => e.Username), "Username", "EmployeeID").ToList();
            }
            return View();
        }

        // POST: Employee/SignIn
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(EmployeeSignIn employeeSignIn, string ReturnUrl)
        {
            using (NMJFoodsEntities db = new NMJFoodsEntities())
            {
                if (ModelState.IsValid)
                {
                    // find employee by EmployeeId
                    Employee employee = db.Employees.Find(employeeSignIn.EmployeeId);
                    
                    // hash & salt the posted password
                    string hash = UserAccount.HashSHA1(employeeSignIn.Password + employee.UserGuid);
                    // Compared posted Password to employee password
                    if (hash == employee.Password)
                    {
                        // Passwords match
                        // authenticate user (this stores the EmployeeID in an encrypted cookie)
                        // normally, you would require HTTPS
                        FormsAuthentication.SetAuthCookie(employee.EmployeeID.ToString(), false);

                        // if there is a return url, redirect to the url
                        //if (ReturnUrl != null)
                        //{
                        //    return Redirect(ReturnUrl);
                        //}

                        HttpCookie myCookie = new HttpCookie("role");
                        myCookie.Value = "employee";
                        Response.Cookies.Add(myCookie);

                        // Redirect to Home page
                        return RedirectToAction(actionName: "OrderManager", controllerName: "Order");
                    }
                    else
                    {
                        // Passwords do not match
                        ModelState.AddModelError("Password", "Incorrect Password");
                    }

                }


                // create drop-down list box for company name
                ViewBag.EmployeeID = new SelectList(db.Employees.OrderBy(e => e.Username), "EmployeeID", "Username").ToList();
                return View();
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}