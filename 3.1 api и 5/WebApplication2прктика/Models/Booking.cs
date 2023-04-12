using System;
using System.Collections.Generic;

namespace WebApplication2прктика.Models
{
    public partial class Booking
    {
        public int BookingId { get; set; }
        public int CartId { get; set; }
        public int? Price { get; set; }
        public string BookingStatus { get; set; } = null!;
        public string Delivery { get; set; } = null!;
        public string BookingAdress { get; set; } = null!;

        public virtual Cart Cart { get; set; } = null!;
    }
}
