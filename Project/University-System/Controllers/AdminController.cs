using Microsoft.AspNetCore.Mvc;
using SysUniPro.Factory;
using SysUniPro.Models;
using SysUniPro.Repostory;

namespace SysUniPro.Controllers
{
    public class AdminController : Controller
    {
        //private readonly IAdminRepostory _adminRepostory;
        private readonly IRepository<Admin> _adminRepository;

        public AdminController(RepositoryFactory factory)
        {
            _adminRepository = factory.CreateRepository<Admin>();
        }

        //public AdminController(IAdminRepostory adminRepostory) {
        //    _adminRepostory = adminRepostory;
        //}
        public ActionResult Index()
        {
            var admins = _adminRepository.GetAll();
            return View( admins);
        }
        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(Admin admin)
        {
            _adminRepository.Add(admin);
            var admins = _adminRepository.GetAll();
            return View("Index", admins);
        }

        public ViewResult Delete(int id)
        {
            _adminRepository.Delete(id);
            var admins = _adminRepository.GetAll();
            return View("Index", admins);
        }
    }
}
