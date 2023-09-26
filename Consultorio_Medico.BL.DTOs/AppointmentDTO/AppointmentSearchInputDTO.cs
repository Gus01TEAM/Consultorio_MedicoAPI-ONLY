using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Medico.BL.DTOs.AppointmentDTO
{
    public class AppointmentSearchInputDTO
    {
        [Key]
        public int AppointmentId { get; set; }
        [ForeignKey("UsersSchedules")]
        public int UserSchedulesId { get; set; }
        public string UserName { get; set; }

        [ForeignKey("Specialties")]
        public int SpecialtieId { get; set; }
        public string SpecialtieName { get; set;}
        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string Appointment_Name { get; set; }
        public string Reason { get; set; }
        
        public byte Status { get; set; }
    }
}
