using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;
using Consultorio_Medico.DAL;
using Consultorio_Medico.Entities;
using Consultorio_Medico.Entities.Interfaces;

namespace Consultorio_Medico.DAL.Tests
{
    [TestClass]
    public class SpecialtiesDALTests
    {
        [TestMethod]
        public async Task CreateSpecialtyAsync()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ConsultorioDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new ConsultorioDbContext(options))
            {
                ISpecialtiesDAL specialtiesDAL = new SpecialtiesDAL(context);
                var specialty = new Specialties { Specialty = "Test Specialty" };

                // Act
                 specialtiesDAL.Create(specialty);
                await context.SaveChangesAsync();

                // Assert
                var savedSpecialty = await context.Specialties.FirstOrDefaultAsync(s => s.Specialty == "Test Specialty");
                Assert.IsNotNull(savedSpecialty);
            }
        }

        [TestMethod]
        public async Task GetByIdSpecialtyAsync()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ConsultorioDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new ConsultorioDbContext(options))
            {
                ISpecialtiesDAL specialtiesDAL = new SpecialtiesDAL(context);
                var specialty = new Specialties { Specialty = "Test Specialty" };
                context.Specialties.Add(specialty);
                await context.SaveChangesAsync();

                // Act

                var retrievedSpecialty = await specialtiesDAL.GetById(specialty.SpecialtiesId);

                // Assert
                Assert.IsNotNull(retrievedSpecialty);
                Assert.AreEqual("Test Specialty", retrievedSpecialty.Specialty);
            }
        }

        [TestMethod]
        public async Task UpdateSpecialtyAsync()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ConsultorioDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new ConsultorioDbContext(options))
            {
                ISpecialtiesDAL specialtiesDAL = new SpecialtiesDAL(context);
                var specialty = new Specialties { Specialty = "Test Specialty" };
                context.Specialties.Add(specialty);
                await context.SaveChangesAsync();

                // Act
                specialty.Specialty = "Updated Specialty";
                specialtiesDAL.Update(specialty);
                await context.SaveChangesAsync();

                // Assert
                var updatedSpecialty = await context.Specialties.FirstOrDefaultAsync(s => s.Specialty == "Updated Specialty");
                Assert.IsNotNull(updatedSpecialty);
            }
        }

        [TestMethod]
        public async Task DeleteSpecialtyAsync()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ConsultorioDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new ConsultorioDbContext(options))
            {
                ISpecialtiesDAL specialtiesDAL = new SpecialtiesDAL(context);
                var specialty = new Specialties { Specialty = "Test Specialty" };
                context.Specialties.Add(specialty);
                await context.SaveChangesAsync();

                // Act
                specialtiesDAL.Delete(specialty);
                await context.SaveChangesAsync();

                // Assert
                var deletedSpecialty = await context.Specialties.FirstOrDefaultAsync(s => s.Specialty == "Test Specialty");
                Assert.IsNull(deletedSpecialty);
            }
        }

        [TestMethod]
        public async Task SearchSpecialtiesAsync()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ConsultorioDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new ConsultorioDbContext(options))
            {
                ISpecialtiesDAL specialtiesDAL = new SpecialtiesDAL(context);
                var specialty = new Specialties { Specialty = "Test Specialty" };
                context.Specialties.Add(specialty);
                await context.SaveChangesAsync();

                // Act
                var searchCriteria = new Specialties { Specialty = "Test Specialty" };
                var result = await specialtiesDAL.Search(searchCriteria);

                // Assert
                Assert.AreEqual(1, result.Count);
            }
        }

        // ...
        [TestMethod]
        public async Task GetAllSpecialtiesAsync()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ConsultorioDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new ConsultorioDbContext(options))
            {
                ISpecialtiesDAL specialtiesDAL = new SpecialtiesDAL(context);
                var specialty1 = new Specialties { Specialty = "Test Specialty 1" };
                var specialty2 = new Specialties { Specialty = "Test Specialty 2" };
                context.Specialties.AddRange(specialty1, specialty2);
                await context.SaveChangesAsync();

                // Act
                var result = await specialtiesDAL.GetAll();

                // Assert
                Assert.AreEqual(2, result.Count);
            }
        }
        // ...

    }

}