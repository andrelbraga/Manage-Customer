using MANAGE_CUSTOMER_CONTACT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MANAGE_CUSTOMER_CONTACT.ViewModels
{
    public class CommonViewModel
    {
        public Customer Customer { get; set; }

        public DateTime? UntilPurchase { get; set; }

        public int? Roles { get; set; }

        public IEnumerable<Classification> Classifications { get; set; }

        public IEnumerable<Region> Regions { get; set; }

        public IEnumerable<City> Citys { get; set; }

        public IEnumerable<Gender> Genders { get; set; }

        public IEnumerable<Customer> Customers { get; set; }

        public IEnumerable<UserSys> UserSys { get; set; }
    }
}