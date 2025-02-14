using SchoolManagementSystem.BusinessLayer.Interface;
using SchoolManagementSystem.Data.Data;
using SchoolManagementSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.BusinessLayer.Repositories
{
    public class SetupRepository : ISetup
    {
        private readonly ApplicationDbContext _context;

        public SetupRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        #region BusRoute
        public Task<BusRouteViewModel> GetBusRouteById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<List<BusRouteViewModel>> GetBusRouteList()
        {
            throw new NotImplementedException();
        }
        public Task<bool> InsertUpdateBusRoute(BusRouteViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteBusRoute(int? id)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region BusMap
        public Task<List<RouteMapViewModel>> GetRouteMapList()
        {
            throw new NotImplementedException();
        }

        public Task<RouteMapViewModel> GetRouteMapById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertUpdateRouteMap(RouteMapViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteRouteMap(int? id)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Home
        public Task<HomeViewModel> GetHome(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertUpdateHome(HomeViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<AboutViewModel> GetAboutUs(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertUpdateAboutUs(AboutViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<List<SubjectViewModel>> GetSubjectList()
        {
            throw new NotImplementedException();
        }

        public Task<SubjectViewModel> GetSubjectById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertUpdateSubject(SubjectViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteSubject(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ClassViewModel>> GetClassList()
        {
            throw new NotImplementedException();
        }

        public Task<ClassViewModel> GetClassById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertUpdateClass(ClassViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteClass(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<List<SectionViewModel>> GetSectionList()
        {
            throw new NotImplementedException();
        }

        public Task<SectionViewModel> GetSectionById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertUpdateSection(SectionViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteSection(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProgramViewModel>> GetProgramList()
        {
            throw new NotImplementedException();
        }

        public Task<ProgramViewModel> GetProgramById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertUpdateProgram(ProgramViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProgram(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TeamCategoryViewModel>> GetTeamCategoryList()
        {
            throw new NotImplementedException();
        }

        public Task<TeamCategoryViewModel> GetTeamCategoryById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertUpdateTeamCategory(TeamCategoryViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTeam(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<List<AssignmentCategoryViewModel>> GetAssignmentCategoryList()
        {
            throw new NotImplementedException();
        }

        public Task<AssignmentCategoryViewModel> GetAssignmentCategoryById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertUpdateAssignmentCategory(AssignmentCategoryViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAssignmentCategory(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<List<StudentGroupViewModel>> GetStudentGroupList()
        {
            throw new NotImplementedException();
        }

        public Task<StudentGroupViewModel> GetStudentGroupById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertUpdateStudentGroup(StudentGroupViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteStudentGroup(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<List<GroupClassAssociationViewModel>> GetGroupClassAssociationList()
        {
            throw new NotImplementedException();
        }

        public Task<GroupClassAssociationViewModel> GetGroupClassAssociationById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertUpdateGroupClassAssociation(GroupClassAssociationViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteGroupClassAssociation(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<List<BankDetailsViewModel>> GetBankDetailsList()
        {
            throw new NotImplementedException();
        }

        public Task<BankDetailsViewModel> GetBankDetailsById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertUpdateBankDetails(BankDetailsViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteBankDetails(int? id)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Home
        #endregion
        #region About
        #endregion
        #region Subject
        #endregion
        #region Class
        #endregion
        #region Section
        #endregion
        #region Program
        #endregion
        #region Team
        #endregion
        #region Student Group
        #endregion
        #region Group Assocation
        #endregion
        #region Bank Details
        #endregion
    }
}
