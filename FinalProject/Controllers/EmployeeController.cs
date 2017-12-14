using FinalProject.Models;
using FinalProject.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Controllers
{
    public class EmployeeController : FinalProject.Configuration.ControllerBase
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        // GET: Employee/Register
        public ActionResult Register()
        {
            return View();
        }
        // POST: Employee/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(EmployeeRegister employeeRegister)
        {
            using (NMJFoodsEntities db = new NMJFoodsEntities())
            {
                if (ModelState.IsValid)
                {
                    #region Inside using db
                    var employee = Mapper.Map<Employee>(employeeRegister);

                    if (db.Employees.Any(c => c.Username == employee.Username))
                    {
                        // duplicate
                        return View();
                    }
                    // Generate guid for this customer
                    employee.UserGuid = System.Guid.NewGuid();
                    // Generate hash with password+guid
                    employee.Password = UserAccount.HashSHA1(employee.Password + employee.UserGuid);
                    // Add new customer to database

                    db.Employees.Add(employee);
                    db.SaveChanges();
                    return RedirectToAction(actionName: "Index", controllerName: "Home");
                    #endregion
                }
            }

            return View();
        }
    }
}