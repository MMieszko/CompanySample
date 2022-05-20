using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Company.Application.Controllers;
using Company.Application.DataTransferObjects.Employees;

namespace Company.Api.Controllers
{
    [ApiController]
    [Route("employee")]
    public class EmployeeApiController : ControllerBase
    {
        private readonly EmployeeController _appController;

        public EmployeeApiController(EmployeeController appController)
        {
            _appController = appController;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmployeeDto data)
        {
            await _appController.CreateAsync(data);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Get([FromBody] EmployeeDto data)
        {
            await _appController.UpdateAsync(data);

            return Ok();
        }
    }
}
