using CrecheApp.Domain.Entity;
using CrecheApp.Domain.Model;
using FluentValidation;

namespace CrecheApp.Service.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(m => m.Email).NotEmpty();
            RuleFor(m => m.FirstName).NotEmpty();
            RuleFor(m => m.LastName).NotEmpty();
            RuleFor(m => m.Password).NotEmpty();
        }
    }
}
