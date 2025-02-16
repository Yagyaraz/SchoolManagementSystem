using SchoolManagementSystem.Data.Model;
using SchoolManagementSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.BusinessLayer.Interface
{
    public interface IStudent
    {
        Task<Result<List<StudentViewModel>>> GetAllStudentList();
        Task<Result<StudentViewModel>> GetStudentById(int? id);
        Task<Result<bool>>InsertUpdateStudent(StudentViewModel model);
        Task<Result<bool>>DeleteStudent(int? id);

    }
}
