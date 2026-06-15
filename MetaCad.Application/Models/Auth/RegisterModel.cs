using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MetaCad.Application.Models.Auth
{
    public class RegisterModel
    {
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; } 
        public string? CountryCode { get; set; } 
        public string? PhoneNumber { get; set; }

        [JsonIgnore]
        public string? ActivationCode { get; set; }  = new Random().Next(100000, 1000000).ToString(),
    }
}
