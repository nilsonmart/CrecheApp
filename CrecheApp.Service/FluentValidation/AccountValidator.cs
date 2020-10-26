using CrecheApp.Domain.Model;
using FluentValidation;

namespace CrecheApp.Service.FluentValidation
{
    public class AccountValidator : AbstractValidator<AccountModel>
    {
        public AccountValidator()
        {
            RuleFor(m => m.Name).NotEmpty();
        }
    }
}
