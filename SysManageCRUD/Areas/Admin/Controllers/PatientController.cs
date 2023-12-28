using Humanizer.Localisation.TimeToClockNotation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SysManageCRUD.Models;
using SysManageCRUD.Repository;
using XAct.Security;

namespace SysManageCRUD.Areas.Admin.Controllers
{
    [Authorize]
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
        public IActionResult Create([Bind("IdPatient,PatientName,LastName,Age,Description")]Patient patient)
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
                return NotFound(); 
            }

            if (ModelState.IsValid) { 
            
              _repoPatient.UpdatePatient(patient);
              return RedirectToAction(nameof(Index));
            }

            return View(patient);
        }


        [HttpDelete]

        public IActionResult Delete(int? id) {

            if (id==null)
            {
                return NotFound();
            }
            else
            {
                _repoPatient.DeletePatient(id.GetValueOrDefault());
                return Json(new {success = true, message= "Patient has been deleted correctly" });
            }

        
        }


    }
}
