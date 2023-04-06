using FluentValidation;
using Travel.Web.Models.Catalog;

namespace Travel.Web.Validators
{
	public class TourUpdateInputValidator : AbstractValidator<TourUpdateInput>
	{
		public TourUpdateInputValidator()
		{
			RuleFor(x => x.Name).NotEmpty().WithMessage("Turun adını daxil edin");
			RuleFor(x => x.Description).NotEmpty().WithMessage("Tur haqqında məlumatları daxil edin");
			RuleFor(x => x.Feature.Duration).InclusiveBetween(1, int.MaxValue).WithMessage("Turun vaxtını daxil edin");
			RuleFor(x => x.Price).NotEmpty().WithMessage("Turun qiymətini daxil edin").ScalePrecision(2, 6).WithMessage("Qiyməti düzgün daxil edin");
		}
	}
}
