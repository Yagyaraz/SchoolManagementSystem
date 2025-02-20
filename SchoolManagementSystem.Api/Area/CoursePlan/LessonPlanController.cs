using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.BusinessLayer.Interface;
using SchoolManagementSystem.Data.Models;

namespace SchoolManagementSystem.Api.Area.CoursePlan
{
    [Route("api/CoursePlan/[Controller]")]
    [ApiController]
    public class LessonPlanController : Controller
    {
        private readonly ICoursePlan _coursePlan;

        public LessonPlanController(ICoursePlan coursePlan)
        {
            _coursePlan = coursePlan;
        }
        [HttpGet("LessonPlanIndex")]
        public async Task<IActionResult> Index()
        {
            var data = await _coursePlan.GetLessonPlanList();
            return Ok(data);
        }
        [HttpGet("GetLessonPlanById/{id}")]
        public async Task<IActionResult> GetLessonPlanById(int? id)
        {
            var data = await _coursePlan.GetLessonPlanById(id);
            return Ok(data);
        }
        [HttpPost("CreateLessonPlan")]
        public async Task<IActionResult> InsertUpdateLessonPlan(LessonPlanViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(x => x.Key, x => x.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(new { Message = "Validation failed", Errors = errors });
            }
            var data = await _coursePlan.InsertUpdateLessonPlan(model);

            return Ok(data);
        }
        [HttpDelete("DeleteLessonPlan/{id}")]
        public async Task<IActionResult> DeleteLessonPlan(int? id)
        {
            var data = await _coursePlan.DeleteLessonPlan(id);
            return Ok(data);
        }
    }
}
