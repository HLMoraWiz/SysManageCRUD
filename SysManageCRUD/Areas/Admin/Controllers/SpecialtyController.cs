using Microsoft.AspNetCore.Mvc;
using SysManageCRUD.Models;
using SysManageCRUD.Repository;

namespace SysManageCRUD.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SpecialtyController : Controller
    {
        private readonly ISpecialtyRepository _repoSpecialty;

        public SpecialtyController(ISpecialtyRepository repoSpecialty)
        {
                _repoSpecialty = repoSpecialty;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        #region
        public ActionResult GetSpecialtys()
        {
            return Json(new {data = _repoSpecialty.GetSpecialtyList()});
        }

        #endregion


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("IdSpecialty,SpecialtyName")] Specialty specialty) {

            if (ModelState.IsValid)
            {
                _repoSpecialty.CreateSpecialty(specialty);
                return RedirectToAction("Index");
            }
         
            return View(specialty);
        }




    }
}
