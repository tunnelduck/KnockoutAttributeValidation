
namespace KnockoutAttributeValidation.Validators
{
    public class RegularExpressionValidator : IValidator
    {
        public string ValidatorType { get { return "RegularExpression"; } }

        public string Pattern { get; set; }

        public string ErrorMessage { get; set; }
    }

}
