using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Data.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public string CitizenshipNo { get; set; }
        public string MobileNo { get; set; }
        public int? DepartmentId { get; set; }
        public int? PostId { get; set; }
        public int? EmpId { get; set; }
        public string Address { get; set; }
        public string PISCode { get; set; }
        public string PersonalEmail { get; set; }
        public string NiyuktiMiti { get; set; }
        public int WardId { get; set; }
        public DateTime? NiyuktiMitiEng { get; set; }

        public DateTime? DiactivateDate { get; set; }

    }
}
