using System.ComponentModel.DataAnnotations;


namespace webapp4_mvc.Models
{
    public class Createmvc
    {

        public int Id { get; set; }
        
        [Required(ErrorMessage = "Name is required.")]
        public string? InsuredName { get; set; }
        public string? InsuredClaimNo { get; set; }
        public DateTime? InsuredContactedDate { get; set; }
        [Required(ErrorMessage = "claimTypoe code  required.")]
        public string? ClaimTypeCode { get; set; }
        public string? LossDescCode { get; set; }
        [Required(ErrorMessage = "InsurerId required.")]
        public string? InsurerId { get; set; }
        public double? Rate { get; set; }
        public double? Period { get; set; }
        [Required(ErrorMessage = "LossLocation required.")]
        public string? LossLocation { get; set; }
        [Required(ErrorMessage = "LossDate required.")]

        public DateTime? LossDate { get; set; }
        [Required(ErrorMessage = "ReceiveDate required.")]

        public DateTime? ReceiveDate { get; set; }
        [Required(ErrorMessage = "OpenDate required.")]

        public DateTime? OpenDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public DateTime? PolicyInceptionDate { get; set; }
        public DateTime? PolicyExpiryDate { get; set; }
        public double? Taxable { get; set; }
        public string? InsuredFirstName { get; set; }
        [Required(ErrorMessage = "Organization code is required.")]

        public string? OrganizationCode { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? LastChangedBy { get; set; }
        public string? LastChanged { get; set; }
        public string? PolicyNumber { get; set; }
        public double? ClaimedAmount { get; set; }
        public int? AdjestorId { get; set; }
        public int? BrokerId { get; set; }
        [Required(ErrorMessage = "Brokername required.")]

        public string? BrokerName { get; set; }

        public Dictionary<int, string> BrokersList { get; set; }
        public Dictionary<string, string> InsurerList { get; set; }

        public List<string>Totalclaims{ get; set; }
    }
}

