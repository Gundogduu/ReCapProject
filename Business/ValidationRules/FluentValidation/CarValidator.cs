using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        
        public CarValidator()
        {
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.BrandId).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(10).When(c => c.ColorId == 1);
            RuleFor(c => c.Description).Must(StartWithA).WithMessage("Açıklama B harfi ile başlamalı");
        }

        
        private bool StartWithA(string arg)
        {
            return arg.StartsWith("B");
        }
    }
}
