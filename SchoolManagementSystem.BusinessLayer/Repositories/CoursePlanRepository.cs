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
    public class CoursePlanRepository : ICoursePlan
    {
        private readonly ApplicationDbContext _dbContext;

        public CoursePlanRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Chapter
        public async Task<Result<ChapterViewModel>> GetChapterById(int? id)
        {
            var data= await _dbContext.Chapter.Where(x => x.Id == id && x.Status==true).Select(x=>new ChapterViewModel()
            {
                Id = x.Id,
                ChapterTitle=x.ChapterTitle,
                Subject=x.Subject,  
                Class=x.Class,
                LearningHours=x.LearningHours,

            }).FirstOrDefaultAsync()??new ChapterViewModel();
            return Result<ChapterViewModel>.Success(data);
        }

        public  async Task<Result<List<ChapterViewModel>>> GetChapterList()
        {
            var list= await _dbContext.Chapter.Where(x=>x.Status==true).Select(x=> new ChapterViewModel()
            {
                Id = x.Id,
                ChapterTitle=x.ChapterTitle,
                Subject=x.Subject,
                Class = x.Class,
            }).ToListAsync()??new List<ChapterViewModel>();
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
                            Id=model.Id,
                            ChapterTitle=model.ChapterTitle,
                            Subject=model.Subject,
                            LearningHours=model.LearningHours,
                            Class = model.Class,
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
            var data=await _dbContext.Chapter.FindAsync(id);
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
        #endregion
        #region Course Plan
        public async Task<Result<CoursePlanViewModel>> GetCoursePlanById(int? id)
        {
            var data = await _dbContext.CoursePlan.Where(x => x.Id == id && x.Status == true).Select(x => new CoursePlanViewModel()
            {
                Id = x.Id,
                Title=x.Title,
                Credits = x.Credits,
                ExpectedOutcome=x.ExpectedOutcome,
                TeachingDate=x.TeachingDate,
                Code=x.Code,
                TeachingDuration=x.TeachingDuration,
                Description=x.Description,
                Subject=x.Subject,
                Class=x.Class,
            }).FirstOrDefaultAsync() ?? new CoursePlanViewModel();
            return Result<CoursePlanViewModel>.Success(data);
        }

        public async Task<Result<List<CoursePlanViewModel>>> GetCoursePlanList()
        {
            var list = await _dbContext.CoursePlan.Where(x => x.Status == true).Select(x => new CoursePlanViewModel()
            {
                Id = x.Id,
                Title = x.Title,
                Class=x.Class,
                Subject=x.Subject,
                TeachingDuration= x.TeachingDuration,
                TeachingDate = x.TeachingDate,
                Code= x.Code,                
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
                        data.Credits= model.Credits;
                        data.ExpectedOutcome = model.ExpectedOutcome;
                        _dbContext.Entry(data).State = EntityState.Modified;

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
                        };
                        await _dbContext.CoursePlan.AddAsync(coursePlan);

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
        #endregion
        #region Lesson Plan
        public async Task<Result<LessonPlanViewModel>> GetLessonPlanById(int? id)
        {
            var data = await _dbContext.LessonPlan.Where(x => x.Id == id && x.Status == true).Select(x => new LessonPlanViewModel()
            {
                Id = x.Id,
                Title = x.Title,
                TeachingDuration = x.TeachingDuration,
                TeachingDate= x.TeachingDate,
                Description = x.Description,
                TeachingMethods= x.TeachingMethods,
                ExpectedOutcome= x.ExpectedOutcome,
                Class= x.Class,
                Subject=x.Subject,
                Section=x.Section,
                Chapter=x.Chapter,
                Year=x.Year,
            }).FirstOrDefaultAsync() ?? new LessonPlanViewModel();
            return Result<LessonPlanViewModel>.Success(data);
        }

        public async Task<Result<List<LessonPlanViewModel>>> GetLessonPlanList()
        {
            var list = await _dbContext.LessonPlan.Where(x => x.Status == true).Select(x => new LessonPlanViewModel()
            {
                Id = x.Id,
                Class= x.Class,
                Subject= x.Subject,
                Section= x.Section,
                Chapter= x.Chapter,
                TeachingDuration= x.TeachingDuration,
                Year=x.Year,               
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
                        data.Description= model.Description;
                        data.TeachingMethods= model.TeachingMethods;
                        data.TeachingDate = model.TeachingDate;
                        data.ExpectedOutcome = model.ExpectedOutcome;
                        _dbContext.Entry(data).State = EntityState.Modified;

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
                             TeachingMethods=model.TeachingMethods,
                             ExpectedOutcome = model.ExpectedOutcome,
                        };
                        await _dbContext.LessonPlan.AddAsync(lessonPlan);

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
        #endregion
        #region Teaching Method
        public async Task<Result<TeachingMethodViewModel>> GetTeachingMethodById(int? id)
        {
            var data = await _dbContext.TeachingMethod.Where(x => x.Id == id && x.Status == true).Select(x => new TeachingMethodViewModel()
            {
                Id = x.Id,
                Name=x.Name,
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
                        _dbContext.Entry(data).State = EntityState.Modified;

                    }
                    else
                    {
                        var teachingMethod = new TeachingMethod()
                        {
                            Id=model.Id,
                            Name=model.Name,
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
        #endregion
    }

}
