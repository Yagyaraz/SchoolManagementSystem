﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Data.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
        #region Required Initial Data
        public DbSet<States> State { get; set; }
        public DbSet<District> District { get; set; }
        public DbSet<Palika> Palika { get; set; }
        public DbSet<Ward> Ward { get; set; }
        public DbSet<FiscalYear> FiscalYear { get; set; }
        public DbSet<Project> Project { get; set; }
        #endregion
        #region Student Database
        public DbSet<Student> Student { get; set; }
        public DbSet<Student_AccountInfo> StudentAccountInfo { get; set; }
        public DbSet<Student_Address> StudentAddress { get; set; }
        public DbSet<Student_AcademicInfo> StudentAcademicInfo { get; set; }
        public DbSet<Student_ParentsDetails> StudentParentsDetails { get; set; }
        public DbSet<Student_OtherDetails> StudentOtherDetails { get; set; }
        public DbSet<PreviousSchoolDetails> PreviousSchoolDetails { get; set; }
        #endregion
        #region Setup
        public DbSet<BusRoute> BusRoute {  get; set; }
        public DbSet<RouteMap> RouteMap {  get; set; }
        public DbSet<LocationDetails> LocationDetail {  get; set; }
        public DbSet<Home> Home {  get; set; }
        public DbSet<About> About {  get; set; }
        public DbSet<Subject> Subject {  get; set; }
        public DbSet<Section> Section {  get; set; }
        public DbSet<Program> Program {  get; set; }
        public DbSet<TeamCategory> TeamCategory {  get; set; }
        public DbSet<AssignmentCategory> AssignmentCategory {  get; set; }
        public DbSet<StudentGroup> StudentGroup {  get; set; }
        public DbSet<GroupClassAssociation> GroupClassAssociation {  get; set; }
        public DbSet<BankDetails> BankDetail {  get; set; }
        public DbSet<Class>Classe { get; set; }
        #endregion
        #region Employee
        public DbSet<Employee> Employee {  get; set; }
        #endregion
        #region Course Plan
        public DbSet<CoursePlan> CoursePlan { get; set; }
        public DbSet<TeachingMaterial> TeachingMaterial { get; set; }
        public DbSet<CourseFile> CourseFile { get; set; }
        public DbSet<LessonPlan> LessonPlan { get; set; }
        public DbSet<LessonPlanTeachingMaterial> LessonPlanTeachingMaterial { get; set; }
        public DbSet<LessonPlanCourseFile> LessonPlanCourseFile { get; set; }
        public DbSet<Chapter> Chapter { get; set; }
        public DbSet<TeachingMethod> TeachingMethod { get; set; }
        #endregion
        #region Library
        public DbSet<Book> Book { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<BookType> BookType { get; set; }
        public DbSet<Rack> Rack { get; set; }
        public DbSet<BookIssue> BookIssue { get; set; }
        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<Keyword> Keyword { get; set; }
        public DbSet<Author> Author { get; set; }
        #endregion

    }
}
