using System;
using System.Collections.Generic;
using System.Text;

namespace AuthDemo.Application.Options
{
    public class AdministratorOptions
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string PasswordHash { get; set; }
    }
}
