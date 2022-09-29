using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AFMS.Models
{
    public partial class FlightDetails
    {
        public FlightDetails()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public string FlightNo { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string AircraftType { get; set; }
        public int ClientId { get; set; }

        public virtual ClientTable Client { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
