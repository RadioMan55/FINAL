using FinalProject.Models;
using FinalProject.Security;
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
                ViewBag.CustomerID = new SelectList(db.Customers.OrderBy(c => c.CompanyName), "CustomerID", "CompanyName").ToList();
            }
            return View();
        }

        // POST: Employee/SignIn
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(CustomerSignIn customerSignIn, string ReturnUrl)
        {
            using (NMJFoodsEntities db = new NMJFoodsEntities())
            {
                if (ModelState.IsValid)
                {


                    // find customer by CustomerId
                    Customer customer = db.Customers.Find(customerSignIn.CustomerId);
                    // hash & salt the posted password
                    string hash = UserAccount.HashSHA1(customerSignIn.Password + customer.UserGuid);
                    // Compared posted Password to customer password
                    if (hash == customer.Password)
                    {
                        // Passwords match
                        // authenticate user (this stores the CustomerID in an encrypted cookie)
                        // normally, you would require HTTPS
                        FormsAuthentication.SetAuthCookie(customer.CustomerID.ToString(), false);

                        HttpCookie myCookie = new HttpCookie("role");
                        myCookie.Value = "customer";
                        Response.Cookies.Add(myCookie);

                        // Redirect to Home page
                        return RedirectToAction(actionName: "Index", controllerName: "Home");
                    }
                    else
                    {
                        // Passwords do not match
                        ModelState.AddModelError("Password", "Incorrect Password");
                    }

                }
                // create drop-down list box for company name
                ViewBag.CustomerID = new SelectList(db.Customers.OrderBy(c => c.CompanyName), "CustomerID", "CompanyName").ToList();
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