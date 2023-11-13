using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Medico.BL.DTOs.SpecialtiesDTO
{
    public class SpecialtiesInputDTO
    {
        public SpecialtiesInputDTO()
        {

        }

        public SpecialtiesInputDTO(SpecialtiesOutputDTO specialtiesOutput)
        {
            Id = specialtiesOutput.Id;
            Specialty = specialtiesOutput.Specialty;
        }

        public int Id { get; set; }
        public string Specialty { get; set; }
    }
}
