using FluentValidation;
using Temp.Common.Resources;
using Temp.DataAccess.Migrations;
using Temp.Service.ViewModel;

namespace Temp.Web.Infrastructure.Validations
{
    /// <summary>
    /// validate form register new user
    /// </summary>
    public class CreateUserValidate : AbstractValidator<CreateAccViewModel>
    {
        public CreateUserValidate()
        {
            RuleFor(s => s.Username).NotNull()
                .WithMessage(MessageResource.NullPassword);
            
            RuleFor(reg => reg.Password).NotNull()
                  .WithMessage(MessageResource.NullPassword)
                   .MinimumLength(3)
                   .WithMessage(MessageResource.PasswordLength)
                   .MaximumLength(50);
            
            RuleFor(reg => reg.ConfirmPass).NotNull()
                    .WithMessage(MessageResource.NullPassword)                    
                    .Equal(reg => reg.Password).WithMessage(MessageResource.Compare);
        } 
    }
}