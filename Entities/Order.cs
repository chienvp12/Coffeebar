using System;
using System.Collections.Generic;

namespace Coffee.Entities
{
    public partial class Order
    {
        public Order()
        {
            Bills = new HashSet<Bill>();
            BookedTables = new HashSet<BookedTable>();
            UserDrinks = new HashSet<UserDrink>();
        }

        public string Id { get; set; } = null!;
        public DateTime? DateCreate { get; set; }
        public string? Note { get; set; }
        public string? EmployeeId { get; set; }
        public string? CustomerId { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual Employee? Employee { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
        public virtual ICollection<BookedTable> BookedTables { get; set; }
        public virtual ICollection<UserDrink> UserDrinks { get; set; }
    }
}
