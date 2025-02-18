using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SchoolManagementSystem.Data.Data.Entities
{
    public class BusRoute
    {
        [Key]
        public int Id { get; set; }
        public string DriverName { get; set; }
        public string BusNo { get; set; }
        public string AssistantName { get; set; }
        public string AssistantPhone { get; set; }
        public int? Teacher { get; set; }
        public bool? Status { get; set; }
    }
    public class RouteMap
    {
        [Key]
        public int Id { get; set; }
        public string BusRouteId { get; set; }
        public string GPSDevice { get; set; }
        public string GPSDeviceId { get; set; }
        public bool? Status { get; set; }

    }
    public class LocationDetails
    {
        [Key]
        public int Id { get; set; }
        public string LocationName { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string PickupTime { get; set; }
        public string DropTime { get; set; }
        public string Fee { get; set; }
        public bool? Status { get; set; }
    }
    public class Home
    {
        [Key]
        public int Id { get; set; }
        public string LogoPath { get; set; }
        public string ImageForResult { get; set; }
        public string Website { get; set; }
        public bool? Status { get; set; }
        public string Name { get; set; }
        public string Slogan { get; set; }
    }
    public class About
    {
        [Key]
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public string Name { get; set; }
        public string Introduction { get; set; }
        public string VisionStatement { get; set; }
        public string PrincipalName { get; set; }
        public string PrincipalImage { get; set; }
        public string PrincipalSignature { get; set; }
        public string PrincipalMessage { get; set; }
        public string RulesRegulation { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string YouTube { get; set; }
        public string TikTok { get; set; }
        public string Location { get; set; }
        public bool? Status { get; set; }
    }
    public class Subject
    {
        [Key]
        public int Id { get; set; }
        public string SubjectName { get; set; }
        public string ShortCode { get; set; }
        public int TheoryCredit { get; set; }
        public int PracticalCredit { get; set; }
        public bool CalculateMarks { get; set; }
        public bool? Status { get; set; }
    }
    public class Class
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool? Status { get; set; }
    }
    public class Section
    {
        [Key]
        public int Id { get; set; }
        public string SectionName { get; set; }
        public bool? Status { get; set; }

    }
    public class Program
    {
        [Key]
        public int Id { get; set; }
        public string ProgramName { get; set; }
        public bool? Status { get; set; }

    }
    public class TeamCategory
    {
        [Key]
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public bool? Status { get; set; }
    }
    public class AssignmentCategory
    {
        [Key]
        public int Id { get; set; }
        public string AssignmentCategoryName { get; set; }
        public bool? Status { get; set; }

    }
    public class StudentGroup
    {
        [Key]
        public int Id { get; set; }
        public string GroupName { get; set; }
        public int YearId { get; set; }
        public bool? Status { get; set; }
    }
    public class GroupClassAssociation
    {
        [Key]
        public int Id { get; set; }
        public string Group { get; set; }
        public string Class { get; set; }
        public string Subject { get; set; }
        public string Year { get; set; }
        public bool? Status { get; set; }

    }
    public class BankDetails
    {
        [Key]
        public int Id { get; set; }
        public string BankName { get; set; }
        public string Branch { get; set; }
        public string AcccountNumber { get; set; }
        public string QRCode { get; set; }
        public bool? Status { get; set; }
    }

}

