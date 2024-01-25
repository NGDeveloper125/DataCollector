
namespace Domain.DataValidator;

public interface IValidator
{
    ValidationResult ValidateData(object[] data);
}