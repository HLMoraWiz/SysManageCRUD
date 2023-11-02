using SysManageCRUD.Models;

namespace SysManageCRUD.Repository
{
    public interface IPatientRepository
    {
        Patient GetPatient(int id);

        List<Patient> GetPatients();

        Patient CreatePatient(Patient patient); 

        Patient UpdatePatient(Patient patient);

        Patient DeletePatient(int id);
    }
}
