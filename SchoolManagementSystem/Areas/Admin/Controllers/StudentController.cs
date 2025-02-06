using Microsoft.AspNetCore.Mvc;

namespace SchoolManagementSystem.Areas.Admin.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
