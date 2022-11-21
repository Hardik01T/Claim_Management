using System;
using System.Collections.Generic;

namespace managementapi.Models
{
    public partial class LoginT
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? Age { get; set; }
        public string Username { get; set; } = null!;
        public string? Password { get; set; }
    }
}
