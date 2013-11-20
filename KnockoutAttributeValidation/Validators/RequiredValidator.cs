
namespace KnockoutAttributeValidation.Validators
{
    public class RequiredValidator : IValidator
    {
        public string ValidatorType { get { return "Required"; } }

        public string ErrorMessage { get; set; }
    }
}
