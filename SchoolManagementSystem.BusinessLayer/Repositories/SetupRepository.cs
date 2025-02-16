using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.BusinessLayer.Interface;
using SchoolManagementSystem.Data.Data;
using SchoolManagementSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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
        public async Task<BusRouteViewModel> GetBusRouteById(int? id)
        {
           var data= await _context.BusRoute.Where(x => x.Id == id).Select(x=>new BusRouteViewModel()
           {
               Id = x.Id,
               DriverName = x.DriverName,
               BusNo = x.BusNo,
               AssistantName= x.AssistantName,
               AssistantPhone= x.AssistantPhone,
               Teacher=x.Teacher,
               Status=x.Status,
           }).FirstOrDefaultAsync()?? new BusRouteViewModel();
            return data;
        }

        public async Task<List<BusRouteViewModel>> GetBusRouteList()
        {
            var list = await _context.BusRoute.Select(x => new BusRouteViewModel()
            {
                Id = x.Id,
                DriverName = x.DriverName,
                BusNo = x.BusNo,
            }).ToListAsync() ?? new List<BusRouteViewModel>();
            return list;
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
        #region Route Map
        public async Task<List<RouteMapViewModel>> GetRouteMapList()
        {
            var list = await _context.RouteMap.Select(x => new RouteMapViewModel()
            {
                Id = x.Id,
                BusRouteId = x.BusRouteId,
                GPSDevice= x.GPSDevice,
            }).ToListAsync() ?? new List<RouteMapViewModel>();
            return list;
        }

        public async Task<RouteMapViewModel> GetRouteMapById(int? id)
        {
            var data = await _context.RouteMap.Where(x => x.Id == id).Select(x => new RouteMapViewModel()
            {
                Id = x.Id,
                BusRouteId = x.BusRouteId,
                GPSDevice= x.GPSDevice,
                GPSDeviceId= x.GPSDevice,
                Status= x.Status,

            }).FirstOrDefaultAsync() ?? new RouteMapViewModel();
            return data;
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
        #endregion       
        #region About
        public Task<AboutViewModel> GetAboutUs(int? id)
        {
            throw new NotImplementedException();
        }
        public Task<bool> InsertUpdateAboutUs(AboutViewModel model)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Subject
        public async Task<List<SubjectViewModel>> GetSubjectList()
        {
            var list = await _context.Subject.Select(x => new SubjectViewModel()
            {
                Id = x.Id,
                SubjectName = x.SubjectName,
                ShortCode = x.ShortCode,
            }).ToListAsync() ?? new List<SubjectViewModel>();
            return list;
        }

        public async Task<SubjectViewModel> GetSubjectById(int? id)
        {
            var data = await _context.Subject.Where(x => x.Id == id).Select(x => new SubjectViewModel()
            {
                Id = x.Id,
                SubjectName = x.SubjectName,
                ShortCode = x.ShortCode,
                TheoryCredit = x.TheoryCredit,
                PracticalCredit = x.TheoryCredit,
                CalculateMarks = x.CalculateMarks,
                Status = x.Status,
            }).FirstOrDefaultAsync() ?? new SubjectViewModel();
            return data;
        }

        public Task<bool> InsertUpdateSubject(SubjectViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteSubject(int? id)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Class
        public Task<List<ClassViewModel>> GetClassList()
        {
            throw new NotImplementedException();
        }

        public async Task<ClassViewModel> GetClassById(int? id)
        {
            var data = await _context.Classe.Where(x => x.Id == id).Select(x => new ClassViewModel()
            {
                Id = x.Id,
                Status = x.Status,
            }).FirstOrDefaultAsync() ?? new ClassViewModel();
            return data;
        }

        public Task<bool> InsertUpdateClass(ClassViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteClass(int? id)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Section
        public Task<List<SectionViewModel>> GetSectionList()
        {
            throw new NotImplementedException();
        }

        public async Task<SectionViewModel> GetSectionById(int? id)
        {
            var data = await _context.Section.Where(x => x.Id == id).Select(x => new SectionViewModel()
            {
                Id = x.Id,
                SectionName = x.SectionName,
                Status = x.Status,
            }).FirstOrDefaultAsync() ?? new SectionViewModel();
            return data;
        }

        public Task<bool> InsertUpdateSection(SectionViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteSection(int? id)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Program
        public  async Task<List<ProgramViewModel>> GetProgramList()
        {
            var list = await _context.Program.Select(x => new ProgramViewModel()
            {
                Id = x.Id,
                ProgramName = x.ProgramName,
                Status = x.Status,
            }).ToListAsync() ?? new List<ProgramViewModel>();
            return list;
        }

        public async Task<ProgramViewModel> GetProgramById(int? id)
        {
            var data = await _context.Program.Where(x => x.Id == id).Select(x => new ProgramViewModel()
            {
                Id = x.Id,
                ProgramName = x.ProgramName,
                Status = x.Status,
            }).FirstOrDefaultAsync() ?? new ProgramViewModel();
            return data;
        }

        public Task<bool> InsertUpdateProgram(ProgramViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProgram(int? id)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Team
        public Task<List<TeamCategoryViewModel>> GetTeamCategoryList()
        {
            throw new NotImplementedException();
        }

        public async Task<TeamCategoryViewModel> GetTeamCategoryById(int? id)
        {
            var data = await _context.TeamCategory.Where(x => x.Id == id).Select(x => new TeamCategoryViewModel()
            {
                Id = x.Id,
                CategoryName = x.CategoryName,
                Status = x.Status,
            }).FirstOrDefaultAsync() ?? new TeamCategoryViewModel();
            return data;
        }

        public Task<bool> InsertUpdateTeamCategory(TeamCategoryViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTeam(int? id)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Assignment Category
        public Task<List<AssignmentCategoryViewModel>> GetAssignmentCategoryList()
        {
            throw new NotImplementedException();
        }

        public async Task<AssignmentCategoryViewModel> GetAssignmentCategoryById(int? id)
        {
            var data = await _context.AssignmentCategory.Where(x => x.Id == id).Select(x => new AssignmentCategoryViewModel()
            {
                Id = x.Id,
                AssignmentCategoryName = x.AssignmentCategoryName,
                Status = x.Status,
            }).FirstOrDefaultAsync() ?? new AssignmentCategoryViewModel();
            return data;
        }

        public Task<bool> InsertUpdateAssignmentCategory(AssignmentCategoryViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAssignmentCategory(int? id)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Student Group
        public async Task<List<StudentGroupViewModel>> GetStudentGroupList()
        {
            var list = await _context.StudentGroup.Select(x => new StudentGroupViewModel()
            {
                Id = x.Id,
                GroupName=x.GroupName,
            }).ToListAsync() ?? new List<StudentGroupViewModel>();
            return list;
        }

        public async Task<StudentGroupViewModel> GetStudentGroupById(int? id)
        {
            var data = await _context.StudentGroup.Where(x => x.Id == id).Select(x => new StudentGroupViewModel()
            {
                Id = x.Id,
                GroupName = x.GroupName,
                YearId=x.YearId,
                Status = x.Status,
            }).FirstOrDefaultAsync() ?? new StudentGroupViewModel();
            return data;
        }

        public Task<bool> InsertUpdateStudentGroup(StudentGroupViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteStudentGroup(int? id)
        {
            throw new NotImplementedException();
        }

        #endregion
        #region Group Assocation
        public Task<List<GroupClassAssociationViewModel>> GetGroupClassAssociationList()
        {
            throw new NotImplementedException();
        }

        public async Task<GroupClassAssociationViewModel> GetGroupClassAssociationById(int? id)
        {
            var data = await _context.GroupClassAssociation.Where(x => x.Id == id).Select(x => new GroupClassAssociationViewModel()
            {
                Id = x.Id,
                Group=x.Group,
                Class=x.Class,
                Subject=x.Subject,
                Year=x.Year,
                Status = x.Status,
            }).FirstOrDefaultAsync() ?? new GroupClassAssociationViewModel();
            return data;
        }

        public Task<bool> InsertUpdateGroupClassAssociation(GroupClassAssociationViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteGroupClassAssociation(int? id)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Bank Details
        public async Task<List<BankDetailsViewModel>> GetBankDetailsList()
        {
            var list = await _context.BankDetail.Select(x => new BankDetailsViewModel()
            {
                Id = x.Id,
                AcccountNumber = x.AcccountNumber,
                BankName = x.BankName,
                QRCode = x.QRCode,
                Status = x.Status,
                Branch=x.Branch,
            }).ToListAsync() ?? new List<BankDetailsViewModel>();
            return list;
        }

        public async Task<BankDetailsViewModel> GetBankDetailsById(int? id)
        {
            var data = await _context.BankDetail.Where(x => x.Id == id).Select(x => new BankDetailsViewModel()
            {
                Id = x.Id,
                BankName= x.BankName,
                Branch= x.Branch,
                AcccountNumber= x.AcccountNumber,
                QRCode= x.QRCode,
                Status=x.Status,
            }).FirstOrDefaultAsync() ?? new BankDetailsViewModel();
            return data;
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
    }
}
