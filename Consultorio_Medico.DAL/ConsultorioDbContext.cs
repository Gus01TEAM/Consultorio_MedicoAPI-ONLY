using Consultorio_Medico.Entities;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
namespace Consultorio_Medico.DAL
{
    public class ConsultorioDbContext : DbContext
    {
        public ConsultorioDbContext(DbContextOptions<ConsultorioDbContext> options) : base(options) { }

        public DbSet<Clinic> Clinics { get; set; }

        public DbSet<Users> Users { get; set; }

        public DbSet<Schedules> Schedules { get; set; }

        public DbSet<Rol> Rol { get; set; }

        public DbSet<WorkPlace> WorkPlaces { get; set; }
        public DbSet<UserSchedules> UserSchedules { get; set; }

        public DbSet<Specialties> Specialties { get; set; }

        public DbSet<DoctorSpecialties> DoctorSpecialties { get; set; }
        public DbSet<Patient> Patient { get; set; }

        public DbSet<Appointment> Appointment { get; set; }
    }
}

