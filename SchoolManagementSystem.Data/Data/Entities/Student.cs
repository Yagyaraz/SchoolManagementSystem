using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Data.Data.Entities
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string StudentUniqueId { get; set; }
        public string StudentName { get; set; }
        public string StudentName_Nep { get; set; }
        public int Gender { get; set; }
        public DateTime DOB_AD { get; set; }
        public string DOB_BS { get; set; }
        public int? BloodGroup { get; set; }
        public string StudentImage { get; set; }

        public string PhoneNumber { get; set; }
        public int? Nationality { get; set; }
        public bool? Status { get; set; }
        public string AdmittedBy { get; set; }
        public Nullable<System.DateTime> AdmittedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }

    }
    public class Student_AccountInfo
    {
        [Key]
        public int Id { get; set; }
        public string LastInsertedId { get; set; }
        public string StudentIDUnique { get; set; }
        public string StudentPreviousCode { get; set; }
        public string StudentEmail { get; set; }
        public int BusRoute { get; set; }
        public int BusStop { get; set; }
        public int BusRouteEvening { get; set; }
        public int BusStopEvening { get; set; }
        [ForeignKey("Student")]
        public int StudentId { get; set; }

    }


    public class Student_Address
    {
        [Key]
        public int Id { get; set; }
        public int? PermanentProvince { get; set; }
        public int? PermanentDistrict { get; set; }
        public int? PermanentMunicipality { get; set; }
        public string PermanentAddress { get; set; }
        public int? CurrentProvince { get; set; }
        public int? CurrentDistrict { get; set; }
        public int? CurrentMunicipality { get; set; }
        public string CurrentAddress { get; set; }
        [ForeignKey("Student")]
        public int StudentId { get; set; }
    }
    public class Student_AcademicInfo
    {
        [Key]
        public int Id { get; set; }
        public int Class { get; set; }
        public int Section { get; set; }
        public int AdmittedYear { get; set; }
        public string ClassRollNo { get; set; }
        public string SymbolNumber { get; set; }
        public string Team { get; set; }
        public bool? Coaching { get; set; }
        public int? TransportationMode { get; set; }
        public bool? TeaBreakfast { get; set; }
        public bool? LunchSnacks { get; set; }
        public bool? Vegetarian { get; set; }
        public int? EnrollmentType { get; set; }
        public string IEMISNumber { get; set; }
        [ForeignKey("Student")]
        public int StudentId { get; set; }
    }
    public class Student_ParentsDetails
    {
        [Key]
        public int Id { get; set; }
        public string FatherName { get; set; }
        public string FatherImage { get; set; }
        public string FatherOccupation { get; set; }
        public string FatherCell { get; set; }
        public string FatherEmail { get; set; }
        public string MotherName { get; set; }
        public string MotherImage { get; set; }
        public string MotherOccupation { get; set; }
        public string MotherCell { get; set; }
        public string MotherEmail { get; set; }
        public string GuardianName { get; set; }
        public string GuardianRelation { get; set; }
        public string GuardianImage { get; set; }
        public string GuardianCell { get; set; }
        [ForeignKey("Student")]
        public int StudentId { get; set; }
    }
    public class Student_OtherDetails
    {
        [Key]
        public int Id { get; set; }
        public string Religion { get; set; }
        public string Ethnicity { get; set; }
        public string Citizenship { get; set; }
        public string DifferentlyAbled { get; set; }
        public string UserCode { get; set; }
        [ForeignKey("Student")]
        public int StudentId { get; set; }
    }
    public class PreviousSchoolDetails
    {
        [Key]
        public int Id { get; set; }
        public string PreviousSchoolName { get; set; }
        public string PreviousSchoolLevel { get; set; }
        public string PreviousSchoolUniversity { get; set; }
        public string PreviousSchoolType { get; set; }
        public string PreviousSchoolSymbolNumber { get; set; }
        public string PreviousSchoolRegistrationNumber { get; set; }
        public string PreviousSchoolPassedYear { get; set; }
        public string PreviousSchoolPercentage { get; set; }
        [ForeignKey("Student")]
        public int StudentId { get; set; }
    }
}
