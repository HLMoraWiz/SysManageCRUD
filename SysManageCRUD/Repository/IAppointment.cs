using SysManageCRUD.Models;

namespace SysManageCRUD.Repository
{
    public interface IAppointment
    {
        Doctor GetAppointment(int id);
        List<Doctor> GetAppointment();
        Doctor CreateAppointment(Doctor doctor);
        Doctor UpdateAppointment(Doctor doctor);
        void DeleteAppointment(int id);
        
        //without relation
    }
}
