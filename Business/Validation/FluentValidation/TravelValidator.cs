using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation.FluentValidation
{
    public class TravelValidator : AbstractValidator<Travel>
    {
        public TravelValidator()
        {
            RuleFor(t => t.CountryName).MinimumLength(4).WithMessage("minimum uzunluq 4 dur");
        }
    }
}
