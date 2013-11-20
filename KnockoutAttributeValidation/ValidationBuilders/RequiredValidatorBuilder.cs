using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KnockoutAttributeValidation.Validators;

namespace KnockoutAttributeValidation.ValidationBuilders
{
    public class RequiredValidatorBuilder : IValidatorBuilder
    {
        public Type ValidationAttributeType { get { return typeof(RequiredAttribute); } }

        public IEnumerable<IValidator> Build(ValidationAttribute attribute)
        {
            var requiredAttribute = (RequiredAttribute)attribute;

            var validator = new RequiredValidator()
            {
                ErrorMessage = requiredAttribute.ErrorMessage,


            };

            return new IValidator[] { validator };
        }
    }
}
