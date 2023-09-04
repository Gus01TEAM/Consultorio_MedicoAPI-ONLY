using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Medico.BL.DTOs.AppointmentDTO
{
    public class AppointmentInputDTO
    {
        [Key]
        public int AppointmentId { get; set; }
        [ForeignKey("Users")]
        public int UserId { get; set; }

        [ForeignKey("Specialties")]
        public int SpecialtieId { get; set; }
        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public string Appointment_Name { get; set; }
        public string Reason { get; set; }
        public DateTime Appointment_date { get; set; }
        public decimal Appointment_Hour { get; set; }
        public bool? Shift { get; set; }
        public byte Status { get; set; }
    }
}

