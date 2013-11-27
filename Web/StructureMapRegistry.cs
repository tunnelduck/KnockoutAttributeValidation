using System;
using System.Collections.Generic;
using KnockoutAttributeValidation;
using KnockoutAttributeValidation.ValidationBuilders;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace Web
{
    public class StructureMapRegistry : Registry
    {
        public StructureMapRegistry()
        {
            ObjectFactory.Initialize(x =>
            {
                x.Scan(scan =>
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                });

                x.For<AttributeValidationModelBuilder>().Use(new AttributeValidationModelBuilder(new List<IValidatorBuilder>()
                    {
                        new MaxLengthValidatorBuilder(),
                        new MinLengthValidatorBuilder(),
                        new RegularExpressionValidatorBuilder(),
                        new RequiredValidatorBuilder(),
                        new StringLengthValidatorBuilder(),
                        new CompareValidatorBuilder(),
                        new EmailAddressValidatorBuilder(),
                        new RangeValidatorBuilder()
                    }));
            });
        }
    }
}