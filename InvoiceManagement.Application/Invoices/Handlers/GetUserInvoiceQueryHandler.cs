using InvoiceManagement.Application.Common.Interfaces;
using InvoiceManagement.Application.Invoices.Queries;
using InvoiceManagement.Application.Invoices.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace InvoiceManagement.Application.Invoices.Handlers
{
    public class GetUserInvoiceQueryHandler : IRequestHandler<GetUserInvoicesQuery, ICollection<InvoiceViewModel>>
    {
        private readonly IApplicationDbContext _context;

        public GetUserInvoiceQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ICollection<InvoiceViewModel>> Handle(GetUserInvoicesQuery request, CancellationToken cancellationToken)
        {
            var result = new List<InvoiceViewModel>();
            var invoices = await _context.Invoices.Include(i => i.InvoiceItems).Where(i => i.CreatedBy == request.UserId).ToListAsync();
            if (invoices != null)
            {
                result = invoices.Select(i => new InvoiceViewModel
                {
                    AmountPaid = i.AmountPaid,
                    Date = i.Date,
                    Discount = i.Discount,
                    DiscountType = i.DiscountType,
                    DueDate = i.DueDate,
                    From = i.From,
                    Id = i.Id,
                    InvoiceNumber = i.InvoiceNumber,
                    Logo = i.Logo,
                    PaymentTerms = i.PaymentTerms,
                    Tax = i.Tax,
                    TaxType = i.TaxType,
                    To = i.To,
                    InvoiceItems = i.InvoiceItems.Select(item => new InvoiceItemViewModel
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Quantity = item.Quantity,
                        Rate = item.Rate
                    }).ToList()

                }).ToList();
            }
            return result;
        }
    }
}
