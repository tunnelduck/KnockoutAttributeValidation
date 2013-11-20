using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KnockoutAttributeValidation.Validators;

namespace KnockoutAttributeValidation.ValidationBuilders
{
    public class MaxLengthValidatorBuilder : IValidatorBuilder
    {
        public Type ValidationAttributeType { get { return typeof(MaxLengthAttribute); } }

        public IEnumerable<IValidator> Build(ValidationAttribute attribute)
        {
            var maxLengthAttribute = (MaxLengthAttribute)attribute;

            var validator = new MaxLengthValidator()
            {
                ErrorMessage = maxLengthAttribute.ErrorMessage,
                Length = maxLengthAttribute.Length
            };

            return new IValidator[] { validator };
        }
    }
}
