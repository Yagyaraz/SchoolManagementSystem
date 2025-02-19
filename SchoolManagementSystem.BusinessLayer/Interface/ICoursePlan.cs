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
        public Task<Result<CoursePlanViewModel>> GetCoursePlanList();
        public Task<Result<CoursePlanViewModel>>GetCoursePlanById(int? id);
        public Task<Result<bool>> InertUpdateCoursePlan(CoursePlanViewModel model);
        public Task<Result<bool>> DeleteCoursePlan(int? id);
        #endregion
        #region Lesson Plan
        public Task<Result<LessonPlanViewModel>> GetLessonPlanList();
        public Task<Result<LessonPlanViewModel>> GetLessonPlanById(int? id);
        public Task<Result<bool>> InertUpdateLessonPlan(LessonPlanViewModel model);
        public Task<Result<bool>> DeleteLessonPlan(int? id);
        #endregion
        #region Teaching Method
        public Task<Result<ChapterViewModel>> GetChapterList();
        public Task<Result<ChapterViewModel>> GetChapterById(int? id);
        public Task<Result<bool>> InertUpdateChapter(ChapterViewModel model);
        public Task<Result<bool>> DeleteChapter(int? id);
        #endregion
        #region Chapter
        public Task<Result<TeachingMethodViewModel>> GetTeachingMethodList();
        public Task<Result<TeachingMethodViewModel>> GetTeachingMethodById(int? id);
        public Task<Result<bool>> InertUpdateTeachingMethod(TeachingMethodViewModel model);
        public Task<Result<bool>> DeleteTeachingMethod(int? id);
        #endregion
    }
}
