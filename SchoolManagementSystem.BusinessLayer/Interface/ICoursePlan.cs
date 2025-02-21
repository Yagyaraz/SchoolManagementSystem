using SchoolManagementSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.BusinessLayer.Interface
{
    public interface ICoursePlan
    {
        #region Course Plan
        public Task<Result<List<CoursePlanViewModel>>> GetCoursePlanList();
        public Task<Result<CoursePlanViewModel>> GetCoursePlanById(int? id);
        public Task<Result<bool>> InsertUpdateCoursePlan(CoursePlanViewModel model);
        public Task<Result<bool>> DeleteCoursePlan(int? id);
        #endregion
    }
    public interface ILessonPlan
    {
        #region Lesson Plan
        public Task<Result<List<LessonPlanViewModel>>> GetLessonPlanList();
        public Task<Result<LessonPlanViewModel>> GetLessonPlanById(int? id);
        public Task<Result<bool>> InsertUpdateLessonPlan(LessonPlanViewModel model);
        public Task<Result<bool>> DeleteLessonPlan(int? id);
        #endregion

    }
    public interface ITeachingMethod
    {
        #region Teaching Method
        public Task<Result<List<TeachingMethodViewModel>>> GetTeachingMethodList();
        public Task<Result<TeachingMethodViewModel>> GetTeachingMethodById(int? id);
        public Task<Result<bool>> InsertUpdateTeachingMethod(TeachingMethodViewModel model);
        public Task<Result<bool>> DeleteTeachingMethod(int? id);
        #endregion

    }
    public interface IChapter
    {
        #region Chapter
        public Task<Result<List<ChapterViewModel>>> GetChapterList();
        public Task<Result<ChapterViewModel>> GetChapterById(int? id);
        public Task<Result<bool>> InsertUpdateChapter(ChapterViewModel model);
        public Task<Result<bool>> DeleteChapter(int? id);
        #endregion
    }

}
