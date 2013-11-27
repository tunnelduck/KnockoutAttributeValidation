
namespace KnockoutAttributeValidation.Validators
{
    public class RangeValidator : IValidator
    {
        public string ValidatorType { get { return "Range"; } }

        public string ErrorMessage { get; set; }

        public object Maximum { get; set; }

        public object Minimum { get; set; }
    }
}
