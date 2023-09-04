

using Consultorio_Medico.BL.DTOs.RolDTO;

using Consultorio_Medico.BL.Interfaces;
using Consultorio_Medico.Entities;
using Consultorio_Medico.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Consultorio_Medico.BL.DTOs.DTOs;



namespace Consultorio_Medico.BL
{
    public class RolBL : IRolBL

    {
        readonly IRolDAL _rolDAL;
        readonly IUnitOfWork _unitOfWork;

        public RolBL(IRolDAL rolDAL, IUnitOfWork unitOfWork)
        {
            _rolDAL = rolDAL;
            _unitOfWork = unitOfWork;
        }


        public async Task<int> Create(RolInputDTO pRol)
        {
            Rol rolEN = new Rol()
            {
                Name = pRol.Name,
                Status = pRol.Status,
            };
            _rolDAL.Create(rolEN);
            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<int> Delete(int Id)
        {
            Rol rolEN = await _rolDAL.GetById(Id);
            if (rolEN.RolId == Id)
            {
                _rolDAL.Delete(rolEN);
                return await _unitOfWork.SaveChangesAsync();
            }
            else
                return 0;
        }

        public async Task<List<RolSearchingOutputDTO>> Search(RolSearchingInputDTO pRol)
        {
            List<Rol> Rol = await _rolDAL.Search(new Rol { RolId = pRol.RolIdLike, Name = pRol.NameLike });
            List<RolSearchingOutputDTO> list = new List<RolSearchingOutputDTO>();
            Rol.ForEach(s => list.Add(new RolSearchingOutputDTO
            {

                RolId = s.RolId,
                Name = s.Name,
                Status = s.Status,

            }));
            return list;

        }

        public async Task<int> Update(RolInputDTO pRol)
        {
            Rol rol = await _rolDAL.GetById(pRol.RolId);
            if (rol.RolId == pRol.RolId)
            {

                rol.RolId = pRol.RolId;
                rol.Name = pRol.Name;
                rol.Status = pRol.Status;
                _rolDAL.Update(rol);
                return await _unitOfWork.SaveChangesAsync();

            }
            else return 0;
        }

        public async Task<RolSearchingOutputDTO> GetById(int Id)
        {
            Rol rolEN = await _rolDAL.GetById(Id);
            return new RolSearchingOutputDTO()
            {

                RolId = rolEN.RolId,
                Name=rolEN.Name,
                Status = rolEN.Status,
            };
        }
    }
}

    


