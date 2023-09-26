using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Medico.BL.DTOs.AppointmentDTO
{
    public class AppointmentSearchOutputDTO
    {
        [Key]
        public int AppointmentId { get; set; }
        [ForeignKey("UsersSchedules")]
        public int UserSchedulesId { get; set; }
        public string UserName { get; set; }
        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string Reason { get; set; }
        public DateTime Appointment_date { get; set; }
        public byte Status { get; set; }
        public int Cupos { get; set; }
    }
    public enum Appointment_Status
    {
        Done = 1,
        Inactive = 2,
        Pending = 3,
        Canceled = 4,
    }

    public enum Appointment_Shift
    {
        AM = 1,
        PM = 2,
    }
}
