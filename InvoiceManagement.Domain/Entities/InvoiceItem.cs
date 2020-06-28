using InvoiceManagement.Domain.Common;
using System;

namespace InvoiceManagement.Domain.Entities
{
    public class InvoiceItem : AuditEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Quantity { get; set; }
        public double Rate { get; set; }
        public Invoice Invoice { get; set; }
    }
}
