using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Medico.Entities.Interfaces
{
    public interface IWorkPlaceDAL
    {
        public void Create(WorkPlace pWork);
        public void Update(WorkPlace pWork);
        public void Delete(WorkPlace pWork);
        public Task<WorkPlace> GetById(int Id);
        public Task<List<WorkPlace>> Search(WorkPlace pWork);
    }
}
