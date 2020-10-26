using CrecheApp.Domain.Model;
using FluentValidation;

namespace CrecheApp.Service.FluentValidation
{
    public class UserValidator : AbstractValidator<UserModel>
    {
        public UserValidator()
        {
            RuleFor(m => m.Email).NotEmpty();
            RuleFor(m => m.FirstName).NotEmpty();
            RuleFor(m => m.LastName).NotEmpty();
            RuleFor(m => m.Password).NotEmpty();
            RuleFor(m => m.UserRole).NotEmpty();
        }
    }
}
