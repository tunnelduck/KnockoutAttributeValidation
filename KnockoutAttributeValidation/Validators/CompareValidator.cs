
namespace KnockoutAttributeValidation.Validators
{
    public class CompareValidator : IValidator
    {
        public string ValidatorType { get { return "Compare"; } }
        public string ErrorMessage { get; set; }
        public string OtherProperty { get; set; }
    }
}
