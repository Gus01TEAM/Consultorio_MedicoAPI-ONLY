using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Medico.Entities.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();

    }
}
