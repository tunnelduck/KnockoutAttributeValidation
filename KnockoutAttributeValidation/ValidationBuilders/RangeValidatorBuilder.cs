using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnockoutAttributeValidation.Validators;

namespace KnockoutAttributeValidation.ValidationBuilders
{
    public class RangeValidatorBuilder : IValidatorBuilder
    {
        public Type ValidationAttributeType { get { return typeof(RangeAttribute); } }

        public IEnumerable<IValidator> Build(ValidationAttribute attribute)
        {
            var rangeAttribute = (RangeAttribute)attribute;

            var validator = new RangeValidator()
            {
                ErrorMessage = rangeAttribute.ErrorMessage,
                Minimum = rangeAttribute.Minimum,
                Maximum = rangeAttribute.Maximum,
            };

            return new IValidator[] { validator };
        }
    }
}
