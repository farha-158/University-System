using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using SysUniPro.Factory;
using SysUniPro.Models;
using SysUniPro.Repostory;

namespace SysUniPro.Controllers
{
    public class FacultyController : Controller
    {
        //private readonly IFacultyRepostory _facultyRepostory;
        private readonly IRepository<Faculty> _facultyRepostory;
        


        public FacultyController(RepositoryFactory factory)
        {
            _facultyRepostory = factory.CreateRepository<Faculty>();
       
        }
        //public FacultyController (IFacultyRepostory facultyRepostory)
        //{
        //    _facultyRepostory = facultyRepostory;
        //}

        [HttpGet]
        public ActionResult Index()
        {
            var faculties = _facultyRepostory.GetAll();
            return View(faculties);
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Faculty faculty)
        {
            
            _facultyRepostory.Add(faculty);
            var faculties = _facultyRepostory.GetAll();
            return View("Index", faculties);

        }
        public ActionResult Delete(int id) {
            _facultyRepostory.Delete(id);
            var faculties = _facultyRepostory.GetAll();
            return View("Index", faculties);
        }

    }
}
