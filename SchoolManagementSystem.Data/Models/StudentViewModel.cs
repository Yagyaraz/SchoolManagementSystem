﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Data.Model
{
    public class StudentViewModel
    {
       public StudentViewModel()
        {
            PreviousSchoolDetailsList = new List<PreviousSchoolDetailsViewModel>();
        }
        public int StudentId { get; set; }
        [Required]
        public string StudentName { get; set; }
        [Required]
        public string StudentName_Nep { get; set; }
        public int Gender { get; set; }
        public DateTime? DOB_AD { get; set; }
        public string DOB_BS { get; set; }
        public int? BloodGroup { get; set; }
        public string StudentImage { get; set; }
        public string LastInsertedId { get; set; }
        public string StudentIDUnique { get; set; }
        public string StudentPreviousCode { get; set; }
        public string StudentEmail { get; set; }
        public int BusRoute { get; set; }
        public int BusStop { get; set; }
        public int BusRouteEvening { get; set; }
        public int BusStopEvening { get; set; }          
        public string PhoneNumber { get; set; }
        public int? Nationality { get; set; }
        public bool? Status { get; set; }
        public int? PermanentProvince { get; set; }
        public int? PermanentDistrict { get; set; }
        public int? PermanentMunicipality { get; set; }
        public string PermanentAddress { get; set; }
        public int? CurrentProvince { get; set; }
        public int? CurrentDistrict { get; set; }
        public int? CurrentMunicipality { get; set; }
        public string CurrentAddress { get; set; }       
        public int Class { get; set; }
        public int Section { get; set; }
        public string LastInsertedRollNo { get; set; }
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

        public string Religion { get; set; }
        public string Ethnicity { get; set; }
        public string Citizenship { get; set; }
        public string DifferentlyAbled { get; set; }
        public string UserCode { get; set; }
        public string AdmittedBy { get; set; }
        public Nullable<System.DateTime> AdmittedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }

       public  List<PreviousSchoolDetailsViewModel> PreviousSchoolDetailsList { get; set; }=new List< PreviousSchoolDetailsViewModel>();
    }
    public class PreviousSchoolDetailsViewModel
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string PreviousSchoolName { get; set; }
        public string PreviousSchoolLevel { get; set; }
        public string PreviousSchoolUniversity { get; set; }
        public string PreviousSchoolType { get; set; }
        public string PreviousSchoolSymbolNumber { get; set; }
        public string PreviousSchoolRegistrationNumber { get; set; }
        public string PreviousSchoolPassedYear { get; set; }
        public string PreviousSchoolPercentage { get; set; }   
    }
}
