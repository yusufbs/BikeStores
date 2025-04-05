using BikeStores.Domain.Models;
using FluentValidation;

namespace BikeStores.Domain.Validators;

public class CustomerValidator : AbstractValidator<Customer>
{
    public CustomerValidator()
    {
        
    }
}
