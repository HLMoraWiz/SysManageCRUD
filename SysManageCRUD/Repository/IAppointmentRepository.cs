using SysManageCRUD.Models;

namespace SysManageCRUD.Repository
{
    public interface IAppointmentRepository
    {
        Appointment GetAppointment(int id);
        List<Appointment> GetAppointment();
        Appointment CreateAppointment(Appointment appointment);
        Appointment UpdateAppointment(Appointment appointment);
        void DeleteAppointment(int id);
        
        //without relation
    }
}
