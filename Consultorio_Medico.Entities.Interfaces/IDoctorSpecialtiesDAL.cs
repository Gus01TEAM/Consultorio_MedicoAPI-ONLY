using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Medico.Entities.Interfaces
{
    public interface IDoctorSpecialtiesDAL
    {
        public void Create(DoctorSpecialties pDoctorSpecialties);
        public void Update(DoctorSpecialties pDoctorSpecialties);
        public void Delete(DoctorSpecialties pDoctorSpecialties);
        public Task<DoctorSpecialties> GetById(int Id);

        public Task<List<DoctorSpecialties>> Search(DoctorSpecialties pDoctorSpecialties);
        public Task<List<DoctorSpecialties>> GetAll();

    }
}
