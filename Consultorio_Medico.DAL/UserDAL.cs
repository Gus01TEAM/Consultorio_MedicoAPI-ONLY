using Consultorio_Medico.Entities;
using Consultorio_Medico.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Medico.DAL
{
    public class UserDAL:IUserDAL
    {
        private readonly ConsultorioDbContext DbContext;

        public UserDAL(ConsultorioDbContext pDbContext)
        {
            DbContext = pDbContext;
        }
        

        public void Create(Users pUser)
        {

            DbContext.Add(pUser);
        }
        public void Delete(Users pUser)
        {
            DbContext.Remove(pUser);
        }

        public async Task<List<Users>> GetAll()
        {
            var list = await DbContext.Users.ToListAsync();
            return list;
        }

        public async Task<Users> GetById(int id)
        {
            Users? user = await DbContext.Users.FirstOrDefaultAsync(s => s.UserId == id);
            if (user != null)
                return user;
            else
                return new Users();
        }
        public async Task<List<Users>> Search(Users pUser)
        {
            var query = DbContext.Users.AsQueryable();

            if (!string.IsNullOrWhiteSpace(pUser.PhoneNumber))
                query = query.Where(s => s.PhoneNumber == pUser.PhoneNumber);

            if (!string.IsNullOrWhiteSpace(pUser.Name))
                query = query.Where(s => s.Name == pUser.Name);

            if (!string.IsNullOrWhiteSpace(pUser.Name))
                query = query.Where(s => s.Name == pUser.Name);

            query = query.OrderByDescending(s => s.UserId).AsQueryable();
            query = query.Include(s => s.Rol).AsQueryable();
     

            return await query.ToListAsync();
        }
        public void Update(Users pUser)
        {
            DbContext.Update(pUser);    
        }
    }

}
