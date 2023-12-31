﻿using Humanizer.Localisation.TimeToClockNotation;
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
        public IActionResult Create([Bind("IdPatient,PatientName,LastName,IdCard,Age,Description")]Patient patient)
        {
            if (ModelState.IsValid)
            {
                if (_repoPatient.PatientExists(patient.IdCard?.ToString()))
                {
                    ModelState.AddModelError("IdCard", "This patient already exists"); 
                    return View(patient);
                }

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
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("IdPatient,PatientName,LastName,IdCard,Age,Description")]Patient patient, int id)
        {

            if (id!=patient.IdPatient)
            {
                return NotFound(); 
            }
            if (string.IsNullOrWhiteSpace(patient.IdCard))
            {
                ModelState.AddModelError("IdCard", "This patient already exists");
                return View(patient);   
            }

            var existingPatient = _repoPatient.GetPatient(id);

            if (existingPatient.IdCard != patient.IdCard)
            {
                if (ModelState.IsValid)
                {
                    if (_repoPatient.PatientExists(patient.IdCard))
                    {

                        ModelState.AddModelError("IdCard", "This patient already exists.");
                        return View(patient);
                    }


                    _repoPatient.UpdatePatient(patient);
                    return RedirectToAction("Index");
                }

            }
            else
            {

                _repoPatient.UpdatePatient(patient);
                return RedirectToAction("Index");
            }


            return RedirectToAction(nameof(Index)); 
        }


        [HttpDelete]

        public IActionResult Delete(int? id) {

            if (id==null)
            {
                return NotFound();
            }
            else
            {
                if (_repoPatient.PatientyHasAppointment(id.GetValueOrDefault()))
                {
                    return Json(new { success = false, message = "Unable to delete. Patient is associated with one appointment" });
                }
                _repoPatient.DeletePatient(id.GetValueOrDefault());
                return Json(new {success = true, message= "Patient has been deleted correctly" });
            }

        
        }


    }
}
