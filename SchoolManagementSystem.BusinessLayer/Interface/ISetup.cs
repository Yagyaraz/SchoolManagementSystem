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
        Task<List<BusRouteViewModel>> GetBusRouteList();
        Task<BusRouteViewModel> GetBusRouteById(int? id);
        Task<bool>InsertUpdateBusRoute(BusRouteViewModel model);
        Task<bool> DeleteBusRoute(int? id);
        #endregion
        #region Route Map
        Task<List<RouteMapViewModel>> GetRouteMapList();
        Task<RouteMapViewModel> GetRouteMapById(int? id);
        Task<bool> InsertUpdateRouteMap(RouteMapViewModel model);
        Task<bool> DeleteRouteMap(int? id);
        #endregion
        #region Home
        Task<HomeViewModel> GetHome(int? id);
        Task<bool> InsertUpdateHome(HomeViewModel model);
        #endregion
        #region About Us
        Task<AboutViewModel> GetAboutUs(int? id);
        Task<bool> InsertUpdateAboutUs(AboutViewModel model);
        #endregion
        #region Subject
        Task<List<SubjectViewModel>> GetSubjectList();
        Task<SubjectViewModel> GetSubjectById(int? id);
        Task<bool>InsertUpdateSubject(SubjectViewModel model);
        Task<bool>DeleteSubject(int? id);
        #endregion
        #region Class
        Task<List<ClassViewModel>> GetClassList();
        Task<ClassViewModel> GetClassById(int? id);
        Task<bool>InsertUpdateClass(ClassViewModel model);
        Task<bool>DeleteClass(int? id);
        #endregion
        #region Section
        Task<List<SectionViewModel>> GetSectionList();
        Task<SectionViewModel> GetSectionById(int? id);
        Task<bool>InsertUpdateSection(SectionViewModel model);
        Task<bool>DeleteSection(int? id);
        #endregion
        #region Program
        Task<List<ProgramViewModel>> GetProgramList();
        Task<ProgramViewModel> GetProgramById(int? id);
        Task<bool> InsertUpdateProgram(ProgramViewModel model);
        Task<bool> DeleteProgram(int? id);
        #endregion
        #region Team
        Task<List<TeamCategoryViewModel>> GetTeamCategoryList();
        Task<TeamCategoryViewModel> GetTeamCategoryById(int? id);
        Task<bool> InsertUpdateTeamCategory(TeamCategoryViewModel model);
        Task<bool> DeleteTeam(int? id);
        #endregion
        #region Assignment Category
        Task<List<AssignmentCategoryViewModel>> GetAssignmentCategoryList();
        Task<AssignmentCategoryViewModel> GetAssignmentCategoryById(int? id);
        Task<bool> InsertUpdateAssignmentCategory(AssignmentCategoryViewModel model);
        Task<bool> DeleteAssignmentCategory(int? id);
        #endregion
        #region Student Group
        Task<List<StudentGroupViewModel>> GetStudentGroupList();
        Task<StudentGroupViewModel> GetStudentGroupById(int? id);
        Task<bool> InsertUpdateStudentGroup(StudentGroupViewModel model);
        Task<bool> DeleteStudentGroup(int? id);
        #endregion
        #region GroupAssocition
        Task<List<GroupClassAssociationViewModel>> GetGroupClassAssociationList();
        Task<GroupClassAssociationViewModel> GetGroupClassAssociationById(int? id);
        Task<bool> InsertUpdateGroupClassAssociation(GroupClassAssociationViewModel model);
        Task<bool> DeleteGroupClassAssociation(int? id);
        #endregion
        #region BankDetails
        Task<List<BankDetailsViewModel>> GetBankDetailsList();
        Task<BankDetailsViewModel> GetBankDetailsById(int? id);
        Task<bool> InsertUpdateBankDetails(BankDetailsViewModel model);
        Task<bool> DeleteBankDetails(int? id);
        #endregion
    }
}
