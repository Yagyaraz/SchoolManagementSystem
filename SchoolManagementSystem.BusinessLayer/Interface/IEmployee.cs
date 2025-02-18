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
        Task<Result<List<EmployeeViewModel>>> GetAllEmployeeList();
        Task<Result<EmployeeViewModel>> GetEmployeeById(int? id);
        Task<Result<bool>> InsertUpdateEmployee(EmployeeViewModel model);
        Task<Result<bool>> DeleteEmplyee(int? id);
    }
}
