using Microsoft.VisualStudio.TestTools.UnitTesting;
using Consultorio_Medico.DAL;
using Consultorio_Medico.Entities;
using Consultorio_Medico.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultorio_Medico.DAL.Tests
{
    [TestClass]
    public class RolDalTests
    {
        private DbContextOptions<ConsultorioDbContext> dbContextOptions;

        [TestInitialize]
        public void Initialize()
        {
            // Configura las opciones de contexto de base de datos en memoria para tus pruebas.
            dbContextOptions = new DbContextOptionsBuilder<ConsultorioDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
        }

        [TestMethod]
        public void Create_ShouldCreateRol()
        {
            // Arrange
            using (var context = new ConsultorioDbContext(dbContextOptions))
            {
                IRolDAL rolDal = new RolDal(context);
                var rol = new Rol { Name = "Test Role" };

                // Act
                rolDal.Create(rol);
                context.SaveChanges();

                // Assert
                var savedRol = context.Rol.FirstOrDefault(r => r.Name == "Test Role");
                Assert.IsNotNull(savedRol);
            }
        }

        [TestMethod]
        public void Delete_ShouldDeleteRol()
        {
            // Arrange
            using (var context = new ConsultorioDbContext(dbContextOptions))
            {
                IRolDAL rolDal = new RolDal(context);
                var rol = new Rol { Name = "Test Role" };
                context.Rol.Add(rol);
                context.SaveChanges();

                // Act
                rolDal.Delete(rol);
                context.SaveChanges();

                // Assert
                var deletedRol = context.Rol.FirstOrDefault(r => r.Name == "Test Role");
                Assert.IsNull(deletedRol);
            }
        }

        [TestMethod]
        public async Task Search_ShouldReturnMatchingRoles()
        {
            // Arrange
            using (var context = new ConsultorioDbContext(dbContextOptions))
            {
                IRolDAL rolDal = new RolDal(context);
                var rol1 = new Rol { Name = "Test Role 1" };
                var rol2 = new Rol { Name = "Test Role 2" };
                context.Rol.AddRange(rol1, rol2);
                context.SaveChanges();

                // Act
                var searchCriteria = new Rol { Name = "Test Role 1" };
                var result = await rolDal.Search(searchCriteria);

                // Assert
                Assert.AreEqual(1, result.Count);
                Assert.AreEqual("Test Role 1", result[0].Name);
            }
        }

        [TestMethod]
        public void Update_ShouldUpdateRol()
        {
            // Arrange
            using (var context = new ConsultorioDbContext(dbContextOptions))
            {
                IRolDAL rolDal = new RolDal(context);
                var rol = new Rol { Name = "Test Role" };
                context.Rol.Add(rol);
                context.SaveChanges();

                // Act
                rol.Name = "Updated Role";
                rolDal.Update(rol);
                context.SaveChanges();

                // Assert
                var updatedRol = context.Rol.FirstOrDefault(r => r.Name == "Updated Role");
                Assert.IsNotNull(updatedRol);
            }
        }

        [TestMethod]
        public async Task GetAll_ShouldReturnAllRoles()
        {
            // Arrange
            using (var context = new ConsultorioDbContext(dbContextOptions))
            {
                IRolDAL rolDal = new RolDal(context);
                var rol1 = new Rol { Name = "Test Role 1" };
                var rol2 = new Rol { Name = "Test Role 2" };
                context.Rol.AddRange(rol1, rol2);
                context.SaveChanges();

                // Act
                var result = await rolDal.GetAll();

                // Assert
                Assert.AreEqual(2, result.Count);
            }
        }

        [TestMethod]
        public async Task GetById_ShouldReturnRoleById()
        {
            // Arrange
            using (var context = new ConsultorioDbContext(dbContextOptions))
            {
                IRolDAL rolDal = new RolDal(context);
                var rol = new Rol { Name = "Test Role" };
                context.Rol.Add(rol);
                context.SaveChanges();

                // Act
                var retrievedRol = await rolDal.GetById(rol.RolId);

                // Assert
                Assert.IsNotNull(retrievedRol);
                Assert.AreEqual("Test Role", retrievedRol.Name);
            }
        }
    }
}
