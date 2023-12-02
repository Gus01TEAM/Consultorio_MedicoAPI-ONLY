using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Medico.BL.DTOs.DTOs
{
    public class ClinicInputDTO
    {

        public int ClinicsId { get; set; }

        public string OfficeName { get; set; }
        public string OfficeAddres { get; set; }

        public string OfficeEmail { get; set; }

        public string OfficePhone { get; set; }

    }
}
