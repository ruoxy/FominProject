using System;
using System.Collections.Generic;

namespace WebApplication2прктика.Models
{
    public partial class Product
    {
        public Product()
        {
            CartItems = new HashSet<CartItem>();
            DescriptionProducts = new HashSet<DescriptionProduct>();
        }

        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; } = null!;
        public string? ProductDescription { get; set; }
        public int ProductAvailability { get; set; }
        public int Price { get; set; }

        public virtual Filterr Category { get; set; } = null!;
        public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual ICollection<DescriptionProduct> DescriptionProducts { get; set; }
    }
}
