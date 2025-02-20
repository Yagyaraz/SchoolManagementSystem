using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.BusinessLayer.Interface;
using SchoolManagementSystem.Data.Data.Entities;
using SchoolManagementSystem.Data.Models;

namespace SchoolManagementSystem.Api.Area.CoursePlan
{
    [Route("api/CoursePlan/[Controller]")]
    [ApiController]
    public class TeachingMethodController : Controller
    {
        private readonly ICoursePlan _coursePlan;

        public TeachingMethodController(ICoursePlan coursePlan )
        {
            _coursePlan = coursePlan;
        }
        [HttpGet("TeachingMethodIndex")]
        public async Task<IActionResult> Index()
        {
            var data = await _coursePlan.GetTeachingMethodList();
            return Ok(data);
        }
        [HttpGet("GetTeachingMethodById/{id}")]
        public async Task<IActionResult> GetTeachingMethodById(int? id)
        {
            var data = await _coursePlan.GetTeachingMethodById(id);
            return Ok(data);
        }
        [HttpPost("CreateTeachingMethod")]
        public async Task<IActionResult> InsertUpdateTeachingMethod(TeachingMethodViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(x => x.Key, x => x.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(new { Message = "Validation failed", Errors = errors });
            }
            var data = await _coursePlan.InsertUpdateTeachingMethod(model);

            return Ok(data);
        }
        [HttpDelete("DeleteTeachingMethod/{id}")]
        public async Task<IActionResult> DeleteTeachingMethod(int? id)
        {
            var data = await _coursePlan.DeleteTeachingMethod(id);
            return Ok(data);
        }
    }
}
