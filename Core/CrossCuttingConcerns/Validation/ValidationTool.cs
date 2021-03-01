using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator,object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}

//kural kodunun business'da yazdığımız hali
//var context = new ValidationContext<Car>(car);
//CarValidator carValidator = new CarValidator();
//var result = CarValidator.Validate(context);
//if (!result.IsValid)
//{
//    throw new ValidationException(result.Errors);
//}
