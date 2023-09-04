using Consultorio_Medico.BL.DTOs.ScheduleDTO;
using Consultorio_Medico.BL.DTOs.userDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Medico.BL.Interfaces
{
    public interface IScheduleBL
    {
        Task<int> Create(ScheduleInputDTO Schedule);

        Task<int> Update(ScheduleInputDTO Schedule);

        Task<int> Delete(int Id);

        Task<ScheduleSearchOutPutDTO> GetById(int Id);

        Task<List<ScheduleSearchOutPutDTO>> Search(ScheduleSearchInputDTO Schedule);
    }
}
