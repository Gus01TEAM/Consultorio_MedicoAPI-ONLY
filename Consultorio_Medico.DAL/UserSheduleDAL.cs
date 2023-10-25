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
    public class UserSheduleDAL: IUserSchedulesDAL
    {

        readonly ConsultorioDbContext _DbContext;
        public UserSheduleDAL(ConsultorioDbContext pDbContext)
        {
            _DbContext = pDbContext;
        }

        public void Create(UserSchedules pUserChed)
        {
            _DbContext.Add(pUserChed);
        }

        public void Delete(UserSchedules pUserChed)
        {
            _DbContext.Remove(pUserChed);
        }

        public async Task<List<UserSchedules>> GetAll()
        {
            var list = await _DbContext.UserSchedules.ToListAsync();
            return list;
        }

        public async Task<UserSchedules> GetById(int Id)
        {
            UserSchedules? UserSched = await _DbContext.UserSchedules.FirstOrDefaultAsync(r => r.UserSchedulesId == Id);

            if (UserSched != null)
                return UserSched;
            else
                return new UserSchedules();
            
        }

        public async Task<List<UserSchedules>> Search(UserSchedules pUserChed)
        {
            var query = _DbContext.UserSchedules.AsQueryable();
            if (pUserChed.UserSchedulesId > 0)
                query = query.Where(s => s.UserSchedulesId == pUserChed.UserSchedulesId);

            if(pUserChed.UserId>0)
                query = query.Where(s => s.UserId == pUserChed.UserId);

            if (pUserChed.SchedulesId > 0)
                query = query.Where(s => s.SchedulesId == pUserChed.SchedulesId);

            if (pUserChed.SpecialtieId > 0)
                query = query.Where(s => s.SpecialtieId == pUserChed.SpecialtieId);

            query = query.OrderByDescending(s => s.UserId).AsQueryable();

            query = query.Include(s => s.User).AsQueryable();

            query = query.Include(s => s.Schedules).AsQueryable();

            query = query.Include(s => s.Specialties).AsQueryable();

            return await query.ToListAsync();
        }
        public void Update(UserSchedules pUserChed)
        {
            _DbContext.Update(pUserChed);
        }
    }


    
}

