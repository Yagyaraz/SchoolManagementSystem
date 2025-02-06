using SchoolManagementSystem.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.BusinessLayer.Interface
{
    public interface IStudent
    {
        Task<List<StudentViewModel>> GetAllStudentList();
        Task<StudentViewModel> GetStudentById(int? id);
        Task<bool>InsertUpdateStudent(StudentViewModel model);
        Task<bool>DeleteStudent(int? id);

    }
}
