using Consultorio_Medico.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Medico.DAL
{
    public class UnitOfWork :IUnitOfWork
    {
        readonly ConsultorioDbContext dbContext;
        public UnitOfWork(ConsultorioDbContext pDbContext)
        {
            dbContext = pDbContext;
        }
        public Task<int> SaveChangesAsync()
        {
            return dbContext.SaveChangesAsync();
        }
    }
}
