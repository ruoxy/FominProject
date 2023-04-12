using System;
using System.Collections.Generic;

namespace WebApplication2прктика.Models
{
    public partial class CartItem
    {
        public int ProductId { get; set; }
        public int CartId { get; set; }
        public int Amount { get; set; }
        public int? Price { get; set; }

        public virtual Cart Cart { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
