using Consultorio_Medico.Entities.Interfaces;
using Consultorio_Medico.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Consultorio_Medico.DAL
{
    public static class DepencyContainer
    {
        public static IServiceCollection AddDALDepencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ConsultorioDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("conexion")));


            services.AddScoped<IClinicDAL, ClinicDAL>();
            services.AddScoped < IUserDAL, UserDAL>();
            services.AddScoped<IScheduleDAL, ScheduleDAL>();
            services.AddScoped<IRolDAL, RolDal>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IWorkPlaceDAL, WorkPlaceDAL>();
            services.AddScoped<IUserSchedulesDAL, UserSheduleDAL>();
            services.AddScoped<ISecurityDAL, SecurityDAL>();
            services.AddScoped<ISpecialtiesDAL, SpecialtiesDAL>();
            services.AddScoped<IDoctorSpecialtiesDAL, DoctorSpecialtiesDAL>();
            services.AddScoped<IPatientDAL, PatientDAL>();
            services.AddScoped<IAppointmentDAL, AppointmentDAL>();
            return services;
        }
    }
}
