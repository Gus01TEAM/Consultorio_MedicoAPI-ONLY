using Consultorio_Medico.BL.DTOs.DTOs;
using Consultorio_Medico.BL.Interfaces;
using Consultorio_Medico.Entities;
using Consultorio_Medico.Entities.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using Dapper;
namespace Consultorio_Medico.BL
{
    public class ClinicBL : IClinicBL
    {
        
        readonly IClinicDAL clinicDAL;
      readonly IUnitOfWork unitOfWork;

     

        public ClinicBL(IClinicDAL pClinicDAL, IUnitOfWork pUnitWork)
        {
            clinicDAL = pClinicDAL;
        unitOfWork = pUnitWork;
        }

        public async Task<int> Create(CreateInputDTO pClinic)
        {
            Clinic clinic = new Clinic
            {
                OfficeName = pClinic.OfficeName,
                OfficeEmail = pClinic.OfficeEmail,
                OfficePhone = pClinic.OfficePhone,
                OfficeAddres = pClinic.OfficeAddres,


            };
            clinicDAL.Create(clinic);
            return await unitOfWork.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            Clinic clinic = await clinicDAL.GetById(id);
            if (clinic.ClinicsId==id)
            {
                clinicDAL.Delete(clinic);
                return await unitOfWork.SaveChangesAsync();
            }
            else
                return 0;

        }

      

        public async Task<List<ClinicGetAllDTO>> GetAll()
        {
            
            List<Clinic> clinic = await clinicDAL.GetAll();
            List<ClinicGetAllDTO> list = new List<ClinicGetAllDTO>();
            clinic.ForEach(s => list.Add(new ClinicGetAllDTO
            {
                ClincisId = s.ClinicsId,
                OfficeName = s.OfficeName,
                OfficeAddres = s.OfficeAddres,
                OfficeEmail = s.OfficeEmail,
                OfficePhone = s.OfficePhone,
                UserId = s.UserId,
            }));
            return list;
        }

        public async Task<GetByIdOutputDTO> GetById(int id)
        {
            Clinic clinic = await clinicDAL.GetById(id);
            return new GetByIdOutputDTO
            {
                ClincisId = clinic.ClinicsId,
                OfficeName = clinic.OfficeName,
                OfficeAddres = clinic.OfficeAddres,
                OfficeEmail = clinic.OfficeEmail,
                OfficePhone = clinic.OfficePhone,
                UserId = clinic.UserId,
            };
        }

       

        public async Task<List<SearchOutputDTO>> Search(SearchinputDTO pClinic)
        {
            List<Clinic> clinics = await clinicDAL.Search(new Clinic { OfficePhone = pClinic.OfficePhoneLike, OfficeName = pClinic.OfficeNameLike });
            List<SearchOutputDTO> list = new List<SearchOutputDTO>();
            clinics.ForEach(s => list.Add(new SearchOutputDTO
            {
                ClinicsId = s.ClinicsId,
                OfficeEmail = s.OfficeEmail,
                OfficeName = s.OfficeName,
                OfficeAddres = s.OfficeAddres,
                OfficePhone= s.OfficePhone,
                UserId= s.UserId,
                UserName=s.Users.Name,
                UserLastName=s.Users.LastName,
            }));
            return list;
        }

        

        public async Task<int> Update(UpdateDTO pClinic)
        {
          Clinic eClinic = await clinicDAL.GetById(pClinic.ClincisId);
            if (eClinic.ClinicsId == pClinic.ClincisId)
            {
                eClinic.OfficeName = pClinic.OfficeEmail;
                clinicDAL.Update(eClinic);
                return await unitOfWork.SaveChangesAsync(); 
            }
            else
                return 0;
        }

      
    }
 }

