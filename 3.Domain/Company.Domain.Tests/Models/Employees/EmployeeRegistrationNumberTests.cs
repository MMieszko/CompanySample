using System;
using Company.Domain.Exceptions;
using Company.Domain.Models.Employees;
using FluentAssertions;
using Xunit;

namespace Company.Domain.Tests.Models.Employees
{
    public class EmployeeRegistrationNumberTests
    {

        [Fact]
        public void Ctor_CorrectData_ShouldCreate1()
        {
            var result = new EmployeeRegistrationNumber(1);

            result.Value.Should().Be("00000001");
            result.IntegerValue.Should().Be(1);
        }

        [Fact]
        public void Ctor_CorrectData_ShouldCreate2()
        {
            var result = new EmployeeRegistrationNumber(99999999);

            result.Value.Should().Be("99999999");
            result.IntegerValue.Should().Be(99999999);
        }

        [Fact]
        public void Ctor_CorrectData_ShouldCreate3()
        {
            var result = new EmployeeRegistrationNumber(5123);

            result.Value.Should().Be("00005123");
            result.IntegerValue.Should().Be(5123);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-999991)]
        public void Ctor_ValueTooLow_ShouldThrow(int value)
        {
            Action action = () => new EmployeeRegistrationNumber(value);

            action.Should().Throw<ObjectCreationException>();
        }

        [Theory]
        [InlineData(100000000)]
        [InlineData(100000001)]
        [InlineData(999999999)]
        public void Ctor_ValueTooHigh_ShouldThrow(int value)
        {
            Action action = () => new EmployeeRegistrationNumber(value);

            action.Should().Throw<ObjectCreationException>();
        }
    }
}