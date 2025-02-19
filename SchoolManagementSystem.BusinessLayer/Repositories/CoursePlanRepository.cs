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
    public class CoursePlanRepository : ICoursePlan
    {
        private readonly ApplicationDbContext _dbContext;

        public CoursePlanRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Chapter
        public Task<Result<ChapterViewModel>> GetChapterById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<ChapterViewModel>> GetChapterList()
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> InertUpdateChapter(ChapterViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> DeleteChapter(int? id)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Course Plan
        public Task<Result<CoursePlanViewModel>> GetCoursePlanById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<CoursePlanViewModel>> GetCoursePlanList()
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> InertUpdateCoursePlan(CoursePlanViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> DeleteCoursePlan(int? id)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Lesson Plan
        public Task<Result<LessonPlanViewModel>> GetLessonPlanById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<LessonPlanViewModel>> GetLessonPlanList()
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> InertUpdateLessonPlan(LessonPlanViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> DeleteLessonPlan(int? id)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Teaaching Method
        public Task<Result<TeachingMethodViewModel>> GetTeachingMethodById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<TeachingMethodViewModel>> GetTeachingMethodList()
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> InertUpdateTeachingMethod(TeachingMethodViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> DeleteTeachingMethod(int? id)
        {
            throw new NotImplementedException();
        }
        #endregion
    }

}
