using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KnockoutAttributeValidation.Validators;

namespace KnockoutAttributeValidation.ValidationBuilders
{
    public class MinLengthValidatorBuilder : IValidatorBuilder
    {
        public Type ValidationAttributeType { get { return typeof(MinLengthAttribute); } }

        public IEnumerable<IValidator> Build(ValidationAttribute attribute)
        {
            var minLengthAttribute = (MinLengthAttribute)attribute;

            var validator = new MinLengthValidator()
            {
                ErrorMessage = minLengthAttribute.ErrorMessage,
                Length = minLengthAttribute.Length
            };

            return new IValidator[] { validator };
        }
    }
}
