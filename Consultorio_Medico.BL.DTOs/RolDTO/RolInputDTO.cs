using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Medico.BL.DTOs.RolDTO
{
    public class RolInputDTO
    {
        public RolInputDTO()
        {

        }

        public RolInputDTO(RolSearchingOutputDTO getIdResultRolDTO)
        {
            RolId = getIdResultRolDTO.RolId;
            Name = getIdResultRolDTO.Name;
            Status = getIdResultRolDTO.Status;
        }


        public int RolId { get; set; }
        public string Name { get; set; }
        public byte Status { get; set; }
    }
}
