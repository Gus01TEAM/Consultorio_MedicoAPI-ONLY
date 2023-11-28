using Consultorio_Medico.Entities;
using Consultorio_Medico.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Medico.DAL
{
    public class AppointmentDAL : IAppointmentDAL
    {
        private readonly ConsultorioDbContext _context;
        public AppointmentDAL(ConsultorioDbContext context)
        {
            _context = context;
        }
        public void Create (Appointment pAppointment)
        {
            _context.Appointment.Add(pAppointment);
        }
        public void Update (Appointment pAppointment)
        {
            _context.Appointment.Update(pAppointment);
        }
        public void Delete (Appointment pAppointment)
        {
            _context.Appointment.Remove(pAppointment);
        }
        public async  Task<List<Appointment>> GetAll ()
        {
            List<Appointment> list = new List<Appointment>();
             return list = await _context.Appointment.ToListAsync();
        }
        public async Task<Appointment> GetById (int Id)
        {
            var Appointment = await _context.Appointment.Include(s => s.UserSchedules).ThenInclude(s => s.User)
              .Include(s => s.UserSchedules).ThenInclude(s => s.Specialties)
                .Include(s => s.Patient).FirstOrDefaultAsync(s => s.AppointmentId == Id);
            return Appointment;
        }
        public async Task<List<Appointment>> Search(Appointment pAppoitment)
        {

            var query = _context.Appointment.AsQueryable();
            
            if (!string.IsNullOrWhiteSpace(pAppoitment.Reason))
                query = query.Where(s => s.Reason.Contains(pAppoitment.Reason));

            if (pAppoitment.Status > 0)

                query = query.Where(s => s.Status == pAppoitment.Status);

            if (pAppoitment.UserSchedulesId > 0)
                query = query.Where(s => s.UserSchedules == pAppoitment.UserSchedules);

            if (pAppoitment.PatientId > 0)
                query = query.Where(s => s.PatientId == pAppoitment.PatientId);       

            query = query.OrderByDescending(s => s.AppointmentId).AsQueryable();

            query = query.Include(s => s.UserSchedules).ThenInclude(s=> s.User)
              .Include(s=> s.UserSchedules).ThenInclude(s=> s.Specialties)
                .AsQueryable();


            query = query.Include(s => s.Patient).AsQueryable();

            return await query.ToListAsync();
        }
    }
}
