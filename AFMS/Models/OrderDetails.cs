using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AFMS.Models
{
    public partial class OrderDetails
    {
        public int OrderId { get; set; }
        public int ClientId { get; set; }
        public string FlightNo { get; set; }
        public float FuelAmt { get; set; }
        public int FuelId { get; set; }
        public DateTime? OrderPlaceDate { get; set; }
        public DateTime? OrderDeliveryDate { get; set; }
        public string Status { get; set; }

        public virtual ClientTable Client { get; set; }
        public virtual FlightDetails FlightNoNavigation { get; set; }
        public virtual FuelList Fuel { get; set; }
    }
}
