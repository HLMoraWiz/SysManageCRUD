using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SysManageCRUD.Models;
using SysManageCRUD.Repository;
using XAct.Security;

namespace SysManageCRUD.Areas.Admin.Controllers
{
    [Authorize]
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

        [HttpGet]
        public IActionResult Edit(int?id) {

            if (id==null)
            {
               return NotFound(); 
            }
           var specialty = _repoSpecialty.GetSpecialty(id.GetValueOrDefault());
            if (specialty==null)
            {
                return NotFound(); 
            }
            return View(specialty);
        }

        [HttpPost]
        public IActionResult Edit([Bind("IdSpecialty,SpecialtyName")] Specialty specialty, int id)
        {

            if (id!=specialty.IdSpecialty)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _repoSpecialty.UpdateSpecialty(specialty);
                return RedirectToAction("Index");
            }

            return View(specialty);
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }
            else
            {
                _repoSpecialty.DeleteSpecialty(id.GetValueOrDefault());
                return Json(new { success = true, message = "Specialty has been deleted correctly" });
            }

        }

    }
}
