using FluentValidation;
using Temp.Common.Resources;
using Temp.Service.ViewModel;

namespace Temp.Web.Infrastructure.Validations
{
    /// <summary>
    /// validate form create or edit category
    /// </summary>
    public class CreateCategoryValidate : AbstractValidator<CategoryViewModel>
    {
        public CreateCategoryValidate()
        {
            RuleFor(s => s.Name).NotNull()
                .WithMessage(MessageResource.IsNull);
        }
    }
}