
using Microsoft.EntityFrameworkCore;
using Owner.Infrastructure.BusinessRepositories.Read;
using Owner.Infrastructure.EF.Context;

namespace Owner.Test
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
            _context.Owners.Add(new Owner
            {
                OId = 1,
                OFirstName = "Laura",
                OLastName = "Gómez",
                OEmail = "laura@test.com"
            });
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetAllAsync();
            var owner = result.First();

            // Assert
            Assert.That(owner.OFirstName, Is.EqualTo("Laura"));
        }

        [Test]
        public async Task GetAllAsync_WhenMultipleOwnersExist_ReturnsCorrectCount()
        {
            // Arrange
            _context.Owners.AddRange(
                new Owner { OId = 1, OFirstName = "Ana" },
                new Owner { OId = 2, OFirstName = "Carlos" }
            );
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetAllAsync();

            // Assert
            Assert.That(result.Count(), Is.EqualTo(2));
        }
    }
}
