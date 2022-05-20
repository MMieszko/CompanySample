using Company.Domain.Abstraction;
using Company.Domain.Exceptions;
using Company.Domain.Extensions;

namespace Company.Domain.Models.Employees
{
    public class EmployeeSurname : SinglePropertyValueObject<string>
    {
        public const int MinimumLength = 1;
        public const int MaximumLength = 50;

        public EmployeeSurname(string value)
            : base(value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ObjectCreationException(nameof(EmployeeSurname), "Empty value");

            if (!value.Length.IsInRange(MinimumLength, MaximumLength))
                throw new ObjectCreationException(nameof(EmployeeSurname), "Invalid length");
        }
    }
}