using Consultorio_Medico.BL.DTOs.AppointmentDTO;
using Consultorio_Medico.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Medico.BL.Interfaces
{
    public interface IAppointmentBL
    {
        Task<int> Create(AppointmentInputDTO pAppointment);
        Task<int> Update(AppointmentInputDTO pAppointment);
        Task<int> Delete(int Id);
        Task<AppointmentSearchOutputDTO> GetById(int Id);
        Task<List<AppointmentSearchOutputDTO>> GetAll();
        Task<List<AppointmentSearchOutputDTO>> Search(AppointmentSearchInputDTO pAppointmentSearch);
    }
}
