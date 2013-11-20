using System.Collections.Generic;

namespace KnockoutAttributeValidation
{
    public class AttributeValidationModel
    {
        public Dictionary<string, PropertyValidation> PropertyValidators { get; set; }
    }
}
