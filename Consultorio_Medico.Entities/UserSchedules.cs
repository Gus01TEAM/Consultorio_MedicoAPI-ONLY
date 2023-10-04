using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Medico.Entities
{
    public class UserSchedules
    {
        [Key]
        public int UserSchedulesId { get; set; }
        [ForeignKey("Users")]
        public int UserId { get; set; }
        [ForeignKey("Specialties")]
        public int SpecialtieId { get; set; }
        [ForeignKey("Schedules")]
        public int SchedulesId { get; set; }
        public decimal NumberHoursFree { get; set; }
        public decimal NumberHoursUsed { get; set; }
        public decimal Cupo { get; set; }

        public Users User { get; set; }

        public Schedules Schedules { get; set; }

        public Specialties Specialties { get; set; }
    }
}
