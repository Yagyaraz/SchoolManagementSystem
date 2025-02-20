using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.BusinessLayer.Interface;
using SchoolManagementSystem.Data.Models;

namespace SchoolManagementSystem.Api.Area.CoursePlan
{
    [Route("api/CoursePlan/[Controller]")]
    [ApiController]
    public class ChapterController : Controller
    {
        private readonly ICoursePlan _coursePlan;

        public ChapterController(ICoursePlan coursePlan)
        {
            _coursePlan = coursePlan;
        }
        [HttpGet("ChapterIndex")]
        public async Task<IActionResult> Index()
        {
            var data = await _coursePlan.GetChapterList();
            return Ok(data);
        }
        [HttpGet("GetChapterById/{id}")]
        public async Task<IActionResult> GetChapterById(int? id)
        {
            var data = await _coursePlan.GetChapterById(id);
            return Ok(data);
        }
        [HttpPost("CreateChapter")]
        public async Task<IActionResult> InsertUpdateChapter(ChapterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(x => x.Key, x => x.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(new { Message = "Validation failed", Errors = errors });
            }
            var data = await _coursePlan.InsertUpdateChapter(model);

            return Ok(data);
        }
        [HttpDelete("DeleteChapter/{id}")]
        public async Task<IActionResult> DeleteChapter(int? id)
        {
            var data = await _coursePlan.DeleteChapter(id);
            return Ok(data);
        }
    }
}
