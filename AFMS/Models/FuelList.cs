using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AFMS.Models
{
    public partial class FuelList
    {
        public FuelList()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int FuelId { get; set; }
        public string FuelName { get; set; }
        public double FuelPrevCost { get; set; }
        public double FuelCurrentPrice { get; set; }
        public TimeSpan? LastUpdated { get; set; }
        public string Place { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
