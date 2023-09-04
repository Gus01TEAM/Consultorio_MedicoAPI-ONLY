using Consultorio_Medico.BL.DTOs.PatientDTO;
using Consultorio_Medico.BL.DTOs.RolDTO;
using Consultorio_Medico.BL.DTOs.SpecialtiesDTO;
using Consultorio_Medico.BL.Interfaces;
using Consultorio_Medico.Entities;
using Consultorio_Medico.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Medico.BL
{
    public class PatientBL : IPatientBL
    {
        private readonly IPatientDAL _patient;
        private readonly IUnitOfWork _unitOfWork;
        public PatientBL(IPatientDAL patient, IUnitOfWork unitOfWork)
        {
            _patient = patient;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Create(patientAddDTO pPatient)
        {
            try
            {
                Patient patientEN = new Patient()
                {
                    Name = pPatient.Name,
                    LastName = pPatient.LastName,
                    Telefono = pPatient.Telefono,
                    DUI = pPatient.DUI,
                };
                _patient.Create(patientEN);
                return await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> Delete(int Id)
        {
            try
            {
                Patient patient = await _patient.GetById(Id);
                if (patient.PatientId == Id)
                {
                    _patient.Delete(patient);
                    return await _unitOfWork.SaveChangesAsync();
                }
                return 0;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public async Task<List<patientSearchOutputDTO>> GetAll()
        {
            List<patientSearchOutputDTO> patientSearchOutput = new List<patientSearchOutputDTO>();

            List<Patient> patient = await _patient.GetAll();

            patient.ForEach(s => patientSearchOutput.Add(new patientSearchOutputDTO
            {
                patientId = s.PatientId,    
                Name = s.Name,
                Telefono= s.Telefono,
                DUI= s.DUI,

            }));
            return patientSearchOutput;
        }

        public async Task<patientSearchOutputDTO> GetById(int Id)
        {
            try
            {
                Patient patient = await _patient.GetById(Id);
                return new patientSearchOutputDTO()
                {
                    patientId = patient.PatientId,
                    Name = patient.Name,
                    LastName = patient.LastName,
                    Telefono= patient.Telefono,
                    DUI= patient.DUI,
                };
            }
            catch (Exception e)
            {
                return new patientSearchOutputDTO();
            }
        }

        public async Task<List<patientSearchOutputDTO>> Search(patientSearchInputDTO pPatient)
        {
            List<Patient> patient = await _patient.Search(new Patient { PatientId = pPatient.patientId });
            List<patientSearchOutputDTO> list = new List<patientSearchOutputDTO>();
            patient.ForEach(s => list.Add(new patientSearchOutputDTO
            {
                patientId=s.PatientId,
                Name=s.Name,
                LastName=s.LastName,
                Telefono = s.Telefono,
                DUI = s.DUI,
            }));
            return list;

        }

        public async Task<int> Update(patientAddDTO pPatient)
        {
            try
            {
                Patient patient = await _patient.GetById(pPatient.patientId);
                if (patient.PatientId == pPatient.patientId)
                {
                    patient.Name = pPatient.Name;
                    patient.LastName = pPatient.LastName;   
                    patient.Telefono = pPatient.Telefono;   
                    patient.DUI = pPatient.DUI; 

                    _patient.Update(patient);
                    return await _unitOfWork.SaveChangesAsync();
                }
                else return 0;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
    }
}
