using InvoiceManagement.Application.Invoices.ViewModels;
using MediatR;
using System.Collections.Generic;

namespace InvoiceManagement.Application.Invoices.Queries
{
    public class GetUserInvoicesQuery : IRequest<ICollection<InvoiceViewModel>>
    {
        public string UserId { get; set; }
    }
}
