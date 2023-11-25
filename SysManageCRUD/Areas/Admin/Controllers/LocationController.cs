using Microsoft.AspNetCore.Mvc;

namespace SysManageCRUD.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LocationController : Controller
    { 
        public IActionResult Index()
        {
            return View();
        }

    }
}
