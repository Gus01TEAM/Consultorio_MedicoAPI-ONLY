using Consultorio_Medico.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Consultorio_Medico.Entities.Interfaces;


using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Consultorio_Medico.DAL
{
    public class ClinicDAL : IClinicDAL
    {
        readonly ConsultorioDbContext DbContext;
        public ClinicDAL(ConsultorioDbContext pDbContext)
        {
            DbContext = pDbContext;
        }
        public void Create(Clinic pClinic)
        {
            DbContext.Add(pClinic);
        }

        public void Delete(Clinic pClinic)
        {
          DbContext.Remove(pClinic);
        }

        public async Task<List<Clinic>> GetAll()
        {
            var list= await DbContext.Clinics.ToListAsync();
            return list;
        }

        public async Task<Clinic> GetById(int id)
        {
            Clinic? clinic = await DbContext.Clinics.FirstOrDefaultAsync(s => s.ClinicsId == id);
            if (clinic != null)
                return clinic;
            else
                return new Clinic();
        }

        public async Task<List<Clinic>> Search(Clinic pClinic)
        {
          var query = DbContext.Clinics.AsQueryable();
            if (!string.IsNullOrWhiteSpace(pClinic.OfficeName))
                query = query.Where(s => s.OfficeName == pClinic.OfficeName);
            if (!string.IsNullOrWhiteSpace(pClinic.OfficeEmail))
                query = query.Where(s => s.OfficeEmail == pClinic.OfficeEmail);
            if (!string.IsNullOrWhiteSpace(pClinic.OfficeAddres))
                query = query.Where(s => s.OfficeAddres == pClinic.OfficeAddres);
                query = query.Where(s => s.OfficePhone == pClinic.OfficePhone);
            query = query.OrderByDescending(s=>s.ClinicsId).AsQueryable();
            query = query.Include(s => s.Users).AsQueryable();       
            return await query.ToListAsync();

        }

        public void Update(Clinic pClinic)
        {
          DbContext.Update(pClinic);
        }
    }
}

