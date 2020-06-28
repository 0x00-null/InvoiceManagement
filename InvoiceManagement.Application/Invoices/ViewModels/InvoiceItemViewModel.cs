using System;

namespace InvoiceManagement.Application.Invoices.ViewModels
{
    public class InvoiceItemViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Quantity { get; set; }
        public double Rate { get; set; }
        public double Amount
        {
            get
            {
                return Quantity * Rate;
            }
        }
    }
}
