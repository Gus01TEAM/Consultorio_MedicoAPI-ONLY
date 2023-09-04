using Consultorio_Medico.BL.DTOs.DTOs;
using Consultorio_Medico.BL.DTOs.userDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Medico.BL.Interfaces
{
    public interface IUserBL
    {
        Task<int> Create(UserAddDTO pUser);

        Task<int> Update(userUpdateDTO pUser);

        Task<int> Delete(int Id);

        Task<userSearchOutputDTO> GetById(int Id);

        Task<List<userSearchOutputDTO>> Search(userSearchInputDTO pUser);
       
      

    }
}
