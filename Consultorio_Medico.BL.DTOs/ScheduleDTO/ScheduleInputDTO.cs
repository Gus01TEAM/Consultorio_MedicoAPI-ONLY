using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Medico.BL.DTOs.ScheduleDTO
{
    public class ScheduleInputDTO
    {
        public int SchedulesId { get; set; }
        public string DayName { get; set; }
        public decimal StartOfShift { get; set; }
        public decimal EndOfShift { get; set; }
        public decimal NumberOfHours { get; set; }
    }
}
