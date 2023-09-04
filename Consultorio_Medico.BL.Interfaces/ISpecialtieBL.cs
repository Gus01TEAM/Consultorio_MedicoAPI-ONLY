using Consultorio_Medico.BL.DTOs.SpecialtiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Medico.BL.Interfaces
{
    public interface ISpecialtieBL
    {
        Task<int> Create(SpecialtiesInputDTO pSpecialties);
        Task<int> Update(SpecialtiesInputDTO pSpecialties);
        Task<int> Delete(int Id);
        Task<SpecialtiesOutputDTO> GetById(int Id);
        Task<List<SpecialtiesOutputDTO>> Search(SpecialtiesInputDTO pSpecialties);
        Task<List<SpecialtiesOutputDTO>> GetAll();
    }
}
