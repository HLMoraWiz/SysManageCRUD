using System.ComponentModel.DataAnnotations;

namespace SysManageCRUD.Models
{
    public class Doctor
    {
        [Key]
        public int IdDoctor { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "field must be at least 3 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Doctor name is required")]
        public int IdSpecialty { get; set; }
        public virtual Specialty Specialty { get; set; } 
   
    }
}
