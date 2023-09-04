using Consultorio_Medico.BL.DTOs.DoctorSpecialtiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Medico.BL.Interfaces
{
    public interface IDoctorSpecialtiesBL
    {
        Task<int> Create(DoctorSpecialtiesInputDTO pDoctorSpecialtie);
        Task<int> CreateList(List<DoctorSpecialtiesInputDTO> list);
        Task<int> Update(DoctorSpecialtiesInputDTO pDoctorSpecialtie);
        Task<int> Delete(int Id);
        Task<DoctorSpecialties_SearchOutputDTO> GetById(int Id);
        Task<List<DoctorSpecialties_SearchOutputDTO>> GetAll();
        Task<List<DoctorSpecialties_SearchOutputDTO>> Search(DoctorSpecialtie_SearchInputDTO pDoctorSpecialtie);

    }
}
