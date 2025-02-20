using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Data.Data.Entities
{
    public class CoursePlan
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public int Subject { get; set; }
        public int Class { get; set; }
        public DateTime? TeachingDate { get; set; }
        public int? TeachingDuration { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public List<TeachingMaterial> TeachingMaterials { get; set; }
        public List<CourseFile> CourseFiles { get; set; }
        public string Credits { get; set; }
        public string ExpectedOutcome { get; set; }
        public bool Status { get; set; }
    }

    public class TeachingMaterial
    {
        [Key]
        public int Id { get; set; }
        public int CoursePlanId { get; set; }
        public string Link { get; set; }
        public CoursePlan CoursePlan { get; set; }
    }

    public class CourseFile
    {
        [Key]
        public int Id { get; set; }
        public int CoursePlanId { get; set; }
        public string Caption { get; set; }
        public string FilePath { get; set; }
        public CoursePlan CoursePlan { get; set; }
    }
    public class LessonPlan
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? TeachingDate { get; set; }
        public int? TeachingDuration { get; set; }
        public string Description { get; set; }
        public int Class { get; set; }
        public int Section { get; set; }
        public int Subject { get; set; }
        public int Chapter { get; set; }
        public int Year { get; set; }
        public List<TeachingMaterial> TeachingMaterials { get; set; }
        public List<CourseFile> CourseFiles { get; set; }
        public string TeachingMethods { get; set; }
        public string ExpectedOutcome { get; set; }
        public bool Status { get; set; }

    }

    public class LessonPlanTeachingMaterial
    {
        [Key]
        public int Id { get; set; }
        public int LessonPlanId { get; set; }
        public string Link { get; set; }
    }

    public class LessonPlanCourseFile
    {
        [Key]
        public int Id { get; set; }
        public int LessonPlanId { get; set; }
        public string Caption { get; set; }
        public string FilePath { get; set; }

    }
    public class Chapter
    {
        [Key]
        public int Id { get; set; }
        public string ChapterTitle { get; set; }
        public int Subject { get; set; }
        public int Class { get; set; }
        public int? LearningHours { get; set; }
        public bool Status { get; set; }

    }
    public class TeachingMethod
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }

    }

}
