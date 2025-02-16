using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.BusinessLayer.Interface;
using SchoolManagementSystem.Data.Data;
using SchoolManagementSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.BusinessLayer.Repositories
{
    public class EmployeeRepository : IEmployee
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<List<EmployeeViewModel>> GetAllEmployeeList()
        {
            var list= await _context.Employee.Select(x=>new EmployeeViewModel()
            {
                Id = x.Id,
                Department=x.Department,
                Name=x.Name,
                NameNepali=x.NameNepali,
                Email=x.Email,
                OfficialEmail=x.OfficialEmail,
                Phone=x.Phone,
                Username=x.Username,
                ImagePath=x.ImagePath,
                SchoolJoinedDate=x.SchoolJoinedDate,
                StaffType=x.StaffType,
                Position=x.Position,
            }).ToListAsync()??new List<EmployeeViewModel>();
            return list;
        }

        public async Task<EmployeeViewModel> GetEmployeeById(int? id)
        {
            var data= await _context.Employee.Where(x=>x.Id==id && x.Status).Select(x=>new EmployeeViewModel()
            {
                Id = x.Id,
                Department = x.Department,
                Name = x.Name,
                NameNepali = x.NameNepali,
                Email = x.Email,
                OfficialEmail = x.OfficialEmail,
                Phone = x.Phone,
                Username = x.Username,
                ImagePath = x.ImagePath,
                SchoolJoinedDate = x.SchoolJoinedDate,
                StaffType = x.StaffType,
                Position = x.Position,
            }).FirstOrDefaultAsync()??new EmployeeViewModel();
            return data;
        }
        public Task<bool> InsertUpdateEmployee(EmployeeViewModel model)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteEmplyee(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
