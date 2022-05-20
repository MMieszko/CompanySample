using System.Threading.Tasks;
using Company.Domain.Contracts;
using Company.Domain.Models.Employees;

namespace Company.Persistance.Ef
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public Task<Employee> GetByRegistrationNumberAsync(string number)
        {
            throw new System.NotImplementedException();
        }

        public Task<EmployeeRegistrationNumber> GetLatestRegistrationNumberAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task AddAsync(Employee employee)
        {
            throw new System.NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}