using SchoolManagementSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.BusinessLayer.Interface
{
    public  interface IEmployee
    {
        Task<List<EmployeeViewModel>> GetAllEmployeeList();
        Task<EmployeeViewModel> GetEmployeeById(int? id);
        Task<bool> InsertUpdateEmployee(EmployeeViewModel model);
        Task<bool> DeleteEmplyee(int? id);
    }
}
