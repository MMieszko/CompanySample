using System.Text.RegularExpressions;
using Company.Domain.Abstraction;
using Company.Domain.Exceptions;

namespace Company.Domain.Models.Employees
{
    public class EmployeeRegistrationNumber : SinglePropertyValueObject<string>
    {
        public const int MaxLength = 8;
        private const int MinimumIntegerValue = 1;

        internal int IntegerValue => int.Parse(Regex.Match(this.Value, @"\d+").Value);

        internal EmployeeRegistrationNumber(int value)
            : base(value.ToString($"D{MaxLength}"))
        {
            if (value < MinimumIntegerValue || value.ToString().Length > MaxLength)
                throw new ObjectCreationException(nameof(EmployeeRegistrationNumber), $"Incorrect value: {value}");
        }
    }
}