using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Medico.BL.DTOs.DoctorSpecialtiesDTO
{
    public class DoctorSpecialties_SearchOutputDTO
    {
        public int DoctorSpecialtiesId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int SpecialtieId { get; set; }
        public string SpecialtieName { get; set;}
    }
}
