using Consultorio_Medico.BL.DTOs.DoctorSpecialtiesDTO;
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
    public class DoctorSpecialtiesBL : IDoctorSpecialtiesBL
    {
        private readonly IDoctorSpecialtiesDAL _doctorSpecialties;
        private readonly IUnitOfWork _unitOfWork;
        public DoctorSpecialtiesBL (IDoctorSpecialtiesDAL doctorSpecialties, IUnitOfWork unitOfWork)
        {
            _doctorSpecialties = doctorSpecialties;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Create (DoctorSpecialtiesInputDTO pDoctorSpecialtie)
        {
            try
            {
                _doctorSpecialties.Create(new DoctorSpecialties
                {
                    UserId = pDoctorSpecialtie.UserId,
                    SpecialtieId = pDoctorSpecialtie.SpecialtieId
                });
                return await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public async Task<int> CreateList(List<DoctorSpecialtiesInputDTO> list)
        {
            try
            {
                foreach (var item in list)
                {
                    _doctorSpecialties.Create(new DoctorSpecialties
                    {
                        UserId = item.UserId,
                        SpecialtieId = item.SpecialtieId
                    });
                }
                return await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public async Task<int> Update (DoctorSpecialtiesInputDTO pDoctorSpecialtie)
        {
            try
            {
                DoctorSpecialties docSpecialtie = await _doctorSpecialties.GetById(pDoctorSpecialtie.Id);
                if (docSpecialtie != null && docSpecialtie.SpecialtieId == pDoctorSpecialtie.Id)
                {
                    docSpecialtie.UserId = pDoctorSpecialtie.UserId;
                    docSpecialtie.SpecialtieId = pDoctorSpecialtie.SpecialtieId;
                    _doctorSpecialties.Update(docSpecialtie);
                    return await _unitOfWork.SaveChangesAsync();
                }
                else
                    return 0;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public async Task<int> Delete (int Id)
        {
            try
            {
                DoctorSpecialties docSpecialtie = await _doctorSpecialties.GetById(Id);
                if (docSpecialtie != null)
                {
                    _doctorSpecialties.Delete(docSpecialtie);
                    return await _unitOfWork.SaveChangesAsync();
                }
                else
                    return 0;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public async Task<List<DoctorSpecialties_SearchOutputDTO>> Search(DoctorSpecialtie_SearchInputDTO pDoctorSpecialtie)
        {
            List<DoctorSpecialties_SearchOutputDTO> list = new List<DoctorSpecialties_SearchOutputDTO> ();
            try
            {
                List<DoctorSpecialties> docSpecialties = await _doctorSpecialties.Search(new DoctorSpecialties
                {
                    UserId = pDoctorSpecialtie.UserId,
                    SpecialtieId = pDoctorSpecialtie.SpecialtieId
                });

                docSpecialties.ForEach(s => list.Add( new DoctorSpecialties_SearchOutputDTO
                {
                    DoctorSpecialtiesId = s.DoctorSpecialtiesId,
                    UserId= s.UserId,
                    UserName = s.user.Name + s.user.LastName,
                    SpecialtieId= s.SpecialtieId,
                    SpecialtieName = s.specialties.Specialty
                   
                }));
                return list;
            }
            catch (Exception)
            {
                return list;
            }
        }

        public async Task<List<DoctorSpecialties_SearchOutputDTO>> GetAll()
        {
            List<DoctorSpecialties_SearchOutputDTO> list = new List<DoctorSpecialties_SearchOutputDTO>();
            List<DoctorSpecialties> docSpecialties = await _doctorSpecialties.GetAll();

            docSpecialties.ForEach(s => list.Add(new DoctorSpecialties_SearchOutputDTO
            {
                DoctorSpecialtiesId = s.DoctorSpecialtiesId,
                UserId = s.UserId,
                UserName = s.user.Name + s.user.LastName,
                SpecialtieId = s.SpecialtieId,
                SpecialtieName = s.specialties.Specialty
            }));
            return list;
        }

        public async Task<DoctorSpecialties_SearchOutputDTO> GetById (int Id)
        {
            try
            {
                DoctorSpecialties docSpecialties = await _doctorSpecialties.GetById(Id);
                return new DoctorSpecialties_SearchOutputDTO
                {
                    DoctorSpecialtiesId = docSpecialties.DoctorSpecialtiesId,
                    UserId = docSpecialties.UserId,
                    SpecialtieId = docSpecialties.SpecialtieId
                };
            }
            catch (Exception e)
            {
                return new DoctorSpecialties_SearchOutputDTO();
            }
        }
    }
}
