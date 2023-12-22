using Microsoft.AspNetCore.Mvc;
using SysManageCRUD.Models;
using SysManageCRUD.Repository;

namespace SysManageCRUD.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AppointmentController : Controller
    {
        private readonly IAppointmentRepository _repoAppointment; 
        private readonly IDoctorRepository _repoDoctor; 
        private readonly IPatientRepository _repoPatient; 
        private readonly ILocationRepository _repoLocation; 


        public AppointmentController(IAppointmentRepository appointmentRepository,IDoctorRepository doctorRepository,IPatientRepository patientRepository,ILocationRepository locationRepository)
        {
                _repoAppointment = appointmentRepository;
                _repoDoctor = doctorRepository;
                _repoPatient = patientRepository;
                _repoLocation = locationRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        #region
        [HttpGet]
        public IActionResult GetAppointments()
        {
            return Json(new { data = _repoAppointment.GetAppointment()}); 
      
        }
        #endregion

        [HttpGet]
        public IActionResult Create() //to Show
        {
            ViewBag.SelectListLocation = _repoLocation.GetSelectListLocation();
            ViewBag.SelectListDoctor = _repoDoctor.GetSelectListDoctor(); 
            ViewBag.SelectListPatient = _repoPatient.GetSelectListPatient(); 
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("IdAppointment", "Date", "IdDoctor,IdPatient,IdLocation")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                if (appointment.IdAppointment == 0)
                {
                    _repoAppointment.CreateAppointment(appointment);
                    return RedirectToAction(nameof(Index));
                }

                return RedirectToAction(nameof(Create));
            }

            return View(appointment);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var appointment = _repoAppointment.GetAppointment(id.GetValueOrDefault());
            if (appointment == null)
            {
                return NotFound();
            }
            ViewBag.SelectListLocation = _repoLocation.GetSelectListLocation();
            ViewBag.SelectListDoctor = _repoDoctor.GetSelectListDoctor();
            ViewBag.SelectListPatient = _repoPatient.GetSelectListPatient();

            return View(appointment);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("IdAppointment", "Date", "IdDoctor,IdPatient,IdLocation")] Appointment appointment, int id)
        {
            if (id != appointment.IdAppointment)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _repoAppointment.UpdateAppointment(appointment);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Edit));
        }


        [HttpDelete]
        public IActionResult Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            else
            {
                _repoAppointment.DeleteAppointment(id.GetValueOrDefault());
                return Json(new { success = true, message = "Appointment deleted correctly" });

            }


        }

    }
}
