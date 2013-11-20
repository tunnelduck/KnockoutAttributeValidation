using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using KnockoutAttributeValidation.ValidationBuilders;
using KnockoutAttributeValidation.Validators;

namespace KnockoutAttributeValidation
{
    public class AttributeValidationModelBuilder
    {
        private readonly Dictionary<Type, IValidatorBuilder> _validationBuilders;

        public AttributeValidationModelBuilder(IEnumerable<IValidatorBuilder> validationBuilders)
        {
            _validationBuilders = validationBuilders.ToDictionary(x => x.ValidationAttributeType, y => y);
        }

        public AttributeValidationModel GetValidation(Type modelType)
        {
            var properties =
                modelType.GetProperties();

            var validationModel = new AttributeValidationModel();
            var objectPropertyValidators = new Dictionary<string, PropertyValidation>();

            foreach (var property in properties)
            {
                var attributes = property.GetCustomAttributes(true);
                var propertyValidators = new List<IValidator>();

                foreach (var attribute in attributes)
                {
                    if (attribute is ValidationAttribute == false)
                    {
                        continue;
                    }

                    var attributeType = attribute.GetType();

                    IValidatorBuilder builder;
                    if (!_validationBuilders.TryGetValue(attributeType, out builder))
                    {
                        continue;
                    }

                    var validators = builder.Build(attribute as ValidationAttribute);
                    propertyValidators.AddRange(validators);
                }

                objectPropertyValidators.Add(property.Name, new PropertyValidation()
                {
                    //recurse complex types
                    ChildModel = ShouldRecurseForType(property.PropertyType) ? GetValidation(property.PropertyType) : null,
                    Validators = propertyValidators
                });
            }

            validationModel.PropertyValidators = objectPropertyValidators;

            return validationModel;
        }

        private bool ShouldRecurseForType(Type propertyType)
        {
            if (propertyType.IsClass && propertyType.Name != "String")
            {
                return true;
            }

            return false;
        }


    }
}
