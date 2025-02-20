using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Api.Models;
using SchoolManagementSystem.BusinessLayer.Interface;
using SchoolManagementSystem.Data.Data.Entities;
using SchoolManagementSystem.Data.Model;
using System.Net;

namespace SchoolManagementSystem.Api.Area.Student
{
    [Route("api/Admin/[controller]")]
    [ApiController]

    public class StudentController : Controller
    {
        private readonly IStudent _student;


        public StudentController(IStudent student)
        {
            _student = student;
        }
        [HttpGet("StudentIndex")]
        public async Task<IActionResult> Index()
        {

            var data = await _student.GetAllStudentList();
            return Ok(data);
        }
        [HttpGet("GetStudent/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            var data = await _student.GetStudentById(id);
            return Ok(data);
        }
        [HttpPost("CreateStudent")]
        public async Task<IActionResult> CreateStudent(StudentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(x => x.Key, x => x.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(new { Message = "Validation failed", Errors = errors });
            }
            var data = await _student.InsertUpdateStudent(model);
            return Ok(data);
        }
        [HttpDelete("DeleteStudent/{id}")]
        public async Task<IActionResult> DeleteStudent(int? id)
        {
            var data = await _student.DeleteStudent(id);
            return Ok(data);
        }
    }
}


