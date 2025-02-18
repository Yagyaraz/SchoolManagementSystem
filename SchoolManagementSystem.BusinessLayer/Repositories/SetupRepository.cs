using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.BusinessLayer.Interface;
using SchoolManagementSystem.Data.Data;
using SchoolManagementSystem.Data.Data.Entities;
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
        public async Task<Result<BusRouteViewModel>> GetBusRouteById(int? id)
        {
            var data = await _context.BusRoute.Where(x => x.Id == id).Select(x => new BusRouteViewModel()
            {
                Id = x.Id,
                DriverName = x.DriverName,
                BusNo = x.BusNo,
                AssistantName = x.AssistantName,
                AssistantPhone = x.AssistantPhone,
                Teacher = x.Teacher,
                Status = x.Status,
            }).FirstOrDefaultAsync() ?? new BusRouteViewModel();
            return Result<BusRouteViewModel>.Success(data);
        }

        public async Task<Result<List<BusRouteViewModel>>> GetBusRouteList()
        {
            var list = await _context.BusRoute.Select(x => new BusRouteViewModel()
            {
                Id = x.Id,
                DriverName = x.DriverName,
                BusNo = x.BusNo,
            }).ToListAsync() ?? new List<BusRouteViewModel>();
            return Result<List<BusRouteViewModel>>.Success(list);
        }
        public async Task<Result<bool>> InsertUpdateBusRoute(BusRouteViewModel model)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    if (model.Id > 0)
                    {
                        var busRoute = await _context.BusRoute.FirstOrDefaultAsync(x => x.Id == model.Id);
                        if (busRoute == null)
                        {
                            return Result<bool>.Failure($"BusRoute not found with id : {model.Id}");
                        }
                        busRoute.Id = model.Id;
                        busRoute.DriverName = model.DriverName;
                        busRoute.BusNo = model.BusNo;
                        busRoute.Teacher = model.Teacher;
                        busRoute.AssistantPhone = model.AssistantPhone;
                        busRoute.Status = model.Status;
                        busRoute.AssistantName = model.AssistantName;
                        _context.Entry(busRoute).State = EntityState.Modified;
                    }
                    else
                    {
                        var BusRoute = new BusRoute()
                        {
                            Id = model.Id,
                            DriverName = model.DriverName,
                            BusNo = model.BusNo,
                            Teacher = model.Teacher,
                            AssistantPhone = model.AssistantPhone,
                            Status = true,
                            AssistantName = model.AssistantName,
                        };
                        await _context.BusRoute.AddAsync(BusRoute);
                    }

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return Result<bool>.Success(true);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return Result<bool>.Failure("Insert/Update failed!!");
                }
            }
        }

        public async Task<Result<bool>> DeleteBusRoute(int? id)
        {
            var busroute = await _context.BusRoute.Where(x => x.Id == id).FirstOrDefaultAsync();
            try
            {
                if (busroute != null)
                {
                    busroute.Status = false;
                    _context.Entry(busroute).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Result<bool>.Success(true);
                }
                else
                {
                    return Result<bool>.Failure($"Bus Route can't found !!");
                }

            }
            catch (Exception ex)
            {
                return Result<bool>.Failure($"Failed to delete Bus Route with id:{busroute.Id}");
            }
        }
        #endregion
        #region Route Map
        public async Task<Result<List<RouteMapViewModel>>> GetRouteMapList()
        {
            var list = await _context.RouteMap.Select(x => new RouteMapViewModel()
            {
                Id = x.Id,
                BusRouteId = x.BusRouteId,
                GPSDevice = x.GPSDevice,
            }).ToListAsync() ?? new List<RouteMapViewModel>();
            return Result<List<RouteMapViewModel>>.Success(list);
        }

        public async Task<Result<RouteMapViewModel>> GetRouteMapById(int? id)
        {
            var data = await _context.RouteMap.Where(x => x.Id == id).Select(x => new RouteMapViewModel()
            {
                Id = x.Id,
                BusRouteId = x.BusRouteId,
                GPSDevice = x.GPSDevice,
                GPSDeviceId = x.GPSDevice,
                Status = x.Status,

            }).FirstOrDefaultAsync() ?? new RouteMapViewModel();
            return Result<RouteMapViewModel>.Success(data);
        }

        public async Task<Result<bool>> InsertUpdateRouteMap(RouteMapViewModel model)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    if (model.Id > 0)
                    {
                        var routeMap = await _context.RouteMap.FirstOrDefaultAsync(x => x.Id == model.Id);
                        if (routeMap == null)
                        {
                            return Result<bool>.Failure($"Route map not found with id : {model.Id}");
                        }
                        routeMap.Id = model.Id;
                        routeMap.BusRouteId = model.BusRouteId;
                        routeMap.GPSDevice = model.GPSDevice;
                        routeMap.GPSDeviceId = model.GPSDeviceId;
                        routeMap.Status = model.Status;
                        _context.Entry(routeMap).State = EntityState.Modified;
                    }
                    else
                    {
                        var routeMap = new RouteMap()
                        {
                            Id = model.Id,
                            BusRouteId = model.BusRouteId,
                            GPSDevice = model.GPSDevice,
                            GPSDeviceId = model.GPSDeviceId,
                            Status = true,
                        };
                        await _context.RouteMap.AddAsync(routeMap);
                    }

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return Result<bool>.Success(true);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return Result<bool>.Failure("Insert/Update failed!!");
                }
            }
        }


        public async Task<Result<bool>> DeleteRouteMap(int? id)
        {
            var routeMap = await _context.RouteMap.Where(x => x.Id == id).FirstOrDefaultAsync();
            try
            {
                if (routeMap != null)
                {
                    routeMap.Status = false;
                    _context.Entry(routeMap).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Result<bool>.Success(true);
                }
                else
                {
                    return Result<bool>.Failure($"Route Map can't found !!");
                }

            }
            catch (Exception ex)
            {
                return Result<bool>.Failure($"Failed to delete Route map with id:{routeMap.Id}");
            }
        }
        #endregion
        #region Home
        public async Task<Result<HomeViewModel>> GetHome(int? id)
        {
            var data = await _context.Home.Where(x => x.Id == id).Select(x => new HomeViewModel()
            {
                Id = x.Id,
                Website = x.Website,
                LogoPath = x.LogoPath,
                Name = x.Name,
                Slogan = x.Slogan,
                ImageForResult = x.ImageForResult,
            }).FirstOrDefaultAsync() ?? new HomeViewModel();
            return Result<HomeViewModel>.Success(data);
        }

        public async Task<Result<bool>> InsertUpdateHome(HomeViewModel model)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    if (model.Id > 0)
                    {
                        var home = await _context.Home.FirstOrDefaultAsync(x => x.Id == model.Id);
                        if (home == null)
                        {
                            return Result<bool>.Failure($"Home Details not found with id : {model.Id}");
                        }
                        home.Id = model.Id;
                        home.Website = model.Website;
                        home.LogoPath = model.LogoPath;
                        home.Name = model.Name;
                        home.Slogan = model.Slogan;
                        home.ImageForResult = model.ImageForResult;
                        _context.Entry(home).State = EntityState.Modified;
                    }
                    else
                    {
                        var home = new Home()
                        {
                            Id = model.Id,
                            Website = model.Website,
                            LogoPath = model.LogoPath,
                            Name = model.Name,
                            Slogan = model.Slogan,
                            ImageForResult = model.ImageForResult,
                        };
                        await _context.Home.AddAsync(home);
                    }

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return Result<bool>.Success(true);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return Result<bool>.Failure("Insert/Update failed!!");
                }
            }

        }
        #endregion       
        #region About
        public async Task<Result<AboutViewModel>> GetAboutUs(int? id)
        {
            var data = await _context.About.Where(x => x.Id == id).Select(x => new AboutViewModel()
            {
                Id = x.Id,
                ImagePath = x.ImagePath,
                Name = x.Name,
                Introduction = x.Introduction,
                VisionStatement = x.VisionStatement,
                PrincipalName = x.PrincipalName,
                PrincipalImage = x.PrincipalImage,
                PrincipalSignature = x.PrincipalSignature,
                PrincipalMessage = x.PrincipalMessage,
                RulesRegulation = x.RulesRegulation,
                Address = x.Address,
                Email = x.Email,
                Phone = x.Phone,
                Fax = x.Fax,
                Facebook = x.Facebook,
                Instagram = x.Instagram,
                YouTube = x.YouTube,
                TikTok = x.TikTok,
                Location = x.Location,
                Status = x.Status

            }).FirstOrDefaultAsync() ?? new AboutViewModel();
            return Result<AboutViewModel>.Success(data);
        }
        public async Task<Result<bool>> InsertUpdateAboutUs(AboutViewModel model)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    if (model.Id > 0)
                    {
                        var about = await _context.About.FirstOrDefaultAsync(x => x.Id == model.Id);
                        if (about == null)
                        {
                            return Result<bool>.Failure($"About Us not found with id : {model.Id}");
                        }
                        about.Id = model.Id;
                        about.ImagePath = model.ImagePath;
                        about.Name = model.Name;
                        about.Introduction = model.Introduction;
                        about.VisionStatement = model.VisionStatement;
                        about.PrincipalName = model.PrincipalName;
                        about.PrincipalImage = model.PrincipalImage;
                        about.PrincipalSignature = model.PrincipalSignature;
                        about.PrincipalMessage = model.PrincipalMessage;
                        about.RulesRegulation = model.RulesRegulation;
                        about.Address = model.Address;
                        about.Email = model.Email;
                        about.Phone = model.Phone;
                        about.Fax = model.Fax;
                        about.Facebook = model.Facebook;
                        about.Instagram = model.Instagram;
                        about.YouTube = model.YouTube;
                        about.TikTok = model.TikTok;
                        about.Location = model.Location;
                        about.Status = model.Status;
                        _context.Entry(about).State = EntityState.Modified;
                    }
                    else
                    {
                        var about = new About()
                        {
                            Id = model.Id,
                            ImagePath = model.ImagePath,
                            Name = model.Name,
                            Introduction = model.Introduction,
                            VisionStatement = model.VisionStatement,
                            PrincipalName = model.PrincipalName,
                            PrincipalImage = model.PrincipalImage,
                            PrincipalSignature = model.PrincipalSignature,
                            PrincipalMessage = model.PrincipalMessage,
                            RulesRegulation = model.RulesRegulation,
                            Address = model.Address,
                            Email = model.Email,
                            Phone = model.Phone,
                            Fax = model.Fax,
                            Facebook = model.Facebook,
                            Instagram = model.Instagram,
                            YouTube = model.YouTube,
                            TikTok = model.TikTok,
                            Location = model.Location,
                            Status = model.Status
                        };
                        await _context.About.AddAsync(about);
                    }

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return Result<bool>.Success(true);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return Result<bool>.Failure("Insert/Update failed!!");
                }
            }

        }
        #endregion
        #region Subject
        public async Task<Result<List<SubjectViewModel>>> GetSubjectList()
        {
            var list = await _context.Subject.Select(x => new SubjectViewModel()
            {
                Id = x.Id,
                SubjectName = x.SubjectName,
                ShortCode = x.ShortCode,
            }).ToListAsync() ?? new List<SubjectViewModel>();
            return Result<List<SubjectViewModel>>.Success(list);
        }

        public async Task<Result<SubjectViewModel>> GetSubjectById(int? id)
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
            return Result<SubjectViewModel>.Success(data);
        }

        public async Task<Result<bool>> InsertUpdateSubject(SubjectViewModel model)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    if (model.Id > 0)
                    {
                        var subject = await _context.Subject.FirstOrDefaultAsync(x => x.Id == model.Id);
                        if (subject == null)
                        {
                            return Result<bool>.Failure($"Subject not found with id : {model.Id}");
                        }
                        subject.Id = model.Id;
                        subject.SubjectName = model.SubjectName;
                        subject.ShortCode = model.ShortCode;
                        subject.TheoryCredit = model.TheoryCredit;
                        subject.CalculateMarks = model.CalculateMarks;
                        subject.Status = model.Status;
                        subject.PracticalCredit = model.PracticalCredit;
                        _context.Entry(subject).State = EntityState.Modified;
                    }
                    else
                    {
                        var subject = new Subject()
                        {
                            Id = model.Id,
                            SubjectName = model.SubjectName,
                            ShortCode = model.ShortCode,
                            TheoryCredit = model.TheoryCredit,
                            CalculateMarks = model.CalculateMarks,
                            Status = model.Status,
                            PracticalCredit = model.PracticalCredit,
                        };
                        await _context.Subject.AddAsync(subject);
                    }

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return Result<bool>.Success(true);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return Result<bool>.Failure("Insert/Update failed!!");
                }
            }

        }

        public async Task<Result<bool>> DeleteSubject(int? id)
        {
            var subject = await _context.BusRoute.Where(x => x.Id == id).FirstOrDefaultAsync();
            try
            {
                if (subject != null)
                {
                    subject.Status = false;
                    _context.Entry(subject).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Result<bool>.Success(true);
                }
                else
                {
                    return Result<bool>.Failure($"Subject can't found !!");
                }

            }
            catch (Exception ex)
            {
                return Result<bool>.Failure($"Failed to delete Subject with id:{subject.Id}");
            }
        }
        #endregion
        #region Class
        public async Task<Result<List<ClassViewModel>>> GetClassList()
        {
            var data = await _context.Classe.Where(x => x.Status == true).Select(x => new ClassViewModel()
            {
                Id = x.Id,
                Name = x.Name,
            }).ToListAsync() ?? new List<ClassViewModel>();
            return Result<List<ClassViewModel>>.Success(data);
        }

        public async Task<Result<ClassViewModel>> GetClassById(int? id)
        {
            var data = await _context.Classe.Where(x => x.Id == id).Select(x => new ClassViewModel()
            {
                Id = x.Id,
                Status = x.Status,
                Name = x.Name,
            }).FirstOrDefaultAsync() ?? new ClassViewModel();
            return Result<ClassViewModel>.Success(data);
        }

        public async Task<Result<bool>> InsertUpdateClass(ClassViewModel model)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    if (model.Id > 0)
                    {
                        var data = await _context.Classe.FirstOrDefaultAsync(x => x.Id == model.Id);
                        if (data == null)
                        {
                            return Result<bool>.Failure($"Class not found with id : {model.Id}");
                        }
                        data.Status = model.Status;
                        data.Name = model.Name;
                        _context.Entry(data).State = EntityState.Modified;
                    }
                    else
                    {
                        var data = new Class()
                        {
                            Id = model.Id,
                            Name = model.Name,
                            Status = true,
                        };
                        await _context.Classe.AddAsync(data);
                    }

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return Result<bool>.Success(true);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return Result<bool>.Failure("Insert/Update failed!!");
                }
            }

        }

        public async Task<Result<bool>> DeleteClass(int? id)
        {
            var data = await _context.Classe.Where(x => x.Id == id).FirstOrDefaultAsync();
            try
            {
                if (data != null)
                {
                    data.Status = false;
                    _context.Entry(data).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Result<bool>.Success(true);
                }
                else
                {
                    return Result<bool>.Failure($"Class can't found !!");
                }

            }
            catch (Exception ex)
            {
                return Result<bool>.Failure($"Failed to delete Class with id:{data.Id}");
            }
        }
        #endregion
        #region Section
        public async Task<Result<List<SectionViewModel>>> GetSectionList()
        {
            var list = await _context.Section.Where(x => x.Status == true).Select(x => new SectionViewModel()
            {
                Id = x.Id,
                SectionName = x.SectionName,
            }).ToListAsync() ?? new List<SectionViewModel>();
            return Result<List<SectionViewModel>>.Success(list);
        }

        public async Task<Result<SectionViewModel>> GetSectionById(int? id)
        {
            var data = await _context.Section.Where(x => x.Id == id).Select(x => new SectionViewModel()
            {
                Id = x.Id,
                SectionName = x.SectionName,
                Status = x.Status,
            }).FirstOrDefaultAsync() ?? new SectionViewModel();
            return Result< SectionViewModel>.Success(data);
        }

        public async Task<Result<bool>> InsertUpdateSection(SectionViewModel model)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    if (model.Id > 0)
                    {
                        var section = await _context.Section.FirstOrDefaultAsync(x => x.Id == model.Id);
                        if (section == null)
                        {
                            return Result<bool>.Failure($"Section not found with id : {model.Id}");
                        }
                        section.Id = model.Id;
                        section.SectionName = model.SectionName;
                        section.Status = model.Status;
                        _context.Entry(section).State = EntityState.Modified;
                    }
                    else
                    {
                        var section = new Section()
                        {
                            Id = model.Id,
                            SectionName = model.SectionName,
                            Status = true,
                        };
                        await _context.Section.AddAsync(section);
                    }

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return Result<bool>.Success(true);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return Result<bool>.Failure("Insert/Update failed!!");
                }
            }

        }

        public async Task<Result<bool>> DeleteSection(int? id)
        {
            var section = await _context.Section.Where(x => x.Id == id).FirstOrDefaultAsync();
            try
            {
                if (section != null)
                {
                    section.Status = false;
                    _context.Entry(section).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Result<bool>.Success(true);
                }
                else
                {
                    return Result<bool>.Failure($"section can't found !!");
                }

            }
            catch (Exception ex)
            {
                return Result<bool>.Failure($"Failed to delete section with id:{section.Id}");
            }
        }
        #endregion
        #region Program
        public async Task<Result<List<ProgramViewModel>>> GetProgramList()
        {
            var list = await _context.Program.Select(x => new ProgramViewModel()
            {
                Id = x.Id,
                ProgramName = x.ProgramName,
                Status = x.Status,
            }).ToListAsync() ?? new List<ProgramViewModel>();
            return Result<List<ProgramViewModel>>.Success(list);

        }

        public async Task<Result<ProgramViewModel>> GetProgramById(int? id)
        {
            var data = await _context.Program.Where(x => x.Id == id).Select(x => new ProgramViewModel()
            {
                Id = x.Id,
                ProgramName = x.ProgramName,
                Status = x.Status,
            }).FirstOrDefaultAsync() ?? new ProgramViewModel();
            return Result<ProgramViewModel>.Success(data);

        }

        public async Task<Result<bool>> InsertUpdateProgram(ProgramViewModel model)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    if (model.Id > 0)
                    {
                        var program = await _context.Program.FirstOrDefaultAsync(x => x.Id == model.Id);
                        if (program == null)
                        {
                            return Result<bool>.Failure($"Program not found with id : {model.Id}");
                        }
                        program.Id = model.Id;
                        program.ProgramName = model.ProgramName;
                        program.Status = model.Status;
                        _context.Entry(program).State = EntityState.Modified;
                    }
                    else
                    {
                        var program = new Program()
                        {
                            Id = model.Id,
                            ProgramName = model.ProgramName,
                            Status = model.Status,
                        };
                        await _context.Program.AddAsync(program);
                    }

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return Result<bool>.Success(true);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return Result<bool>.Failure("Insert/Update failed!!");
                }
            }

        }

        public async Task<Result<bool>> DeleteProgram(int? id)
        {
            var program = await _context.Program.Where(x => x.Id == id).FirstOrDefaultAsync();
            try
            {
                if (program != null)
                {
                    program.Status = false;
                    _context.Entry(program).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Result<bool>.Success(true);
                }
                else
                {
                    return Result<bool>.Failure($"Program can't found !!");
                }

            }
            catch (Exception ex)
            {
                return Result<bool>.Failure($"Failed to delete Program with id:{program.Id}");
            }
        }
        #endregion
        #region Team
        public async Task<Result<List<TeamCategoryViewModel>>> GetTeamCategoryList()
        {
            var list = await _context.TeamCategory.Where(x => x.Status == true).Select(x => new TeamCategoryViewModel()
            {
                Id = x.Id,
                CategoryName = x.CategoryName,
            }).ToListAsync() ?? new List<TeamCategoryViewModel>();
            return Result<List<TeamCategoryViewModel>>.Success(list);
        }

        public async Task<Result<TeamCategoryViewModel>> GetTeamCategoryById(int? id)
        {
            var data = await _context.TeamCategory.Where(x => x.Id == id).Select(x => new TeamCategoryViewModel()
            {
                Id = x.Id,
                CategoryName = x.CategoryName,
                Status = x.Status,
            }).FirstOrDefaultAsync() ?? new TeamCategoryViewModel();
            return Result<TeamCategoryViewModel>.Success(data);

        }

        public async Task<Result<bool>> InsertUpdateTeamCategory(TeamCategoryViewModel model)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    if (model.Id > 0)
                    {
                        var team = await _context.TeamCategory.FirstOrDefaultAsync(x => x.Id == model.Id);
                        if (team == null)
                        {
                            return Result<bool>.Failure($"Team not found with id : {model.Id}");
                        }
                        team.Id = model.Id;
                        team.CategoryName = model.CategoryName;
                        team.Status = model.Status;
                        _context.Entry(team).State = EntityState.Modified;
                    }
                    else
                    {
                        var team = new TeamCategory()
                        {
                            Id = model.Id,
                            CategoryName = model.CategoryName,
                            Status = true,
                        };
                        await _context.TeamCategory.AddAsync(team);
                    }

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return Result<bool>.Success(true);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return Result<bool>.Failure("Insert/Update failed!!");
                }
            }

        }

        public async Task<Result<bool>> DeleteTeam(int? id)
        {
            var team = await _context.TeamCategory.Where(x => x.Id == id).FirstOrDefaultAsync();
            try
            {
                if (team != null)
                {
                    team.Status = false;
                    _context.Entry(team).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Result<bool>.Success(true);
                }
                else
                {
                    return Result<bool>.Failure($"team can't found !!");
                }

            }
            catch (Exception ex)
            {
                return Result<bool>.Failure($"Failed to delete team with id:{team.Id}");
            }
        }
        #endregion
        #region Assignment Category
        public async Task<Result<List<AssignmentCategoryViewModel>>> GetAssignmentCategoryList()
        {
            var list = await _context.AssignmentCategory.Where(x => x.Status == true).Select(x => new AssignmentCategoryViewModel()
            {
                Id = x.Id,
                AssignmentCategoryName = x.AssignmentCategoryName,
            }).ToListAsync() ?? new List<AssignmentCategoryViewModel>();
            return Result<List<AssignmentCategoryViewModel>>.Success(list);
        }

        public async Task<Result<AssignmentCategoryViewModel>> GetAssignmentCategoryById(int? id)
        {
            var data = await _context.AssignmentCategory.Where(x => x.Id == id).Select(x => new AssignmentCategoryViewModel()
            {
                Id = x.Id,
                AssignmentCategoryName = x.AssignmentCategoryName,
                Status = x.Status,
            }).FirstOrDefaultAsync() ?? new AssignmentCategoryViewModel();
            return Result<AssignmentCategoryViewModel>.Success(data);

        }

        public async Task<Result<bool>> InsertUpdateAssignmentCategory(AssignmentCategoryViewModel model)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    if (model.Id > 0)
                    {
                        var assingment = await _context.AssignmentCategory.FirstOrDefaultAsync(x => x.Id == model.Id);
                        if (assingment == null)
                        {
                            return Result<bool>.Failure($"Assingnment category not found with id : {model.Id}");
                        }
                        assingment.Id = model.Id;
                        assingment.AssignmentCategoryName = model.AssignmentCategoryName;
                        assingment.Status = model.Status;
                        _context.Entry(assingment).State = EntityState.Modified;
                    }
                    else
                    {
                        var assingment = new AssignmentCategory()
                        {
                            Id = model.Id,
                            AssignmentCategoryName = model.AssignmentCategoryName,
                            Status = true,
                        };
                        await _context.AssignmentCategory.AddAsync(assingment);
                    }

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return Result<bool>.Success(true);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return Result<bool>.Failure("Insert/Update failed!!");
                }
            }

        }

        public async Task<Result<bool>> DeleteAssignmentCategory(int? id)
        {
            var assignment = await _context.AssignmentCategory.Where(x => x.Id == id).FirstOrDefaultAsync();
            try
            {
                if (assignment != null)
                {
                    assignment.Status = false;
                    _context.Entry(assignment).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Result<bool>.Success(true);
                }
                else
                {
                    return Result<bool>.Failure($"assignment can't found !!");
                }

            }
            catch (Exception ex)
            {
                return Result<bool>.Failure($"Failed to delete assignment with id:{assignment.Id}");
            }
        }
        #endregion
        #region Student Group
        public async Task<Result<List<StudentGroupViewModel>>> GetStudentGroupList()
        {
            var list = await _context.StudentGroup.Select(x => new StudentGroupViewModel()
            {
                Id = x.Id,
                GroupName = x.GroupName,
            }).ToListAsync() ?? new List<StudentGroupViewModel>();
            return Result<List<StudentGroupViewModel>>.Success(list);

        }

        public async Task<Result<StudentGroupViewModel>> GetStudentGroupById(int? id)
        {
            var data = await _context.StudentGroup.Where(x => x.Id == id).Select(x => new StudentGroupViewModel()
            {
                Id = x.Id,
                GroupName = x.GroupName,
                YearId = x.YearId,
                Status = x.Status,
            }).FirstOrDefaultAsync() ?? new StudentGroupViewModel();
            return Result<StudentGroupViewModel>.Success(data);

        }

        public async Task<Result<bool>> InsertUpdateStudentGroup(StudentGroupViewModel model)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    if (model.Id > 0)
                    {
                        var group = await _context.StudentGroup.FirstOrDefaultAsync(x => x.Id == model.Id);
                        if (group == null)
                        {
                            return Result<bool>.Failure($"StudentGroup not found with id : {model.Id}");
                        }
                        group.GroupName = model.GroupName;
                        group.YearId = model.YearId;
                        group.Status = model.Status;
                        _context.Entry(group).State = EntityState.Modified;
                    }
                    else
                    {
                        var group = new StudentGroup()
                        {
                            Id = model.Id,
                            GroupName = model.GroupName,
                            YearId = model.YearId,
                            Status = true,
                        };
                        await _context.StudentGroup.AddAsync(group);
                    }

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return Result<bool>.Success(true);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return Result<bool>.Failure("Insert/Update failed!!");
                }
            }

        }

        public async Task<Result<bool>> DeleteStudentGroup(int? id)
        {
            var group = await _context.StudentGroup.Where(x => x.Id == id).FirstOrDefaultAsync();
            try
            {
                if (group != null)
                {
                    group.Status = false;
                    _context.Entry(group).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Result<bool>.Success(true);
                }
                else
                {
                    return Result<bool>.Failure($"StudentGroup can't found !!");
                }

            }
            catch (Exception ex)
            {
                return Result<bool>.Failure($"Failed to delete StudentGroup with id:{group.Id}");
            }

        }

        #endregion
        #region Group Assocation
        public async Task<Result<List<GroupClassAssociationViewModel>>> GetGroupClassAssociationList()
        {
            var list = await _context.GroupClassAssociation.Where(x => x.Status == true).Select(x => new GroupClassAssociationViewModel()
            {
                Id = x.Id,
                Group = x.Group,
                Class = x.Class,
                Subject = x.Subject,
                Year = x.Year,

            }).ToListAsync() ?? new List<GroupClassAssociationViewModel>();
            return Result<List<GroupClassAssociationViewModel>>.Success(list);
        }

        public async Task<Result<GroupClassAssociationViewModel>> GetGroupClassAssociationById(int? id)
        {
            var data = await _context.GroupClassAssociation.Where(x => x.Id == id).Select(x => new GroupClassAssociationViewModel()
            {
                Id = x.Id,
                Group = x.Group,
                Class = x.Class,
                Subject = x.Subject,
                Year = x.Year,
                Status = x.Status,
            }).FirstOrDefaultAsync() ?? new GroupClassAssociationViewModel();
            return Result< GroupClassAssociationViewModel>.Success(data);

        }

        public async Task<Result<bool>> InsertUpdateGroupClassAssociation(GroupClassAssociationViewModel model)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    if (model.Id > 0)
                    {
                        var association = await _context.GroupClassAssociation.FirstOrDefaultAsync(x => x.Id == model.Id);
                        if (association == null)
                        {
                            return Result<bool>.Failure($"GroupClassAssociation not found with id : {model.Id}");
                        }
                        association.Group = model.Group;
                        association.Class = model.Class;
                        association.Subject = model.Subject;
                        association.Year = model.Year;
                        association.Status = model.Status;
                        _context.Entry(association).State = EntityState.Modified;
                    }
                    else
                    {
                        var association = new GroupClassAssociation()
                        {
                            Id = model.Id,
                            Group = model.Group,
                            Class = model.Class,
                            Subject = model.Subject,
                            Year = model.Year,
                            Status = true,
                        };
                        await _context.GroupClassAssociation.AddAsync(association);
                    }

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return Result<bool>.Success(true);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return Result<bool>.Failure("Insert/Update failed!!");
                }
            }

        }

        public async Task<Result<bool>> DeleteGroupClassAssociation(int? id)
        {
            var Association = await _context.GroupClassAssociation.Where(x => x.Id == id).FirstOrDefaultAsync();
            try
            {
                if (Association != null)
                {
                    Association.Status = false;
                    _context.Entry(Association).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Result<bool>.Success(true);
                }
                else
                {
                    return Result<bool>.Failure($"GroupClassAssociation can't found !!");
                }

            }
            catch (Exception ex)
            {
                return Result<bool>.Failure($"Failed to delete Group Association with id:{Association.Id}");
            }
        }
        #endregion
        #region Bank Details
        public async Task<Result<List<BankDetailsViewModel>>> GetBankDetailsList()
        {
            var list = await _context.BankDetail.Select(x => new BankDetailsViewModel()
            {
                Id = x.Id,
                AcccountNumber = x.AcccountNumber,
                BankName = x.BankName,
                QRCode = x.QRCode,
                Status = x.Status,
                Branch = x.Branch,
            }).ToListAsync() ?? new List<BankDetailsViewModel>();
            return Result<List<BankDetailsViewModel>>.Success(list);

        }

        public async Task<Result<BankDetailsViewModel>> GetBankDetailsById(int? id)
        {
            var data = await _context.BankDetail.Where(x => x.Id == id).Select(x => new BankDetailsViewModel()
            {
                Id = x.Id,
                BankName = x.BankName,
                Branch = x.Branch,
                AcccountNumber = x.AcccountNumber,
                QRCode = x.QRCode,
                Status = x.Status,
            }).FirstOrDefaultAsync() ?? new BankDetailsViewModel();
            return Result<BankDetailsViewModel>.Success(data);
        }

        public async Task<Result<bool>> InsertUpdateBankDetails(BankDetailsViewModel model)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    if (model.Id > 0)
                    {
                        var bank = await _context.BankDetail.FirstOrDefaultAsync(x => x.Id == model.Id);
                        if (bank == null)
                        {
                            return Result<bool>.Failure($"BankDetail not found with id : {model.Id}");
                        }
                        bank.BankName = model.BankName;
                        bank.Branch = model.Branch;
                        bank.AcccountNumber = model.
                            AcccountNumber = model.AcccountNumber;
                        bank.QRCode = model.QRCode;
                        bank.Status = model.Status;
                        _context.Entry(bank).State = EntityState.Modified;
                    }
                    else
                    {
                        var bank = new BankDetails()
                        {
                            Id = model.Id,
                            BankName = model.BankName,
                            Branch = model.Branch,
                            AcccountNumber = model.AcccountNumber,
                            QRCode = model.QRCode,
                            Status = true,
                        };
                        await _context.BankDetail.AddAsync(bank);
                    }

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return Result<bool>.Success(true);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return Result<bool>.Failure("Insert/Update failed!!");
                }
            }

        }

        public async Task<Result<bool>> DeleteBankDetails(int? id)
        {
            var bank = await _context.BankDetail.Where(x => x.Id == id).FirstOrDefaultAsync();
            try
            {
                if (bank != null)
                {
                    bank.Status = false;
                    _context.Entry(bank).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Result<bool>.Success(true);
                }
                else
                {
                    return Result<bool>.Failure($"BankDetail can't found !!");
                }

            }
            catch (Exception ex)
            {
                return Result<bool>.Failure($"Failed to delete BankDetail with id:{bank.Id}");
            }
        }
        #endregion
    }
}
