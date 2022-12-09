using FluentValidation;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationException = FluentValidation.ValidationException;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {//Static sınıfın methodları da static olmakk zorundadır. --C# için

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
