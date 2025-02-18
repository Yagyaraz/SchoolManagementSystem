using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.BusinessLayer.Interface;
using SchoolManagementSystem.Data.Data.Entities;
using SchoolManagementSystem.Data.Models;

namespace SchoolManagementSystem.Api.Area.Admin
{
    [Route("api/Admin/[controller]")]
    [ApiController]
    public class SetupController : Controller
    {
        private readonly ISetup _setup;

        public SetupController(ISetup setup)
        {
            _setup = setup;
        }
        #region Bus Route
        [HttpGet("BusRouteIndex")]
        public async Task<IActionResult> BusRouteIndex()
        {
            var data = await _setup.GetBusRouteList();
            return Ok(data);
        }
        [HttpGet("GetBusRouteById/{id}")]
        public async Task<IActionResult> GetBusRouteById(int? id)
        {
            var data = await _setup.GetBusRouteById(id);
            return Ok(data);
        }
        [HttpPost("CreateBusRoute")]
        public async Task<IActionResult> InsertUpdateBusRoute(BusRouteViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(x => x.Key, x => x.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(new { Message = "Validation failed", Errors = errors });
            }
            var data = await _setup.InsertUpdateBusRoute(model);
            return Ok(data);
        }
        [HttpDelete("DeleteBusRoute/{id}")]
        public async Task<IActionResult> DeleteBusRoute(int? id)
        {
            var data = await _setup.DeleteBusRoute(id);
            return Ok(data);
        }
        #endregion
        #region Route Map
        [HttpGet("RouteMapIndex")]
        public async Task<IActionResult> RouteMapInsex()
        {
            var data = await _setup.GetRouteMapList();
            return Ok(data);
        }
        [HttpGet("GetRouteMapById/{id}")]
        public async Task<IActionResult> GetRouteMapById(int? id)
        {
            var data = await _setup.GetRouteMapById(id);
            return Ok(data);
        }
        [HttpPost("CreateRouteMap")]
        public async Task<IActionResult> InsertUpdateRouteMap(RouteMapViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(x => x.Key, x => x.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(new { Message = "Validation failed", Errors = errors });
            }
            var data = await _setup.InsertUpdateRouteMap(model);
            return Ok(data);
        }
        [HttpDelete("DeleteRouteMap/{id}")]
        public async Task<IActionResult> DeleteRouteMap(int? id)
        {
            var data = await _setup.DeleteRouteMap(id);
            return Ok(data);
        }
        #endregion
        #region Home
        [HttpGet("GetHomeById/{id}")]
        public async Task<IActionResult> GetHomeById(int? id)
        {
            var data = await _setup.GetHome(id);
            return Ok(data);
        }
        [HttpPost("CreateHome")]
        public async Task<IActionResult> InsertUpdateHome(HomeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(x => x.Key, x => x.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(new { Message = "Validation failed", Errors = errors });
            }
            var data = await _setup.InsertUpdateHome(model);
            return Ok(data);
        }
        #endregion
        #region About
        [HttpGet("GetAboutUsById/{id}")]
        public async Task<IActionResult> GetAboutUsById(int? id)
        {
            var data = await _setup.GetAboutUs(id);
            return Ok(data);
        }
        [HttpPost("CreateAboutUs")]
        public async Task<IActionResult> InsertUpdateAboutUs(AboutViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(x => x.Key, x => x.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(new { Message = "Validation failed", Errors = errors });
            }
            var data = await _setup.InsertUpdateAboutUs(model);
            return Ok(data);
        }
        #endregion
        #region Subject
        [HttpGet("SubjectIndex")]
        public async Task<IActionResult> SubjectIndex()
        {
            var data = await _setup.GetSubjectList();
            return Ok(data);
        }
        [HttpGet("GetSubjectById/{id}")]
        public async Task<IActionResult> GetSubjectById(int? id)
        {
            var data = await _setup.GetSubjectById(id);
            return Ok(data);
        }
        [HttpPost("CreateSubject")]
        public async Task<IActionResult> InsertUpdateSubject(SubjectViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(x => x.Key, x => x.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(new { Message = "Validation failed", Errors = errors });
            }
            var data = await _setup.InsertUpdateSubject(model);
            return Ok(data);
        }
        [HttpDelete("DeleteSubject/{id}")]
        public async Task<IActionResult> DeleteSubject(int? id)
        {
            var data = await _setup.DeleteSubject(id);
            return Ok(data);
        }
        #endregion
        #region Class
        [HttpGet("ClassIndex")]
        public async Task<IActionResult> ClassIndex()
        {
            var data = await _setup.GetClassList();
            return Ok(data);
        }
        [HttpGet("GetClassById/{id}")]
        public async Task<IActionResult> GetClassById(int? id)
        {
            var data = await _setup.GetClassById(id);
            return Ok(data);
        }
        [HttpPost("CreateClass")]
        public async Task<IActionResult> InsertUpdateClass(ClassViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(x => x.Key, x => x.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(new { Message = "Validation failed", Errors = errors });
            }
            var data = await _setup.InsertUpdateClass(model);
            return Ok(data);
        }
        [HttpDelete("DeleteClass/{id}")]
        public async Task<IActionResult> DeleteClass(int? id)
        {
            var data = await _setup.DeleteClass(id);
            return Ok(data);
        }
        #endregion
        #region Section
        [HttpGet("SectionIndex")]
        public async Task<IActionResult> SectionIndex()
        {
            var data = await _setup.GetSectionList();
            return Ok(data);
        }
        [HttpGet("GetSectionById/{id}")]
        public async Task<IActionResult> GetSectionById(int? id)
        {
            var data = await _setup.GetSectionById(id);
            return Ok(data);
        }
        [HttpPost("CreateSection")]
        public async Task<IActionResult> InsertUpdateSection(SectionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(x => x.Key, x => x.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(new { Message = "Validation failed", Errors = errors });
            }
            var data = await _setup.InsertUpdateSection(model);
            return Ok(data);
        }
        [HttpDelete("DeleteSection/{id}")]
        public async Task<IActionResult> DeleteSection(int? id)
        {
            var data = await _setup.DeleteSection(id);
            return Ok(data);
        }
        #endregion
        #region Program
        [HttpGet("ProgramIndex")]
        public async Task<IActionResult> ProgramIndex()
        {
            var data = await _setup.GetProgramList();
            return Ok(data);
        }
        [HttpGet("GetProgramById/{id}")]
        public async Task<IActionResult> GetProgramById(int? id)
        {
            var data = await _setup.GetProgramById(id);
            return Ok(data);
        }
        [HttpPost("CreateProgram")]
        public async Task<IActionResult> InsertUpdateProgram(ProgramViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(x => x.Key, x => x.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(new { Message = "Validation failed", Errors = errors });
            }
            var data = await _setup.InsertUpdateProgram(model);
            return Ok(data);
        }
        [HttpDelete("DeleteProgram/{id}")]
        public async Task<IActionResult> DeleteProgram(int? id)
        {
            var data = await _setup.DeleteProgram(id);
            return Ok(data);
        }
        #endregion
        #region Team
        [HttpGet("TeamCategoryIndex")]
        public async Task<IActionResult> TeamCategoryIndex()
        {
            var data = await _setup.GetTeamCategoryList();
            return Ok(data);
        }
        [HttpGet("GetTeamCategoryById/{id}")]
        public async Task<IActionResult> GetTeamCategoryById(int? id)
        {
            var data = await _setup.GetTeamCategoryById(id);
            return Ok(data);
        }
        [HttpPost("CreateTeamCategory")]
        public async Task<IActionResult> InsertUpdateTeamCategory(TeamCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(x => x.Key, x => x.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(new { Message = "Validation failed", Errors = errors });
            }
            var data = await _setup.InsertUpdateTeamCategory(model);
            return Ok(data);
        }
        [HttpDelete("DeleteTeamCategory/{id}")]
        public async Task<IActionResult> DeleteTeamCategory(int? id)
        {
            var data = await _setup.DeleteTeam(id);
            return Ok(data);
        }
        #endregion
        #region AssignmentCategory
        [HttpGet("AssignmentCategoryIndex")]
        public async Task<IActionResult> AssignmentCategoryIndex()
        {
            var data = await _setup.GetAssignmentCategoryList();
            return Ok(data);
        }
        [HttpGet("GetAssignmentCategoryById/{id}")]
        public async Task<IActionResult> GetAssignmentCategoryById(int? id)
        {
            var data = await _setup.GetAssignmentCategoryById(id);
            return Ok(data);
        }
        [HttpPost("CreateAssignmentCategory")]
        public async Task<IActionResult> InsertUpdateAssignmentCategory(AssignmentCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(x => x.Key, x => x.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(new { Message = "Validation failed", Errors = errors });
            }
            var data = await _setup.InsertUpdateAssignmentCategory(model);
            return Ok(data);
        }
        [HttpDelete("DeleteAssignmentCategory/{id}")]
        public async Task<IActionResult> DeleteAssignmentCategory(int? id)
        {
            var data = await _setup.DeleteAssignmentCategory(id);
            return Ok(data);
        }
        #endregion
        #region Student Group
        [HttpGet("StudentGroupIndex")]
        public async Task<IActionResult> StudentGroupIndex()
        {
            var data = await _setup.GetStudentGroupList();
            return Ok(data);
        }
        [HttpGet("GetStudentGroupById/{id}")]
        public async Task<IActionResult> GetStudentGroupById(int? id)
        {
            var data = await _setup.GetStudentGroupById(id);
            return Ok(data);
        }
        [HttpPost("CreateStudentGroup")]
        public async Task<IActionResult> InsertUpdateStudentGroup(StudentGroupViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(x => x.Key, x => x.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(new { Message = "Validation failed", Errors = errors });
            }
            var data = await _setup.InsertUpdateStudentGroup(model);
            return Ok(data);
        }
        [HttpDelete("DeleteStudentGroup/{id}")]
        public async Task<IActionResult> DeleteStudentGroup(int? id)
        {
            var data = await _setup.DeleteStudentGroup(id);
            return Ok(data);
        }
        #endregion
        #region GroupClass Association
        [HttpGet("GroupClassAssociationIndex")]
        public async Task<IActionResult> GroupClassAssociationIndex()
        {
            var data = await _setup.GetGroupClassAssociationList();
            return Ok(data);
        }
        [HttpGet("GetGroupClassAssociationById/{id}")]
        public async Task<IActionResult> GetGroupClassAssociationById(int? id)
        {
            var data = await _setup.GetGroupClassAssociationById(id);
            return Ok(data);
        }
        [HttpPost("CreateGroupClassAssociation")]
        public async Task<IActionResult> InsertUpdateGroupClassAssociation(GroupClassAssociationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(x => x.Key, x => x.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(new { Message = "Validation failed", Errors = errors });
            }
            var data = await _setup.InsertUpdateGroupClassAssociation(model);
            return Ok(data);
        }
        [HttpDelete("DeleteGroupClassAssociation/{id}")]
        public async Task<IActionResult> DeleteGroupClassAssociation(int? id)
        {
            var data = await _setup.DeleteGroupClassAssociation(id);
            return Ok(data);
        }
        #endregion
        #region Bus Route
        [HttpGet("BankDetailsIndex")]
        public async Task<IActionResult> BankDetailsIndex()
        {
            var data = await _setup.GetBankDetailsList();
            return Ok(data);
        }
        [HttpGet("GetBankDetailsById/{id}")]
        public async Task<IActionResult> GetBankDetailsById(int? id)
        {
            var data = await _setup.GetBankDetailsById(id);
            return Ok(data);
        }
        [HttpPost("CreateBankDetails")]
        public async Task<IActionResult> InsertUpdateBankDetails(BankDetailsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(x => x.Key, x => x.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(new { Message = "Validation failed", Errors = errors });
            }
            var data = await _setup.InsertUpdateBankDetails(model);
            return Ok(data);
        }
        [HttpDelete("DeleteBankDetails/{id}")]
        public async Task<IActionResult> DeleteBankDetails(int? id)
        {
            var data = await _setup.DeleteBankDetails(id);
            return Ok(data);
        }
        #endregion
    }
}
