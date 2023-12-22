using Microsoft.AspNetCore.Mvc;
using SysManageCRUD.Repository;

namespace SysManageCRUD.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AppointmentController : Controller
    {
        private readonly IAppointmentRepository _repoAppointment; 

        public AppointmentController(IAppointmentRepository appointmentRepository)
        {
                _repoAppointment = appointmentRepository;
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

    }
}
