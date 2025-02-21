using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using SchoolManagementSystem.BusinessLayer.Interface;
using SchoolManagementSystem.Data.Data;
using SchoolManagementSystem.Data.Data.Entities;
using SchoolManagementSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SchoolManagementSystem.BusinessLayer.Repositories
{
    #region Course Plan

    public class CoursePlanRepository : ICoursePlan
    {
        private readonly ApplicationDbContext _dbContext;

        public CoursePlanRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<CoursePlanViewModel>> GetCoursePlanById(int? id)
        {
            var data = await _dbContext.CoursePlan.Where(x => x.Id == id).Select(x => new CoursePlanViewModel()
            {
                Id = x.Id,
                Title = x.Title,
                Credits = x.Credits,
                ExpectedOutcome = x.ExpectedOutcome,
                TeachingDate = x.TeachingDate,
                Code = x.Code,
                TeachingDuration = x.TeachingDuration,
                Description = x.Description,
                Subject = x.Subject,
                Class = x.Class,
                TeachingMaterialList = _dbContext.TeachingMaterial.Where(y => y.CoursePlanId == id).Select(y => new TeachingMaterialViewModel()
                {
                    CoursePlanId = y.CoursePlanId,
                    Id = y.Id,
                    Link = y.Link,
                }).ToList() ?? new List<TeachingMaterialViewModel>(),
                CourseFilesList = _dbContext.CourseFile.Where(z => z.CoursePlanId == id).Select(z => new CourseFileViewModel()
                {
                    Id = z.Id,
                    FilePath = z.FilePath,
                    Caption = z.Caption,
                }).ToList() ?? new List<CourseFileViewModel>(),
            }).FirstOrDefaultAsync() ?? new CoursePlanViewModel();
            return Result<CoursePlanViewModel>.Success(data);
        }

        public async Task<Result<List<CoursePlanViewModel>>> GetCoursePlanList()
        {
            var list = await _dbContext.CoursePlan.Where(x => x.Status == true).Select(x => new CoursePlanViewModel()
            {
                Id = x.Id,
                Title = x.Title,
                Class = x.Class,
                Subject = x.Subject,
                TeachingDuration = x.TeachingDuration,
                TeachingDate = x.TeachingDate,
                Code = x.Code,
            }).ToListAsync() ?? new List<CoursePlanViewModel>();
            return Result<List<CoursePlanViewModel>>.Success(list);
        }

        public async Task<Result<bool>> InsertUpdateCoursePlan(CoursePlanViewModel model)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    if (model.Id > 0)
                    {
                        var data = await _dbContext.CoursePlan.FindAsync(model.Id);
                        if (data == null)
                        {
                            return Result<bool>.Failure($"Data is not found with id:{model.Id}");
                        }
                        data.Id = model.Id;
                        data.Title = model.Title;
                        data.Class = model.Class;
                        data.Subject = model.Subject;
                        data.TeachingDuration = model.TeachingDuration;
                        data.TeachingDate = model.TeachingDate;
                        data.Code = model.Code;
                        data.Description = model.Description;
                        data.Credits = model.Credits;
                        data.ExpectedOutcome = model.ExpectedOutcome;
                        _dbContext.Entry(data).State = EntityState.Modified;

                        foreach (var item in await _dbContext.TeachingMaterial.Where(x => x.CoursePlanId == model.Id).ToListAsync())
                        {
                            if (!model.TeachingMaterialList.Any(x => x.Id == item.Id))
                            {
                                _dbContext.TeachingMaterial.Remove(item);
                                await _dbContext.SaveChangesAsync();
                            }
                        }
                        foreach (var item in model.TeachingMaterialList)
                        {
                            var teachingmaterial = await _dbContext.TeachingMaterial.Where(x => x.CoursePlanId == model.Id).FirstOrDefaultAsync();
                            if (teachingmaterial != null)
                            {
                                teachingmaterial.CoursePlanId = model.Id;
                                teachingmaterial.Link = item.Link;
                            }
                        }
                        foreach (var item in await _dbContext.CourseFile.Where(x => x.CoursePlanId == model.Id).ToListAsync())
                        {
                            if (!model.TeachingMaterialList.Any(x => x.Id == item.Id))
                            {
                                _dbContext.CourseFile.Remove(item);
                                await _dbContext.SaveChangesAsync();
                            }
                        }
                        foreach (var item in model.CourseFilesList)
                        {
                            var coursefile = await _dbContext.CourseFile.Where(x => x.CoursePlanId == model.Id).FirstOrDefaultAsync();
                            if (coursefile != null)
                            {
                                coursefile.CoursePlanId = model.Id;
                                coursefile.FilePath = item.FilePath;
                                coursefile.Caption = item.Caption;
                            }
                        }
                    }
                    else
                    {
                        var coursePlan = new CoursePlan()
                        {
                            Id = model.Id,
                            Title = model.Title,
                            Class = model.Class,
                            Subject = model.Subject,
                            TeachingDuration = model.TeachingDuration,
                            TeachingDate = model.TeachingDate,
                            Code = model.Code,
                            Description = model.Description,
                            Credits = model.Credits,
                            ExpectedOutcome = model.ExpectedOutcome,
                            Status = true,
                        };
                        await _dbContext.CoursePlan.AddAsync(coursePlan);
                        foreach (var item in model.TeachingMaterialList)
                        {
                            var teaching = new TeachingMaterial()
                            {
                                CoursePlanId = coursePlan.Id,
                                Link = item.Link,
                            };
                            await _dbContext.TeachingMaterial.AddAsync(teaching);
                        }
                        foreach (var item in model.CourseFilesList)
                        {
                            var coursefile = new CourseFile()
                            {
                                CoursePlanId = coursePlan.Id,
                                Caption = item.Caption,
                                FilePath = item.FilePath,
                            };
                            await _dbContext.CourseFile.AddAsync(coursefile);
                        }

                    }
                    await _dbContext.SaveChangesAsync();
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

        public async Task<Result<bool>> DeleteCoursePlan(int? id)
        {
            var data = await _dbContext.CoursePlan.FindAsync(id);
            try
            {
                if (data != null)
                {
                    data.Status = false;
                    _dbContext.Entry(data).State = EntityState.Modified;
                    await _dbContext.SaveChangesAsync();
                    return Result<bool>.Success(true);

                }
                else
                {
                    return Result<bool>.Failure($"Data can't found !!");
                }
            }
            catch (Exception ex)
            {
                return Result<bool>.Failure($"Failed to delete data with id:{data.Id}");
            }
        }
    }
    #endregion
    #region Chapter

    public class ChapterRepository : IChapter
    {
        private readonly ApplicationDbContext _dbContext;

        public ChapterRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<ChapterViewModel>> GetChapterById(int? id)
        {
            var data = await _dbContext.Chapter.Where(x => x.Id == id).Select(x => new ChapterViewModel()
            {
                Id = x.Id,
                ChapterTitle = x.ChapterTitle,
                Subject = x.Subject,
                Class = x.Class,
                LearningHours = x.LearningHours,

            }).FirstOrDefaultAsync() ?? new ChapterViewModel();
            return Result<ChapterViewModel>.Success(data);
        }

        public async Task<Result<List<ChapterViewModel>>> GetChapterList()
        {
            var list = await _dbContext.Chapter.Where(x => x.Status == true).Select(x => new ChapterViewModel()
            {
                Id = x.Id,
                ChapterTitle = x.ChapterTitle,
                Subject = x.Subject,
                Class = x.Class,
            }).ToListAsync() ?? new List<ChapterViewModel>();
            return Result<List<ChapterViewModel>>.Success(list);
        }

        public async Task<Result<bool>> InsertUpdateChapter(ChapterViewModel model)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    if (model.Id > 0)
                    {
                        var data = await _dbContext.Chapter.FindAsync(model.Id);
                        if (data == null)
                        {
                            return Result<bool>.Failure($"Data is not found with id:{model.Id}");
                        }
                        data.Id = model.Id;
                        data.ChapterTitle = model.ChapterTitle;
                        data.Subject = model.Subject;
                        data.LearningHours = model.LearningHours;
                        data.Class = model.Class;
                        _dbContext.Entry(data).State = EntityState.Modified;

                    }
                    else
                    {
                        var chapter = new Chapter()
                        {
                            Id = model.Id,
                            ChapterTitle = model.ChapterTitle,
                            Subject = model.Subject,
                            LearningHours = model.LearningHours,
                            Class = model.Class,
                            Status = true,
                        };
                        await _dbContext.Chapter.AddAsync(chapter);

                    }
                    await _dbContext.SaveChangesAsync();
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

        public async Task<Result<bool>> DeleteChapter(int? id)
        {
            var data = await _dbContext.Chapter.FindAsync(id);
            try
            {
                if (data != null)
                {
                    data.Status = false;
                    _dbContext.Entry(data).State = EntityState.Modified;
                    await _dbContext.SaveChangesAsync();
                    return Result<bool>.Success(true);

                }
                else
                {
                    return Result<bool>.Failure($"Data can't found !!");
                }
            }
            catch (Exception ex)
            {
                return Result<bool>.Failure($"Failed to delete data with id:{data.Id}");
            }
        }
    }
    #endregion
    #region Lesson Plan
    public class LessonPlanRepository : ILessonPlan
    {
        private readonly ApplicationDbContext _dbContext;

        public LessonPlanRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<LessonPlanViewModel>> GetLessonPlanById(int? id)
        {
            var data = await _dbContext.LessonPlan.Where(x => x.Id == id).Select(x => new LessonPlanViewModel()
            {
                Id = x.Id,
                Title = x.Title,
                TeachingDuration = x.TeachingDuration,
                TeachingDate = x.TeachingDate,
                Description = x.Description,
                TeachingMethods = x.TeachingMethods,
                ExpectedOutcome = x.ExpectedOutcome,
                Class = x.Class,
                Subject = x.Subject,
                Section = x.Section,
                Chapter = x.Chapter,
                Year = x.Year,
                TeachingMaterials = _dbContext.LessonPlanTeachingMaterial.Where(y => y.LessonPlanId == id).Select(y => new LessonPlanTeachingMaterialViewModel()
                {

                    Id = y.Id,
                    Link = y.Link,
                }).ToList() ?? new List<LessonPlanTeachingMaterialViewModel>(),
                CourseFiles = _dbContext.LessonPlanCourseFile.Where(z => z.LessonPlanId == id).Select(z => new LessonPlanCourseFileViewModel()
                {
                    Id = z.Id,
                    FilePath = z.FilePath,
                    Caption = z.Caption,
                }).ToList() ?? new List<LessonPlanCourseFileViewModel>(),
            }).FirstOrDefaultAsync() ?? new LessonPlanViewModel();
            return Result<LessonPlanViewModel>.Success(data);
        }

        public async Task<Result<List<LessonPlanViewModel>>> GetLessonPlanList()
        {
            var list = await _dbContext.LessonPlan.Where(x => x.Status == true).Select(x => new LessonPlanViewModel()
            {
                Id = x.Id,
                Class = x.Class,
                Subject = x.Subject,
                Section = x.Section,
                Chapter = x.Chapter,
                TeachingDuration = x.TeachingDuration,
                Year = x.Year,
            }).ToListAsync() ?? new List<LessonPlanViewModel>();
            return Result<List<LessonPlanViewModel>>.Success(list);
        }

        public async Task<Result<bool>> InsertUpdateLessonPlan(LessonPlanViewModel model)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    if (model.Id > 0)
                    {
                        var data = await _dbContext.LessonPlan.FindAsync(model.Id);
                        if (data == null)
                        {
                            return Result<bool>.Failure($"Data is not found with id:{model.Id}");
                        }
                        data.Id = model.Id;
                        data.Title = model.Title;
                        data.Class = model.Class;
                        data.Subject = model.Subject;
                        data.Section = model.Section;
                        data.Chapter = model.Chapter;
                        data.TeachingDuration = model.TeachingDuration;
                        data.Year = model.Year;
                        data.Description = model.Description;
                        data.TeachingMethods = model.TeachingMethods;
                        data.TeachingDate = model.TeachingDate;
                        data.ExpectedOutcome = model.ExpectedOutcome;
                        data.Status = model.Status;
                        _dbContext.Entry(data).State = EntityState.Modified;

                        foreach (var item in await _dbContext.LessonPlanTeachingMaterial.Where(x => x.LessonPlanId == model.Id).ToListAsync())
                        {
                            if (!model.TeachingMaterials.Any(x => x.Id == item.Id))
                            {
                                _dbContext.LessonPlanTeachingMaterial.Remove(item);
                                await _dbContext.SaveChangesAsync();
                            }
                        }
                        foreach (var item in model.TeachingMaterials)
                        {
                            var teachingmaterial = await _dbContext.LessonPlanTeachingMaterial.Where(x => x.LessonPlanId == model.Id).FirstOrDefaultAsync();
                            if (teachingmaterial != null)
                            {
                                teachingmaterial.LessonPlanId = model.Id;
                                teachingmaterial.Link = item.Link;
                            }
                        }
                        foreach (var item in await _dbContext.LessonPlanCourseFile.Where(x => x.LessonPlanId == model.Id).ToListAsync())
                        {
                            if (!model.TeachingMaterials.Any(x => x.Id == item.Id))
                            {
                                _dbContext.LessonPlanCourseFile.Remove(item);
                                await _dbContext.SaveChangesAsync();
                            }
                        }
                        foreach (var item in model.CourseFiles)
                        {
                            var coursefile = await _dbContext.LessonPlanCourseFile.Where(x => x.LessonPlanId == model.Id).FirstOrDefaultAsync();
                            if (coursefile != null)
                            {
                                coursefile.LessonPlanId = model.Id;
                                coursefile.FilePath = item.FilePath;
                                coursefile.Caption = item.Caption;
                            }
                        }

                    }
                    else
                    {
                        var lessonPlan = new LessonPlan()
                        {
                            Id = model.Id,
                            Title = model.Title,
                            Class = model.Class,
                            Subject = model.Subject,
                            Section = model.Section,
                            Chapter = model.Chapter,
                            TeachingDuration = model.TeachingDuration,
                            Year = model.Year,
                            Description = model.Description,
                            TeachingDate = model.TeachingDate,
                            TeachingMethods = model.TeachingMethods,
                            ExpectedOutcome = model.ExpectedOutcome,
                            Status = true,
                        };
                        await _dbContext.LessonPlan.AddAsync(lessonPlan);
                        foreach (var item in model.TeachingMaterials)
                        {
                            var teaching = new LessonPlanTeachingMaterial()
                            {
                                LessonPlanId = lessonPlan.Id,
                                Link = item.Link,
                            };
                            await _dbContext.LessonPlanTeachingMaterial.AddAsync(teaching);
                        }
                        foreach (var item in model.CourseFiles)
                        {
                            var coursefile = new LessonPlanCourseFile()
                            {
                                LessonPlanId = lessonPlan.Id,
                                Caption = item.Caption,
                                FilePath = item.FilePath,
                            };
                            await _dbContext.LessonPlanCourseFile.AddAsync(coursefile);
                        }

                    }
                    await _dbContext.SaveChangesAsync();
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

        public async Task<Result<bool>> DeleteLessonPlan(int? id)
        {
            var data = await _dbContext.LessonPlan.FindAsync(id);
            try
            {
                if (data != null)
                {
                    data.Status = false;
                    _dbContext.Entry(data).State = EntityState.Modified;
                    await _dbContext.SaveChangesAsync();
                    return Result<bool>.Success(true);

                }
                else
                {
                    return Result<bool>.Failure($"Data can't found !!");
                }
            }
            catch (Exception ex)
            {
                return Result<bool>.Failure($"Failed to delete data with id:{data.Id}");
            }
        }
    }
    #endregion
    #region Teaching Method

    public class TeachingMethodRepository : ITeachingMethod
    {
        private readonly ApplicationDbContext _dbContext;

        public TeachingMethodRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<TeachingMethodViewModel>> GetTeachingMethodById(int? id)
        {
            var data = await _dbContext.TeachingMethod.Where(x => x.Id == id).Select(x => new TeachingMethodViewModel()
            {
                Id = x.Id,
                Name = x.Name,
            }).FirstOrDefaultAsync() ?? new TeachingMethodViewModel();
            return Result<TeachingMethodViewModel>.Success(data);
        }

        public async Task<Result<List<TeachingMethodViewModel>>> GetTeachingMethodList()
        {
            var list = await _dbContext.TeachingMethod.Where(x => x.Status == true).Select(x => new TeachingMethodViewModel()
            {
                Id = x.Id,
                Name = x.Name,
            }).ToListAsync() ?? new List<TeachingMethodViewModel>();
            return Result<List<TeachingMethodViewModel>>.Success(list);
        }

        public async Task<Result<bool>> InsertUpdateTeachingMethod(TeachingMethodViewModel model)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    if (model.Id > 0)
                    {
                        var data = await _dbContext.TeachingMethod.FindAsync(model.Id);
                        if (data == null)
                        {
                            return Result<bool>.Failure($"Data is not found with id:{model.Id}");
                        }
                        data.Id = model.Id;
                        data.Name = model.Name;
                        data.Status = model.Status;
                        _dbContext.Entry(data).State = EntityState.Modified;

                    }
                    else
                    {
                        var teachingMethod = new TeachingMethod()
                        {
                            Id = model.Id,
                            Name = model.Name,
                            Status = true,
                        };
                        await _dbContext.TeachingMethod.AddAsync(teachingMethod);

                    }
                    await _dbContext.SaveChangesAsync();
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

        public async Task<Result<bool>> DeleteTeachingMethod(int? id)
        {
            var data = await _dbContext.TeachingMethod.FindAsync(id);
            try
            {
                if (data != null)
                {
                    data.Status = false;
                    _dbContext.Entry(data).State = EntityState.Modified;
                    await _dbContext.SaveChangesAsync();
                    return Result<bool>.Success(true);

                }
                else
                {
                    return Result<bool>.Failure($"Data can't found !!");
                }
            }
            catch (Exception ex)
            {
                return Result<bool>.Failure($"Failed to delete data with id:{data.Id}");
            }
        }
    }
    #endregion
}



