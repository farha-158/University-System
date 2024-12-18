using Microsoft.AspNetCore.Mvc;
using SysUniPro.Factory;
using SysUniPro.Models;
using SysUniPro.Models.ViewModels;
using SysUniPro.Repostory;


namespace SysUniPro.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepostory _studentRepostory;
        private readonly ICourseRepostory _courseRepostory;

        private readonly IRepository<Department> _departmentRepository;

        public StudentController(IStudentRepostory studentRepostory , ICourseRepostory courseRepostory , RepositoryFactory factory)
        {
            _studentRepostory = studentRepostory;
            _courseRepostory = courseRepostory;
            _departmentRepository = factory.CreateRepository<Department>();

        }


        [HttpGet]
        public ActionResult Index()
        {
            List<Student> stdlist = _studentRepostory.GetAllStudents();
            return View(stdlist);
        }
        [HttpGet]
        public ViewResult Create()
        {
            var departments = _departmentRepository.GetAll();
            return View(departments);
        }

        [HttpPost]
        public ActionResult Create(Student student) {

            _studentRepostory.Create(student);
            List<Student> stdlist = _studentRepostory.GetAllStudents();
            return View("Index",stdlist);
        }

        public ViewResult Delete(int id)
        {
            _studentRepostory.Delete(id);
            List<Student> stdlist = _studentRepostory.GetAllStudents();
            return View("Index", stdlist);
        }

        [HttpGet]
        public ActionResult Register() {
            StudentCoursevm studentCoursevm = new StudentCoursevm();
            studentCoursevm.courses = _courseRepostory.GetAllCourse();
            studentCoursevm.students= _studentRepostory.GetAllStudents();
            return View(studentCoursevm);
        }

        [HttpPost]
        public ActionResult Register(int ID ,int CourseId )
        {
            _studentRepostory.Register(ID, CourseId);
            return RedirectToAction("Index");
        }

    }
}
