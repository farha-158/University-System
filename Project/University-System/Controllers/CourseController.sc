using Microsoft.AspNetCore.Mvc;
using SysUniPro.Context;
using SysUniPro.Factory;
using SysUniPro.Models;
using SysUniPro.Models.ViewModels;
using SysUniPro.Repostory;

namespace SysUniPro.Controllers
{
    public class CourseController : Controller
    {
        //private readonly ICourseRepostory _courseRepostory;
        //private readonly IDepartmentRepostory _repostory;
        private readonly IRepository<Course> _courseRepostory;
        private readonly IRepository<Department> _departmentRepository;


        public CourseController(RepositoryFactory factory)
        {
            _courseRepostory = factory.CreateRepository<Course>();
            _departmentRepository = factory.CreateRepository<Department>();


        }
        //public CourseController(ICourseRepostory courseRepostory, IDepartmentRepostory departmentRepostory ) {
        //    _courseRepostory= courseRepostory;
        //    _repostory = departmentRepostory;
            

        //}
        [HttpGet]
        public ActionResult Index()
        {
            var courses=_courseRepostory.GetAll();
            return View(courses);
        }
        [HttpGet]
        public ViewResult AddCourse()
        {
            var departments = _departmentRepository.GetAll();
            return View(departments);
        }

        
        [HttpPost]
        public IActionResult AddCourse(Course course)
        {
            _courseRepostory.Add(course);

            var courses = _courseRepostory.GetAll();

            return View("Index", courses);
        }


        public ViewResult Delete(int id)
        {
            _courseRepostory.Delete(id);
            var courses = _courseRepostory.GetAll();

            return View("Index",courses);
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using SysUniPro.Context;
using SysUniPro.Factory;
using SysUniPro.Models;
using SysUniPro.Models.ViewModels;
using SysUniPro.Repostory;

namespace SysUniPro.Controllers
{
    public class CourseController : Controller
    {
        //private readonly ICourseRepostory _courseRepostory;
        //private readonly IDepartmentRepostory _repostory;
        private readonly IRepository<Course> _courseRepostory;
        private readonly IRepository<Department> _departmentRepository;


        public CourseController(RepositoryFactory factory)
        {
            _courseRepostory = factory.CreateRepository<Course>();
            _departmentRepository = factory.CreateRepository<Department>();


        }
        //public CourseController(ICourseRepostory courseRepostory, IDepartmentRepostory departmentRepostory ) {
        //    _courseRepostory= courseRepostory;
        //    _repostory = departmentRepostory;
            

        //}
        [HttpGet]
        public ActionResult Index()
        {
            var courses=_courseRepostory.GetAll();
            return View(courses);
        }
        [HttpGet]
        public ViewResult AddCourse()
        {
            var departments = _departmentRepository.GetAll();
            return View(departments);
        }

        
        [HttpPost]
        public IActionResult AddCourse(Course course)
        {
            _courseRepostory.Add(course);

            var courses = _courseRepostory.GetAll();

            return View("Index", courses);
        }


        public ViewResult Delete(int id)
        {
            _courseRepostory.Delete(id);
            var courses = _courseRepostory.GetAll();

            return View("Index",courses);
        }
    }
}
