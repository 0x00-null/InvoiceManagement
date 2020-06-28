using InvoiceManagement.Application.Common.Interfaces;
using InvoiceManagement.Application.Invoices.Commands;
using InvoiceManagement.Application.Invoices.Queries;
using InvoiceManagement.Application.Invoices.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InvoiceManagement.WebApi.Controllers
{
    [Authorize]
    public class InvoicesController : ApiController
    {
        private readonly ICurrentUserService _currentUserService;

        public InvoicesController(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> Create(CreateInvoiceCommand command)
        {
            return await Mediator.Send(command);
        }
        [HttpGet]
        public async Task<ICollection<InvoiceViewModel>> Get()
        {
            return await Mediator.Send(new GetUserInvoicesQuery { UserId = _currentUserService.UserId });
        }
    }
}
