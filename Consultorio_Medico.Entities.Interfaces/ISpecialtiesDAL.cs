using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Medico.Entities.Interfaces
{
    public interface ISpecialtiesDAL
    {
        public void Create(Specialties pSpecialties);

        public void Update(Specialties pSpecialties);

        public void Delete(Specialties pSpecialties);

        public Task<List<Specialties>> Search(Specialties pSpecialties);

        public Task<Specialties> GetById(int Id);

        public Task<List<Specialties>> GetAll();
    }
}
