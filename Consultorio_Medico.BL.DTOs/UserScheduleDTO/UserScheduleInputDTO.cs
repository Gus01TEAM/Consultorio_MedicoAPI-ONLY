using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Medico.BL.DTOs.UserSchedule
{
    public class UserScheduleInputDTO
    {
        public int UserScheduleId { get; set; }
        public int UserId { get; set; }
        public int SchedulesId { get; set; }
        public int SpecialtieId { get; set; }
        public decimal NumberHoursFree { get; set; }
        public decimal NumberHoursUsed { get; set; }   
    
    }
}
