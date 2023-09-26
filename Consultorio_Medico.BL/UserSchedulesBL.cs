using Consultorio_Medico.BL.DTOs.RolDTO;
using Consultorio_Medico.BL.DTOs.UserSchedule;
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
    public class UserSchedulesBL : IUserSchedulesBL
    {
        readonly IUserSchedulesDAL _userScheduleDAL;
        readonly IUnitOfWork _unitOfWork;
        readonly IScheduleBL scheduleBL;
        public UserSchedulesBL(IUserSchedulesDAL UserScheduleDAL, IUnitOfWork unitOfWork, IScheduleBL scheduleBL)
        {
            _userScheduleDAL = UserScheduleDAL;
            _unitOfWork = unitOfWork;
            this.scheduleBL = scheduleBL;
        }
        public async Task<int> Create(UserScheduleInputDTO pUerChed)
        {
            UserSchedules userSchedulesEN = new UserSchedules()
            {
                UserId = pUerChed.UserId,
                SchedulesId = pUerChed.SchedulesId,
                SpecialtieId = pUerChed.SpecialtieId,
              //  NumberHoursFree = pUerChed.NumberHoursFree = schedules.NumberOfHours
               
            };
            var schedule = await scheduleBL.GetById(pUerChed.SchedulesId);
            userSchedulesEN.NumberHoursFree = schedule.NumberOfHours;
            _userScheduleDAL.Create(userSchedulesEN);
            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            UserSchedules userSchedulesEN = await _userScheduleDAL.GetById(id);
            if (userSchedulesEN.UserSchedulesId == id)
            {
                _userScheduleDAL.Delete(userSchedulesEN);
                return await _unitOfWork.SaveChangesAsync();
            }
            else
                return 0;
        }
        public async Task<UserScheduleSearchOutputDTO> GetById(int id)
        {
            UserSchedules userSchedulesEN = await _userScheduleDAL.GetById(id);
            return new UserScheduleSearchOutputDTO()
            {
                UserSchedulesId = userSchedulesEN.UserSchedulesId,
                UserId = userSchedulesEN.UserId,
                SchedulesId = userSchedulesEN.SchedulesId,
                SpecialtieId = userSchedulesEN.SpecialtieId,
              
            };
        }

        public async Task<List<UserScheduleSearchOutputDTO>> Search(UserScheduleSearchInpuntDTO pUserChed)
        {
            List<UserSchedules> UserSchedule = await _userScheduleDAL.Search(new UserSchedules { UserId = pUserChed.UserId, SchedulesId=pUserChed.SchedulesId});
            List<UserScheduleSearchOutputDTO> list = new List<UserScheduleSearchOutputDTO>();
            UserSchedule.ForEach(s => list.Add(new UserScheduleSearchOutputDTO
            {
                UserId = s.UserId,
                UserSchedulesId = s.UserSchedulesId,
                SchedulesId=s.SchedulesId,
                SpecialtieId=s.SpecialtieId,
                NumberHoursFree = s.NumberHoursFree = s.Schedules.NumberOfHours,
                NumberHoursUsed = s.NumberHoursUsed, 
                UserName=s.User.Name,
                Schedule=s.Schedules.DayName+" "+s.Schedules.StartOfShift+" "+s.Schedules.EndOfShift,
                Specialty=s.Specialties.Specialty,
            }));
            return list;
        }
        public async Task<int> Update(UserScheduleInputDTO pUserChed)
        {
            UserSchedules UserChed = await _userScheduleDAL.GetById(pUserChed.UserScheduleId);
            if (UserChed.UserSchedulesId == pUserChed.UserScheduleId)
            {
                UserChed.UserSchedulesId = pUserChed.UserScheduleId;
                UserChed.UserId = pUserChed.UserId;
                UserChed.SchedulesId = pUserChed.SchedulesId;
                UserChed.SpecialtieId=pUserChed.SpecialtieId;

                _userScheduleDAL.Update(UserChed);
                return await _unitOfWork.SaveChangesAsync();

            }
            else return 0;
        }
    }
}
