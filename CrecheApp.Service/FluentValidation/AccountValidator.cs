using CrecheApp.Domain.Entity;
using FluentValidation;

namespace CrecheApp.Service.FluentValidation
{
    public class AccountValidator : AbstractValidator<Account>
    {
        public AccountValidator()
        {
            RuleFor(m => m.Name).NotEmpty();
        }
    }
}
