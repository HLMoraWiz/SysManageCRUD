using Microsoft.AspNetCore.Mvc;
using SysManageCRUD.Repository;

namespace SysManageCRUD.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PatientController : Controller
    {
        private readonly IPatientRepository _repoPatient;

        public PatientController(IPatientRepository patientRepository)
        {
            _repoPatient = patientRepository;       
        }

        public IActionResult Index()
        {
            return View();
        }
        #region
        public IActionResult GetPatients()
        {
            return Json(new {data = _repoPatient.GetPatients()});
        }
        #endregion


      
        public IActionResult Create()
        {

           return View();    
        }
    
    
    }
}
