using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Data.Data
{
    public class FiscalYear
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Name_En { get; set; }
        public string Code { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public bool IsActive { get; set; }
        public string DateFrom { get; set; }
        public DateTime DateFromEng { get; set; }
        public string DateTo { get; set; }
        public DateTime DateToEng { get; set; }
        public int? PreviousFiscalYearId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
    public class States
    {
        [Key]
        public int StateId { get; set; }
        public string StateName { get; set; }
        [Required]
        public string StateNameNep { get; set; }
        public string StateCode { get; set; }
    }
    public class District
    {
        [Key]
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
        [Required]
        public int StateId { get; set; }
        [Required]
        public string DistrictNameNep { get; set; }
        public string DistrictCode { get; set; }

        [ForeignKey("StateId")]
        public States State { get; set; }
    }
    public class Palika
    {
        [Key]
        public int PalikaId { get; set; }
        [Required]
        public int DistrictId { get; set; }
        public string PalikaName { get; set; }
        [Required]
        public string PalikaNameNep { get; set; }
        public string PalikaCode { get; set; }

        [ForeignKey("DistrictId")]
        public District District { get; set; }
    }
    public class Ward
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Name_En { get; set; }
        public string Code { get; set; }
        public bool? Status { get; set; }
        public string Address { get; set; }
        public string Address_En { get; set; }
        public string WardAdhyakshya { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

    }
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Copyright { get; set; }

    }
}
