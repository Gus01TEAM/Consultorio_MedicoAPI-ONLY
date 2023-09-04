
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Medico.Entities.Interfaces
{
    public interface IUserSchedulesDAL
    {
        public void Create(UserSchedules pUserChed);
        public void Update(UserSchedules pUserChed);
        public void Delete(UserSchedules pUserChed);
        public Task<UserSchedules> GetById(int Id);
        public Task<List<UserSchedules>> Search(UserSchedules pUserChed);
        public Task<List<UserSchedules>> GetAll();
    }
}
