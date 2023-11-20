using Consultorio_Medico.BL.DTOs.userDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Medico.BL.DTOs.UserSchedule
{
    public class UserScheduleInputDTO
    {
        public UserScheduleInputDTO()
        {

        }

        public UserScheduleInputDTO(UserScheduleSearchOutputDTO user)
        {
            UserScheduleId = user.UserSchedulesId;
            UserId = user.UserId;
            SchedulesId = user.SchedulesId;
            SpecialtieId = user.SpecialtieId;
            NumberHoursFree = user.NumberHoursFree;
            NumberHoursUsed = user.NumberHoursUsed;
            Cupo = user.Cupo;
        }

        public int UserScheduleId { get; set; }
        public int UserId { get; set; }
        public int SchedulesId { get; set; }
        public int SpecialtieId { get; set; }
        public decimal NumberHoursFree { get; set; }
        public decimal NumberHoursUsed { get; set; }   
        public decimal Cupo { get; set; }
    }
}
