using System;
using System.ComponentModel.DataAnnotations;

namespace CalculoCDB.API.Validators
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class GreaterThanAttribute : ValidationAttribute
    {
        private readonly double _number;
        public double Number => _number;

        public GreaterThanAttribute(double number)
        {
            _number = number;
        }

        public override bool IsValid(object value)
        {
            var inputValue = Convert.ToDecimal(value);
            return decimal.ToDouble(inputValue) > _number;
        }

        public override string FormatErrorMessage(string name)
            => $"The value of {name} must be greater than {_number}";
    }
}