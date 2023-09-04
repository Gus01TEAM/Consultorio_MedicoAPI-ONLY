using Consultorio_Medico.BL.DTOs.RolDTO;
using Consultorio_Medico.BL.DTOs.WorkPlaceDTO;
using Consultorio_Medico.BL.Interfaces;
using Consultorio_Medico.Entities;
using Consultorio_Medico.Entities.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Medico.BL
{
    public class WorkPlaceBL : IWorkPlaceBL
    {

        readonly IWorkPlaceDAL _WorkPlaceDAL;
        readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<WorkPlaceBL> _logger;

        public WorkPlaceBL(IWorkPlaceDAL workPlaceDAL, IUnitOfWork unitOfWork, ILogger<WorkPlaceBL> logger)
        {
            _WorkPlaceDAL = workPlaceDAL;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async  Task<int> Create(WorkPlaceInputDTO pWork)
        {
            WorkPlace WorkEN = new WorkPlace()
            {
                WorkPlaces=pWork.WorkPlaces,

            };
            _WorkPlaceDAL.Create(WorkEN);
            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<int> Delete(int Id)
        {
            WorkPlace WorkEN = await _WorkPlaceDAL.GetById(Id);
            if (WorkEN.WorkPlacesId == Id)
            {
                _WorkPlaceDAL.Delete(WorkEN);
                return await _unitOfWork.SaveChangesAsync();
            }
            else
                return 0;
        }

        public async Task<WorkPlaceSearchOutPutDTO> GetById(int Id)
        {

            WorkPlace WorkEN = await _WorkPlaceDAL.GetById(Id);
            return new WorkPlaceSearchOutPutDTO()
            {

                WorkPlacesId = WorkEN.WorkPlacesId,
                WorkPlaces = WorkEN.WorkPlaces,
            };
        }
    

        public async  Task<List<WorkPlaceSearchOutPutDTO>> Search(WokplaceSearchInputDTO pWork)
        {
            _logger.LogInformation("--------------- INICIO DE METODO SEARCH WORKPLACE -----------------------");
            List<WorkPlace> WorkP = await _WorkPlaceDAL.Search(new WorkPlace { WorkPlaces = pWork.WorkPlaces, WorkPlacesId = pWork.WorkplacesId });
            List<WorkPlaceSearchOutPutDTO> list = new List<WorkPlaceSearchOutPutDTO>();
            WorkP.ForEach(s => list.Add(new WorkPlaceSearchOutPutDTO
            {

                WorkPlacesId=s.WorkPlacesId,
                WorkPlaces = s.WorkPlaces,
              

            }));
            return list;
        }

        public async Task<int> Update(WorkPlaceInputDTO pWork)
        {
            WorkPlace WorkEN = await _WorkPlaceDAL.GetById(pWork.WorkPlacesId);
            if (WorkEN.WorkPlacesId == pWork.WorkPlacesId)
            {
                WorkEN.WorkPlaces = pWork.WorkPlaces;
                
                _WorkPlaceDAL.Update(WorkEN);
                return await _unitOfWork.SaveChangesAsync();

            }
            else return 0;
        }
    }
}
