using System.Text.RegularExpressions;
using Company.Domain.Abstraction;
using Company.Domain.Exceptions;

namespace Company.Domain.Models.Employees
{
    public class EmployeeRegistrationNumber : SinglePropertyValueObject<string>
    {
        public const int ValidLength = 8;
        public int IntegerValue => int.Parse(Regex.Match(this.Value, @"\d+").Value);

        internal EmployeeRegistrationNumber(int value)
            : base(value.ToString("D8"))
        {
            if (value < 1 || value.ToString().Length > ValidLength)
                throw new ObjectCreationException(nameof(EmployeeRegistrationNumber), $"Incorrect value: {value}");
        }
    }
}