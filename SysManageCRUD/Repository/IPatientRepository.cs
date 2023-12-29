using Microsoft.AspNetCore.Mvc.Rendering;
using SysManageCRUD.Models;

namespace SysManageCRUD.Repository
{
    public interface IPatientRepository
    {
        Patient GetPatient(int id);

        List<Patient> GetPatients();

        Patient CreatePatient(Patient patient); 

        Patient UpdatePatient(Patient patient);

        void DeletePatient(int id);

        bool PatientExists(string IdCard);

        IEnumerable<SelectListItem> GetSelectListPatient();
    }
}
