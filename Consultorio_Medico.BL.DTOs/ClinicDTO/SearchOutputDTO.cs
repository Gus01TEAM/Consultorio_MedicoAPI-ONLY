using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Medico.BL.DTOs.DTOs
{
    public class SearchOutputDTO
    {
        public int ClinicsId { get; set; }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserLastName { get; set; }
        public string OfficeName { get; set; }
        public string OfficeAddres { get; set; }

        public string OfficeEmail { get; set; }

        public string OfficePhone { get; set; }

       
    }
}
