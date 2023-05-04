using System;
using System.Collections.Generic;

namespace Coffee.Entities
{
    public partial class CoffeeBar
    {
        public CoffeeBar()
        {
            Employees = new HashSet<Employee>();
            Tables = new HashSet<Table>();
        }

        public string Id { get; set; } = null!;
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Mail { get; set; }
        public string? Hotline { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Table> Tables { get; set; }
    }
}
