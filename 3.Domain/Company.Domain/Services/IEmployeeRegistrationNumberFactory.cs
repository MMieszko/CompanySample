using System.Threading.Tasks;
using Company.Domain.Models.Employees;

namespace Company.Domain.Services
{
    public interface IEmployeeRegistrationNumberFactory
    {
        Task<EmployeeRegistrationNumber> CreateAsync();
    }
}