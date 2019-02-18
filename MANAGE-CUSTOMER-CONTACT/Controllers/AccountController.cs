using MANAGE_CUSTOMER_CONTACT.Infra;
using MANAGE_CUSTOMER_CONTACT.Models;
using MANAGE_CUSTOMER_CONTACT.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MANAGE_CUSTOMER_CONTACT.Controllers
{
    public class AccountController : Controller
    {
        private CustomerDBContext db = new CustomerDBContext();

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AccountViewModels model, string returnUrl)
        {
            UserSys user = new UserSys();

            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                user = db.UserSys.Where(p => p.Email == model.Email && p.Password == model.Password).FirstOrDefault();

                if (user == null)
                {
                    TempData["MsgError"] = "The email and/or password entered is invalid. Please try again.";
                    return RedirectToAction("Login");
                }
                TempData["Role"] = user.UserRoleId;
                return RedirectToRoute(new { controller = "Customers", action = "Index"});
                
            }
            catch
            {
                return View();
            };
        }
    }
}
