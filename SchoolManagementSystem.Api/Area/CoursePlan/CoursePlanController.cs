using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.BusinessLayer.Interface;
using SchoolManagementSystem.Data.Models;

namespace SchoolManagementSystem.Api.Area.CoursePlan
{
    [Route("api/CoursePlan/[Controller]")]
    [ApiController]
    public class CoursePlanController : Controller
    {
        private readonly ICoursePlan _coursePlan;

        public CoursePlanController(ICoursePlan coursePlan)
        {
            _coursePlan = coursePlan;
        }
        [HttpGet("CoursePlanIndex")]
        public async Task<IActionResult> Index()
        {
            var data = await _coursePlan.GetCoursePlanList();
            return Ok(data);
        }
        [HttpGet("GetCoursePlanById/{id}")]
        public async Task<IActionResult> GetCoursePlanById(int? id)
        {
            var data = await _coursePlan.GetCoursePlanById(id);
            return Ok(data);
        }
        [HttpPost("CreateCoursePlan")]
        public async Task<IActionResult> InsertUpdateCoursePlan(CoursePlanViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(x => x.Key, x => x.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(new { Message = "Validation failed", Errors = errors });
            }
            var data = await _coursePlan.InsertUpdateCoursePlan(model);

            return Ok(data);
        }
        [HttpDelete("DeleteCoursePlan/{id}")]
        public async Task<IActionResult> DeleteCoursePlan(int? id)
        {
            var data = await _coursePlan.DeleteCoursePlan(id);
            return Ok(data);
        }
    }
}
