using System.ComponentModel.DataAnnotations;

namespace SysManageCRUD.Models
{
    public class Doctor
    {
        [Key]
        public int IdDoctor { get; set; }
     
        public string DoctorName { get; set; }
    
        public int SpecialtyId { get; set; }
        public virtual Specialty Specialty { get; set; }

        public virtual Appointment Appointment { get; set; }
    }
}
