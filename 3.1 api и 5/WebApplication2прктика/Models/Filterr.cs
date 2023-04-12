using System;
using System.Collections.Generic;

namespace WebApplication2прктика.Models
{
    public partial class Filterr
    {
        public Filterr()
        {
            Products = new HashSet<Product>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public bool Popular { get; set; }
        public int Price { get; set; }
        public int Sale { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
