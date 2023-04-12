﻿using System;
using System.Collections.Generic;

namespace WebApplication2прктика.Models
{
    public partial class User
    {
        public User()
        {
            Carts = new HashSet<Cart>();
            DescriptionProducts = new HashSet<DescriptionProduct>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string? UserEmail { get; set; }
        public string UserRole { get; set; } = null!;
        public string UserPassord { get; set; } = null!;

        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<DescriptionProduct> DescriptionProducts { get; set; }
    }
}
