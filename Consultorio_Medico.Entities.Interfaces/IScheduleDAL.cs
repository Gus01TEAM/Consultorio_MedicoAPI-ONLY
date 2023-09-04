using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Medico.Entities.Interfaces
{
    public interface IScheduleDAL
    {
        public void Create(Schedules schedules);
        public void Update(Schedules schedules);
        public void Delete(Schedules schedules);
        public Task<Schedules> GetById(int Id);
        public Task<List<Schedules>> Search(Schedules schedules);
    }
}
