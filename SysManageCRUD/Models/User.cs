using System.ComponentModel.DataAnnotations;

namespace SysManageCRUD.Models
{
    public class User
    {
        [Key]
        public Guid User_ID { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} & maximum {1} characters.  ", MinimumLength = 5)]
        public string Login { get; set; }
        [Required(ErrorMessage = "This fiel is required")]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} & maximum {1} characters. ", MinimumLength = 6)]
        public string Password { get; set; }

    }
}
