using InvoiceManagement.Application.Invoices.ViewModels;
using InvoiceManagement.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;

namespace InvoiceManagement.Application.Invoices.Commands
{
    public class CreateInvoiceCommand : IRequest<Guid>
    {
        public CreateInvoiceCommand()
        {
            this.InvoiceItems = new List<InvoiceItemViewModel>();
        }
        public string InvoiceNumber { get; set; }
        public string Logo { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime Date { get; set; }
        public string PaymentTerms { get; set; }
        public DateTime? DueDate { get; set; }
        public double Discount { get; set; }
        public DiscountType DiscountType { get; set; }
        public double Tax { get; set; }
        public TaxType TaxType { get; set; }
        public double AmountPaid { get; set; }
        public IList<InvoiceItemViewModel> InvoiceItems { get; set; }
    }
}
