using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Medico.Entities.Interfaces
{
   public interface IRolDAL
    {
        public void Create(Rol pRol);
        public void Update(Rol pRol);
        public void Delete(Rol pRol);
        public  Task<Rol> GetById(int Id);
        public Task<List<Rol>> Search(Rol pRol);
        public Task<List<Rol>> GetAll();
       
    }
}
