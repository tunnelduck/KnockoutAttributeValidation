using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KnockoutAttributeValidation.Validators;

namespace KnockoutAttributeValidation.ValidationBuilders
{
    public interface IValidatorBuilder
    {
        Type ValidationAttributeType { get; }
        IEnumerable<IValidator> Build(ValidationAttribute attribute);
    }
}
