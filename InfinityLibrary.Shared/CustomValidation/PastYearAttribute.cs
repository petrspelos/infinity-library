using System;
using System.ComponentModel.DataAnnotations;

namespace InfinityLibrary.Shared.CustomValidation
{
    public class PastYearAttribute : ValidationAttribute
    {
        private readonly bool _includeCurrentYear;

        public PastYearAttribute(bool includeCurrentYear)
        {
            _includeCurrentYear = includeCurrentYear;
        }

        public override bool IsValid(object value)
        {
            var inputYear = (int) value;
            var currentYear = DateTime.Today.Year;
            return inputYear == currentYear ? _includeCurrentYear : inputYear < currentYear;
        }
    }
}