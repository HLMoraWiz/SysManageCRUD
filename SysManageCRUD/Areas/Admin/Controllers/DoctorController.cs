using Microsoft.AspNetCore.Mvc;
using SysManageCRUD.Models;
using SysManageCRUD.Repository;

namespace SysManageCRUD.Areas.Admin.Controllers
{
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
            return Json(new { data = _RepoDoctor.GetSpecialtyDoctor()});
        }
        #endregion
        [HttpGet]
        public IActionResult Create() {
            ViewBag.SelectList = _RepoSpecialty.GetSelectListSpecialty();
            return View();
          
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
       public ActionResult Create([Bind("IdDoctor","Name","IdSpecialty")]Doctor doctor)
        {
            if (!ModelState.IsValid)
            {
                if (doctor.IdDoctor==0)
                {
                    _RepoDoctor.CreateDoctor(doctor);
                    return RedirectToAction(nameof(Index));
                }
              
            }
            ViewBag.SelectList = _RepoSpecialty.GetSelectListSpecialty();
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
        
    }
}
