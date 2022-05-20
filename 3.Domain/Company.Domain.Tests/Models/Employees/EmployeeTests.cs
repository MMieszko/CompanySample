using System;
using Company.Domain.Exceptions;
using Company.Domain.Models.Employees;
using Company.Domain.Models.Shared;
using FluentAssertions;
using Xunit;

namespace Company.Domain.Tests.Models.Employees
{
    public class EmployeeTests
    {
        [Fact]
        public void Ctor_CorrectData_ShouldCreate1()
        {
            var number = new EmployeeRegistrationNumber(1);
            var gender = new Gender(GenderEnum.Male);
            var surname = new EmployeeSurname("Asd");

            var employee = new Employee(number, surname, gender);

            employee.RegistrationNumber.Value.Should().Be(number.Value);
            employee.Gender.Value.Should().Be(gender.Value);
            employee.Surname.Value.Should().Be(surname.Value);
        }

        [Fact]
        public void Ctor_CorrectData_ShouldCreate2()
        {
            var number = new EmployeeRegistrationNumber(500);
            var gender = new Gender(GenderEnum.Female);
            var surname = new EmployeeSurname("Dsa");

            var employee = new Employee(number, surname, gender);

            employee.RegistrationNumber.Value.Should().Be(number.Value);
            employee.Gender.Value.Should().Be(gender.Value);
            employee.Surname.Value.Should().Be(surname.Value);
        }

        [Fact]
        public void Ctor_NullGender_ShouldThrow()
        {
            var number = new EmployeeRegistrationNumber(500);
            Gender gender = null;
            var surname = new EmployeeSurname("Dsa");

            Action act = () => new Employee(number, surname, gender);

            act.Should().Throw<ObjectCreationException>();
        }

        [Fact]
        public void Ctor_NullSurname_ShouldThrow()
        {
            var number = new EmployeeRegistrationNumber(500);
            var gender = new Gender(GenderEnum.Male);
            EmployeeSurname surname = null;

            Action act = () => new Employee(number, surname, gender);

            act.Should().Throw<ObjectCreationException>();
        }

        [Fact]
        public void Ctor_NullNumber_ShouldThrow()
        {
            EmployeeRegistrationNumber number = null;
            var gender = new Gender(GenderEnum.Male);
            var surname = new EmployeeSurname("Dsa");

            Action act = () => new Employee(number, surname, gender);

            act.Should().Throw<ObjectCreationException>();
        }

        [Fact]
        public void ChangeSurname_CorrectData_ShouldChange()
        {
            const string newSurnameValue = "Dsa";

            var employee = CreateValidEmployee();

            var newSurname = new EmployeeSurname(newSurnameValue);

            employee.ChangeSurname(newSurname);

            employee.Surname.Value.Should().Be(newSurnameValue);
        }

        [Fact]
        public void ChangeSurname_NullSurname_ShouldThrow()
        {
            var employee = CreateValidEmployee();

            EmployeeSurname newSurname = null;

            Action act = () => employee.ChangeSurname(newSurname);

            act.Should().Throw<ObjectUpdateException>();
        }

        [Fact]
        public void ChangeGender_CorrectData_ShouldChange()
        {
            const GenderEnum newGenderValue = GenderEnum.Female;

            var employee = CreateValidEmployee();

            var newGender = new Gender(newGenderValue);

            employee.ChangeGender(newGender);

            employee.Gender.Value.Should().Be(newGenderValue);
        }

        [Fact]
        public void ChangeGender_NullValue_ShouldThrow()
        {
            var employee = CreateValidEmployee();

            Action act = () => employee.ChangeGender(null);

            act.Should().Throw<ObjectUpdateException>();
        }

        private static Employee CreateValidEmployee()
        {
            var number = new EmployeeRegistrationNumber(1);
            var gender = new Gender(GenderEnum.Male);
            var surname = new EmployeeSurname("Asd");

            return new Employee(number, surname, gender);
        }
    }
}
