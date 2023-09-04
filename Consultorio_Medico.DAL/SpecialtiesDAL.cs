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
    public class SpecialtiesDAL : ISpecialtiesDAL
    {
        private readonly ConsultorioDbContext _context;
        public SpecialtiesDAL (ConsultorioDbContext context)
        {
            _context = context;
        }

        public void Create(Specialties pSpecialties)
        {
            _context.Add(pSpecialties);
        }
        public void Delete(Specialties pSpecialties)
        {
            _context.Remove(pSpecialties);
        }

        public async Task<List<Specialties>> Search(Specialties pSpecialties)
        {

            var query = _context.Specialties.AsQueryable();
            if (!string.IsNullOrWhiteSpace(pSpecialties.Specialty))
                query = query.Where(r => r.Specialty == pSpecialties.Specialty);
            if (pSpecialties.SpecialtiesId > 0)
                query = query.Where(s => s.SpecialtiesId == pSpecialties.SpecialtiesId);
            query = query.OrderByDescending(s => s.SpecialtiesId).AsQueryable();
            return await query.ToListAsync();

        }

        public void Update(Specialties pSpecialties)
        {
            _context.Update(pSpecialties);
        }

        public async Task<List<Specialties>> GetAll()
        {

            var list = await _context.Specialties.ToListAsync();
            return list;

        }

        public async Task<Specialties> GetById(int Id)
        {
            Specialties? specialties = await _context.Specialties.FirstOrDefaultAsync(r => r.SpecialtiesId == Id);

            if (specialties != null)
                return specialties;
            else
                return new Specialties();

        }
    }
}
