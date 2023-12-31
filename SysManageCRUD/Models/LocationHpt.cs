﻿using System.ComponentModel.DataAnnotations;

namespace SysManageCRUD.Models
{
    public class LocationHpt
    {
        [Key]
        public int IdLocation { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "field must be at least 6 characters")]
        public string HospitalName { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "field must be at least 6 characters")]
        public string Address { get; set; }

        public virtual Appointment Appointment { get; set; }    
    }
}
