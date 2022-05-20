using System.Threading.Tasks;
using Company.Application.Controllers;
using Company.Application.DataTransferObjects.Employees;
using Company.Domain.Contracts;
using Company.Domain.Models.Employees;
using Company.Domain.Models.Shared;
using Company.Domain.Services;
using FluentAssertions;
using Moq;
using Xunit;

namespace Company.Application.Tests.Controllers
{
    public class EmployeeControllerTests
    {
        private readonly EmployeeController _controller;
        private readonly Mock<IEmployeeRepository> _employeeRepositoryMock;
        private readonly Mock<IEmployeeRegistrationNumberFactory> _registrationNumberFactoryMock;

        public EmployeeControllerTests()
        {
            _employeeRepositoryMock = new Mock<IEmployeeRepository>();
            _registrationNumberFactoryMock = new Mock<IEmployeeRegistrationNumberFactory>();
            _controller = new EmployeeController(_registrationNumberFactoryMock.Object, _employeeRepositoryMock.Object);
        }

        /// <summary>
        /// Ta metoda sprawdza, czy do repozytorium dodal sie ten konkretny pracownik.
        /// Nie tego typu testu wczesniej, zawsze uzywalem InMemoryDatabase od EF, ktory w ten test skraca do kilku linii bez mockowania.
        /// </summary>
        [Fact]
        public async Task CreateAsync_CorrectData_ShouldStoreInRepository()
        {
            var inputEmployee = new EmployeeDto
            {
                Gender = GenderEnum.Male,
                Surname = "Dsa",
                RegistrationNumber = "00000010"
            };

            var databaseAddEmploye = new EmployeeDto();

            _registrationNumberFactoryMock.Setup(x => x.CreateAsync())
                .ReturnsAsync(new EmployeeRegistrationNumber(10));

            _employeeRepositoryMock.Setup(x => x.AddAsync(It.IsAny<Employee>()))
                .Callback<Employee>(employee =>
                {
                    databaseAddEmploye.Gender = employee.Gender;
                    databaseAddEmploye.Surname = employee.Surname;
                    databaseAddEmploye.RegistrationNumber = employee.RegistrationNumber;
                });

            await _controller.CreateAsync(inputEmployee);

            _employeeRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Employee>()), Times.Once);

            databaseAddEmploye.Gender.Should().Be(inputEmployee.Gender);
            databaseAddEmploye.Surname.Should().Be(inputEmployee.Surname);
            databaseAddEmploye.RegistrationNumber.Should().Be(inputEmployee.RegistrationNumber);
        }
    }
}
