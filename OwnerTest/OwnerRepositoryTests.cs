
using Microsoft.EntityFrameworkCore;
using Owner.Infrastructure.BusinessRepositories.Read;
using Owner.Infrastructure.EF.Context;
using Owner.Infrastructure.EF.Entities;

namespace OwnerTest
{
    [TestFixture]
    public class OwnerRepositoryTests
    {
        private OwnerDbContext _context;
        private OwnerRepository _repository;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<OwnerDbContext>()
                .UseInMemoryDatabase(databaseName: "OwnerTestDb")
                .Options;

            _context = new OwnerDbContext(options);

            _context.Owners.RemoveRange(_context.Owners);
            _context.SaveChanges();

            _repository = new OwnerRepository(_context);
        }

        [Test]
        public async Task GetAllAsync_WhenNoOwners_ReturnsEmptyList()
        {
            // Act
            var result = await _repository.GetAllAsync();

            // Assert
            Assert.That(result, Is.Empty);
        }

        [Test]
        public async Task GetAllAsync_WhenOneOwnerExists_ReturnsOwnerWithCorrectData()
        {
            // Arrange
            _context.Owners.AddRange(
                 new Owners
                 {
                     OId = 1,
                     OFirstName = "Ana",
                     OLastName = "Gómez",
                     ODocumentType = "CC",
                     ODocument = "12345678",
                     OEmail = "ana@test.com",
                     OCountry = "Colombia",
                     ORegisterDate = DateTime.UtcNow,
                     OStateRegister = 1
                 }
             );

            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetAllAsync();
            var owner = result.First();

            // Assert
            Assert.That(owner.OFirstName, Is.EqualTo("Ana"));
        }

        [Test]
        public async Task GetAllAsync_WhenMultipleOwnersExist_ReturnsCorrectCount()
        {
            // Arrange
            _context.Owners.AddRange(
                new Owners
                {
                    OId = 1,
                    OFirstName = "Ana",
                    OLastName = "Gómez",
                    ODocumentType = "CC",
                    ODocument = "12345678",
                    OEmail = "ana@test.com",
                    OCountry = "Colombia",
                    ORegisterDate = DateTime.UtcNow,
                    OStateRegister = 1
                },
                new Owners
                {
                    OId = 2,
                    OFirstName = "Carlos",
                    OLastName = "Pérez",
                    ODocumentType = "CC",
                    ODocument = "87654321",
                    OEmail = "carlos@test.com",
                    OCountry = "Colombia",
                    ORegisterDate = DateTime.UtcNow,
                    OStateRegister = 1
                }
            );

            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetAllAsync();

            // Assert
            Assert.That(result.Count(), Is.EqualTo(2));
        }

        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }
    }
}
