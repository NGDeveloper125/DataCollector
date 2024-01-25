using Xunit;
using FluentAssertions;

using Domain.DataValidator;

namespace DomainTests.DataValidatorTests;

public class DataValidatorTests
{
    [Fact]
    public void ValidateData_ReturnsFalse_WhenValidatorIsNull()
    {
        // Given a DataValidator 
        var dataValidator = new DataValidator();

        // When ValidateData is called with null validator
        ValidationResult result = dataValidator.ValidateData(null, new object[0]);

        // Then the result should be false and have an error message 
        result.IsValid.Should().BeFalse();
        result.ErrorMessage.Should().Be("Validator cannot be null");
    }

    [Fact]
    public void ValidateData_ReturnsFalse_WhenObjectsArrayIsNull()
    {
        // Given a DataValidator 
        var dataValidator = new DataValidator();

        // When ValidateData is called with a valid validator and null objects array
        IValidator validator = new TestValidator();
        ValidationResult result = dataValidator.ValidateData(validator, null);

        // Then the result should be false and have an error message 
        result.IsValid.Should().BeFalse();
        result.ErrorMessage.Should().Be("Objects array cannot be null or empty");
    }

    [Fact]
    public void ValidateData_ReturnsFalse_WhenObjectsArrayIsEmpty()
    {
        // Given a DataValidator 
        var dataValidator = new DataValidator();

        // When ValidateData is called with a valid validator and null objects array
        IValidator validator = new TestValidator();
        ValidationResult result = dataValidator.ValidateData(validator, new object[0]);

        // Then the result should be false and have an error message 
        result.IsValid.Should().BeFalse();
        result.ErrorMessage.Should().Be("Objects array cannot be null or empty");
    }

    [Fact]
    public void ValidateData_ReturnsFalse_WhenValidatorDoNotFitObjectsArrayInSize()
    {
        // Given a DataValidator 
        var dataValidator = new DataValidator();

        // When ValidateData is called with a valid validator and null objects array
        IValidator validator = new TestValidator();
        ValidationResult result = dataValidator.ValidateData(validator, new object[1] {0});

        // Then the result should be false and have an error message 
        result.IsValid.Should().BeFalse();
        result.ErrorMessage.Should().Be("Validator and objects array do not match in size");
    }

    [Fact]
    public void ValidateData_ReturnsFalse_WhenValidatorDoNotFitObjectArrayInType()
    {
        // Given a DataValidator 
        var dataValidator = new DataValidator();

        // When ValidateData is called with a valid validator and null objects array
        IValidator validator = new TestValidator();
        ValidationResult result = dataValidator.ValidateData(validator, new object[3] {0, 0, 0});

        // Then the result should be false and have an error message 
        result.IsValid.Should().BeFalse();
        result.ErrorMessage.Should().Be("Validator and objects array do not match in type at index 1");
    }

    [Fact]
    public void ValidateData_ReturnFalse_WhenValidatorFindTheDataNotValid()
    {
        // Given a DataValidator 
        var dataValidator = new DataValidator();

        // When ValidateData is called with a valid validator and null objects array
        IValidator validator = new TestValidator();
        ValidationResult result = dataValidator.ValidateData(validator, new object[3] {0, true, "0"});

        // Then the result should be false and have an error message 
        result.IsValid.Should().BeFalse();
    }

    [Fact]
    public void ValidateData_ReturnTrue_WhenValidatorFindTheDataValid()
    {
        // Given a DataValidator 
        var dataValidator = new DataValidator();

        // When ValidateData is called with a valid validator and null objects array
        IValidator validator = new TestValidator();
        ValidationResult result = dataValidator.ValidateData(validator, new object[3] {1, true, "0"});

        // Then the result should be false and have an error message 
        result.IsValid.Should().BeTrue();
    }
}