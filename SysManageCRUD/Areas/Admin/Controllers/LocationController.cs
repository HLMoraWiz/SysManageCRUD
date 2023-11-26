using Microsoft.AspNetCore.Mvc;
using SysManageCRUD.Repository;

namespace SysManageCRUD.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LocationController : Controller
    {
        private readonly ILocationRepository _repolocation;
        public LocationController(ILocationRepository locationRepository)
        {
            _repolocation = locationRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        #region
        [HttpGet]
        public IActionResult GetLocations()
        {
            return Json(new { data = _repolocation.GetLocations() });
        }
        #endregion




    }
}
