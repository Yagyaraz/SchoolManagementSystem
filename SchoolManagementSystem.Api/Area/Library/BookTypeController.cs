using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.BusinessLayer.Interface;
using SchoolManagementSystem.Data.Models;

namespace SchoolManagementSystem.Api.Area.Library
{
    [Route("api/Library/[controller]")]
    public class BookTypeController : ControllerBase
    {
        private readonly IBookType _bookType;
        public BookTypeController(IBookType bookType)
        {
            _bookType = bookType;
        }
        [HttpGet("BookTypeIndex")]
        public async Task<IActionResult> BookTypeIndex()
        {
            var data = await _bookType.GetAllBookType();
            return Ok(data);
        }
        [HttpGet("GetBookTypeById/{id}")]
        public async Task<IActionResult> GetBookTypeById(int? id)
        {
            var data = await _bookType.GetBookTypeById(id);
            return Ok(data);
        }
        [HttpPost("CreateBookType")]
        public async Task<IActionResult> InsertUpdateBookType(BookTypeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(x => x.Key, x => x.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(new { Message = "Validation failed", Errors = errors });
            }
            var data = await _bookType.InsertUpdateBookType(model);
            return Ok(data);
        }
        [HttpDelete("DeleteBookType/{id}")]
        public async Task<IActionResult> DeleteBookType(int? id)
        {
            var data = await _bookType.DeleteBookType(id);
            return Ok(data);
        }
    }
}
