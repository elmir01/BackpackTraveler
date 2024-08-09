using Entities.Concrete;
using FluentValidation;

namespace Business.Validation.FluentValidation
{
    public class AboutMeValidator : AbstractValidator<AboutMe>
    {
        public AboutMeValidator()
        {
            RuleFor(a => a.Description).MinimumLength(5).WithMessage("5 den cox olmali").NotEmpty().WithMessage("bosh gonderile bilmez");

        }
    }
}
