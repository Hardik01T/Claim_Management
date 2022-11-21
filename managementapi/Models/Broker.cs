using System;
using System.Collections.Generic;

namespace managementapi.Models
{
    public partial class Broker
    {
        public int BrokerId { get; set; }
        public int? AdjestorId { get; set; }
        public string? BrokerName { get; set; }
    }
}
