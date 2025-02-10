using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SchoolManagementSystem.BusinessLayer.Interface;
using SchoolManagementSystem.BusinessLayer.Repository;
using SchoolManagementSystem.Data.Data;
using SchoolManagementSystem.Data.Model;

namespace SchoolManagementSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StudentController : Controller
    {
        private readonly IStudent _student=null;
        private readonly ApplicationDbContext _context=null;
        public StudentController(IStudent student,ApplicationDbContext context ) 
        {
            _context=context;
            _student=student;
        }
        public async Task<IActionResult> StudentList()
        {
            return View( await _student.GetAllStudentList());
        }
        public async Task<IActionResult> StudentDetail(int? id)
        {
            return View(await _student.GetStudentById(id));
        }
        public async Task<IActionResult>InsertStudent(int id = 0)
        {
            return View(await _student.GetStudentById(id));
        }
        [HttpPost]
        public async Task<IActionResult> InsertStudent(StudentViewModel model)
        {
            if(ModelState.IsValid) 
            {
                var result = await _student.InsertUpdateStudent(model);
                if (result == true) 
                {
                    TempData["Msg"] = "Student Inserted Successfully!!";
                    return RedirectToAction("StudentList");
                }
                else
                {
                    TempData["Msg"] = "Failed to insert the student";
                    return View(result);
                }
            }
            TempData["Msg"] = ("Failed");
            return View(model);
        }
        public async Task<IActionResult> DeleteStudent(int? id)
        {
            var delete=await _student.DeleteStudent(id);
            if(delete == true)
            {
                TempData["Msg"] = "Student Deleted Successfully";
                return RedirectToAction("StudentList");
            }
            else
            {
                TempData["Msg"] = "Student Deletion failed";
                return RedirectToAction("StudentList");
            }
        }
        public IActionResult PreviousSchoolDetails() => PartialView("", new PreviousSchoolDetailsViewModel());
       
    }
}
