using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Medico.Entities.Interfaces
{
    public interface IPatientDAL
    {
        public void Create(Patient pPatient);
        public void Update(Patient pPatient);
        public void Delete(Patient pPatient);
        public Task<Patient> GetById(int Id);

        public Task<List<Patient>> Search(Patient pPatient);
        public Task<List<Patient>> GetAll();
    }
}
