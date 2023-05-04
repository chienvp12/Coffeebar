using System;
using System.Collections.Generic;

namespace Coffee.Entities
{
    public partial class Employee
    {
        public Employee()
        {
            Bills = new HashSet<Bill>();
            Orders = new HashSet<Order>();
        }

        public string Id { get; set; } = null!;
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? FullName { get; set; }
        public string? Role { get; set; }
        public string? CoffeeBarId { get; set; }

        public virtual CoffeeBar? CoffeeBar { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
