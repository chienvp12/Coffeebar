using System;
using System.Collections.Generic;

namespace Coffee.Entities
{
    public partial class BookedTable
    {
        public string Id { get; set; } = null!;
        public DateTime? Checkin { get; set; }
        public DateTime? Checkout { get; set; }
        public string? Note { get; set; }
        public string? OrderId { get; set; }
        public string? TableId { get; set; }

        public virtual Order? Order { get; set; }
        public virtual Table? Table { get; set; }
    }
}
