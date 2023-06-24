using System;
using Microsoft.AspNetCore.Identity;

namespace ecom_try1.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

