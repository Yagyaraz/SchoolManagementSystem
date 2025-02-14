using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Data.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameNepali { get; set; }
        public string Email { get; set; }
        public string OfficialEmail { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string ImagePath { get; set; }
        public int? Department { get; set; }
        public int? Position { get; set; }
        public int? StaffType { get; set; }
        public DateTime? SchoolJoinedDate { get; set; }
    }
}
