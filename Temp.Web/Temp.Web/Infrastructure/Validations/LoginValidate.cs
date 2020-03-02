using FluentValidation;
using Temp.Common.Resources;
using Temp.Service.ViewModel;

namespace Temp.Web.Infrastructure.Validations
{
    public class LoginValidate : AbstractValidator<LogInViewModel>
    {
        /// <summary>
        /// validate form login
        /// </summary>
        public LoginValidate()
        {
            RuleFor(s => s.Password).NotNull()
                .WithMessage(MessageResource.NullPassword);                
            RuleFor(reg => reg.Username).NotNull()
                .WithMessage(MessageResource.NullUsername);              
        }
    }
}
