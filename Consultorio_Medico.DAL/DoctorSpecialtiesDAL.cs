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
    public class DoctorSpecialtiesDAL : IDoctorSpecialtiesDAL
    {
        private readonly ConsultorioDbContext _context;
        public DoctorSpecialtiesDAL (ConsultorioDbContext context)
        {
            _context = context;
        }
        public void Create(DoctorSpecialties pDoctorSpecialties)
        {
            _context.Add(pDoctorSpecialties);
        }
        public void Update(DoctorSpecialties pSpecialties)
        {
            _context.Update(pSpecialties);
        }
        public void Delete(DoctorSpecialties pDoctorSpecialties)
        {
            _context.Remove(pDoctorSpecialties);
        }
        public async Task<List<DoctorSpecialties>> GetAll()
        {

            var list = await _context.DoctorSpecialties.ToListAsync();
            return list;

        }
        public async Task<DoctorSpecialties> GetById(int Id)
        {
            DoctorSpecialties? DocSpecialties = await _context.DoctorSpecialties.FirstOrDefaultAsync(r => r.DoctorSpecialtiesId == Id);

            if (DocSpecialties != null)
                return DocSpecialties;
            else
                return new DoctorSpecialties();
        }
        public async Task<List<DoctorSpecialties>> Search(DoctorSpecialties pDoctorSpecialties)
        {

            var query = _context.DoctorSpecialties.AsQueryable();
            if (pDoctorSpecialties.DoctorSpecialtiesId > 0)
                query = query.Where(s => s.DoctorSpecialtiesId == pDoctorSpecialties.DoctorSpecialtiesId);
            if (pDoctorSpecialties.UserId > 0)
                query = query.Where(s => s.UserId == pDoctorSpecialties.UserId);
            if (pDoctorSpecialties.SpecialtieId > 0)
                query = query.Where(s => s.SpecialtieId == pDoctorSpecialties.SpecialtieId);
            query = query.OrderByDescending(s => s.DoctorSpecialtiesId).AsQueryable();
            query = query.Include(s => s.user).AsQueryable();
            query = query.Include(s => s.specialties).AsQueryable();
            return await query.ToListAsync();
        }
        
    }
}
