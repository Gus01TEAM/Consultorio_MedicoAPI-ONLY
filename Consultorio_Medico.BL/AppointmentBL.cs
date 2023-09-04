using Consultorio_Medico.BL.DTOs.AppointmentDTO;
using Consultorio_Medico.BL.Interfaces;
using Consultorio_Medico.Entities;
using Consultorio_Medico.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Medico.BL
{
    public class AppointmentBL : IAppointmentBL
    {
        private readonly IAppointmentDAL _appointment;
        private readonly IUnitOfWork _unitOfWork;
        public AppointmentBL (IUnitOfWork unitOfWork, IAppointmentDAL appointment)
        {
            _appointment = appointment;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Create (AppointmentInputDTO pAppointment)
        {
            try
            {
                Appointment appointment = new Appointment()
                {
                    UserId = pAppointment.UserId,
                    SpecialtieId = pAppointment.SpecialtieId,
                    PatientId = pAppointment.PatientId,
                    Appointment_Name = pAppointment.Appointment_Name,
                    Reason = pAppointment.Reason,
                    Appointment_date = pAppointment.Appointment_date,
                    Appointment_Hour = pAppointment.Appointment_Hour,
                    Shift = pAppointment.Shift,
                    Status = pAppointment.Status
                };
                _appointment.Create(appointment);
                return await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public async Task<int> Update(AppointmentInputDTO pAppointment)
        {
            try
            {
                var appointment = await _appointment.GetById(pAppointment.AppointmentId);
                if (appointment != null) {
                    appointment.UserId = pAppointment.UserId;
                    appointment.SpecialtieId = pAppointment.SpecialtieId;
                    appointment.PatientId = pAppointment.PatientId;
                    appointment.Appointment_Name = pAppointment.Appointment_Name;
                    appointment.Reason = pAppointment.Reason;
                    appointment.Appointment_date = pAppointment.Appointment_date;
                    appointment.Appointment_Hour = pAppointment.Appointment_Hour;
                    appointment.Shift = pAppointment.Shift;
                    appointment.Status = pAppointment.Status;

                    _appointment.Update(appointment);
                    return await _unitOfWork.SaveChangesAsync();
                }
                return 0;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public async Task<int> Delete(int Id)
        {
            try
            {
                var appointment = await _appointment.GetById(Id);
                _appointment.Delete(appointment);
                return await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public async Task<AppointmentSearchOutputDTO> GetById(int Id)
        {
            try
            {
                var appointment = await _appointment.GetById(Id);
                AppointmentSearchOutputDTO pAppointment = new AppointmentSearchOutputDTO()
                {
                    AppointmentId = appointment.AppointmentId,
                    UserId = appointment.UserId,
                    UserName = appointment.Users.Name + " " + appointment.Users.LastName,
                    SpecialtieId = appointment.SpecialtieId,
                    SpecialtieName = appointment.Specialties.Specialty,
                    PatientId = appointment.PatientId,
                    PatientName = appointment.Patient.Name + " " + appointment.Patient.LastName,
                    Appointment_Name = appointment.Appointment_Name,
                    Reason = appointment.Reason,
                    Appointment_date = appointment.Appointment_date,
                    Appointment_Hour = appointment.Appointment_Hour,
                    Shift = appointment.Shift,
                    Status = appointment.Status,
                };
                return pAppointment;
            }
            catch (Exception e)
            {
                return new AppointmentSearchOutputDTO();
            }
        }
        public async Task<List<AppointmentSearchOutputDTO>> GetAll()
        {
            List<AppointmentSearchOutputDTO> list = new List<AppointmentSearchOutputDTO>();
            try
            {
                var appointments = await _appointment.GetAll();
                appointments.ForEach(s => list.Add( new AppointmentSearchOutputDTO()
                {
                    AppointmentId = s.AppointmentId,
                    UserId = s.UserId,
                    UserName = s.Users.Name + " " + s.Users.LastName,
                    SpecialtieId= s.SpecialtieId,
                    SpecialtieName = s.Specialties.Specialty,
                    PatientId= s.PatientId,
                    PatientName = s.Patient.Name + " " + s.Patient.LastName,
                    Reason= s.Reason,
                    Appointment_Name = s.Appointment_Name,
                    Appointment_date= s.Appointment_date,
                    Appointment_Hour = s.Appointment_Hour,
                    Shift = s.Shift,
                    Status = s.Status,
                }));
                return list;
            }
            catch (Exception e)
            {
                return list;
            }
        }
        public async Task<List<AppointmentSearchOutputDTO>> Search(AppointmentSearchInputDTO pAppointmentSearch)
        {
            List<AppointmentSearchOutputDTO> list = new List<AppointmentSearchOutputDTO>();
            try
            {
                var appointments = await _appointment.Search(new Appointment() {
                    UserId = pAppointmentSearch.UserId,
                    SpecialtieId = pAppointmentSearch.SpecialtieId,
                    PatientId = pAppointmentSearch.PatientId,
                    Appointment_Name = pAppointmentSearch.Appointment_Name,
                    Reason = pAppointmentSearch.Reason,
                    Shift = pAppointmentSearch.Shift,
                    Status = pAppointmentSearch.Status,
                });

                appointments.ForEach(s => list.Add(new AppointmentSearchOutputDTO()
                {
                    AppointmentId = s.AppointmentId,
                    UserId = s.UserId,
                    UserName = s.Users.Name + " " + s.Users.LastName,
                    SpecialtieId = s.SpecialtieId,
                    SpecialtieName = s.Specialties.Specialty,
                    PatientId = s.PatientId,
                    PatientName = s.Patient.Name + " " + s.Patient.LastName,
                    Reason = s.Reason,
                    Appointment_Name = s.Appointment_Name,
                    Appointment_date = s.Appointment_date,
                    Appointment_Hour = s.Appointment_Hour,
                    Shift = s.Shift,
                    Status = s.Status,
                }));
                return list;
            }
            catch (Exception e)
            {
                return list;
            }
        }
    }
   
}
