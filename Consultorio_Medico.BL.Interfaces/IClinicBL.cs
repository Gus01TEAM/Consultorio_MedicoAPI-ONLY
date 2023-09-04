using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;



using Consultorio_Medico.BL.DTOs.DTOs;

namespace Consultorio_Medico.BL.Interfaces
{
    public interface IClinicBL
    {
        Task<int> Create(CreateInputDTO pClinic);

        Task<int> Update(UpdateDTO pClinic);

        Task<int> Delete(int Id);

        Task<GetByIdOutputDTO> GetById(int Id);

        Task<List<SearchOutputDTO>> Search(SearchinputDTO pClinic);
      
    }
}
