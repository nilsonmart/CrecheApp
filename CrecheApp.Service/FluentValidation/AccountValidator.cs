using CrecheApp.Domain.Dto;
using FluentValidation;

namespace CrecheApp.Service.FluentValidation
{
    public class AccountValidator : AbstractValidator<AccountDto
        >
    {
        public AccountValidator()
        {
            RuleFor(m => m.Name).NotEmpty();
        }
    }
}
