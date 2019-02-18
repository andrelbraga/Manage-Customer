using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MANAGE_CUSTOMER_CONTACT.Infra;
using MANAGE_CUSTOMER_CONTACT.Models;
using MANAGE_CUSTOMER_CONTACT.ViewModels;

namespace MANAGE_CUSTOMER_CONTACT.Controllers
{
    public class CustomersController : Controller
    {
        private CustomerDBContext db = new CustomerDBContext();
        // GET: Customers
        public ActionResult Index()
        {
            var tmp = TempData.Count();
            if (tmp.Equals(0))
            {
                return RedirectToRoute(new { controller = "Account", action = "Login" });
            }
            

            CommonViewModel common = new CommonViewModel();
            IEnumerable<Customer> customers = db.Customers.ToList();

            common.Citys = db.Citys.ToList();
            common.Classifications = db.Classifications.ToList();
            common.Genders = db.Genders.ToList();
            common.Regions = db.Regions.ToList();
            common.UserSys = db.UserSys.ToList();
            

            common.Customers = db.Customers
                    .Include("Classification")
                    .Include("Gender")
                    .Include("Region")
                    .Include("City")
                    .Include("UserSys")
                    .ToList();

            return View(common);
        }

        [HttpPost]
        public ActionResult Index(CommonViewModel common)
        {
            CommonViewModel commonAux = new CommonViewModel();
            IEnumerable<Customer> customers = db.Customers
                .Include("Classification")
                .Include("Gender")
                .Include("Region")
                .Include("City")
                .Include("UserSys")
                .ToList();


            commonAux.Citys = db.Citys.ToList();
            commonAux.Classifications = db.Classifications.ToList();
            commonAux.Genders = db.Genders.ToList();
            commonAux.Regions = db.Regions.ToList();
            commonAux.UserSys = db.UserSys.ToList();
            commonAux.Roles = common.Roles;

            commonAux.Customers = customers
                .Where(p => (common.Customer.CityId != null) ? p.CityId == common.Customer.CityId : true)
                .Where(p => (common.Customer.ClassificationId != null) ? p.ClassificationId == common.Customer.ClassificationId : true)
                .Where(p => (common.Customer.RegionId != null) ? p.RegionId == common.Customer.RegionId : true)
                .Where(p => (common.Customer.GenderId != null) ? p.GenderId == common.Customer.GenderId : true)
                .Where(p => (common.Customer.Name != null) ? p.Name.Contains(common.Customer.Name) : true)
                .Where(p =>  (common.Customer.UserSysId != null) ? p.UserSysId == common.Customer.UserSysId : true)
                .Where(p => (common.Customer.LastPurchase != null && common.UntilPurchase != null) 
                        ? p.LastPurchase >= common.Customer.LastPurchase && p.LastPurchase <= common.UntilPurchase : true)
                .ToList();

            
            return View(commonAux);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
