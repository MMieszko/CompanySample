using System;
using System.Threading;
using System.Threading.Tasks;
using Company.Domain.Contracts;
using Company.Domain.Models.Employees;

namespace Company.Domain.Services
{
    public class EmployeeRegistrationNumberFactory : IEmployeeRegistrationNumberFactory
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly SemaphoreSlim _semaphore;

        public EmployeeRegistrationNumberFactory(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _semaphore = new SemaphoreSlim(1, 1);
        }

        public async Task<EmployeeRegistrationNumber> CreateAsync()
        {
            try
            {
                await _semaphore.WaitAsync();

                var latestRegistrationNumber = await _employeeRepository.GetLatestRegistrationNumberAsync();

                //Allow repository to return null if entity not found
                return new EmployeeRegistrationNumber(latestRegistrationNumber == null
                    ? 1
                    : latestRegistrationNumber.IntegerValue + 1);
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }
}