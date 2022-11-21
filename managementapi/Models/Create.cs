using System;
using System.Collections.Generic;

namespace managementapi.Models
{
    public partial class Create
    {
        public int Id { get; set; }
        public string? InsuredName { get; set; }
        public string? InsuredClaimNo { get; set; }
        public DateTime? InsuredContactedDate { get; set; }
        public string? ClaimTypeCode { get; set; }
        public string? LossDescCode { get; set; }
        public string? InsurerId { get; set; }
        public double? Rate { get; set; }
        public double? Period { get; set; }
        public string? LossLocation { get; set; }
        public DateTime? LossDate { get; set; }
        public DateTime? ReceiveDate { get; set; }
        public DateTime? OpenDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public DateTime? PolicyInceptionDate { get; set; }
        public DateTime? PolicyExpiryDate { get; set; }
        public double? Taxable { get; set; }
        public string? InsuredFirstName { get; set; }
        public string? OrganizationCode { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? LastChangedBy { get; set; }
        public string? LastChanged { get; set; }
        public string? PolicyNumber { get; set; }
        public double? ClaimedAmount { get; set; }
        public int? BrokerId { get; set; }
        public int? AdjestorId { get; set; }
        public string? BrokerName { get; set; }
    }
}
