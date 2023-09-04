using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Medico.BL.DTOs.ScheduleDTO
{
    public class ScheduleSearchInputDTO
    {
     
        public string? DayNameLike { get; set; }
        public decimal StartShiftLike { get; set; }
        public decimal EndOfShiftLike { get; set; }
    }
}
