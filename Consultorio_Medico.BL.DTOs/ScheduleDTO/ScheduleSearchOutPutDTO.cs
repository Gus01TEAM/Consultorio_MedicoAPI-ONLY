using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Consultorio_Medico.BL.DTOs.ScheduleDTO
{
    public class ScheduleSearchOutPutDTO
    {
        [DisplayName("Id Horario")]
        public int SchedulesId { get; set; }
        [DisplayName("Dia")]
        public string DayName { get; set; }
        [DisplayName("Inicio Jornada")]
        public decimal StartOfShift { get; set; }
        [DisplayName("Finalizar Jornada")]
        public decimal EndOfShift { get; set; }
    }
}
