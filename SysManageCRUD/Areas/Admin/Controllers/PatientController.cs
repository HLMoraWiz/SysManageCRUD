using Microsoft.AspNetCore.Mvc;
using SysManageCRUD.Models;
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
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        #region
        [HttpGet]
        public IActionResult GetPatients()
        {
            return Json(new {data = _repoPatient.GetPatients()});
        }
        #endregion


        [HttpGet]
        public IActionResult Create()
        {

           return View();    
        }

        [HttpPost]
        public IActionResult Create([Bind("IdPatient,Name,LastName,Age,Description")]Patient patient)
        {
            if (ModelState.IsValid)
            {

                _repoPatient.CreatePatient(patient);
                return RedirectToAction(nameof(Index)); 

            }

            return View(patient);
        }

    }
}
