using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Medico.Entities.Interfaces
{
    public interface IClinicDAL

    {
        public void Create(Clinic pClinic);
        public void Update(Clinic pClinic);
        public void Delete(Clinic pClinic);
        public Task<Clinic> GetById(int Id);
        public Task<List<Clinic>> Search(Clinic pClinic);
        public Task<List<Clinic>> GetAll();

    }
}

