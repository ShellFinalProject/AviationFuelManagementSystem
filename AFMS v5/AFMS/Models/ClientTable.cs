using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AFMS.Models
{
    public partial class ClientTable
    {
        public ClientTable()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string Gstin { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? LoyaltyPoints { get; set; }

        public virtual FlightDetails FlightDetails { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
