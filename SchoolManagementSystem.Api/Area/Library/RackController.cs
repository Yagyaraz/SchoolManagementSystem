using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.BusinessLayer.Interface;
using SchoolManagementSystem.Data.Models;

namespace SchoolManagementSystem.Api.Area.Library
{
    [Route("api/Library/[controller]")]
    public class RackController : ControllerBase
    {
        private readonly IRack _rack;
        public RackController(IRack rack)
        {
            _rack = rack;
        }
        [HttpGet("RackIndex")]
        public async Task<IActionResult> RackIndex()
        {
            var data = await _rack.GetAllRack();
            return Ok(data);
        }
        [HttpGet("GetRackById/{id}")]
        public async Task<IActionResult> GetRackById(int? id)
        {
            var data = await _rack.GetRackById(id);
            return Ok(data);
        }
        [HttpPost("CreateRack")]
        public async Task<IActionResult> InsertUpdateRack(RackViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(x => x.Key, x => x.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(new { Message = "Validation failed", Errors = errors });
            }
            var data = await _rack.InsertUpdateRack(model);
            return Ok(data);
        }
        [HttpDelete("DeleteRack/{id}")]
        public async Task<IActionResult> DeleteRack(int? id)
        {
            var data = await _rack.DeleteRack(id);
            return Ok(data);
        }
    }
}
