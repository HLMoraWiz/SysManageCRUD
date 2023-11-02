using Microsoft.AspNetCore.Mvc;

namespace SysManageCRUD.Areas.Admin.Controllers
{
    public class PatientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
