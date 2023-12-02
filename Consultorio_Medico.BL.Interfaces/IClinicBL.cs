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
        Task<int> Create(ClinicInputDTO pClinic);

        Task<int> Update(SearchOutputDTO pClinic);

        Task<int> Delete(int Id);

        Task<SearchOutputDTO> GetById(int Id);

        Task<List<SearchOutputDTO>> Search(SearchinputDTO pClinic);
      
    }
}
