﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Data.Models
{
    public class CoursePlanViewModel
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? TeachingDate { get; set; }
        public int? TeachingDuration { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public int Subject { get; set; }
        public int Class { get; set; }
        public List<TeachingMaterialViewModel> TeachingMaterialList { get; set; }
        public List<CourseFileViewModel> CourseFilesList { get; set; }
        public string Credits { get; set; }
        public string ExpectedOutcome { get; set; }
    }

    public class TeachingMaterialViewModel
    {

        public int Id { get; set; }
        public int CoursePlanId { get; set; }
        public string Link { get; set; }
    }

    public class CourseFileViewModel
    {

        public int Id { get; set; }
        public int CoursePlanId { get; set; }
        public string Caption { get; set; }
        public string FilePath { get; set; }
    }
    public class LessonPlanViewModel
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? TeachingDate { get; set; }
        public int? TeachingDuration { get; set; }
        public string Description { get; set; }
        public int Class { get; set; }
        public int Year { get; set; }
        public int Section { get; set; }
        public int Subject { get; set; }
        public int Chapter { get; set; }
        public bool Status { get; set; }
        public List<LessonPlanTeachingMaterialViewModel> TeachingMaterials { get; set; }
        public List<LessonPlanCourseFileViewModel> CourseFiles { get; set; }
        public string TeachingMethods { get; set; }
        public string ExpectedOutcome { get; set; }
    }

    public class LessonPlanTeachingMaterialViewModel
    {

        public int Id { get; set; }
        public int LessonPlanId { get; set; }
        public string Link { get; set; }
    }

    public class LessonPlanCourseFileViewModel
    {

        public int Id { get; set; }
        public int LessonPlanId { get; set; }
        public string Caption { get; set; }
        public string FilePath { get; set; }
    }
    public class ChapterViewModel
    {

        public int Id { get; set; }
        public string ChapterTitle { get; set; }
        public int Subject { get; set; }
        public int Class { get; set; }
        public int? LearningHours { get; set; }
    }
    public class TeachingMethodViewModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
    }
}
