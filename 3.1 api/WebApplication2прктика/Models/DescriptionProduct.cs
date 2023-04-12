using System;
using System.Collections.Generic;

namespace WebApplication2прктика.Models
{
    public partial class DescriptionProduct
    {
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public string? TextD { get; set; }
        public int Rating { get; set; }

        public virtual User Customer { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
