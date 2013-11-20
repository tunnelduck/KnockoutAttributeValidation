using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KnockoutAttributeValidation.Validators;

namespace KnockoutAttributeValidation.ValidationBuilders
{
    public class RegularExpressionValidatorBuilder : IValidatorBuilder
    {
        public Type ValidationAttributeType { get { return typeof(RegularExpressionAttribute); } }

        public IEnumerable<IValidator> Build(ValidationAttribute attribute)
        {
            var regularExpressionAttribute = (RegularExpressionAttribute)attribute;

            var validator = new RegularExpressionValidator()
            {
                ErrorMessage = regularExpressionAttribute.ErrorMessage,
                Pattern = regularExpressionAttribute.Pattern
            };

            return new IValidator[] { validator };
        }
    }
}
