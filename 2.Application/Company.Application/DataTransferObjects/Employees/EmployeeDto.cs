using Company.Domain.Models.Shared;

namespace Company.Application.DataTransferObjects.Employees
{
    public class EmployeeDto
    {
        public string RegistrationNumber { get; set; }
        public string Surname { get; set; }
        public GenderEnum Gender { get; set; }
    }
}