using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Medico.BL.DTOs.DoctorSpecialtiesDTO
{
    public class DoctorSpecialtiesInputDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SpecialtieId { get; set; }
    }
}
