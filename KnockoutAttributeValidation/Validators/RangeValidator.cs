
namespace KnockoutAttributeValidation.Validators
{
    public class RangeValidator : IValidator
    {
        public string ValidatorType { get { return "Range"; } }

        public int? Min { get; set; }

        public int? Max { get; set; }

        public string ErrorMessage { get; set; }
    }
}
