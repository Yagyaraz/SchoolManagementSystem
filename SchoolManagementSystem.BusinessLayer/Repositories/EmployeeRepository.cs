using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.BusinessLayer.Interface;
using SchoolManagementSystem.Data.Data;
using SchoolManagementSystem.Data.Data.Entities;
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


        public async Task<Result<List<EmployeeViewModel>>> GetAllEmployeeList()
        {
            var list = await _context.Employee.Select(x => new EmployeeViewModel()
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
            }).ToListAsync() ?? new List<EmployeeViewModel>();
            return Result<List<EmployeeViewModel>>.Success(list);
        }

        public async Task<Result<EmployeeViewModel>> GetEmployeeById(int? id)
        {
            var data = await _context.Employee.Where(x => x.Id == id && x.Status).Select(x => new EmployeeViewModel()
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
            }).FirstOrDefaultAsync() ?? new EmployeeViewModel();
            return Result<EmployeeViewModel>.Success(data);
        }
        public async Task<Result<bool>> InsertUpdateEmployee1(EmployeeViewModel model)
        {
            using (var trancastion = _context.Database.BeginTransaction())
            {
                try
                {
                    if (model.Id > 0)
                    {
                        var employee = await _context.Employee.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
                        if (employee == null)
                        {
                            return Result<bool>.Failure($"Employee not found with id : {model.Id}");
                        }
                        if (employee != null)
                        {
                            employee.Id = model.Id;
                            employee.Name = model.Name;
                            employee.Email = model.Email;
                            employee.NameNepali = model.NameNepali;
                            employee.Phone = model.Phone;
                            employee.Username = model.Username;
                            employee.OfficialEmail = model.OfficialEmail;
                            employee.ImagePath = model.ImagePath;
                            employee.Department = model.Department;
                            employee.Position = model.Position;
                            employee.Status = model.Status;
                            employee.SchoolJoinedDate = model.SchoolJoinedDate;
                            employee.StaffType = model.StaffType;
                            _context.Entry(employee).State = EntityState.Modified;
                        }
                        await _context.SaveChangesAsync();
                        await trancastion.CommitAsync();
                        return Result<bool>.Success(true);
                    }
                    else
                    {
                        var employee = new Employee()
                        {
                            Id = model.Id,
                            Name = model.Name,
                            Email = model.Email,
                            NameNepali = model.NameNepali,
                            Phone = model.Phone,
                            Username = model.Username,
                            OfficialEmail = model.OfficialEmail,
                            ImagePath = model.ImagePath,
                            Department = model.Department,
                            Position = model.Position,
                            Status = model.Status,
                            SchoolJoinedDate = model.SchoolJoinedDate,
                            StaffType = model.StaffType,
                        };
                        await _context.Employee.AddAsync(employee);
                    }
                    await _context.SaveChangesAsync();
                    await trancastion.CommitAsync();
                    return Result<bool>.Success(true);
                }
                catch (Exception ex)
                {
                    await trancastion.RollbackAsync();
                    return Result<bool>.Failure("Insert/Update failed!!");
                }
            }
        }
        public async Task<Result<bool>> InsertUpdateEmployee(EmployeeViewModel model)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    if (model.Id > 0)
                    {
                        var employee = await _context.Employee.FirstOrDefaultAsync(x => x.Id == model.Id);
                        if (employee == null)
                        {
                            return Result<bool>.Failure($"Employee not found with id : {model.Id}");
                        }

                        employee.Name = model.Name;
                        employee.Email = model.Email;
                        employee.NameNepali = model.NameNepali;
                        employee.Phone = model.Phone;
                        employee.Username = model.Username;
                        employee.OfficialEmail = model.OfficialEmail;
                        employee.ImagePath = model.ImagePath;
                        employee.Department = model.Department;
                        employee.Position = model.Position;
                        employee.Status = model.Status;
                        employee.SchoolJoinedDate = model.SchoolJoinedDate;
                        employee.StaffType = model.StaffType;

                        _context.Entry(employee).State = EntityState.Modified;
                    }
                    else
                    {
                        var newEmployee = new Employee()
                        {
                            Name = model.Name,
                            Email = model.Email,
                            NameNepali = model.NameNepali,
                            Phone = model.Phone,
                            Username = model.Username,
                            OfficialEmail = model.OfficialEmail,
                            ImagePath = model.ImagePath,
                            Department = model.Department,
                            Position = model.Position,
                            Status = model.Status,
                            SchoolJoinedDate = model.SchoolJoinedDate,
                            StaffType = model.StaffType,
                        };
                        await _context.Employee.AddAsync(newEmployee);
                    }

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return Result<bool>.Success(true);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return Result<bool>.Failure("Insert/Update failed!!");
                }
            }
        }

        public async Task<Result<bool>> DeleteEmplyee(int? id)
        {
            var employee = await _context.Employee.Where(x => x.Id == id).FirstOrDefaultAsync();
            try
            {
                if (employee != null)
                {
                    employee.Status = false;
                    _context.Entry(employee).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Result<bool>.Success(true);
                }
                else 
                {
                    return Result<bool>.Failure($"Employee can't found !!");
                }

            }
            catch (Exception ex)
            {
                return Result<bool>.Failure($"Failed to delete employee with id:{employee.Id}");
            }
        }
    }
}
