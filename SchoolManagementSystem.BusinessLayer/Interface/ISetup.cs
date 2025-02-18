using SchoolManagementSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.BusinessLayer.Interface
{
    public interface ISetup
    {

        #region Bus route
        Task<Result<List<BusRouteViewModel>>> GetBusRouteList();
        Task<Result<BusRouteViewModel>> GetBusRouteById(int? id);
        Task<Result<bool>>InsertUpdateBusRoute(BusRouteViewModel model);
        Task<Result<bool>> DeleteBusRoute(int? id);
        #endregion
        #region Route Map
        Task<Result<List<RouteMapViewModel>>> GetRouteMapList();
        Task<Result<RouteMapViewModel>> GetRouteMapById(int? id);
        Task<Result<bool>> InsertUpdateRouteMap(RouteMapViewModel model);
        Task<Result<bool>> DeleteRouteMap(int? id);
        #endregion
        #region Home
        Task<Result<HomeViewModel>> GetHome(int? id);
        Task<Result<bool>> InsertUpdateHome(HomeViewModel model);
        #endregion
        #region About Us
        Task<Result<AboutViewModel>> GetAboutUs(int? id);
        Task<Result<bool>> InsertUpdateAboutUs(AboutViewModel model);
        #endregion
        #region Subject
        Task<Result<List<SubjectViewModel>>> GetSubjectList();
        Task<Result<SubjectViewModel>> GetSubjectById(int? id);
        Task<Result<bool>>InsertUpdateSubject(SubjectViewModel model);
        Task<Result<bool>>DeleteSubject(int? id);
        #endregion
        #region Class
        Task<Result<List<ClassViewModel>>> GetClassList();
        Task<Result<ClassViewModel>> GetClassById(int? id);
        Task<Result<bool>>InsertUpdateClass(ClassViewModel model);
        Task<Result<bool>>DeleteClass(int? id);
        #endregion
        #region Section
        Task<Result<List<SectionViewModel>>> GetSectionList();
        Task<Result<SectionViewModel>> GetSectionById(int? id);
        Task<Result<bool>>InsertUpdateSection(SectionViewModel model);
        Task<Result<bool>>DeleteSection(int? id);
        #endregion
        #region Program
        Task<Result<List<ProgramViewModel>>> GetProgramList();
        Task<Result<ProgramViewModel>> GetProgramById(int? id);
        Task<Result<bool>> InsertUpdateProgram(ProgramViewModel model);
        Task<Result<bool>> DeleteProgram(int? id);
        #endregion
        #region Team
        Task<Result<List<TeamCategoryViewModel>>> GetTeamCategoryList();
        Task<Result<TeamCategoryViewModel>> GetTeamCategoryById(int? id);
        Task<Result<bool>> InsertUpdateTeamCategory(TeamCategoryViewModel model);
        Task<Result<bool>> DeleteTeam(int? id);
        #endregion
        #region Assignment Category
        Task<Result<List<AssignmentCategoryViewModel>>> GetAssignmentCategoryList();
        Task<Result<AssignmentCategoryViewModel>> GetAssignmentCategoryById(int? id);
        Task<Result<bool>> InsertUpdateAssignmentCategory(AssignmentCategoryViewModel model);
        Task<Result<bool>> DeleteAssignmentCategory(int? id);
        #endregion
        #region Student Group
        Task<Result<List<StudentGroupViewModel>>> GetStudentGroupList();
        Task<Result<StudentGroupViewModel>> GetStudentGroupById(int? id);
        Task<Result<bool>> InsertUpdateStudentGroup(StudentGroupViewModel model);
        Task<Result<bool>> DeleteStudentGroup(int? id);
        #endregion
        #region GroupAssocition
        Task<Result<List<GroupClassAssociationViewModel>>> GetGroupClassAssociationList();
        Task<Result<GroupClassAssociationViewModel>> GetGroupClassAssociationById(int? id);
        Task<Result<bool>> InsertUpdateGroupClassAssociation(GroupClassAssociationViewModel model);
        Task<Result<bool>> DeleteGroupClassAssociation(int? id);
        #endregion
        #region BankDetails
        Task<Result<List<BankDetailsViewModel>>> GetBankDetailsList();
        Task<Result<BankDetailsViewModel>> GetBankDetailsById(int? id);
        Task<Result<bool>> InsertUpdateBankDetails(BankDetailsViewModel model);
        Task<Result<bool>> DeleteBankDetails(int? id);
        #endregion
    }
}
