using System;
using System.Collections.Generic;

namespace Coffee.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public string Id { get; set; } = null!;
        public string? FullName { get; set; }
        public string? Address { get; set; }
        public string? Mobile { get; set; }
        public string? Note { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
