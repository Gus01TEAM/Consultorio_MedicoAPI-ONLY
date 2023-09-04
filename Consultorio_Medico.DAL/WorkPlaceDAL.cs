using Consultorio_Medico.Entities;
using Consultorio_Medico.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Medico.DAL
{
    public class WorkPlaceDAL:IWorkPlaceDAL
    {
        readonly ConsultorioDbContext DbContext;

        public WorkPlaceDAL(ConsultorioDbContext pDbContext)
        {

            DbContext = pDbContext; 
        }

        public void Create(WorkPlace pWork)
        {
            DbContext.Add(pWork);
        }

        public void Delete(WorkPlace pWork)
        {
            DbContext.Remove(pWork);

        }

        public async Task<WorkPlace> GetById(int Id)
        {
            WorkPlace? workPlace = await DbContext.WorkPlaces.FirstOrDefaultAsync(r => r.WorkPlacesId == Id);

            if (workPlace != null)
                return workPlace;
            else
                return new WorkPlace();
        }

        public async  Task<List<WorkPlace>> Search(WorkPlace pWork)
        {

            var query = DbContext.WorkPlaces.AsQueryable();
            if (!string.IsNullOrWhiteSpace(pWork.WorkPlaces))
                query = query.Where(r => r.WorkPlaces == pWork.WorkPlaces);
            if (pWork.WorkPlacesId > 0)
                query = query.Where(s => s.WorkPlacesId == pWork.WorkPlacesId);

            return await query.ToListAsync();
        }

        public void Update(WorkPlace pWork)
        {
            DbContext.Update(pWork);
        }
    }
}
