using System;
using System.Threading.Tasks;
using Company.Application.DataTransferObjects.Employees;
using Company.Application.Exceptions;
using Company.Domain.Contracts;
using Company.Domain.Models.Employees;
using Company.Domain.Models.Shared;
using Company.Domain.Services;

namespace Company.Application.Controllers
{
    public class EmployeeController
    {
        private readonly IEmployeeRegistrationNumberFactory _employeeRegistrationNumberFactory;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRegistrationNumberFactory employeeRegistrationNumberFactory, IEmployeeRepository employeeRepository)
        {
            _employeeRegistrationNumberFactory = employeeRegistrationNumberFactory ?? throw new ArgumentNullException(nameof(employeeRegistrationNumberFactory));
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }

        public async Task CreateAsync(EmployeeDto dto)
        {
            var registrationNumber = await _employeeRegistrationNumberFactory.CreateAsync();

            var employee = new Employee(registrationNumber, new EmployeeSurname(dto.Surname), new Gender(dto.Gender));

            await _employeeRepository.AddAsync(employee);
            await _employeeRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(EmployeeDto dto)
        {
            var employee = await _employeeRepository.GetByRegistrationNumberAsync(dto.RegistrationNumber);

            if (employee == null)
            {
                throw new ObjectNotFoundException(nameof(Employee));
            }

            employee.ChangeGender(new Gender(dto.Gender));
            employee.ChangeSurname(new EmployeeSurname(dto.Surname));

            await _employeeRepository.SaveChangesAsync();
        }
    }
}