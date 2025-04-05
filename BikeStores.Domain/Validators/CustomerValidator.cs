using BikeStores.Domain.Models;
using FluentValidation;

namespace BikeStores.Domain.Validators;

public class CustomerValidator : AbstractValidator<Customer>
{
    public CustomerValidator()
    {
        RuleFor(x => x.FirstName).Length(0, 10);
        RuleFor(x => x.LastName).Length(0, 10);
        RuleFor(x => x.Email).EmailAddress();
    }
}
