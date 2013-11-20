using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KnockoutAttributeValidation.Validators;

namespace KnockoutAttributeValidation.ValidationBuilders
{
    public class StringLengthValidatorBuilder : IValidatorBuilder
    {
        public Type ValidationAttributeType { get { return typeof(StringLengthAttribute); } }

        public IEnumerable<IValidator> Build(ValidationAttribute attribute)
        {
            var stringLengthAttribute = (StringLengthAttribute)attribute;

            var maxLengthValidator = new MaxLengthValidator()
            {
                ErrorMessage = stringLengthAttribute.ErrorMessage,
                Length = stringLengthAttribute.MaximumLength
            };

            var minLengthValidator = new MinLengthValidator()
            {
                ErrorMessage = stringLengthAttribute.ErrorMessage,
                Length = stringLengthAttribute.MinimumLength
            };

            return new IValidator[] { maxLengthValidator, minLengthValidator };
        }
    }
}
