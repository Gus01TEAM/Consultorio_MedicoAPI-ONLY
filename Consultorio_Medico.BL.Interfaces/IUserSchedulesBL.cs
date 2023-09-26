using Consultorio_Medico.BL.DTOs.UserSchedule;
using Consultorio_Medico.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Medico.BL.Interfaces
{
    public interface IUserSchedulesBL
    {
        Task<int> Create(UserScheduleInputDTO pUerChed);

        Task<int> Update(UserScheduleInputDTO pUserChed);

        Task<int> Delete(int id);

        Task<UserScheduleSearchOutputDTO> GetById(int id);

        Task<List<UserScheduleSearchOutputDTO>> Search(UserScheduleSearchInpuntDTO pUserChed);

    }
}
