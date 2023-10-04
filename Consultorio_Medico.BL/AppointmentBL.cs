﻿using Consultorio_Medico.BL.DTOs.AppointmentDTO;
using Consultorio_Medico.BL.DTOs.UserSchedule;
using Consultorio_Medico.BL.Interfaces;
using Consultorio_Medico.Entities;
using Consultorio_Medico.Entities.Interfaces;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Medico.BL
{
    public class AppointmentBL : IAppointmentBL
    {
        private readonly IAppointmentDAL _appointment;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserSchedulesBL _userSchedulesBL;

        public AppointmentBL (IUnitOfWork unitOfWork, IAppointmentDAL appointment, IUserSchedulesBL userSchedulesBL)
        {
            _appointment = appointment;
            _unitOfWork = unitOfWork;
            _userSchedulesBL = userSchedulesBL; 
        }

        public async Task<int> Create (AppointmentInputDTO pAppointment)
        {
            try
            {
                Appointment appointment = new Appointment()
                {
                    UserSchedulesId = pAppointment.UserSchedulesId,
                    PatientId = pAppointment.PatientId,
                    Reason = pAppointment.Reason,
                    Appointment_date = pAppointment.Appointment_date,
                    Status = pAppointment.Status,
          
                };

                var cupo = await _userSchedulesBL.GetById(pAppointment.UserSchedulesId);
                //var cupo2 = await _appointment.GetById(pAppointment.AppointmentId);
                //var calculatedCupos = ((cupo.NumberHoursFree * 60) - (cupo.NumberHoursUsed + 30))/30;

                //appointment.Cupo = (int)calculatedCupos;

                if (cupo.Cupo > 0) 
                {
                    cupo.Cupo = cupo.Cupo - 1;

                    var userScheduleInputDTO = new UserScheduleInputDTO
                    {
                        UserScheduleId = pAppointment.UserSchedulesId,
                        UserId = cupo.UserId,
                        SchedulesId = cupo.SchedulesId,
                        SpecialtieId = cupo.SpecialtieId,
                        Cupo = cupo.Cupo,
                    };

                    await _userSchedulesBL.Update(userScheduleInputDTO);
                }

                //Detalle: 30 min deben agregarse a la hora en que se agende la cita
                DateTime currentTime = DateTime.Now;

                DateTime endOfAppointment = currentTime.AddMinutes(30);

                appointment.EndOfAppoinmet = endOfAppointment;

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
                    appointment.UserSchedulesId = pAppointment.UserSchedulesId;
                    appointment.PatientId = pAppointment.PatientId;
                    appointment.Reason = pAppointment.Reason;
                    appointment.Appointment_date = pAppointment.Appointment_date;            
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
                    UserSchedulesId = appointment.UserSchedulesId,
                    UserName = appointment.UserSchedules.User.Name + " " + appointment.UserSchedules.User.LastName +" "+appointment.UserSchedules.Specialties.Specialty,
                    PatientId = appointment.PatientId,
                    PatientName = appointment.Patient.Name + " " + appointment.Patient.LastName,
                    Reason = appointment.Reason,
                    Appointment_date = appointment.Appointment_date,              
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
                    UserSchedulesId = s.UserSchedulesId,
                    UserName = s.UserSchedules.User.Name + " " + s.UserSchedules.User.LastName + " " +s.UserSchedules.Specialties.Specialty,  
   
                    PatientId= s.PatientId,
                    PatientName = s.Patient.Name + " " + s.Patient.LastName,
                    Reason= s.Reason,
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
                    UserSchedulesId = pAppointmentSearch.UserSchedulesId,
                   
                    PatientId = pAppointmentSearch.PatientId,
                   
                    Reason = pAppointmentSearch.Reason,

                    Status = pAppointmentSearch.Status,

                });

                appointments.ForEach(s => list.Add(new AppointmentSearchOutputDTO()
                {
                    AppointmentId = s.AppointmentId,
                    UserName = s.UserSchedules.User.Name + " " + s.UserSchedules.User.LastName + " " + s.UserSchedules.Specialties.Specialty,

                    PatientId = s.PatientId,
                    PatientName = s.Patient.Name + " " + s.Patient.LastName,
                    Reason = s.Reason,
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
