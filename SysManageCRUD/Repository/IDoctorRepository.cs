using SysManageCRUD.Models;

namespace SysManageCRUD.Repository
{
    public interface IDoctorRepository
    {
        Doctor GetDoctor(int id);
        List<Doctor> GetDoctor();
        Doctor CreateDoctor(Doctor doctor);
        Doctor UpdateDoctor(Doctor doctor); 
        void DeleteDoctor(int id);
        List<Doctor> GetSpecialtyDoctor(); 


    }
}
