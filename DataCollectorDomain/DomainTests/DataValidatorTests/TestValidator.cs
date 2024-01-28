using Domain.DataValidator;

namespace DomainTests.DataValidatorTests;

public class TestValidator : IValidator
{
    public ValidationResult ValidateData(object[] data)
    {
        return RunValidation((int)data[0], (bool)data[1], (string)data[2]);
    }

    public ValidationResult RunValidation(int value1, bool value2, string value3)
    {
        if (value1 == 0)
        {
            return new ValidationResult(false, "Value1 cannot be 0");
        }
        return new ValidationResult(true, string.Empty);
    }
}