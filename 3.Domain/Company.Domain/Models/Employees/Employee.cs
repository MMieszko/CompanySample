using System;
using Company.Domain.Abstraction;
using Company.Domain.Exceptions;
using Company.Domain.Models.Shared;

namespace Company.Domain.Models.Employees
{
    public class Employee : Entity<Guid>
    {
        public EmployeeRegistrationNumber RegistrationNumber { get; }
        public EmployeeSurname Surname { get; private set; }
        public Gender Gender { get; private set; }

        public Employee(EmployeeRegistrationNumber number, EmployeeSurname surname, Gender gender)
        {
            RegistrationNumber = number ?? throw new ObjectCreationException(nameof(Employee), $"Null {nameof(EmployeeRegistrationNumber)} assign");
            Surname = surname ?? throw new ObjectCreationException(nameof(Employee), $"Null {nameof(EmployeeSurname)} assign");
            Gender = gender ?? throw new ObjectCreationException(nameof(Employee), $"Null {nameof(Gender)} assign");
        }

        public void ChangeSurname(EmployeeSurname surname)
        {
            this.Surname = surname ?? throw new ObjectUpdateException(nameof(Employee), nameof(Surname));
        }

        public void ChangeGender(Gender gender)
        {
            this.Gender = gender ?? throw new ObjectUpdateException(nameof(Employee), nameof(Gender));
        }
    }
}