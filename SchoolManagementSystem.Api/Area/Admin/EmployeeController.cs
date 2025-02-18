using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.BusinessLayer.Interface;
using SchoolManagementSystem.Data.Models;

namespace SchoolManagementSystem.Api.Area.Admin
{
    [Route("api/Admin/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployee _employee;

        public EmployeeController(IEmployee employee)
        {
            _employee = employee;
        }
        [HttpGet("EmployeeIndex")]
        public async Task<IActionResult> Index()
        {
           var data= await _employee.GetAllEmployeeList();
            return Ok(data);
        }
        [HttpGet("GetEmployeeById/{id}")]
        public async Task<IActionResult> GetEmployeeById(int? id)
        {
            var data=await _employee.GetEmployeeById(id);
            return Ok(data);
        }
        [HttpPost("CreateEmployee")]
        public async Task<IActionResult> InsertUpdateEmployee(EmployeeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(x => x.Key, x => x.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(new { Message = "Validation failed", Errors = errors });
            }
            var data = await _employee.InsertUpdateEmployee(model);

            return Ok(data);
        }
        [HttpDelete("DeleteEmplyee/{id}")]
        public async Task<IActionResult>DeleteEmployee(int? id)
        {
            var data= await _employee.DeleteEmplyee(id);
            return Ok(data);
        }

    }
}
