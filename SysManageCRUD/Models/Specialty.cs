using System.ComponentModel.DataAnnotations;

namespace SysManageCRUD.Models
{ 
    public class Specialty
    {
        [Key]
        public int IdSpecialty { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "field must be at least 3 characters")]
        public string SpecialtyName { get; set; }
        public List<Doctor> Doctor { get; set;}

    }
}
