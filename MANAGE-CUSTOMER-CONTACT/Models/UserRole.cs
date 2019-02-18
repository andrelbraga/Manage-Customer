using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MANAGE_CUSTOMER_CONTACT.Models
{
    public class UserRole
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsAdmin { get; set; }
    }
}