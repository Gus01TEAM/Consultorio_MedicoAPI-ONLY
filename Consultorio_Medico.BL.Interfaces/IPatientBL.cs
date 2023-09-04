using Consultorio_Medico.BL.DTOs.PatientDTO;
using Consultorio_Medico.BL.DTOs.SpecialtiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Medico.BL.Interfaces
{
    public interface IPatientBL
    {
        Task<int> Create(patientAddDTO pPatient);
        Task<int> Update(patientAddDTO pPatient);
        Task<int> Delete(int Id);
        Task<patientSearchOutputDTO> GetById(int Id);
        Task<List<patientSearchOutputDTO>> Search(patientSearchInputDTO pPatient);
        Task<List<patientSearchOutputDTO>> GetAll();
    }
}
