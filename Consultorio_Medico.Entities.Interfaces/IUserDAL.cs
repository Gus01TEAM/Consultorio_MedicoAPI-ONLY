using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Medico.Entities.Interfaces
{
    public interface IUserDAL
    {
        public void Create(Users pUser);
        public void Update(Users pUser);
        public void Delete(Users pUser);
        public Task<Users> GetById(int Id);
        public Task<List<Users>> Search(Users pUser);
    
    }
}
