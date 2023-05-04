using System;
using System.Collections.Generic;

namespace Coffee.Entities
{
    public partial class UserDrink
    {
        public string Id { get; set; } = null!;
        public int? Quantity { get; set; }
        public string? Note { get; set; }
        public string? DrinkId { get; set; }
        public string? OrderId { get; set; }

        public virtual Drink? Drink { get; set; }
        public virtual Order? Order { get; set; }
    }
}
