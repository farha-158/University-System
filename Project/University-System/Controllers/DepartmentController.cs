using Microsoft.AspNetCore.Mvc;
using SysUniPro.Factory;
using SysUniPro.Models;
using SysUniPro.Repostory;

namespace SysUniPro.Controllers
{
    public class DepartmentController : Controller
    {
        //private readonly IDepartmentRepostory _repostory;
        
        private readonly IRepository<Department> _departmentRepository;


        public DepartmentController(RepositoryFactory factory)
        {
            
            _departmentRepository = factory.CreateRepository<Department>();


        }
        //public DepartmentController (IDepartmentRepostory repostory)
        //{
        //    _repostory = repostory;
        //}
        [HttpGet]
        public ActionResult Index()
        {

            var departments = _departmentRepository.GetAll();
           
            return View(departments);
        }
        [HttpGet]
        public ActionResult AddDepartment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddDepartment(Department department)
        {
            _departmentRepository.Add(department);
            var departments = _departmentRepository.GetAll();

            return View("Index", departments);
        }

        public ViewResult Delete(int id)
        {
            _departmentRepository.Delete(id);

            var departments = _departmentRepository.GetAll();

            return View("Index", departments);
        }

    }
}
