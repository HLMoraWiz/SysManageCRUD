using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using SysManageCRUD.Models;
using SysManageCRUD.Repository;
using XAct.Security;

namespace SysManageCRUD.Areas.Admin.Controllers
{
    [Authorize]
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


        [HttpGet]
        public IActionResult Create()
        {
            return View(); 
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("IdLocation","HospitalName","Address")]LocationHpt location) {

            if (ModelState.IsValid)
            {
              _repolocation.CreateLocation(location);
              return RedirectToAction(nameof(Index));

            }

            return View(location); 

        }

        [HttpGet]   
        public IActionResult Edit(int?id)
        {
            if (id==null)
            {
                return NotFound(); 

            }

            var location = _repolocation.GetLocation(id.GetValueOrDefault());
            if (location==null)
            {
                return NotFound();
            }

            return View(location); 
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("IdLocation", "HospitalName","Address")]LocationHpt location,int id)
        {
            if (id!=location.IdLocation)
            {
                return NotFound(); 
            }

            if (ModelState.IsValid)
            {
                _repolocation.UpdateLocation(location);
                return RedirectToAction(nameof(Index)); 
            }

            return RedirectToAction(nameof(Edit));
        }

    }
}
