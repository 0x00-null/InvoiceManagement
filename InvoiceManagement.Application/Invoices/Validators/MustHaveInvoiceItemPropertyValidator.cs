using FluentValidation.Validators;
using InvoiceManagement.Application.Invoices.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace InvoiceManagement.Application.Invoices.Validators
{
    public class MustHaveInvoiceItemPropertyValidator : PropertyValidator
    {
        public MustHaveInvoiceItemPropertyValidator() : base("Property {PropertyName} should not be an empty list")
        {

        }
        protected override bool IsValid(PropertyValidatorContext context)
        {
            return context.PropertyValue is ICollection<InvoiceItemViewModel> list && list.Any();
        }
    }
}
