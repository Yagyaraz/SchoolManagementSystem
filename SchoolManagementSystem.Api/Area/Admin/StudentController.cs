using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Api.Models;
using SchoolManagementSystem.BusinessLayer.Interface;
using SchoolManagementSystem.Data.Model;
using System.Net;

namespace SchoolManagementSystem.Api.Area.Admin
{
    [Route("api/Admin/[controller]")]
    [ApiController]
    
    public class StudentController : Controller
    {
        private readonly IStudent _student;


        public StudentController( IStudent student)
        {
            _student = student;            
        }
        [HttpGet("StudentIndex")]
        public async Task<IActionResult> Index()
        {
            
            var data=await _student.GetAllStudentList();            
            return Ok(data);
        }
        [HttpGet("GetStudent/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            var data= await _student.GetStudentById(id);
            return Ok(data);
        }
        [HttpPost("CreateStudent")]
        public async Task<IActionResult>CreateStudent(StudentViewModel model)
        {
            var data= await _student.InsertUpdateStudent(model);
            return Ok(data);
        }        
    }
}


