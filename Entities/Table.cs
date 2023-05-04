using System;
using System.Collections.Generic;

namespace Coffee.Entities
{
    public partial class Table
    {
        public Table()
        {
            BookedTables = new HashSet<BookedTable>();
        }

        public string Id { get; set; } = null!;
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }
        public string? CoffeeBarId { get; set; }

        public virtual CoffeeBar? CoffeeBar { get; set; }
        public virtual ICollection<BookedTable> BookedTables { get; set; }
    }
}
