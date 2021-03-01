using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        //kurallar
        public CarValidator()
        {
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.BrandId).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(10).When(c => c.ColorId == 1);
            //kendi kuralımız
            RuleFor(c => c.Description).Must(StartWithA).WithMessage("Açıklama A harfi ile başlamalı");
        }

        //A ile başlamalı kuralı
        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
//validator'ı nesneye göre yani ekranlarınıza göre yapabilirsiniz Dto'ya da yapabilirsiniz.
//kurallar constructor'ın içine yazılır.
//kuralları yan yana da yazabiliriz fakat SOLID'de tek sorumluluk prensibine aykırı bir durum oluyor.
//yarın ben araya when'ler koyabilirim. Örneğin KURAL: tcno zorunludur. NE ZAMAN? eğer tc vatandaşıysa.
//withMessage ile mesaj verebiliriz.