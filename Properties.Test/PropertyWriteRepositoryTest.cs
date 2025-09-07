using Microsoft.EntityFrameworkCore;
using Moq;
using Properties.Entities.Write;
using Properties.Infrastructure.BusinessRepositories.Write;
using Properties.Infrastructure.EF.Context;
using Properties.Infrastructure.EF.Entities;
using User.Entities.Write;
using User.Infrastructure.EF.Interfaces;

namespace PropertiesTest
{
    [TestFixture]
    public class PropertyWriteRepositoryTest
    {
        private PropertiesDbContext _context;
        private Mock<ILogsRepository> _logsRepositoryMock;
        private PropertyWriteRepository _repository;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<PropertiesDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // base fresca en cada test
                .Options;

            _context = new PropertiesDbContext(options);
            _logsRepositoryMock = new Mock<ILogsRepository>();
            _repository = new PropertyWriteRepository(_context, _logsRepositoryMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }

        [Test]
        public async Task AddPropertyAsync_ShouldAddPropertyAndReturnId()
        {
            // Arrange
            var newProperty = new AddProperty
            {
                Name = "Casa Bonita",
                Address = "Calle 123",
                Price = 150000,
                CodeInternal = "CB-001",
                Year = 2020,
                OwnerId = 1,
                PropertyTypeId = 1,
                PropertyStateId = 1
            };

            // Act
            var id = await _repository.AddPropertyAsync(newProperty);

            // Assert
            var propertyInDb = await _context.Properties.FindAsync(id);
            Assert.That(propertyInDb, Is.Not.Null);
            Assert.That(propertyInDb.Name, Is.EqualTo("Casa Bonita"));
            _logsRepositoryMock.Verify(l => l.AddLogAsync(It.IsAny<AddLogs>()), Times.Once);
        }

        [Test]
        public async Task UpdatePropertyAsync_ShouldUpdateAndReturnTrue_WhenPropertyExists()
        {
            // Arrange
            var property = new Property
            {
                Id = 1,
                Name = "Casa Vieja",
                Address = "Calle 100",
                Price = 100000,
                CodeInternal = "CV-001",
                Year = 2015,
                OwnerId = 1,
                PropertyTypeId = 1,
                PropertyStateId = 1,
                State = 1
            };
            _context.Properties.Add(property);
            await _context.SaveChangesAsync();

            var updateRequest = new UpdateProperty
            {
                Name = "Casa Remodelada",
                Address = "Calle 200",
                Price = 200000,
                CodeInternal = "CR-001",
                Year = 2022,
                OwnerId = 2,
                PropertyStateId = 2
            };

            // Act
            var result = await _repository.UpdatePropertyAsync(1, updateRequest);

            // Assert
            Assert.That(result, Is.True);
            var updatedProperty = await _context.Properties.FindAsync(1);
            Assert.That(updatedProperty.Name, Is.EqualTo("Casa Remodelada"));
            _logsRepositoryMock.Verify(l => l.AddLogAsync(It.IsAny<AddLogs>()), Times.Once);
        }

        [Test]
        public async Task ChangePriceAsync_ShouldUpdatePrice_WhenPropertyExists()
        {
            // Arrange
            var property = new Property
            {
                Id = 1,
                Name = "Casa Económica",
                Address = "Calle 50",
                Price = 50000,
                CodeInternal = "CE-001",
                Year = 2010,
                OwnerId = 1,
                PropertyTypeId = 1,
                PropertyStateId = 1,
                State = 1
            };
            _context.Properties.Add(property);
            await _context.SaveChangesAsync();

            var changePriceRequest = new ChangePrices { Price = 75000 };

            // Act
            await _repository.ChangePriceAsync(1, changePriceRequest);

            // Assert
            var updatedProperty = await _context.Properties.FindAsync(1);
            Assert.That(updatedProperty.Price, Is.EqualTo(75000));
            _logsRepositoryMock.Verify(l => l.AddLogAsync(It.IsAny<AddLogs>()), Times.Once);
        }
    }
}
