
namespace KnockoutAttributeValidation.Validators
{
    public class MaxLengthValidator : IValidator
    {
        public string ValidatorType { get { return "MaxLength"; } }

        public int Length { get; set; }

        public string ErrorMessage { get; set; }
    }
}
