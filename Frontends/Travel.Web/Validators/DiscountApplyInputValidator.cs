using FluentValidation;
using Travel.Web.Models.Discounts;

namespace Travel.Web.Validators
{
	public class DiscountApplyInputValidator:AbstractValidator<DiscountApplyInput>
	{
        public DiscountApplyInputValidator()
        {
            RuleFor(x => x.Code).NotEmpty().WithMessage("Kupon kod daxil edin");
        }
    }
}
