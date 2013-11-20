
namespace KnockoutAttributeValidation.Validators
{
    public class MinLengthValidator : IValidator
    {
        public string ValidatorType { get { return "MinLength"; } }

        public int Length { get; set; }

        public string ErrorMessage { get; set; }
    }
}
