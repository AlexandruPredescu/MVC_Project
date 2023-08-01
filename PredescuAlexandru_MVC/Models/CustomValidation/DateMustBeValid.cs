using System.ComponentModel.DataAnnotations;

namespace PredescuAlexandru_MVC.Models.CustomValidation
{
    public class DateMustBeValid : ValidationAttribute
    {
        private readonly string _validFrom;

        public DateMustBeValid(string validFrom)
        {
            _validFrom = validFrom;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var validFromProperty = validationContext.ObjectType.GetProperty(_validFrom);
            var ValidFromValue = validFromProperty.GetValue(validationContext.ObjectInstance, null);
            var validTo = value;

            if (ValidFromValue is DateTime validFromDate && validTo is DateTime validToDate)
            {
                if (validFromDate > validToDate)
                {
                    return new ValidationResult(ErrorMessage);
                }
            }

            return ValidationResult.Success;
        }
    }
}
