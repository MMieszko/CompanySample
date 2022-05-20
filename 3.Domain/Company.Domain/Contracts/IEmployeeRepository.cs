using System.Threading.Tasks;
using Company.Domain.Models.Employees;

namespace Company.Domain.Contracts
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetByRegistrationNumberAsync(string number);
        Task<EmployeeRegistrationNumber> GetLatestRegistrationNumberAsync();
        Task AddAsync(Employee employee);
        Task SaveChangesAsync();
    }
}