using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.BusinessLayer.Interface;
using SchoolManagementSystem.Data.Models;

namespace SchoolManagementSystem.Api.Area.Library
{
    [Route("api/Library/[controller]")]
    [ApiController]
    public class RoomController : Controller
    {
        private readonly IRoom _rooom;
        public RoomController(IRoom room)
        {
            _rooom = room;
        }
        [HttpGet("RoomIndex")]
        public async Task<IActionResult> RoomIndex()
        {
            var data = await _rooom.GetAllRoom();
            return Ok(data);
        }
        [HttpGet("GetRoomById/{id}")]
        public async Task<IActionResult> GetRoomById(int? id)
        {
            var data = await _rooom.GetRoomById(id);
            return Ok(data);
        }
        [HttpPost("CreateRoom")]
        public async Task<IActionResult> InsertUpdateRoom(RoomViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(x => x.Key, x => x.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(new { Message = "Validation failed", Errors = errors });
            }
            var data = await _rooom.InsertUpdateRoom(model);
            return Ok(data);
        }
        [HttpDelete("DeleteRoom/{id}")]
        public async Task<IActionResult> DeleteRoom(int? id)
        {
            var data = await _rooom.DeleteRoom(id);
            return Ok(data);
        }
    }
}
