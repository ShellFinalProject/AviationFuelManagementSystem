using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AFMS.Models
{
    public partial class AdminTable
    {
        public string AdminName { get; set; }
        public int AdminId { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Remarks { get; set; }
    }
}
