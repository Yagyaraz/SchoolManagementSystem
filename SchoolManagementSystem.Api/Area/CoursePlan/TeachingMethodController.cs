using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.BusinessLayer.Interface;
using SchoolManagementSystem.Data.Data.Entities;
using SchoolManagementSystem.Data.Models;

namespace SchoolManagementSystem.Api.Area.TeachingMethod
{
    [Route("api/TeachingMethod/[Controller]")]
    [ApiController]
    public class TeachingMethodController : Controller
    {
        private readonly ITeachingMethod _TeachingMethod;

        public TeachingMethodController(ITeachingMethod TeachingMethod )
        {
            _TeachingMethod = TeachingMethod;
        }
        [HttpGet("TeachingMethodIndex")]
        public async Task<IActionResult> Index()
        {
            var data = await _TeachingMethod.GetTeachingMethodList();
            return Ok(data);
        }
        [HttpGet("GetTeachingMethodById/{id}")]
        public async Task<IActionResult> GetTeachingMethodById(int? id)
        {
            var data = await _TeachingMethod.GetTeachingMethodById(id);
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
            var data = await _TeachingMethod.InsertUpdateTeachingMethod(model);

            return Ok(data);
        }
        [HttpDelete("DeleteTeachingMethod/{id}")]
        public async Task<IActionResult> DeleteTeachingMethod(int? id)
        {
            var data = await _TeachingMethod.DeleteTeachingMethod(id);
            return Ok(data);
        }
    }
}
