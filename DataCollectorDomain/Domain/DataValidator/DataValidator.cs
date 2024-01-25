
using System.ComponentModel.DataAnnotations;

namespace Domain.DataValidator;
    public class DataValidator
    {
        public ValidationResult ValidateData(IValidator validator, object[] data)
        {
            if (validator == null)
            {
                return new ValidationResult(false, "Validator cannot be null");
            }

            if (data == null || data.Length == 0)
            {
                return new ValidationResult(false, "Objects array cannot be null or empty");
            }

            ValidationResult result = IsCompatible(validator, data);
            if (!result.IsValid)
            {
                return result;
            }
            return validator.ValidateData(data);
        }

        private ValidationResult IsCompatible(IValidator validator, object[] data)
        {
            var validateMethod = validator.GetType().GetMethod("RunValidation");
            if (validateMethod == null)
            {
                return new ValidationResult(false, "Could not find a method with this name in the validator");
            }

            var parameters = validateMethod.GetParameters();
            if (parameters.Length != data.Length)
            {
                return new ValidationResult(false, "Validator and objects array do not match in size");
            }

            for (int i = 0; i < parameters.Length; i++)
            {
                if (!parameters[i].ParameterType.IsInstanceOfType(data[i]))
                {
                    return new ValidationResult(false, $"Validator and objects array do not match in type at index {i}");
                }
            }

            return new ValidationResult(true, string.Empty);
        }
    }