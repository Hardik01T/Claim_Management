using System;
using System.Collections.Generic;

namespace managementapi.Models
{
    public partial class Insurer
    {
        public string InsurerId { get; set; } = null!;
        public string? OrganizationCode { get; set; }
        public string? PolicyNumber { get; set; }
    }
}
