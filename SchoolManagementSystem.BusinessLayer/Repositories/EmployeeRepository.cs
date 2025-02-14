using SchoolManagementSystem.BusinessLayer.Interface;
using SchoolManagementSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.BusinessLayer.Repositories
{
    internal class EmployeeRepository : IEmployee
    {
        public Task<bool> DeleteEmplyee(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<List<EmployeeViewModel>> GetAllEmployeeList()
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeViewModel> GetEmployeeById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertUpdateEmployee(EmployeeViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
