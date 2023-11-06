using Microsoft.AspNetCore.Mvc;
using SysManageCRUD.Repository;

namespace SysManageCRUD.Areas.Admin.Controllers
{
    public class SpecialtyController : Controller
    {
        private readonly ISpecialtyRepository _repoSpecialty;

        public SpecialtyController(ISpecialtyRepository repoSpecialty)
        {
                _repoSpecialty = repoSpecialty;
        }

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
    }
}
