using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Identity
{
    public class AppUser : IdentityUser
    {
        public string? FullName { get; set; } 
        public string? CountryCode { get; set; }
        public string? ActivationCode { get; set; }
        public DateTime? ActivationCodeExpiry { get; set; }
        public string? ResetPasswordCode { get; set; }
        public DateTime? ResetPasswordCodeExpiry { get; set; }

    }
}
