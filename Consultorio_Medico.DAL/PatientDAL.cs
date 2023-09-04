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
  
    public class PatientDAL : IPatientDAL
    {
        private readonly ConsultorioDbContext _context;
        public PatientDAL(ConsultorioDbContext context)
        {
            _context = context;
        }
        public void Create(Patient pPatient)
        {
            _context.Add(pPatient);
        }

        public void Delete(Patient pPatient)
        {
            _context.Remove(pPatient);
        }

        public async Task<List<Patient>> GetAll()
        {
            var list = await _context.Patient.ToListAsync();
            return list;
        }

        public async Task<Patient> GetById(int Id)
        {
            Patient? patient = await _context.Patient.FirstOrDefaultAsync(r => r.PatientId == Id);

            if (patient != null)
                return patient;
            else
                return new Patient();
        }

        public async Task<List<Patient>> Search(Patient pPatient)
        {
            var query = _context.Patient.AsQueryable();
            if (!string.IsNullOrWhiteSpace(pPatient.Name))
                query = query.Where(r => r.Name == pPatient.Name);
            if (!string.IsNullOrWhiteSpace(pPatient.LastName))
                query = query.Where(r => r.LastName == pPatient.LastName);
            if (!string.IsNullOrWhiteSpace(pPatient.Telefono))
                query = query.Where(r => r.Telefono == pPatient.Telefono);
            if (!string.IsNullOrWhiteSpace(pPatient.DUI))
                query = query.Where(r => r.DUI == pPatient.DUI);
            if (pPatient.PatientId > 0)
                query = query.Where(s => s.PatientId == pPatient.PatientId);
            query = query.OrderByDescending(s => s.PatientId).AsQueryable();
            return await query.ToListAsync();
        }

        public void Update(Patient pPatient)
        {
           _context.Update(pPatient);
        }
    }
}
