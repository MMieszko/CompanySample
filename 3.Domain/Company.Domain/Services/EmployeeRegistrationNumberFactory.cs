using System;
using System.Threading.Tasks;
using Company.Domain.Contracts;
using Company.Domain.Models.Employees;

namespace Company.Domain.Services
{
    public class EmployeeRegistrationNumberFactory : IEmployeeRegistrationNumberFactory
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeRegistrationNumberFactory(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }

        public async Task<EmployeeRegistrationNumber> CreateAsync()
        {
            var latestRegistrationNumber = await _employeeRepository.GetLatestRegistrationNumberAsync();

            //Check depend of contract with Infrastructure. This showcase null doesn't mean error just that record was not found

            return new EmployeeRegistrationNumber(latestRegistrationNumber == null ? 1 : latestRegistrationNumber.IntegerValue + 1);
        }
    }
}