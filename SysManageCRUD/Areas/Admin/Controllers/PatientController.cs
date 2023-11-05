using Humanizer.Localisation.TimeToClockNotation;
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


        [HttpGet]

        public IActionResult Edit(int?id)
        {
            if (id==null)
            {
                return NotFound();
            }
           
            var patient =   _repoPatient.GetPatient(id.GetValueOrDefault());
            if (patient==null)
            {
                return NotFound();
            }

            return View(patient);  
        }

        [HttpPost]

        public IActionResult Edit([Bind("IdPatient,Name,LastName,Age,Description")]Patient patient, int id)
        {
            if (id!= patient.IdPatient)
            {
                return NotFound(); 
            }

            if (ModelState.IsValid) { 
            
              _repoPatient.UpdatePatient(patient);
              return RedirectToAction(nameof(Index));
            }

            return View(patient);
        }

    }
}
