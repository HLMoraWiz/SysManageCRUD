using SysManageCRUD.Models;

namespace SysManageCRUD.Repository
{
    public interface ISpecialty
    {
        Specialty GetSpecialty(int id);
        List<Specialty> GetSpecialtyList();
        Specialty UpdateSpecialty(Specialty specialty);
        void DeleteSpecialty(int id);
        Specialty CreateSpecialty(Specialty specialty);

    }
}
