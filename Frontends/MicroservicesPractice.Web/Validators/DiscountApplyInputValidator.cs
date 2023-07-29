using FluentValidation;
using MicroservicesPractice.Web.Models.Discount;

namespace MicroservicesPractice.Web.Validators
{
    public class DiscountApplyInputValidator : AbstractValidator<DiscountApplyInput>
    {
        public DiscountApplyInputValidator()
        {
            RuleFor(x => x.Code).NotEmpty().WithMessage("İndirim kupon alanı boş olamaz.");
        }
    }
}
