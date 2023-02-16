using InterviewTest.Applciation.Interface;
using InterviewTest.Applciation.RequesDTO.Employee;
using Microsoft.AspNetCore.Mvc;

namespace InterviewTest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost("CreateOrUpdateEmployee")]
        public async Task<IActionResult> CreateOrUpdateEmployee([FromBody]CreateOrUpdateEmployeeRequest request)
        {
            var response = await _employeeService.AddOrUpdate(request);
            return SendResponse(response);
        }
        [HttpGet("GetAllEmployees")]
        public async Task<IActionResult> GetAllEmployees(string search)
        {
            var response = await _employeeService.GetAllEmployees(search);
            return SendResponse(response);
        }
        [HttpGet("GetSingle")]
        public async Task<IActionResult> GetSingle([FromQuery] int id)
        {
            var response = await _employeeService.GetSingle(id);
            return SendResponse(response);
        }
        [HttpDelete("DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee([FromQuery] int id)
        {
            var response = await _employeeService.Delete(id);
            return SendResponse(response);
        }
    }
}
