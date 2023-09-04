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
    public class RolDal : IRolDAL
    {
        readonly ConsultorioDbContext DbContext;
        public RolDal(ConsultorioDbContext pDbContext)
        {
            DbContext = pDbContext;
        }
        public void Create(Rol pRol)
        {
            DbContext.Add(pRol);
        }
        public void Delete(Rol pRol)
        {
            DbContext.Remove(pRol);
        }


        public async Task<List<Rol>> Search(Rol pRol)
        {

            var query = DbContext.Rol.AsQueryable();
            if (!string.IsNullOrWhiteSpace(pRol.Name))
                query = query.Where(r => r.Name == pRol.Name);
            if (pRol.RolId > 0)
                query = query.Where(s => s.RolId == pRol.RolId);

            return await query.ToListAsync();
           
        }

      

        public void Update(Rol pRol)
        {
            DbContext.Update(pRol);
        }

       public async Task<List<Rol>>GetAll()
        {

            var list = await DbContext.Rol.ToListAsync();
            return list;
          
        }

      public async Task<Rol> GetById(int Id)
        {
            Rol? rol = await DbContext.Rol.FirstOrDefaultAsync(r => r.RolId == Id);

        if (rol != null) 
                return rol;
        else
                return new Rol();
            
        }
    }
}
