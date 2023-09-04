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
    public class SpecialtiesBL : ISpecialtieBL
    {
        private readonly ISpecialtiesDAL _specialties;
        private readonly IUnitOfWork _unitOfWork;

        public SpecialtiesBL (ISpecialtiesDAL specialties, IUnitOfWork unitOfWork)
        {
            _specialties = specialties;
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Create(SpecialtiesInputDTO pSpecialties)
        {
            try
            {
                Specialties specialties = new Specialties()
                {
                    Specialty = pSpecialties.Specialty
                };

                _specialties.Create(specialties);
                var result = await _unitOfWork.SaveChangesAsync();
                return result;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public async Task<int> Update (SpecialtiesInputDTO pSpecialties)
        {
            try
            {
                Specialties specialtie =  await _specialties.GetById(pSpecialties.Id);
                if (specialtie.SpecialtiesId == pSpecialties.Id)
                {
                    specialtie.Specialty = pSpecialties.Specialty;
                    _specialties.Update(specialtie);
                    return await _unitOfWork.SaveChangesAsync();
                }
                else return 0;
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
                Specialties specialtie = await _specialties.GetById(Id);
                if ( specialtie.SpecialtiesId == Id)
                {
                    _specialties.Delete(specialtie);
                    return await _unitOfWork.SaveChangesAsync();
                }
                return 0;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public async Task<SpecialtiesOutputDTO> GetById (int Id)
        {
            try
            {
                Specialties specialties = await _specialties.GetById(Id);
                return new SpecialtiesOutputDTO()
                {
                    Id = specialties.SpecialtiesId,
                    Specialty = specialties.Specialty
                };
            } 
            catch (Exception e)
            {
                return new SpecialtiesOutputDTO();
            }
        }

        public async Task<List<SpecialtiesOutputDTO>> Search (SpecialtiesInputDTO pSpecialties)
        {
            List<SpecialtiesOutputDTO> SpecialtiesOutput = new List<SpecialtiesOutputDTO>();
            try
            {
                List<Specialties> specialties = await _specialties.Search(new Specialties
                {
                    SpecialtiesId = pSpecialties.Id,
                    Specialty = pSpecialties.Specialty
                });

                specialties.ForEach(s => SpecialtiesOutput.Add(new SpecialtiesOutputDTO
                {
                    Id = s.SpecialtiesId,
                    Specialty = s.Specialty
                }));
                return SpecialtiesOutput;
            } 
            catch (Exception e)
            {
                return SpecialtiesOutput;
            }
        }

        public async Task<List<SpecialtiesOutputDTO>> GetAll ()
        {
            List<SpecialtiesOutputDTO> specialtiesOutputDTOs = new List<SpecialtiesOutputDTO>();

            List<Specialties> specialties = await _specialties.GetAll();

            specialties.ForEach(s => specialtiesOutputDTOs.Add(new SpecialtiesOutputDTO
            {
                Id= s.SpecialtiesId,
                Specialty = s.Specialty
            }));
            return specialtiesOutputDTOs;
        }
    }
}
