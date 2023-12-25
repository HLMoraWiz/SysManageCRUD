using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SysManageCRUD.Models;
using SysManageCRUD.Repository;
using XAct.Security;

namespace SysManageCRUD.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class DoctorController : Controller
    {
        private readonly IDoctorRepository _RepoDoctor;
        private readonly ISpecialtyRepository _RepoSpecialty;

        public DoctorController(IDoctorRepository doctorRepository,ISpecialtyRepository specialtyRepository)
        {
                _RepoDoctor = doctorRepository;
                _RepoSpecialty = specialtyRepository;
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
            return Json(new { data = _RepoDoctor.GetSpecialtyDoctor()});///malo
        }
        #endregion
        [HttpGet]
        public IActionResult Create() {
            ViewBag.SelectList = _RepoSpecialty.GetSelectListSpecialty();
            return View();
          
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
       public ActionResult Create([Bind("IdDoctor", "DoctorName", "SpecialtyId")]Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                if (doctor.IdDoctor==0)
                {
                    _RepoDoctor.CreateDoctor(doctor);
                    return RedirectToAction(nameof(Index));
                }

                return RedirectToAction(nameof(Create));
            }
           
            return View(doctor);
       }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }
            var doctor = _RepoDoctor.GetDoctor(id.GetValueOrDefault());
            if (doctor ==null)
            {
                return NotFound(); 
            }
            ViewBag.SelectList = _RepoSpecialty.GetSelectListSpecialty();
            return View(doctor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("IdDoctor","Name", "SpecialtyId")] Doctor doctor, int id)
        {
            if (id!=doctor.IdDoctor)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _RepoDoctor.UpdateDoctor(doctor);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Edit));
        }

        [HttpDelete]
        public IActionResult Delete(int? id) {

            if (id==null)
            {
                return NotFound();
            }
            else
            {
                _RepoDoctor.DeleteDoctor(id.GetValueOrDefault());
                return Json(new {success = true,message="Doctor deleted correctly" });

            }
        
        
        }

    }
}
