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
    public class PropertyImageWriteRepositoryTest
    {
        private PropertiesDbContext _context;
        private Mock<ILogsRepository> _logsRepositoryMock;
        private PropertyImageWriteRepository _repository;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<PropertiesDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) 
                .Options;

            _context = new PropertiesDbContext(options);
            _logsRepositoryMock = new Mock<ILogsRepository>();
            _repository = new PropertyImageWriteRepository(_context, _logsRepositoryMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }

        [Test]
        public async Task AddAsync_ShouldAddPropertyImageAndReturnId()
        {
            // Arrange
            var request = new AddPropertyImages
            {
                pPropertyId = 1,
                pFile = "imagen1.png",
                pEnabled = true
            };

            // Act
            var id = await _repository.AddAsync(request);

            // Assert
            var imageInDb = await _context.PropertyImages.FindAsync(id);
            Assert.That(imageInDb, Is.Not.Null);
            Assert.That(imageInDb.File, Is.EqualTo("imagen1.png"));
            Assert.That(imageInDb.PropertyId, Is.EqualTo(1));
            _logsRepositoryMock.Verify(l => l.AddLogAsync(It.IsAny<AddLogs>()), Times.Once);
        }

        [Test]
        public async Task AddAsync_ShouldAssignIncrementalId_WhenMultipleImagesExist()
        {
            // Arrange: insertamos manualmente una imagen previa
            _context.PropertyImages.Add(new PropertyImage
            {
                Id = 5,
                PropertyId = 1,
                File = "imagenPrev.png",
                Enabled = true,
                RegisterDate = DateTime.UtcNow,
                State = 1
            });
            await _context.SaveChangesAsync();

            var request = new AddPropertyImages
            {
                pPropertyId = 2,
                pFile = "imagenNueva.png",
                pEnabled = false
            };

            // Act
            var id = await _repository.AddAsync(request);

            // Assert
            Assert.That(id, Is.EqualTo(6)); // debe incrementar sobre el último Id
            var imageInDb = await _context.PropertyImages.FindAsync(6);
            Assert.That(imageInDb.File, Is.EqualTo("imagenNueva.png"));
        }
    }
}
