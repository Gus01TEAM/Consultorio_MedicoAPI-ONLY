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
    public class ScheduleDAL:IScheduleDAL
    {
        readonly ConsultorioDbContext DbContext;

        public ScheduleDAL(ConsultorioDbContext pDbContext)
        {
            DbContext = pDbContext;
        }

        public void Create(Schedules pSchedule)
        {
            DbContext.Add(pSchedule);
        }
        public void Delete(Schedules pSchedules)
        {
            DbContext.Remove(pSchedules);
        }

        public async Task<List<Schedules>> GetAll()
        {
            var list = await DbContext.Schedules.ToListAsync();
            return list;
        }

        public async Task<Schedules> GetById(int id)
        {
            Schedules? schedules = await DbContext.Schedules.FirstOrDefaultAsync(s => s.SchedulesId == id);
            if (schedules != null)
                return schedules;
            else
                return new Schedules();
        }
        public async Task<List<Schedules>> Search(Schedules pSchedules)
        {
          
            var query = DbContext.Schedules.AsQueryable();
            if (!string.IsNullOrWhiteSpace(pSchedules.DayName))
                query = query.Where(s => s.DayName  == pSchedules.DayName);
            query = query.OrderByDescending(s => s.SchedulesId).AsQueryable();

            return await query.ToListAsync();
        }
        public void Update(Schedules pSchedules)
        {
            DbContext.Update(pSchedules);
        }
    }
}
