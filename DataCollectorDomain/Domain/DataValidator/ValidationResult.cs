
namespace Domain.DataValidator;

public record ValidationResult
{
    public bool IsValid { get; init; }
    public string ErrorMessage { get; init; }

    public ValidationResult(bool isValid, string errorMessage)
    {
        IsValid = isValid;
        ErrorMessage = errorMessage;
    }
}