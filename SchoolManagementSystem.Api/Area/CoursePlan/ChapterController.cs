using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.BusinessLayer.Interface;
using SchoolManagementSystem.Data.Models;

namespace SchoolManagementSystem.Api.Area.CoursePlan
{
    [Route("api/CoursePlan/[Controller]")]
    [ApiController]
    public class ChapterController : Controller
    {
        private readonly IChapter _chapter;

        public ChapterController(IChapter chapter)
        {
            _chapter = chapter;
        }
        [HttpGet("ChapterIndex")]
        public async Task<IActionResult> Index()
        {
            var data = await _chapter.GetChapterList();
            return Ok(data);
        }
        [HttpGet("GetChapterById/{id}")]
        public async Task<IActionResult> GetChapterById(int? id)
        {
            var data = await _chapter.GetChapterById(id);
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
            var data = await _chapter.InsertUpdateChapter(model);

            return Ok(data);
        }
        [HttpDelete("DeleteChapter/{id}")]
        public async Task<IActionResult> DeleteChapter(int? id)
        {
            var data = await _chapter.DeleteChapter(id);
            return Ok(data);
        }
    }
}
