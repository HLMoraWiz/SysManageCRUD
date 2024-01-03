using System.ComponentModel.DataAnnotations;

namespace SysManageCRUD.Models
{
    public class Appointment
    {

        [Key]
        public int IdAppointment { get; set; }
        public DateTime Date { get; set; }
        public int IdPatient { get; set; }
        public int IdLocation { get; set; }
        public int IdDoctor { get; set; }

        public virtual LocationHpt Location { get; set; }

        public virtual Doctor Doctor { get; set; }  

        public virtual Patient Patient { get; set; }
    }
}
