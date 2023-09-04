using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Medico.BL.DTOs.RolDTO
{
    public class RolSearchingInputDTO
    {
      
        public int RolIdLike { get; set; }
        public string? NameLike { get; set;}

    }
}
