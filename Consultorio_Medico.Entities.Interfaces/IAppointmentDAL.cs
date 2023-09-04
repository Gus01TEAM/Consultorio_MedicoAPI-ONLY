using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Medico.Entities.Interfaces
{
    public interface IAppointmentDAL
    {
        void Create(Appointment pApointment);
        void Update(Appointment pAppointment);
        void Delete(Appointment pAppointment);
        Task<List<Appointment>> GetAll();
        Task<Appointment> GetById(int Id);
        Task<List<Appointment>> Search(Appointment pAppoitment);
    }
}
