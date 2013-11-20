using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KnockoutAttributeValidation.Validators;

namespace KnockoutAttributeValidation.ValidationBuilders
{
    public class CompareValidatorBuilder : IValidatorBuilder
    {
        public Type ValidationAttributeType { get { return typeof(CompareAttribute); } }

        public IEnumerable<IValidator> Build(ValidationAttribute attribute)
        {
            var compareAttribute = (CompareAttribute)attribute;

            var validator = new CompareValidator()
            {
                ErrorMessage = compareAttribute.ErrorMessage,
                OtherProperty = compareAttribute.OtherProperty,
            };

            return new IValidator[] { validator };
        }
    }
}
