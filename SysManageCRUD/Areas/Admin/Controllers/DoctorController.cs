using Microsoft.AspNetCore.Mvc;
using SysManageCRUD.Repository;

namespace SysManageCRUD.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DoctorController : Controller
    {
        private readonly IDoctorRepository _RepoDoctor;

        public DoctorController(IDoctorRepository doctorRepository)
        {
                _RepoDoctor = doctorRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        #region
        [HttpGet]
        public ActionResult GetDoctors()
        {
            return Json(new { data = _RepoDoctor.GetSpecialtyDoctor()});
        }
        #endregion

    }
}
