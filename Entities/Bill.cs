using System;
using System.Collections.Generic;

namespace Coffee.Entities
{
    public partial class Bill
    {
        public string Id { get; set; } = null!;
        public DateTime? PaymentDate { get; set; }
        public string? PaymentType { get; set; }
        public float? TotalMoney { get; set; }
        public string? Note { get; set; }
        public string? EmployeeId { get; set; }
        public string? OrderId { get; set; }

        public virtual Employee? Employee { get; set; }
        public virtual Order? Order { get; set; }
    }
}
