
namespace KnockoutAttributeValidation.Validators
{
    public interface IValidator
    {
        string ValidatorType { get; }

        string ErrorMessage { get; }
    }
}
