using System.Collections.Generic;
using KnockoutAttributeValidation.Validators;

namespace KnockoutAttributeValidation
{
    public class PropertyValidation
    {
        public IEnumerable<IValidator> Validators { get; set; }

        public AttributeValidationModel ChildModel { get; set; }
    }
}
