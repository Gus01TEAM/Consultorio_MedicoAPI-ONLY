using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Medico.BL.DTOs.DTOs
{
    public class SearchinputDTO
    {
       
        public int ClinicsIdLike { get; set; }

        public string? OfficeNameLike { get; set; }
     
    }
}
