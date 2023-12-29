using System.ComponentModel.DataAnnotations;

namespace SysManageCRUD.Models
{
    public class Patient
    {
        [Key]
        public int IdPatient { get; set; }

        [Required(ErrorMessage = "Patient name is required")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "field must be at least 6 characters")]
        public string PatientName { get; set; }

        [Required(ErrorMessage = "Patient lastname is required")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "field must be at least 6 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Patient age is required")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "field must be at least 6 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The IdCard field is required.")]
        [RegularExpression("^[0-9]{9}$", ErrorMessage = "The IdCard field must contain exactly 9 digits and only numeric characters.")]
        public string IdCard { get; set; }
        public virtual Patient patient { get; set;}

    }
}
