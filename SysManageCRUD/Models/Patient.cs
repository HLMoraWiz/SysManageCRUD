using System.ComponentModel.DataAnnotations;

namespace SysManageCRUD.Models
{
    public class Patient
    {
        [Key]
        public int IdPatient { get; set; }

        [Required(ErrorMessage = "Patient name is required")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "field must be at least 6 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Patient lastname is required")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "field must be at least 6 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Patient age is required")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "field must be at least 6 characters")]
        public string Description { get; set; }

    }
}
