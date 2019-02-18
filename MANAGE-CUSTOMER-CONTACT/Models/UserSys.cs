using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MANAGE_CUSTOMER_CONTACT.Models
{
    public class UserSys
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int UserRoleId { get; set; }
    }
}