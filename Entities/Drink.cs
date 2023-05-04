using System;
using System.Collections.Generic;

namespace Coffee.Entities
{
    public partial class Drink
    {
        public Drink()
        {
            UserDrinks = new HashSet<UserDrink>();
        }

        public string Id { get; set; } = null!;
        public string? Name { get; set; }
        public float? Price { get; set; }
        public float? Discount { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<UserDrink> UserDrinks { get; set; }
    }
}
